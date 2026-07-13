<h1 align="center">🏛️ SmartMunicipality</h1>

<p align="center">
  <strong>Next-Generation Smart Municipality Management Platform / Yeni Nesil Akıllı Belediye Yönetim Platformu</strong><br>
  SoftITO Backend Developer Eğitimi kapsamında geliştirilen bitirme projesidir. / Developed as the graduation project under the SoftITO Backend Developer Training program.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8.0">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server">
  <img src="https://img.shields.io/badge/Entity_Framework_Core-68217A?style=for-the-badge&logo=nuget&logoColor=white" alt="EF Core">
  <img src="https://img.shields.io/badge/Dapper-1E88E5?style=for-the-badge&logo=dapper&logoColor=white" alt="Dapper">
  <img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white" alt="JWT">
  <img src="https://img.shields.io/badge/Serilog-FCC624?style=for-the-badge" alt="Serilog">
  <img src="https://img.shields.io/badge/EPPlus-00A651?style=for-the-badge" alt="EPPlus">
  <img src="https://img.shields.io/badge/QuestPDF-512BD4?style=for-the-badge" alt="QuestPDF">
  <img src="https://img.shields.io/badge/Gemini_AI-4285F4?style=for-the-badge&logo=google&logoColor=white" alt="Gemini">
  <img src="https://img.shields.io/badge/OpenAI-412991?style=for-the-badge&logo=openai&logoColor=white" alt="OpenAI">
</p>

<p align="center">
  <a href="#-türkçe">🇹🇷 Türkçe</a> • <a href="#-english">🇬🇧 English</a>
</p>

---

# 📸 Step-by-Step User Journey & Screenshots / Adım Adım Kullanıcı Akışı ve Ekran Görüntüleri

> *Sistemdeki temel iş akışları ve modüllere ait adım adım ekran görüntüleri.*

---

### 🟢 Phase 1: Welcome & Authentication / Aşama 1: Karşılama ve Kimlik Doğrulama
#### 🏠 1. Homepage (Belediye Portalı Ana Sayfa)
*Uygulama ilk çalıştığında kullanıcıyı karşılayan, belediye tanıtımı, duyurular ve portal giriş bağlantılarını içeren genel ana sayfa.*
<p align="center">
<img width="1919" height="875" alt="Ekran görüntüsü 2026-07-13 230829" src="https://github.com/user-attachments/assets/674e7db8-4bcc-4f6f-a298-a261b3eef9ff" />
<img width="1919" height="874" alt="Ekran görüntüsü 2026-07-13 230846" src="https://github.com/user-attachments/assets/a2a70d1b-0029-4050-8f96-e95b54463c45" />
<img width="1919" height="873" alt="Ekran görüntüsü 2026-07-13 230900" src="https://github.com/user-attachments/assets/7102d252-93cf-4ab6-89db-85f0e278715d" />
<img width="1919" height="871" alt="Ekran görüntüsü 2026-07-13 230910" src="https://github.com/user-attachments/assets/1e634130-1bc0-42a0-9316-17913397e2c3" />
<img width="1919" height="869" alt="Ekran görüntüsü 2026-07-13 230930" src="https://github.com/user-attachments/assets/417f35d7-925a-4341-b962-d3cebbe50d14" />
<img width="1919" height="871" alt="Ekran görüntüsü 2026-07-13 230938" src="https://github.com/user-attachments/assets/1606a7f9-7265-4f16-990e-d46dbd943035" />
Haber detay sayfası:
<img width="1919" height="868" alt="Ekran görüntüsü 2026-07-13 230945" src="https://github.com/user-attachments/assets/6cc3d24a-e2b6-440d-bc34-f65c6e28989d" />
Chatbot sayfasına gidiş:
<img width="1919" height="875" alt="Ekran görüntüsü 2026-07-13 231002" src="https://github.com/user-attachments/assets/c7fce7c2-9ef9-411e-89e9-e64ae0ca6ce8" />

</p>

