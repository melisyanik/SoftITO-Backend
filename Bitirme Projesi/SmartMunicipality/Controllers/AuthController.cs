using Microsoft.AspNetCore.Mvc;
using SmartMunicipality.Models;
using System.Text;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SmartMunicipality.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "http://localhost:5010/api/Auth"; 

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_apiUrl}/Register", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Kayıt başarılı! Lütfen giriş yapın.";
                return RedirectToAction("Login");
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            try 
            {
                var errorObj = JsonSerializer.Deserialize<JsonElement>(errorContent);
                
                JsonElement errorsProp = default;
                bool hasErrors = false;
                foreach (var prop in errorObj.EnumerateObject())
                {
                    if (string.Equals(prop.Name, "errors", StringComparison.OrdinalIgnoreCase))
                    {
                        errorsProp = prop.Value;
                        hasErrors = true;
                        break;
                    }
                }

                JsonElement msgProp = default;
                bool hasMsg = false;
                foreach (var prop in errorObj.EnumerateObject())
                {
                    if (string.Equals(prop.Name, "message", StringComparison.OrdinalIgnoreCase))
                    {
                        msgProp = prop.Value;
                        hasMsg = true;
                        break;
                    }
                }

                if (hasErrors && errorsProp.ValueKind == JsonValueKind.Array)
                {
                    foreach (var err in errorsProp.EnumerateArray())
                    {
                        ModelState.AddModelError(string.Empty, err.GetString() ?? "Geçersiz değer.");
                    }
                }
                else if (hasMsg)
                {
                    ModelState.AddModelError(string.Empty, msgProp.GetString() ?? "Bir hata oluştu.");
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Kayıt işlemi başarısız oldu. API Hatası.");
                }
            }
            catch 
            {
                ModelState.AddModelError(string.Empty, $"Kayıt işlemi başarısız oldu. Lütfen bilgilerinizi kontrol edin.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_apiUrl}/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<JsonElement>(jsonString);
                var token = result.GetProperty("token").GetString();

                if (!string.IsNullOrEmpty(token))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token);

                    var claims = jwtToken.Claims.ToList();

                    
                    var subClaim = claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "nameid");
                    if (subClaim != null && !claims.Any(c => c.Type == ClaimTypes.NameIdentifier))
                    {
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, subClaim.Value));
                    }

                    var uniqueNameClaim = claims.FirstOrDefault(c => c.Type == "unique_name" || c.Type == "name");
                    if (uniqueNameClaim != null && !claims.Any(c => c.Type == ClaimTypes.Name))
                    {
                        claims.Add(new Claim(ClaimTypes.Name, uniqueNameClaim.Value));
                    }

                    var roleClaims = claims.Where(c => c.Type == "role" || c.Type == "roles" || c.Type == ClaimTypes.Role).ToList();
                    foreach (var rc in roleClaims)
                    {
                        if (!claims.Any(c => c.Type == ClaimTypes.Role && c.Value == rc.Value))
                        {
                            claims.Add(new Claim(ClaimTypes.Role, rc.Value));
                        }
                    }

                    
                    claims.Add(new Claim("JWToken", token));

                    var claimsIdentity = new ClaimsIdentity(
                        claims, 
                        CookieAuthenticationDefaults.AuthenticationScheme, 
                        ClaimTypes.Name, 
                        ClaimTypes.Role);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = jwtToken.ValidTo
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    TempData["Message"] = "Giriş başarılı!";
                    
                    if (claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Admin"))
                    {
                        return RedirectToAction("Reports", "Admin");
                    }
                    else if (claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Operator"))
                    {
                        return RedirectToAction("Subscriptions", "Operator");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Giriş başarısız. Bilgilerinizi kontrol edin.");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Message"] = "Başarıyla çıkış yapıldı.";
            return RedirectToAction("Index", "Home");
        }
    }
}
