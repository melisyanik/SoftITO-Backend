<div align="center">

# 🏛️ Belediye Şikayet (Municipality Complaint CMS)
**Citizen-Centric Complaint Management & Resolution System**

[![.NET](https://img.shields.io/badge/.NET_9.0-5C2D91?style=flat-square&logo=.net&logoColor=white)](#)
[![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core_(DB_First)-0078D4?style=flat-square&logo=dotnet&logoColor=white)](#)
[![Bootstrap](https://img.shields.io/badge/Bootstrap_5-563D7C?style=flat-square&logo=bootstrap&logoColor=white)](#)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](#)

[🇺🇸 Read in English](#-english-documentation) | [🇹🇷 Türkçe Okuyun](#-türkçe-dokümantasyon)

</div>

---

<br>

## 🇺🇸 English Documentation

### 📌 Project Overview
**Belediye Şikayet** is a comprehensive municipality complaint management web application built with **ASP.NET Core MVC**. This system allows citizens to digitally submit their complaints and requests, while providing municipality officials with a powerful backend administrative dashboard to track, update, and resolve these issues efficiently.

> **Note:** This is the **second project** in this series and was developed using the **Database-First (DB First)** approach with Entity Framework Core, contrasting with the Code-First approach used in the first project.

### 🎯 Scope & Capabilities

The system is designed with distinct functional domains to streamline municipal operations:

#### 1. Identity & Security Management
- **Admin Authentication:** Secure admin panel access protected by ASP.NET Core Identity.
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 123636" src="https://github.com/user-attachments/assets/1af9d361-8d60-4ef6-80da-9eeec763a2de" />

- **Admin Management:** Capability for existing administrators to create and manage new admin users directly from the dashboard.
<img width="1919" height="557" alt="Ekran görüntüsü 2026-07-03 141614" src="https://github.com/user-attachments/assets/43ece1de-fc1f-402f-ad0e-f7c2e6536bd5" />
<img width="1919" height="603" alt="Ekran görüntüsü 2026-07-03 141642" src="https://github.com/user-attachments/assets/ac079d4e-96af-4e8b-8359-3933d02a8c03" />
<img width="1919" height="538" alt="Ekran görüntüsü 2026-07-03 141702" src="https://github.com/user-attachments/assets/a6eb7ee3-683c-4c97-b533-02badada34bd" />

- **Secure Sessions:** Robust cookie-based authentication with encrypted password hashing.
Admin registiration interface:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 123636" src="https://github.com/user-attachments/assets/d478525d-c566-41d9-ba2d-5944324e48b3" />

#### 2. Complaint Management Engine & Admin CRUD
- **Citizen Portal:** A public-facing interface where citizens can submit complaints.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-03 123213" src="https://github.com/user-attachments/assets/0040973a-0677-48d4-b905-0fd6da074941" />
- **Dynamic Filtering & Search:** Advanced search capabilities using combobox (dropdown) selections for District (İlçe) and Category, allowing rapid filtering on the Admin panel.
For public page according to cities:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-03 123431" src="https://github.com/user-attachments/assets/d02c20ef-49eb-46a5-9ff4-728f46bd165b" />
- **Status Tracking:** Admins can dynamically update the status of complaints (e.g., Pending, In Progress, Resolved).
<img width="1919" height="755" alt="Ekran görüntüsü 2026-07-03 141347" src="https://github.com/user-attachments/assets/bc3539c1-710f-4903-b2f0-5802b1dbaeb4" />
- **Admin CRUD Operations:** Full Create, Read, Update, and Delete operations for managing system categories, complaint statuses, and citizen complaints.
For example, lets change the status of the complaint and then check from the public page:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-03 123650" src="https://github.com/user-attachments/assets/70ac9e8d-1729-40b2-baa3-2c0a9557873e" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-03 123752" src="https://github.com/user-attachments/assets/a4ee247a-2aef-4ee8-bf5a-7106e3ce309c" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 123802" src="https://github.com/user-attachments/assets/48df0ab8-03c8-4290-a112-6e6299ebcf48" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-03 123817" src="https://github.com/user-attachments/assets/8ba88e5a-83da-42f8-b63d-715cb622d245" />
- **Communication:** Built-in mechanism for admins to append official responses (Cevap) to specific complaints.
Answering the questions after marking the complaints as "solved" and then checking again from the public page:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 141358" src="https://github.com/user-attachments/assets/682f8bac-efc1-43c9-bbc9-7018f526fc9f" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 141722" src="https://github.com/user-attachments/assets/95c1bfdc-d78a-4390-84e0-f4e89c5b9854" />

Citizen Portal and Complaint Submission Form:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 123605" src="https://github.com/user-attachments/assets/e99f6a36-a23c-48b7-bd82-7edbb1107003" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-03 123614" src="https://github.com/user-attachments/assets/ccb143cb-df41-43a7-be47-34e4adc3b213" />

Examples of CRUD operations with search module:
<img width="1891" height="792" alt="Ekran görüntüsü 2026-07-03 151059" src="https://github.com/user-attachments/assets/10e63158-60bf-4e10-8381-4484a1ba794f" />
<img width="1919" height="578" alt="Ekran görüntüsü 2026-07-03 151242" src="https://github.com/user-attachments/assets/1e4b0dc3-53ad-4c2a-9368-dcad090976ed" />
<img width="1919" height="857" alt="Ekran görüntüsü 2026-07-03 151251" src="https://github.com/user-attachments/assets/be0934b2-510c-44fd-bf62-f46e2dcd244b" />

Dynamic Search and Filtering Interface from admin panel:
<img width="1918" height="548" alt="Ekran görüntüsü 2026-07-03 141955" src="https://github.com/user-attachments/assets/062081ac-2f0b-4374-a6df-01a096a85379" />

#### 3. Analytics & Export Pipeline
- **Visual Telemetry:** Interactive dashboards visualizing complaint distributions by district and category.
- **Document Generation:** 
  - **PDF Reports:** Automatic generation of printable, pixel-perfect complaint reports using `QuestPDF`.
  - **Spreadsheets:** Extraction of raw complaint data into Excel spreadsheets using `EPPlus` for deeper municipal analysis.
Advanced Reporting & Analytics Dashboard:
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-03 141415" src="https://github.com/user-attachments/assets/0937c317-ef44-4818-9078-bca6fc34c75d" />
<img width="1919" height="527" alt="Ekran görüntüsü 2026-07-03 141458" src="https://github.com/user-attachments/assets/de6b2aa8-fc89-41b4-a129-046747b04070" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-03 141510" src="https://github.com/user-attachments/assets/823381be-18d9-48c2-b193-a8558bdbaebc" />
PDF and Excel reports for selected report:
<img width="974" height="338" alt="Ekran görüntüsü 2026-07-03 141533" src="https://github.com/user-attachments/assets/3b0658b1-5e4b-4a4b-a465-decb3ab45c38" />
<img width="473" height="191" alt="Ekran görüntüsü 2026-07-03 141552" src="https://github.com/user-attachments/assets/7ee4323e-e4f1-4e68-a706-a621eaffe564" />

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
   git clone https://github.com/melisyanik/SoftITO-Backend.git
   cd SoftITO-Backend/BelediyeSikayet
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

> **Not:** Bu proje, serideki **ikinci projedir** ve ilk projedeki Code-First yaklaşımının aksine Entity Framework Core ile **Database-First (Önce Veritabanı)** yaklaşımı kullanılarak geliştirilmiştir.

### 🎯 Proje Kapsamı ve Yetenekleri

Sistem, belediye operasyonlarını kolaylaştırmak amacıyla farklı işlevsel alanlara ayrılmıştır:

#### 1. Kimlik ve Güvenlik Yönetimi
- **Yönetici Girişi:** ASP.NET Core Identity altyapısı ile korunan güvenli admin paneli.
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 123636" src="https://github.com/user-attachments/assets/1af9d361-8d60-4ef6-80da-9eeec763a2de" />

- **Kullanıcı Yönetimi:** Mevcut yöneticilerin, panel üzerinden yeni yönetici hesapları açabilme ve yönetebilme yeteneği.
<img width="1919" height="557" alt="Ekran görüntüsü 2026-07-03 141614" src="https://github.com/user-attachments/assets/43ece1de-fc1f-402f-ad0e-f7c2e6536bd5" />
<img width="1919" height="603" alt="Ekran görüntüsü 2026-07-03 141642" src="https://github.com/user-attachments/assets/ac079d4e-96af-4e8b-8359-3933d02a8c03" />
<img width="1919" height="538" alt="Ekran görüntüsü 2026-07-03 141702" src="https://github.com/user-attachments/assets/a6eb7ee3-683c-4c97-b533-02badada34bd" />

- **Güvenli Oturum:** Şifrelenmiş parola altyapısı (hash) ve güvenli çerez (cookie) tabanlı oturum yönetimi.
Yönetici kayıt (registration) arayüzü:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 123636" src="https://github.com/user-attachments/assets/d478525d-c566-41d9-ba2d-5944324e48b3" />

#### 2. Şikayet Yönetim Motoru ve Admin CRUD İşlemleri
- **Vatandaş Portalı:** Vatandaşların şikayet oluşturabildiği herkese açık yüz.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-03 123213" src="https://github.com/user-attachments/assets/0040973a-0677-48d4-b905-0fd6da074941" />
- **Dinamik Arama ve Filtreleme:** Yönetici panelinde yer alan Combobox (Açılır Liste) seçimleri ile İlçe ve Kategori bazlı hızlı arama ve filtreleme yeteneği.
İlçelere göre halka açık sayfa için:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-03 123431" src="https://github.com/user-attachments/assets/d02c20ef-49eb-46a5-9ff4-728f46bd165b" />
- **Durum Takibi:** Yöneticilerin taleplerin durumunu (Örn: Beklemede, İşlemde, Çözüldü) dinamik olarak güncelleyebilmesi.
<img width="1919" height="755" alt="Ekran görüntüsü 2026-07-03 141347" src="https://github.com/user-attachments/assets/bc3539c1-710f-4903-b2f0-5802b1dbaeb4" />
- **Tam Kapsamlı CRUD İşlemleri:** Kategorilerin, şikayet durumlarının ve gelen taleplerin yönetimi için tam Create, Read, Update, Delete operasyonları.
Örneğin, şikayet durumunu değiştirip halka açık sayfadan kontrol edelim:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-03 123650" src="https://github.com/user-attachments/assets/70ac9e8d-1729-40b2-baa3-2c0a9557873e" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-03 123752" src="https://github.com/user-attachments/assets/a4ee247a-2aef-4ee8-bf5a-7106e3ce309c" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 123802" src="https://github.com/user-attachments/assets/48df0ab8-03c8-4290-a112-6e6299ebcf48" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-03 123817" src="https://github.com/user-attachments/assets/8ba88e5a-83da-42f8-b63d-715cb622d245" />
- **İletişim ve Yanıt:** Yöneticilerin belirli şikayetlere resmi yanıtlar (Cevap) ekleyebilmesini sağlayan yerleşik mekanizma.
Şikayetleri "çözüldü" olarak işaretledikten sonra yanıtlayıp, halka açık sayfadan tekrar kontrol edelim:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 141358" src="https://github.com/user-attachments/assets/682f8bac-efc1-43c9-bbc9-7018f526fc9f" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 141722" src="https://github.com/user-attachments/assets/95c1bfdc-d78a-4390-84e0-f4e89c5b9854" />

Vatandaş Portalı ve Şikayet Ekleme Formu:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 123605" src="https://github.com/user-attachments/assets/e99f6a36-a23c-48b7-bd82-7edbb1107003" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-03 123614" src="https://github.com/user-attachments/assets/ccb143cb-df41-43a7-be47-34e4adc3b213" />

Arama modüllü CRUD işlemleri örnekleri:
<img width="1891" height="792" alt="Ekran görüntüsü 2026-07-03 151059" src="https://github.com/user-attachments/assets/10e63158-60bf-4e10-8381-4484a1ba794f" />
<img width="1919" height="578" alt="Ekran görüntüsü 2026-07-03 151242" src="https://github.com/user-attachments/assets/1e4b0dc3-53ad-4c2a-9368-dcad090976ed" />
<img width="1919" height="857" alt="Ekran görüntüsü 2026-07-03 151251" src="https://github.com/user-attachments/assets/be0934b2-510c-44fd-bf62-f46e2dcd244b" />

Yönetici panelinden Dinamik Arama ve Filtreleme Arayüzü:
<img width="1918" height="548" alt="Ekran görüntüsü 2026-07-03 141955" src="https://github.com/user-attachments/assets/062081ac-2f0b-4374-a6df-01a096a85379" />

#### 3. Analitik ve Veri Dışa Aktarımı
- **Görsel Telemetri:** Şikayetlerin ilçelere ve kategorilere göre dağılımını gösteren interaktif istatistik panoları.
- **Doküman Üretimi:** 
  - **PDF Raporlar:** `QuestPDF` kütüphanesi ile şikayetlerin anında yazdırılabilir, profesyonel PDF raporlarına dönüştürülmesi.
  - **Tablo Formatları:** Kurum içi detaylı veri analizi için şikayet listelerinin `EPPlus` kullanılarak standart Excel dosyalarına dönüştürülmesi.
Gelişmiş İstatistik ve Raporlama Paneli:
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-03 141415" src="https://github.com/user-attachments/assets/0937c317-ef44-4818-9078-bca6fc34c75d" />
<img width="1919" height="527" alt="Ekran görüntüsü 2026-07-03 141458" src="https://github.com/user-attachments/assets/de6b2aa8-fc89-41b4-a129-046747b04070" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-03 141510" src="https://github.com/user-attachments/assets/823381be-18d9-48c2-b193-a8558bdbaebc" />
Seçili rapor için PDF ve Excel raporları:
<img width="974" height="338" alt="Ekran görüntüsü 2026-07-03 141533" src="https://github.com/user-attachments/assets/3b0658b1-5e4b-4a4b-a465-decb3ab45c38" />
<img width="473" height="191" alt="Ekran görüntüsü 2026-07-03 141552" src="https://github.com/user-attachments/assets/7ee4323e-e4f1-4e68-a706-a621eaffe564" />

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
   git clone https://github.com/melisyanik/SoftITO-Backend.git
   cd SoftITO-Backend/BelediyeSikayet
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
