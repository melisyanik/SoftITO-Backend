using System.Text;
using System.Text.Json;

namespace SmartMunicipality.EFCoreApi.Services
{
    public class AIService : IAIService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public AIService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> AskQuestionAsync(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                return "Lütfen geçerli bir soru yazın.";
            }

            string? geminiApiKey = _configuration["Gemini:ApiKey"] ?? Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            string? openAiApiKey = _configuration["OpenAI:ApiKey"] ?? Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            string systemInstruction = "Sen Akıllı Belediye (Smart Municipality) platformunun yapay zeka asistanısın. Vatandaşların su aboneliği, doğalgaz aboneliği, vergi işlemleri, şikayet yönetimi ve belediye hizmetleri ile ilgili sorularına nazik, yardımsever ve bilgilendirici Türkçe cevaplar ver. Cevapların kısa ve öz olsun.";

            
            if (!string.IsNullOrEmpty(geminiApiKey) && geminiApiKey != "YOUR_GEMINI_API_KEY")
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();
                    var requestBody = new
                    {
                        contents = new[]
                        {
                            new { role = "user", parts = new[] { new { text = prompt } } }
                        },
                        systemInstruction = new
                        {
                            parts = new[] { new { text = systemInstruction } }
                        },
                        generationConfig = new
                        {
                            temperature = 0.7,
                            maxOutputTokens = 500
                        }
                    };

                    var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={geminiApiKey}", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        using var doc = JsonDocument.Parse(responseString);
                        var root = doc.RootElement;
                        if (root.TryGetProperty("candidates", out var candidates) && candidates.GetArrayLength() > 0)
                        {
                            var content = candidates[0].GetProperty("content");
                            if (content.TryGetProperty("parts", out var parts) && parts.GetArrayLength() > 0)
                            {
                                var text = parts[0].GetProperty("text").GetString();
                                if (!string.IsNullOrEmpty(text))
                                {
                                    return text.Trim();
                                }
                            }
                        }
                    }
                }
                catch
                {
                    
                }
            }

            
            if (!string.IsNullOrEmpty(openAiApiKey) && openAiApiKey != "YOUR_OPENAI_API_KEY")
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", openAiApiKey);

                    var requestBody = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = new[]
                        {
                            new { role = "system", content = systemInstruction },
                            new { role = "user", content = prompt }
                        },
                        max_tokens = 500,
                        temperature = 0.7
                    };

                    var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        using var doc = JsonDocument.Parse(responseString);
                        var root = doc.RootElement;
                        var choices = root.GetProperty("choices");
                        if (choices.GetArrayLength() > 0)
                        {
                            var text = choices[0].GetProperty("message").GetProperty("content").GetString();
                            if (!string.IsNullOrEmpty(text))
                            {
                                return text.Trim();
                            }
                        }
                    }
                }
                catch
                {
                    
                }
            }

            
            string lowerPrompt = prompt.ToLower();

            if (lowerPrompt.Contains("fatura") || lowerPrompt.Contains("borç") || lowerPrompt.Contains("tutar"))
            {
                return "Su ve Doğalgaz faturalarınızı görüntülemek ve ödemek için 'Aboneliklerim' sayfasını ziyaret edebilirsiniz. Herhangi bir faturanın detayına tıklayarak 'Pay (Öde)' butonuna basıp kredi kartınızla güvenli bir şekilde ödeme işlemini gerçekleştirebilirsiniz.";
            }

            if (lowerPrompt.Contains("şikayet") || lowerPrompt.Contains("arıza") || lowerPrompt.Contains("ihbar") || lowerPrompt.Contains("talep"))
            {
                return "Belediyemize yeni bir şikayet veya talep bildirmek için sol menüdeki 'Şikayetler' sekmesini kullanabilirsiniz. Şikayet oluştururken harita üzerinden sorunun yaşandığı tam konumu seçerek ekiplerimizin adrese daha hızlı ulaşmasını sağlayabilirsiniz. Şikayetinizin durumu güncellendiğinde sağ üstteki zil simgesinden anlık bildirim alırsınız.";
            }

            if (lowerPrompt.Contains("abonelik") || lowerPrompt.Contains("abone") || lowerPrompt.Contains("su açtır") || lowerPrompt.Contains("doğalgaz açtır"))
            {
                return "Belediyemizde aktif olarak Su ve Doğalgaz abonelik işlemleri yapılmaktadır. Yeni bir abonelik başlatmak için kimlik belgeniz ve mülk/kira tapu belgeniz ile birlikte en yakın Belediye Hizmet Noktasına şahsen başvurabilir ya da 444 0 153 çağrı merkezimizden bilgi alabilirsiniz.";
            }

            if (lowerPrompt.Contains("vergi") || lowerPrompt.Contains("emlak") || lowerPrompt.Contains("çevre") || lowerPrompt.Contains("temizlik"))
            {
                return "Emlak Vergisi ve Çevre Temizlik Vergisi borçlarınızı online ödeme sistemi üzerinden T.C. Kimlik numaranız veya Sicil numaranız ile sorgulayıp kredi kartınızla ödeyebilirsiniz. Dönemsel vergi yapılandırma ve vade bilgileri için belediyemiz Gelirler Şefliği ile iletişime geçebilirsiniz.";
            }

            if (lowerPrompt.Contains("duyuru") || lowerPrompt.Contains("haber") || lowerPrompt.Contains("etkinlik"))
            {
                return "Belediyemizle ilgili en güncel duyuruları ve planlı kesintileri ana sayfamızda yer alan son dakika şeridinden ve haberler kısmından takip edebilirsiniz.";
            }

            if (lowerPrompt.Contains("selam") || lowerPrompt.Contains("merhaba") || lowerPrompt.Contains("nasılsın"))
            {
                return "Merhaba! Ben SmartMunicipality Akıllı Belediye Asistanıyım. Size su/doğalgaz abonelikleri, fatura borçları, şikayet takibi veya vergilerle ilgili nasıl yardımcı olabilirim?";
            }

            return "Sorunuzu aldım. Belediyemiz hizmetleri (su/doğalgaz aboneliği, fatura ödemeleri, şikayet kaydı oluşturma, vergi sorgulama) hakkında sormak istediğiniz soruları yanıtlayabilirim. Lütfen sorunuzu daha açık yazmayı deneyin.";
        }
    }
}