#### 🔐 2. Login & Registration (Giriş Yap ve Kayıt Ol)
*Vatandaşlar, operatörler ve yöneticiler için güvenli, rol bazlı JWT & Cookie kimlik doğrulama altyapısına sahip kayıt ve giriş ekranları.*
> [!NOTE]
> Sistemde rol ayrımı e-posta uzantılarına (domain) göre dinamik olarak yönetilir:
> - **Yönetici (Admin)** girişi için: `@belediye.bel.tr` uzantılı e-posta adresleri kullanılır.
> - **Operatör (Operator)** girişi için: `@operator.bel.tr` uzantılı e-posta adresleri kullanılır.
> - **Vatandaş (Citizen)** girişi için: Diğer tüm genel e-posta adresleri kullanılır.

<p align="center">
  <strong>Vatandaş Hesap Oluşturma Ekranı (Citizen Registration)</strong><br>
  <img src="Screenshots/01_Register.png" width="850" alt="Citizen Registration">
</p>
<p align="center">
  <strong>Vatandaş Giriş Paneli (Citizen Login)</strong><br>
  <img src="Screenshots/01_Login_Citizen.png" width="850" alt="Citizen Login">
</p>
<p align="center">
  <strong>Yönetici Giriş Paneli (Admin Login - @belediye.bel.tr)</strong><br>
  <img src="Screenshots/01_Login_Admin.png" width="850" alt="Admin Login">
</p>
<p align="center">
  <strong>Operatör Giriş Paneli (Operator Login - @operator.bel.tr)</strong><br>
  <img src="Screenshots/01_Login_Operator.png" width="850" alt="Operator Login">
</p>

---

### 🟢 Phase 2: Citizen Portal Journey / Aşama 2: Vatandaş Portal Akışı
#### 📊 3. Citizen Dashboard (Vatandaş Yönetim Paneli)
*Vatandaşın giriş yaptığında kendisini özel karşılama mesajıyla karşılayan, aktif abonelik özetlerini ve güncel fatura borçlarını takip ettiği ana panel.*
<p align="center">
  <strong>Vatandaş Ana Karşılama Ekranı (Citizen Home View)</strong><br>
  <img src="Screenshots/02_Citizen_Dashboard.png" width="850" alt="Citizen Dashboard Home">
</p>
<p align="center">
  <strong>Vatandaş Yönetim Paneli ve Hızlı İşlemler (Citizen Dashboard Inner & Quick Actions)</strong><br>
  <img src="Screenshots/02_Citizen_Dashboard_Inner.png" width="850" alt="Citizen Dashboard Inner">
</p>

#### 👤 4. Profile Management (Kişisel Bilgileri Güncelleme)
*Vatandaşın kendi T.C. Kimlik No, İletişim, İlçe ve Açık Adres gibi sistem profili detaylarını görüntülediği ve güncellediği güvenli alan.*
<p align="center">
  <strong>Profil Detay Ekranı (Profile Details View)</strong><br>
  <img src="Screenshots/02_Profile_View.png" width="850" alt="Profile View">
</p>
<p align="center">
  <strong>Bilgileri Güncelleme Formu (Update Profile Form)</strong><br>
  <img src="Screenshots/02_Profile_Edit.png" width="850" alt="Profile Edit Form">
</p>
<p align="center">
  <strong>Başarılı Güncelleme Bildirimi (Profile Update Success Notification Toast)</strong><br>
  <img src="Screenshots/02_Profile_Success.png" width="850" alt="Profile Update Success">
</p>

#### 💧 5. Utility Subscription Application (Yeni Abonelik Başvurusu)
*Su, doğalgaz ve diğer şebeke hizmetleri için hızlı başvuru formu ve gerekli evrak yükleme arayüzü.*
<p align="center">
  <img src="Screenshots/03_SubscriptionApplication.png" width="850" alt="Subscription Application">
</p>

#### 💵 6. Invoice Inquiries & Secure Payment (Fatura Sorgulama ve Güvenli Ödeme)
*Aboneliklere ait faturaların listelenmesi ve sanal POS üzerinden 3D Secure simülasyonlu ödeme adımı.*
<p align="center">
  <img src="Screenshots/04_InvoicePayment.png" width="850" alt="Invoice and Payment">
</p>

