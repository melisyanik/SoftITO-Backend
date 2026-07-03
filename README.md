<div align="center">

# 🎬 BiletSinema CMS (Project 1 - Code First)
**Enterprise-Grade Cinema & Entertainment Content Management System**

[![.NET](https://img.shields.io/badge/.NET_8.0-5C2D91?style=flat-square&logo=.net&logoColor=white)](#)
[![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core-0078D4?style=flat-square&logo=dotnet&logoColor=white)](#)
[![Bootstrap](https://img.shields.io/badge/Bootstrap_5-563D7C?style=flat-square&logo=bootstrap&logoColor=white)](#)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](#)

[🇺🇸 Read in English](#-english-documentation) | [🇹🇷 Türkçe Okuyun](#-türkçe-dokümantasyon)

</div>

---

<br>

## 🇺🇸 English Documentation

### 📌 Project Overview
**BiletSinema** is a comprehensive, monolithic web application designed to manage the entire lifecycle of cinema and entertainment content. Built on the robust **ASP.NET Core MVC** framework, it serves as a centralized hub for administrators to oversee movies, TV series, theaters, and their associated metadata. 

Unlike standard CRUD applications, BiletSinema incorporates advanced reporting, dynamic role-based access control (RBAC), and complex relational data mapping to provide a scalable administration experience.

### 🎯 Scope & Capabilities

The system is strictly divided into functional domains to ensure high cohesion:

#### 1. Identity & Security Management
- **Role-Based Access Control (RBAC):** Strict isolation between `Admin`, `Manager`, and `User` roles using ASP.NET Core Identity.
- **Account Administration:** Full lifecycle management of user accounts (creation, suspension, password resets) directly from the dashboard.
- **Secure Authentication:** Implementation of secure cookie-based authentication with anti-forgery token validations.

#### 2. Media Content Engine
- **Unified Media Catalog:** Relational management of Movies, TV Series, and Theater Plays.
- **Dynamic Categorization:** Many-to-many relationship mapping allowing a single media entity to belong to multiple genres or categories.
- **Metadata Management:** Handling of directors, cast, release dates, durations, and poster imagery.

![Media Content Engine](docs/images/content-management.png)
*> Screenshot placeholder: Film, TV Series, and Category Management Interface*

#### 3. Analytics & Export Pipeline
- **Visual Telemetry:** Integration with `Chart.js` to provide real-time dashboard analytics regarding content distribution and category density.
- **Document Generation:** 
  - **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports.
  - **Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets into standard Excel formats for external data analysis.

![Analytics & Reports](docs/images/reporting-charts.png)
*> Screenshot placeholder: Advanced Reporting & Analytics Dashboard*

### 🏗️ Technical Architecture

- **Pattern:** Model-View-Controller (MVC)
- **ORM:** Entity Framework Core (Code-First Approach)
- **Database:** Microsoft SQL Server
- **Frontend Stack:** HTML5, CSS3, Bootstrap 5, JavaScript (Vanilla), jQuery (for AJAX operations)
- **Dependency Injection:** Built-in .NET IoC Container for loosely coupled services.

### ⚙️ Local Development Setup

To run this project locally, ensure you have the **.NET SDK** installed.

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/BiletSinema.git
   cd BiletSinema
   ```

2. **Database Configuration:**
   Update the `DefaultConnection` string in your `appsettings.json` file to target your local SQL Server instance.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=BiletSinema;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. **Execute Migrations:**
   Apply the EF Core code-first migrations to provision your database schema.
   ```bash
   dotnet ef database update
   ```

4. **Launch the Application:**
   ```bash
   dotnet run
   ```

---

<br>

## 🇹🇷 Türkçe Dokümantasyon

### 📌 Proje Özeti
**BiletSinema**, sinema ve eğlence içeriklerinin tüm yaşam döngüsünü yönetmek için tasarlanmış kapsamlı, monolitik bir web uygulamasıdır. Güçlü **ASP.NET Core MVC** altyapısı üzerine inşa edilen bu sistem; yöneticilerin filmleri, dizileri, tiyatroları ve bu içeriklere ait üst verileri (metadata) merkezi bir noktadan yönetmesini sağlar.

Standart CRUD (Oluştur, Oku, Güncelle, Sil) uygulamalarından farklı olarak BiletSinema; gelişmiş raporlama, dinamik rol tabanlı erişim kontrolü (RBAC) ve karmaşık ilişkisel veri haritalaması sunarak ölçeklenebilir bir yönetim paneli deneyimi sağlar.

### 🎯 Proje Kapsamı ve Yetenekleri

Sistem, yüksek uyumluluk sağlamak amacıyla işlevsel alanlara (domain) bölünmüştür:

#### 1. Kimlik ve Güvenlik Yönetimi
- **Rol Tabanlı Erişim Kontrolü (RBAC):** ASP.NET Core Identity kullanılarak `Admin`, `Yönetici` ve `Kullanıcı` rolleri arasında kesin bir izolasyon sağlanmıştır.
- **Hesap Yönetimi:** Kullanıcı hesaplarının (oluşturma, askıya alma, şifre sıfırlama) doğrudan panel üzerinden tam yaşam döngüsü yönetimi.
- **Güvenli Kimlik Doğrulama:** Anti-forgery (sahtecilik önleme) token doğrulamaları ile desteklenen, çerez (cookie) tabanlı güvenli oturum yönetimi.

#### 2. Medya İçerik Motoru
- **Bütünleşik Medya Kataloğu:** Filmler, Diziler ve Tiyatro Oyunlarının ilişkisel bir veritabanı yapısıyla yönetilmesi.
- **Dinamik Kategorizasyon:** Tek bir medya içeriğinin birden fazla türe veya kategoriye ait olabilmesini sağlayan çoktan-çoğa (many-to-many) ilişki yapısı.
- **Meta Veri Yönetimi:** Yönetmenler, oyuncu kadrosu, vizyon tarihleri, süreler ve afiş görsellerinin yönetimi.

![Medya İçerik Motoru](docs/images/content-management.png)
*> Ekran görüntüsü (Placeholder): Film, Dizi ve Kategori Yönetim Arayüzü*

#### 3. Analitik ve Veri Dışa Aktarımı
- **Görsel Telemetri:** İçerik dağılımı ve kategori yoğunluğu hakkında gerçek zamanlı panel analitiği sunmak için `Chart.js` entegrasyonu.
- **Doküman Üretimi:** 
  - **PDF Raporlar:** Piksel mükemmelliğinde, yazdırılabilir yönetimsel raporlar oluşturmak için `QuestPDF` kullanımı.
  - **Tablo Formatları:** Ham veri setlerini harici analizler için standart Excel formatında dışa aktarmak amacıyla `EPPlus` kullanımı.

![Analitik ve Raporlar](docs/images/reporting-charts.png)
*> Ekran görüntüsü (Placeholder): Gelişmiş Raporlama ve Analitik Paneli*

### 🏗️ Teknik Mimari

- **Tasarım Deseni:** Model-View-Controller (MVC)
- **ORM:** Entity Framework Core (Code-First Yaklaşımı)
- **Veritabanı:** Microsoft SQL Server
- **Ön Yüz (Frontend):** HTML5, CSS3, Bootstrap 5, JavaScript (Vanilla), jQuery (AJAX işlemleri için)
- **Bağımlılık Enjeksiyonu (DI):** Gevşek bağlı (loosely coupled) servisler için yerleşik .NET IoC Container.

### ⚙️ Geliştirme Ortamı Kurulumu

Projeyi yerel ortamınızda çalıştırmak için **.NET SDK**'nın kurulu olduğundan emin olun.

1. **Repoyu Klonlayın:**
   ```bash
   git clone https://github.com/kullanici-adiniz/BiletSinema.git
   cd BiletSinema
   ```

2. **Veritabanı Yapılandırması:**
   `appsettings.json` dosyasındaki `DefaultConnection` bağlantı dizesini kendi SQL Server sunucunuza (veya LocalDB) göre güncelleyin.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=BiletSinema;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. **Migration'ları Uygulayın:**
   Veritabanı şemasını oluşturmak için EF Core code-first migration'larını çalıştırın.
   ```bash
   dotnet ef database update
   ```

4. **Uygulamayı Başlatın:**
   ```bash
   dotnet run
   ```
