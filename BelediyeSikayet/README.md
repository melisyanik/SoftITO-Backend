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

> **Note:** This is the **second project** in this series and was developed using the **Database-First (DB First)** approach with Entity Framework Core, contrasting with the Code-First approach used in previous projects.

### 🎯 Scope & Capabilities

The system is designed with distinct functional domains to streamline municipal operations:

#### 1. Identity & Security Management
- **Admin Authentication:** Secure admin panel access protected by ASP.NET Core Identity.
- **Admin Management:** Capability for existing administrators to create and manage new admin users directly from the dashboard.
- **Secure Sessions:** Robust cookie-based authentication with encrypted password hashing.

![Admin Login Placeholder](docs/images/admin-login.png)
*> Screenshot placeholder: Admin Login Interface*

![Admin Registration Placeholder](docs/images/admin-registration.png)
*> Screenshot placeholder: Admin Registration Interface*

#### 2. Complaint Management Engine & Admin CRUD
- **Citizen Portal:** A public-facing interface where citizens can submit complaints.
- **Dynamic Filtering & Search:** Advanced search capabilities using combobox (dropdown) selections for District (İlçe) and Category, allowing rapid filtering on the Admin panel.
- **Admin CRUD Operations:** Full Create, Read, Update, and Delete operations for managing system categories, complaint statuses, and citizen complaints.
- **Status Tracking:** Admins can dynamically update the status of tickets (e.g., Pending, In Progress, Resolved).
- **Communication:** Built-in mechanism for admins to append official responses (Cevap) to specific complaints.

![Citizen Portal Placeholder](docs/images/citizen-portal.png)
*> Screenshot placeholder: Citizen Portal and Complaint Submission Form*

![Category & Status CRUD Placeholder](docs/images/category-crud.png)
*> Screenshot placeholder: Category & Status CRUD Operations*

![Complaint Management Placeholder](docs/images/complaint-management.png)
*> Screenshot placeholder: Complaint Inbox, Resolution, and Reply Interface*

![Search & Filter Placeholder](docs/images/search-filter.png)
*> Screenshot placeholder: Dynamic Search and Filtering Interface*

#### 3. Analytics & Export Pipeline
- **Visual Telemetry:** Interactive dashboards visualizing complaint distributions by district and category.
- **Document Generation:** 
  - **PDF Reports:** Automatic generation of printable, pixel-perfect complaint reports using `QuestPDF`.
  - **Spreadsheets:** Extraction of raw complaint data into Excel spreadsheets using `EPPlus` for deeper municipal analysis.

![Analytics & Reports](docs/images/reporting-dashboard.png)
*> Screenshot placeholder: Advanced Reporting & Analytics Dashboard*

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
