<div align="center">

# 🎬 BiletSinema

[![.NET](https://img.shields.io/badge/.NET_8.0-5C2D91?style=flat-square&logo=.net&logoColor=white)](#)
[![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core-0078D4?style=flat-square&logo=dotnet&logoColor=white)](#)
[![Bootstrap](https://img.shields.io/badge/Bootstrap_5-563D7C?style=flat-square&logo=bootstrap&logoColor=white)](#)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](#)

[🇬🇧 Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

</div>

---

<br>

## 🇬🇧 English Documentation

### 🎯 Project Overview
**BiletSinema** is a comprehensive, monolithic web application designed to manage the entire lifecycle of cinema and entertainment content. Built on the robust **ASP.NET Core MVC** framework, it serves as a centralized hub for administrators to oversee movies, TV series, theaters, and their associated metadata, while providing a seamless user experience for customers.

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
- **Secure Authentication & Login Screen:** A dedicated, fully functional login and registration interface ensuring robust session management.
- **Role-Based Routing:** Smart routing powered by ASP.NET Core Identity. Admins are redirected to the management dashboard upon login, while regular users are routed to the public homepage.
- **Account Administration:** Full lifecycle management of user accounts.
- **Admin Management:** Dedicated interface within the dashboard to securely create and onboard new administrator accounts.

![Login Screen](docs/images/login-placeholder.png)
*> Screenshot placeholder: Secure Login and Registration Interface*

#### 2. Public User Experience
- **Interactive Homepage:** A dynamic, user-facing homepage displaying the catalog of movies, series, and theater plays.
- **Field-Based Combobox Search:** Advanced search functionality utilizing a combobox interface. Users can perform granular searches by selecting specific fields (e.g., Name, Category, ID) for accurate results.

![Public Homepage](docs/images/homepage-placeholder.png)
*> Screenshot placeholder: Public Homepage and Catalog*

![Search Module](docs/images/search-module-placeholder.png)
*> Screenshot placeholder: Field-Based Combobox Search Interface*

#### 3. Media Content Engine
- **Unified Media Catalog:** Relational management of Movies, TV Series, and Theater Plays.
- **QR Code Integration:** A dedicated QR Code module for generating scannable codes for tickets, events, or content sharing.

![QR Code Module](docs/images/qrcode-module-placeholder.png)
*> Screenshot placeholder: QR Code Generation and Scanning Module*

#### 4. Analytics & Export Pipeline
- **Visual Telemetry:** Integration with `Chart.js` to provide real-time dashboard analytics.
- **Document Generation:** 
  - **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for all content categories.
  - **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets (Movies, Series, Categories) into standard Excel formats.

![Analytics & Reports](docs/images/reporting-charts-placeholder.png)
*> Screenshot placeholder: PDF and Excel Export Interface*

---

<br>

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
**BiletSinema**, sinema ve eğlence içeriklerinin tüm yaşam döngüsünü yönetmek için tasarlanmış kapsamlı bir web uygulamasıdır. **ASP.NET Core MVC** altyapısı üzerine inşa edilen bu sistem; yöneticilerin içerikleri merkezi bir noktadan yönetmesini sağlarken, müşteriler için de akıcı bir deneyim sunar.

### 🚀 Proje Kapsamı ve Yetenekleri

#### 1. Kimlik Yönetimi ve Yönlendirme
- **Giriş ve Kayıt Ekranı (Login):** Kullanıcıların sisteme güvenli bir şekilde dahil olduğu, cookie (çerez) tabanlı tam donanımlı giriş ve kayıt arayüzü.
- **Kimlik Tabanlı Yönlendirme (Identity Routing):** ASP.NET Core Identity ile güçlendirilmiş akıllı yönlendirme. Giriş yapan yetkili kullanıcılar admin paneline yönlendirilirken, standart kullanıcılar anasayfaya yönlendirilir.
- **Kullanıcı İşlemleri:** Şifre yönetimi ve güvenli hesap işlemleri.
- **Yönetici (Admin) Ekleme:** Admin paneli üzerinden sisteme yetkili yeni yöneticiler (admin) eklenebilmesi.

![Giriş Ekranı](docs/images/login-placeholder.png)
*> Ekran görüntüsü (Placeholder): Giriş Yap (Login) ve Kayıt Ol Arayüzü*

#### 2. Kullanıcı Arayüzü (Ön Yüz)
- **Kullanıcı Anasayfası:** Müşterilerin görebildiği; film, dizi ve tiyatro oyunlarının listelendiği dinamik ve modern anasayfa.
- **Alan Bazlı Combobox Arama:** Combobox menüsü ile entegre edilmiş gelişmiş arama özelliği. Kullanıcılar kategori, ad veya ID gibi belirli alanları (field) seçerek nokta atışı filtrelemeler yapabilirler.

![Kullanıcı Anasayfası](docs/images/homepage-placeholder.png)
*> Ekran görüntüsü (Placeholder): Kullanıcıların gördüğü dinamik anasayfa*

![Alan Bazlı Arama](docs/images/search-module-placeholder.png)
*> Ekran görüntüsü (Placeholder): Combobox ile alan bazlı arama modülü*

#### 3. Medya İçerik Motoru
- **Bütünleşik Medya Kataloğu:** Filmler, Diziler ve Tiyatro Oyunlarının ilişkisel bir veritabanı yapısıyla yönetilmesi.
- **QR Kod Modülü:** Biletler, etkinlik bilgileri veya hızlı içerik paylaşımı için taranabilir QR kodların üretildiği entegre modül.

![QR Kod Modülü](docs/images/qrcode-module-placeholder.png)
*> Ekran görüntüsü (Placeholder): QR Kod oluşturma ve detay arayüzü*

#### 4. Analitik ve Veri Dışa Aktarımı
- **Görsel Analitikler:** İçerik dağılımı hakkında gerçek zamanlı veriler sunan `Chart.js` grafikleri.
- **PDF ve Excel Raporları:** 
  - **PDF Çıktıları:** `QuestPDF` altyapısıyla kategoriler, filmler ve diğer içerikler için yazdırılabilir PDF raporlarının alınması.
  - **Excel Export:** `EPPlus` kullanılarak verilerin standart Excel (.xlsx) formatında tablo halinde dışa aktarılması.

![Analitik ve Raporlar](docs/images/reporting-charts-placeholder.png)
*> Ekran görüntüsü (Placeholder): PDF ve Excel dışa aktarım butonları ve tablolar*

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
