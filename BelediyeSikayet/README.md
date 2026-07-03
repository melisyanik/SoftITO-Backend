 
### 🏗️ Technical Architecture

- **Architecture Pattern:** Model-View-Controller (MVC)
- **ORM:** Entity Framework Core (**Database-First Approach**)
- **Identity:** ASP.NET Core Identity
- **Database:** Microsoft SQL Server
- **Frontend Stack:** HTML5, CSS3, Bootstrap 5

### ⚙️ Local Development Setup

To run this project locally, ensure you have the **.NET 9 SDK** installed.

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/BelediyeSikayet.git
   cd BelediyeSikayet
   ```

2. **Database Configuration:**
   Update the `Default` connection string in your `appsettings.json` file to target your local SQL Server instance.
   ```json
   "ConnectionStrings": {
     "Default": "Server=(localdb)\\MSSQLLocalDB;Database=BelediyeSikayetDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. **Launch the Application:**
   Because this is a **DB First** project with a recently added Identity Migration, ensure the database is up to date:
   ```bash
   dotnet ef database update
   dotnet run
   ```

---

<br>

## 🇹🇷 Türkçe Dokümantasyon

### 📌 Proje Özeti
**Belediye Şikayet**, **ASP.NET Core MVC** ile geliştirilmiş kapsamlı bir belediye talep ve şikayet yönetim sistemidir. Bu uygulama, vatandaşların şikayet ve isteklerini dijital ortamda iletmelerine olanak tanırken; belediye yetkililerine de bu talepleri takip etmeleri, güncellemeleri ve hızlıca çözüme kavuşturmaları için güçlü bir yönetim paneli sunar.

> **Not:** Bu proje, serideki **ikinci projedir** ve önceki projelerdeki Code-First yaklaşımının aksine Entity Framework Core ile **Database-First (Önce Veritabanı)** yaklaşımı kullanılarak geliştirilmiştir.

### 🎯 Proje Kapsamı ve Yetenekleri

Sistem, belediye operasyonlarını kolaylaştırmak amacıyla farklı işlevsel alanlara ayrılmıştır:

#### 1. Kimlik ve Güvenlik Yönetimi
- **Yönetici Girişi:** ASP.NET Core Identity altyapısı ile korunan güvenli admin paneli.
- **Kullanıcı Yönetimi:** Mevcut yöneticilerin, panel üzerinden yeni yönetici hesapları açabilme ve silebilme yeteneği.
- **Güvenli Oturum:** Şifrelenmiş parola altyapısı (hash) ve güvenli çerez (cookie) tabanlı oturum yönetimi.

![Yönetici Girişi Placeholder](docs/images/admin-login.png)
*> Ekran görüntüsü (Placeholder): Admin Girişi Arayüzü*

![Yönetici Kaydı Placeholder](docs/images/admin-registration.png)
*> Ekran görüntüsü (Placeholder): Yeni Yönetici Kaydı (Registration) Arayüzü*

#### 2. Şikayet Yönetim Motoru ve Admin CRUD İşlemleri
- **Vatandaş Portalı:** Vatandaşların şikayet oluşturabildiği açık yüz.
- **Dinamik Arama ve Filtreleme:** Yönetici panelinde yer alan Combobox (Açılır Liste) seçimleri ile İlçe ve Kategori bazlı hızlı arama ve filtreleme yeteneği.
- **Tam Kapsamlı CRUD:** Kategorilerin, şikayet durumlarının ve gelen taleplerin yönetimi için tam Create, Read, Update, Delete (Ekle, Oku, Güncelle, Sil) operasyonları.
- **Durum Takibi:** Yöneticilerin taleplerin durumunu (Beklemede, İşlemde, Çözüldü) dinamik olarak güncelleyebilmesi.
- **İletişim ve Yanıt:** Yöneticilerin belirli şikayetlere resmi yanıtlar (Cevap) ekleyebilmesini sağlayan yerleşik mekanizma.

![Vatandaş Portalı Placeholder](docs/images/citizen-portal.png)
*> Ekran görüntüsü (Placeholder): Vatandaş Portalı ve Şikayet Ekleme Formu*

![Kategori CRUD Placeholder](docs/images/category-crud.png)
*> Ekran görüntüsü (Placeholder): Kategori ve Durum CRUD İşlemleri*

![Şikayet Yönetimi Placeholder](docs/images/complaint-management.png)
*> Ekran görüntüsü (Placeholder): Gelen Kutusu, Şikayet Yanıtlama ve Detay Ekranı*

![Arama ve Filtreleme Placeholder](docs/images/search-filter.png)
*> Ekran görüntüsü (Placeholder): Dinamik Arama ve Filtreleme Arayüzü*

#### 3. Analitik ve Veri Dışa Aktarımı
- **Görsel Telemetri:** Şikayetlerin ilçelere ve kategorilere göre dağılımını gösteren interaktif istatistik panoları.
- **Doküman Üretimi:** 
  - **PDF Raporlar:** `QuestPDF` kütüphanesi ile şikayetlerin anında yazdırılabilir, profesyonel PDF raporlarına dönüştürülmesi.
  - **Tablo Formatları:** Kurum içi detaylı veri analizi için şikayet listelerinin `EPPlus` kullanılarak standart Excel dosyalarına (.xlsx) dönüştürülmesi.

![Analitik ve Raporlar Placeholder](docs/images/reporting-dashboard.png)
*> Ekran görüntüsü (Placeholder): Gelişmiş İstatistik ve Raporlama Paneli*

### 🏗️ Teknik Mimari

- **Tasarım Deseni:** Model-View-Controller (MVC)
- **ORM:** Entity Framework Core (**Database-First / Önce Veritabanı Yaklaşımı**)
- **Kimlik Doğrulama:** ASP.NET Core Identity
- **Veritabanı:** Microsoft SQL Server
- **Ön Yüz (Frontend):** HTML5, CSS3, Bootstrap 5

### ⚙️ Geliştirme Ortamı Kurulumu

Projeyi yerel ortamınızda çalıştırmak için **.NET 9 SDK**'nın kurulu olduğundan emin olun.

1. **Repoyu Klonlayın:**
   ```bash
   git clone https://github.com/kullanici-adiniz/BelediyeSikayet.git
   cd BelediyeSikayet
   ```

2. **Veritabanı Yapılandırması:**
   `appsettings.json` dosyasındaki `Default` bağlantı dizesini kendi SQL Server sunucunuza (veya LocalDB) göre güncelleyin.
   ```json
   "ConnectionStrings": {
     "Default": "Server=(localdb)\\MSSQLLocalDB;Database=BelediyeSikayetDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. **Uygulamayı Başlatın:**
   Bu proje **DB First** yaklaşımıyla oluşturulduğu ve sonrasında Identity eklendiği için veritabanınızın güncel olduğundan emin olup başlatın:
   ```bash
   dotnet ef database update
   dotnet run
   ```
