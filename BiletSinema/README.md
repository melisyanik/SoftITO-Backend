<div align="center">

# 🎬 BiletSinema - Code First (PROJECT 1)

[![.NET](https://img.shields.io/badge/.NET_8.0-5C2D91?style=flat-square&logo=.net&logoColor=white)](#)
[![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core-0078D4?style=flat-square&logo=dotnet&logoColor=white)](#)
[![Bootstrap](https://img.shields.io/badge/Bootstrap_5-563D7C?style=flat-square&logo=bootstrap&logoColor=white)](#)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](#)

[🇬🇧 Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

</div>

---

<br>

## 🇺🇸 English Documentation

### 🎯 Project Overview
**BiletSinema** is a comprehensive, monolithic web application designed to manage the entire lifecycle of cinema and entertainment content. Built on the robust **ASP.NET Core MVC** framework, it serves as a centralized hub for administrators to oversee movies, TV series, theaters, and their associated metadata, while providing a seamless user experience for customers.

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
- **Secure Authentication & Login Screen:** A dedicated, fully functional login and registration interface ensuring robust session management.
- **Role-Based Routing:** Smart routing powered by ASP.NET Core Identity. Admins are redirected to the management dashboard upon login, while regular users are routed to the public homepage.
- **Account Administration:** Full lifecycle management of user accounts.
- **Admin Management:** Dedicated interface within the dashboard to securely create and onboard new administrator accounts.
Login Interface for admins:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 094939" src="https://github.com/user-attachments/assets/d130c85b-afe5-46ed-8bbc-b168627c7a14" />


#### 2. Public User Experience
- **Interactive Homepage:** A dynamic, user-facing homepage displaying the catalog of movies, series, and theater plays.
Public Homepage and Catalog:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 094733" src="https://github.com/user-attachments/assets/87d11669-bf47-4018-a771-c6f091567b88" />
<img width="1919" height="919" alt="Ekran görüntüsü 2026-07-03 094746" src="https://github.com/user-attachments/assets/cf424f90-0cc6-49af-b903-09007dbe2cf4" />
<img width="1919" height="906" alt="Ekran görüntüsü 2026-07-03 094753" src="https://github.com/user-attachments/assets/ffb87192-ec31-41fe-b224-56cf29775d7f" />

- **Field-Based Combobox Search:** Advanced search functionality utilizing a combobox interface. Users can perform granular searches by selecting specific fields (e.g., Name, Category, ID) for accurate results.
Search module for public homepage:
<img width="1919" height="915" alt="Ekran görüntüsü 2026-07-03 094917" src="https://github.com/user-attachments/assets/02061b9a-b815-4078-9a7e-d73327b4837c" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 094836" src="https://github.com/user-attachments/assets/27208893-22ed-45d4-acd3-bf1b55f785e4" />

Field-Based Combobox Search for every table in admin page:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 095147" src="https://github.com/user-attachments/assets/7cae39d5-ef73-4921-8d2c-23e72fa98708" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 120004" src="https://github.com/user-attachments/assets/84269733-f1df-4e24-bd38-4fec193b5dd4" />

Adding new data:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 095237" src="https://github.com/user-attachments/assets/c0f4790d-0411-4f89-bf98-839a94535216" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 095259" src="https://github.com/user-attachments/assets/719e7e66-c1a0-4940-8c66-3addbf3b8808" />

Updating data:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-03 095316" src="https://github.com/user-attachments/assets/26f03b41-2396-456b-9d07-e7017a1beee2" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-03 095323" src="https://github.com/user-attachments/assets/639ac258-93aa-43cc-92f1-ded0883b4e95" />
Another options in admin panel:
<img width="1919" height="904" alt="Ekran görüntüsü 2026-07-03 095518" src="https://github.com/user-attachments/assets/ab40252b-19e4-4db4-b090-8250d5a60b99" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 114349" src="https://github.com/user-attachments/assets/58aae41d-c62b-43c9-88c4-506bc07856a1" />

Adding new admin user:
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-03 101512" src="https://github.com/user-attachments/assets/bbf263f6-8690-4e60-b197-ede723587979" />


#### 3. Media Content Engine
- **Unified Media Catalog:** Relational management of Movies, TV Series, and Theater Plays.
- **QR Code Integration:** A dedicated QR Code module for generating scannable codes for tickets, events, or content sharing.
 QR Code Generation and Scanning Module:
<img width="890" height="502" alt="Ekran görüntüsü 2026-07-03 115129" src="https://github.com/user-attachments/assets/c1baad55-89f4-457e-a9e0-83c7c27c619f" />

#### 4. Analytics & Export Pipeline
- **Visual Telemetry:** Integration with `Chart.js` to provide real-time dashboard analytics.
Reports and visuals for admins:
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-03 095722" src="https://github.com/user-attachments/assets/a87fcd26-ebe7-43e1-ac4d-107c99b19dc6" />
<img width="1919" height="915" alt="Ekran görüntüsü 2026-07-03 095007" src="https://github.com/user-attachments/assets/d6f4a86f-8665-4092-913f-f74a2daf2b1f" />
<img width="1919" height="902" alt="Ekran görüntüsü 2026-07-03 095739" src="https://github.com/user-attachments/assets/1901ce35-dffb-432c-815d-630e74c0e585" />
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-03 095730" src="https://github.com/user-attachments/assets/482566a3-f4c9-42dd-9701-19eb1119ae16" />
- **Document Generation:** 
  - **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for all content categories.
  - **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets (Movies, Series, Categories) into standard Excel formats.
PDF and Excel Export Interface for admins:
<img width="1135" height="373" alt="Ekran görüntüsü 2026-07-03 114402" src="https://github.com/user-attachments/assets/149d84ec-519d-4ae6-8876-ac593142334a" />
<img width="469" height="233" alt="Ekran görüntüsü 2026-07-03 114428" src="https://github.com/user-attachments/assets/d1a33942-c781-49a3-8d54-90170a54c54a" />

---

<br>

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
**BiletSinema**, sinema ve eğlence içeriklerinin tüm yaşam döngüsünü yönetmek için tasarlanmış kapsamlı ve monolitik bir web uygulamasıdır. Güçlü **ASP.NET Core MVC** altyapısı üzerine inşa edilen bu sistem; yöneticilerin filmleri, dizileri, tiyatro oyunlarını ve bunlara ait meta verileri merkezi bir noktadan yönetmesini sağlarken, müşteriler için de kesintisiz bir kullanıcı deneyimi sunar.

### 🚀 Proje Kapsamı ve Yetenekleri

#### 1. Kimlik Yönetimi ve Yönlendirme
- **Güvenli Kimlik Doğrulama ve Giriş Ekranı:** Güçlü oturum yönetimi sağlayan, özel ve tam donanımlı bir giriş ve kayıt arayüzü.
- **Rol Tabanlı Yönlendirme:** ASP.NET Core Identity ile desteklenen akıllı yönlendirme. Yöneticiler giriş yaptıklarında yönetim paneline (dashboard) yönlendirilirken, standart kullanıcılar herkese açık anasayfaya yönlendirilir.
- **Hesap Yönetimi:** Kullanıcı hesaplarının tam yaşam döngüsü yönetimi.
- **Yönetici (Admin) Yönetimi:** Yönetim paneli içinde güvenli bir şekilde yeni yönetici hesapları oluşturmak ve sisteme dahil etmek için özel arayüz.
Yöneticiler için giriş arayüzü:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 094939" src="https://github.com/user-attachments/assets/d130c85b-afe5-46ed-8bbc-b168627c7a14" />


#### 2. Kullanıcı Arayüzü (Ön Yüz)
- **Etkileşimli Anasayfa:** Film, dizi ve tiyatro oyunları kataloğunu gösteren dinamik ve kullanıcılara yönelik anasayfa.
Herkese Açık Anasayfa ve Katalog:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 094733" src="https://github.com/user-attachments/assets/87d11669-bf47-4018-a771-c6f091567b88" />
<img width="1919" height="919" alt="Ekran görüntüsü 2026-07-03 094746" src="https://github.com/user-attachments/assets/cf424f90-0cc6-49af-b903-09007dbe2cf4" />
<img width="1919" height="906" alt="Ekran görüntüsü 2026-07-03 094753" src="https://github.com/user-attachments/assets/ffb87192-ec31-41fe-b224-56cf29775d7f" />

- **Alan Bazlı Combobox Arama:** Combobox arayüzü kullanan gelişmiş arama işlevselliği. Kullanıcılar, doğru sonuçlar için belirli alanları (örn. Ad, Kategori, ID) seçerek ayrıntılı aramalar yapabilirler.
Genel anasayfa için arama modülü:
<img width="1919" height="915" alt="Ekran görüntüsü 2026-07-03 094917" src="https://github.com/user-attachments/assets/02061b9a-b815-4078-9a7e-d73327b4837c" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 094836" src="https://github.com/user-attachments/assets/27208893-22ed-45d4-acd3-bf1b55f785e4" />

Yönetici sayfasındaki her tablo için Alan Bazlı Combobox Arama:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 095147" src="https://github.com/user-attachments/assets/7cae39d5-ef73-4921-8d2c-23e72fa98708" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 120004" src="https://github.com/user-attachments/assets/84269733-f1df-4e24-bd38-4fec193b5dd4" />

Yeni veri ekleme:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 095237" src="https://github.com/user-attachments/assets/c0f4790d-0411-4f89-bf98-839a94535216" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-03 095259" src="https://github.com/user-attachments/assets/719e7e66-c1a0-4940-8c66-3addbf3b8808" />

Veri güncelleme:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-03 095316" src="https://github.com/user-attachments/assets/26f03b41-2396-456b-9d07-e7017a1beee2" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-03 095323" src="https://github.com/user-attachments/assets/639ac258-93aa-43cc-92f1-ded0883b4e95" />
Yönetici panelindeki diğer seçenekler:
<img width="1919" height="904" alt="Ekran görüntüsü 2026-07-03 095518" src="https://github.com/user-attachments/assets/ab40252b-19e4-4db4-b090-8250d5a60b99" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-03 114349" src="https://github.com/user-attachments/assets/58aae41d-c62b-43c9-88c4-506bc07856a1" />

Yeni yönetici (admin) kullanıcısı ekleme:
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-03 101512" src="https://github.com/user-attachments/assets/bbf263f6-8690-4e60-b197-ede723587979" />


#### 3. Medya İçerik Motoru
- **Bütünleşik Medya Kataloğu:** Filmler, Diziler ve Tiyatro Oyunlarının ilişkisel yönetimi.
- **QR Kod Entegrasyonu:** Biletler, etkinlikler veya içerik paylaşımı için taranabilir kodlar üreten özel bir QR Kod modülü.
 QR Kod Oluşturma ve Tarama Modülü:
<img width="890" height="502" alt="Ekran görüntüsü 2026-07-03 115129" src="https://github.com/user-attachments/assets/c1baad55-89f4-457e-a9e0-83c7c27c619f" />

#### 4. Analitik ve Veri Dışa Aktarımı
- **Görsel Telemetri (Analitikler):** Gerçek zamanlı panel analizleri sunmak için `Chart.js` entegrasyonu.
Yöneticiler için raporlar ve görseller:
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-03 095722" src="https://github.com/user-attachments/assets/a87fcd26-ebe7-43e1-ac4d-107c99b19dc6" />
<img width="1919" height="915" alt="Ekran görüntüsü 2026-07-03 095007" src="https://github.com/user-attachments/assets/d6f4a86f-8665-4092-913f-f74a2daf2b1f" />
<img width="1919" height="902" alt="Ekran görüntüsü 2026-07-03 095739" src="https://github.com/user-attachments/assets/1901ce35-dffb-432c-815d-630e74c0e585" />
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-03 095730" src="https://github.com/user-attachments/assets/482566a3-f4c9-42dd-9701-19eb1119ae16" />
- **Belge Üretimi:** 
  - **PDF Raporları:** Tüm içerik kategorileri için piksel mükemmelliğinde, yazdırılabilir idari raporlar oluşturmak amacıyla `QuestPDF` kullanımı.
  - **Excel Tabloları:** Ham veri setlerini (Filmler, Diziler, Kategoriler vb.) standart Excel formatında dışa aktarmak için `EPPlus` kullanımı.
Yöneticiler için PDF ve Excel Dışa Aktarım Arayüzü:
<img width="1135" height="373" alt="Ekran görüntüsü 2026-07-03 114402" src="https://github.com/user-attachments/assets/149d84ec-519d-4ae6-8876-ac593142334a" />
<img width="469" height="233" alt="Ekran görüntüsü 2026-07-03 114428" src="https://github.com/user-attachments/assets/d1a33942-c781-49a3-8d54-90170a54c54a" />

### ⚙️ Geliştirme Ortamı Kurulumu

Projeyi yerel ortamınızda çalıştırmak için **.NET SDK**'nın kurulu olduğundan emin olun.

1. **Repoyu Klonlayın:**
   ```bash
   git clone https://github.com/melisyanik/SoftITO-Backend.git
   cd BiletSinema
   ```

2. **Veritabanı Yapılandırması:**
   `appsettings.json` dosyasındaki `DefaultConnection` bağlantı dizesini kendi SQL Server sunucunuza (veya LocalDB) göre güncelleyin.

3. **Migration'ları Uygulayın:**
   ```bash
   dotnet ef database update
   ```

4. **Uygulamayı Başlatın:**
   ```bash
   dotnet run
   ```

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