#### ⚠️ 7. Geolocation-Based Complaint Submission (Konum Destekli Şikayet Bildirimi)
*Harita üzerinden nokta konum seçerek, kategori bazlı fotoğraf ve açıklama ile şikayet bildirme, onay/cevap sürecini takip etme arayüzü.*
<p align="center">
  <strong>1. Kayıtlı Şikayetler Listesi - Boş Durum (Complaints List - Empty State)</strong><br>
  <img src="Screenshots/05_Complaint_List_Empty.png" width="850" alt="Complaints List Empty">
</p>
<p align="center">
  <strong>2. Şikayet Bildirim Formu & Kategori Seçimi (Complaint Form & Category Dropdown)</strong><br>
  <img src="Screenshots/05_Complaint_Form.png" width="850" alt="Complaint Submission Form">
</p>
<p align="center">
  <strong>3. İlçe Seçim Dropdown Menüsü (District Selection Dropdown)</strong><br>
  <img src="Screenshots/05_Complaint_Form_Districts.png" width="850" alt="Complaint District Selection">
</p>
<p align="center">
  <strong>4. Harita Üzerinde Konum İşaretleme - Leaflet Map (Geolocation Marker on Map)</strong><br>
  <img src="Screenshots/05_Complaint_Form_Map.png" width="850" alt="Complaint Map Location Selection">
</p>
<p align="center">
  <strong>5. Başarıyla Oluşturuldu Bildirimi & Güncel Liste (Success Toast & Updated List View)</strong><br>
  <img src="Screenshots/05_Complaint_Success_List.png" width="850" alt="Complaint Success and List">
</p>
<p align="center">
  <strong>6. Şikayet Detay ve Takip Kartı (Complaint Details & Status Tracker Card)</strong><br>
  <img src="Screenshots/05_Complaint_Details.png" width="850" alt="Complaint Details View">
</p>

#### 🤖 8. AI Municipal Assistant Chatbot (Yapay Zeka Destekli Belediye Asistanı)
*Gemini & OpenAI API ile entegre, vatandaşın sorularını yanıtlayan ve şikayet/başvuru adımlarını yönlendiren chatbot.*
<p align="center">
  <strong>Akıllı Asistan ile Canlı Sohbet Oturumu (AI Chatbot Chat Session)</strong><br>
  <img src="Screenshots/06_AIChatbot_Chat.png" width="850" alt="AI Chatbot Chat Session">
</p>

---

### 🟢 Phase 3: Operator & Admin Console / Aşama 3: Operatör ve Yönetici Paneli
#### 💼 8. Subscription Review & Bill Generation (Abonelik Onay ve Fatura Tanımlama)
*Operatörlerin yeni abonelik taleplerini inceleyip onayladığı ve dönemsel tüketim faturalarını oluşturduğu yönetim alanı.*
<p align="center">
  <img src="Screenshots/07_OperatorApproval.png" width="850" alt="Operator Approvals">
</p>

#### 🛠️ 9. Complaint Tracking & Status Management (Şikayet Değerlendirme ve Süreç Takibi)
*Vatandaşlardan gelen şikayetlerin incelendiği, sahaya atandığı ve çözümlenerek cevaplandığı merkez.*
<p align="center">
  <img src="Screenshots/08_ComplaintManagement.png" width="850" alt="Complaint Management">
</p>

---

### 🟢 Phase 4: High-Performance Analytics / Aşama 4: Yüksek Performanslı Analiz
#### 📊 10. Dapper Reporting Dashboard (Yönetici Analitik Rapor Ekranı)
*Dapper ve Stored Procedure'ler ile beslenen, mahalle bazlı şikayet yoğunluk haritaları ve gelir grafiklerini içeren analitik panel.*
<p align="center">
  <img src="Screenshots/09_AnalyticalReports.png" width="850" alt="Reporting Dashboard">
</p>

---

### 🟢 Phase 5: API Documentation & Swagger UI / Aşama 5: API Dokümantasyonu ve Swagger Arayüzleri
#### 🔌 11. SmartMunicipality.EFCoreApi (Swagger UI)
*Kullanıcı kimlik doğrulama, abonelik ve şikayet CRUD işlemlerinin test edildiği ana API arayüzü.*
<p align="center">
  <img src="Screenshots/10_EFCoreApi_Swagger.png" width="850" alt="EFCoreApi Swagger Documentation">
</p>

#### ⚡ 12. SmartMunicipality.DapperApi (Swagger UI)
*Yüksek hızlı analitik sorguların, gösterge paneli istatistiklerinin ve raporların test edildiği Dapper API arayüzü.*
<p align="center">
  <img src="Screenshots/11_DapperApi_Swagger.png" width="850" alt="DapperApi Swagger Documentation">
</p>

---

# 🇹🇷 Türkçe

## 📖 Proje Hakkında

SmartMunicipality, modern belediyecilik süreçlerini dijitalleştirerek vatandaşlar ile yerel yönetim arasındaki iletişimi ve hizmet akışını optimize etmek amacıyla geliştirilmiş *kurumsal düzeyde bir Akıllı Belediye Yönetim Platformudur*.

Proje; katmanlı mimari, bağımsız API servisleri, rol bazlı yetkilendirme, hibrit veri erişim katmanı (EF Core & Dapper) ve yapay zeka entegrasyonu gibi modern yazılım desenleri kullanılarak inşa edilmiştir.

*Sistem, üç temel katman ve servis üzerinden çalışmaktadır:*
- **SmartMunicipality MVC**: Kullanıcıların ve operatörlerin etkileşime girdiği web arayüzü sunum katmanı.
- **SmartMunicipality.EFCoreApi**: CRUD işlemleri, kullanıcı yönetimi (Identity), JWT üretimi ve veri manipülasyonu için geliştirilmiş ana API katmanı.
- **SmartMunicipality.DapperApi**: Raporlama, gösterge paneli istatistikleri ve yüksek performans gerektiren okuma sorguları için geliştirilmiş Dapper API katmanı.

## 🏗️ Sistem Mimarisi

Sistem, gevşek bağlı (loosely coupled) ve REST API'ler aracılığıyla haberleşen servis tabanlı bir mimariye sahiptir.

```mermaid
graph TD
A[Vatandaş & Operatör Tarayıcısı] --> B[SmartMunicipality MVC]
B --> C[SmartMunicipality.EFCoreApi]
B --> D[SmartMunicipality.DapperApi]
C --> E[Data Access Layer - EF Core]
D --> F[Data Access Layer - Dapper]
E --> G[(SQL Server)]
F --> G
```

## 🏛️ Katmanlı Mimari (Layered Architecture)

Uygulama, sorumlulukların net bir şekilde ayrıldığı N-Tier (Çok Katmanlı) mimariyi takip eder.

```mermaid
graph TD
Presentation[Presentation Layer<br>SmartMunicipality MVC] --> EF_API[EFCore API Layer]
Presentation --> Dapper_API[Dapper API Layer]
EF_API --> Data[SmartMunicipality.DATA]
Dapper_API --> Data
Data --> Database[(SQL Server)]
```

## 🔄 İstek Akışı (Request Flow)

Sunum katmanı (MVC), veritabanı ile asla doğrudan iletişim kurmaz. Tüm işlemler ve veri okuma/yazma süreçleri EFCore ve Dapper API uç noktaları (Endpoints) üzerinden yönlendirilir.

## 📊 Raporlama ve Gösterge Paneli Mimarisi

Hızlı ve optimize edilmiş sorgular için Dapper ve Stored Procedure'ler (Saklı Yordamlar) tercih edilmiştir:
- `sp_GetDashboardStats` (Genel İstatistik Raporu)
- `sp_GetComplaintsByCategory` (Kategorilere Göre Şikayetler)
- `sp_GetComplaintsByDistrict` (İlçelere/Mahallelere Göre Şikayetler)
- `sp_GetMonthlyRevenue` & `sp_GetYearlyRevenue` (Aylık/Yıllık Gelir Grafikleri)
- `sp_GetHeatMapData` (Şikayet Yoğunluk Haritası Verisi)
- `sp_GetComplaintsByStatus` (Durumlarına Göre Şikayet Grafiği)

## 🤖 Yapay Zeka Destekli Asistan Servisi

Sistem bünyesinde barındırdığı `AIService` ile vatandaşların su/doğalgaz abonelikleri, faturalar, şikayet süreçleri ve vergiler hakkındaki sorularını yanıtlayan akıllı bir belediye asistanı sunar. Servis:
- **Gemini API** (`gemini-1.5-flash`) entegrasyonu
- **OpenAI API** (`gpt-3.5-turbo`) entegrasyonu
- Servislerin çalışmadığı durumlar için gelişmiş yerel Türkçe doğal dil çıkarım (Fallback) mekanizması içerir.

---

## 🌟 Öne Çıkan Özellikler

- **ASP.NET Core 8.0**: Çok katmanlı ve ölçeklenebilir temiz mimari yapısı.
- **EF Core & Dapper Hibrit ORM**: Yazma ve ilişkisel işlemler için EF Core, yüksek performanslı raporlama okumaları için Dapper.
- **Güvenlik & Rol Yetkilendirme**: ASP.NET Core Identity altyapısı, JWT (JSON Web Tokens) ile güvenli API iletişimi, Rol Bazlı Yetkilendirme (Vatandaş ve Operatör rolleri).
- **Abonelik Yönetimi**: Su, doğalgaz, elektrik vb. abonelik başvuruları ve onay süreçleri.
- **Fatura ve Ödeme**: Otomatik fatura oluşturma, fatura detayları ve sanal pos ile ödeme entegrasyonu.
- **Akıllı Şikayet Yönetimi**: Harita/Konum destekli şikayet kaydı oluşturma, durum güncelleme ve operatör yönlendirmesi.
- **Anlık Bildirimler**: Şikayet güncellemeleri ve önemli olaylar için anlık bildirim sistemi.
- **Rapor Dışa Aktarma**: PDF çıktıları (QuestPDF) ve Excel listeleri (EPPlus) olarak veri aktarma.
- **Yapılandırılmış Günlükleme**: Serilog entegrasyonu ve dosya tabanlı loglama.

## 👥 Yetkilendirme Matrisi

| Modül | Vatandaş (Citizen) | Operatör (Operator) |
|---|:---:|:---:|
| Fatura Görüntüleme & Ödeme | ✅ | ✅ |
| Şikayet Oluşturma & Takip | ✅ | ✅ |
| Yapay Zeka Asistanı | ✅ | ✅ |
| Abonelik Başvurusu | ✅ | ✅ |
| Şikayet Durumu Güncelleme & Cevaplama | ❌ | ✅ |
| Abonelik Onaylama & Fatura Oluşturma | ❌ | ✅ |
| Raporlar & İstatistikler | ❌ | ✅ |

## ⚙️ Kurulum

```bash
# Projeyi klonlayın
git clone <repository-url>
cd SmartMunicipality

# Veritabanını oluşturmak için EF Core migrasyonlarını uygulayın
dotnet ef database update --project SmartMunicipality.DATA --startup-project SmartMunicipality.EFCoreApi

# Projeyi çalıştırın (Visual Studio üzerinde Çoklu Başlangıç Projesi / Multiple Startup Projects olarak ayarlayın)
# Çalıştırılacak Servisler: SmartMunicipality.EFCoreApi, SmartMunicipality.DapperApi ve SmartMunicipality (MVC)
```

---

# 🇬🇧 English

## 📖 About the Project

SmartMunicipality is an enterprise-level Smart Municipality Management Platform built to digitalize modern municipal processes, optimizing communication and service delivery between citizens and local government.

The project is built on modern software architecture patterns, utilizing layered structure, independent API services, role-based authorization, a hybrid data access layer (EF Core & Dapper), and artificial intelligence integration.

*The system operates across three core layers and services:*
- **SmartMunicipality MVC**: The user-facing web presentation layer where citizens and operators interact.
- **SmartMunicipality.EFCoreApi**: The main API layer responsible for CRUD operations, user management (Identity), JWT token generation, and data manipulation.
- **SmartMunicipality.DapperApi**: A lightweight API layer powered by Dapper for analytical reports, dashboard statistics, and high-performance read queries.

## 🏗️ System Architecture

The system utilizes a service-oriented, loosely coupled architecture communicating via REST APIs.

```mermaid
graph TD
A[Citizen & Operator Browser] --> B[SmartMunicipality MVC]
B --> C[SmartMunicipality.EFCoreApi]
B --> D[SmartMunicipality.DapperApi]
C --> E[Data Access Layer - EF Core]
D --> F[Data Access Layer - Dapper]
E --> G[(SQL Server)]
F --> G
```

## 🏛️ Layered Architecture

The application adopts an N-Tier architecture with clean separation of concerns.

```mermaid
graph TD
Presentation[Presentation Layer<br>SmartMunicipality MVC] --> EF_API[EFCore API Layer]
Presentation --> Dapper_API[Dapper API Layer]
EF_API --> Data[SmartMunicipality.DATA]
Dapper_API --> Data
Data --> Database[(SQL Server)]
```

## 🔄 Request Flow

The MVC presentation layer never queries the database directly. All read/write operations go through EFCore and Dapper API endpoints.

## 📊 Reporting and Dashboard Architecture

Dapper and Stored Procedures are preferred for rapid, optimized reporting:
- `sp_GetDashboardStats` (Overall Municipal Stats)
- `sp_GetComplaintsByCategory` (Complaints grouped by category)
- `sp_GetComplaintsByDistrict` (District-wise complaints distribution)
- `sp_GetMonthlyRevenue` & `sp_GetYearlyRevenue` (Monthly/Yearly Revenue charts)
- `sp_GetHeatMapData` (Complaint density data for GIS heat maps)
- `sp_GetComplaintsByStatus` (Complaint status distribution)

## 🤖 AI-Powered Assistant Service

Equipped with an integrated `AIService`, the platform provides an AI-powered conversational assistant to guide citizens through subscription processes, bills, complaint submissions, and taxes. The service integrates:
- **Gemini API** (`gemini-1.5-flash`)
- **OpenAI API** (`gpt-3.5-turbo`)
- Local rule-based Turkish Natural Language Processing fallback mechanism for offline scenarios.

---

## 🌟 Key Features

- **ASP.NET Core 8.0**: Clean, multi-layered, and scalable architectural foundation.
- **EF Core & Dapper Hybrid ORM**: EF Core for transactional writes and entity mappings; Dapper for lightning-fast reads.
- **Security & Authorization**: ASP.NET Core Identity integration, JWT token-based API authentication, and Role-Based Access Control (Citizen & Operator roles).
- **Subscription Management**: Application and approval pipelines for water, gas, electricity, and other municipal utility services.
- **Billing & Payments**: Automated bill generator, detailed invoice views, and secure mockup credit card checkout.
- **Smart Complaints Portal**: Geolocation-aware complaint registration, workflow tracker, and operator routing.
- **Instant Notifications**: Real-time push updates for ticket status changes.
- **Document Export**: PDF exports (QuestPDF) and Excel sheet exports (EPPlus).
- **Structured Logging**: Diagnostic logging and file sinks powered by Serilog.

## 👥 Authorization Matrix

| Module | Citizen | Operator |
|---|:---:|:---:|
| View & Pay Bills | ✅ | ✅ |
| Submit & Track Complaints | ✅ | ✅ |
| AI Chatbot Helper | ✅ | ✅ |
| Apply for Subscriptions | ✅ | ✅ |
| Update/Resolve Complaints | ❌ | ✅ |
| Approve Subscriptions & Generate Bills | ❌ | ✅ |
| Reports & Statistics Dashboard | ❌ | ✅ |

## ⚙️ Installation

```bash
# Clone the repository
git clone <repository-url>
cd SmartMunicipality

# Apply EF Core migrations to create the database
dotnet ef database update --project SmartMunicipality.DATA --startup-project SmartMunicipality.EFCoreApi

# Run the project (Set Multiple Startup Projects in Visual Studio)
# Start: SmartMunicipality.EFCoreApi, SmartMunicipality.DapperApi, and SmartMunicipality (MVC)
```

---

# 📜 License & Developer

This project was developed for educational purposes as a graduation project.

*Developer:* Melis Yanık  
Backend Developer (.NET)

<p align="center">
⭐ If you found this project useful, don't forget to leave a star.<br>
Made with ❤️ using ASP.NET Core 8.0
</p>
