<div align="center">

# ğŸ¬ BiletSinema

[![.NET](https://img.shields.io/badge/.NET_8.0-5C2D91?style=flat-square&logo=.net&logoColor=white)](#)
[![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core-0078D4?style=flat-square&logo=dotnet&logoColor=white)](#)
[![Bootstrap](https://img.shields.io/badge/Bootstrap_5-563D7C?style=flat-square&logo=bootstrap&logoColor=white)](#)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](#)

[ğŸ‡¬ğŸ‡§ Read in English](#-english-documentation) | [ğŸ‡¹ğŸ‡· TÃ¼rkÃ§e DokÃ¼mantasyon](#-tÃ¼rkÃ§e-dokÃ¼mantasyon)

</div>

---

<br>

## ğŸ‡¬ğŸ‡§ English Documentation

### ğŸ¯ Project Overview
**BiletSinema** is a comprehensive, monolithic web application designed to manage the entire lifecycle of cinema and entertainment content. Built on the robust **ASP.NET Core MVC** framework, it serves as a centralized hub for administrators to oversee movies, TV series, theaters, and their associated metadata, while providing a seamless user experience for customers.

### ğŸš€ Scope & Capabilities

#### 1. Identity & Routing Management
- **Role-Based Routing:** Smart routing powered by ASP.NET Core Identity. Admins are redirected to the management dashboard, while regular users are routed to the public homepage.
- **Account Administration:** Full lifecycle management of user accounts (creation, login, registration).`n- **Admin Management:** Dedicated interface within the dashboard to securely create and onboard new administrator accounts.
- **Secure Authentication:** Implementation of secure cookie-based authentication.

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

## ğŸ‡¹ğŸ‡· TÃ¼rkÃ§e DokÃ¼mantasyon

### ğŸ¯ Proje Ã–zeti
**BiletSinema**, sinema ve eÄŸlence iÃ§eriklerinin tÃ¼m yaÅŸam dÃ¶ngÃ¼sÃ¼nÃ¼ yÃ¶netmek iÃ§in tasarlanmÄ±ÅŸ kapsamlÄ± bir web uygulamasÄ±dÄ±r. **ASP.NET Core MVC** altyapÄ±sÄ± Ã¼zerine inÅŸa edilen bu sistem; yÃ¶neticilerin iÃ§erikleri merkezi bir noktadan yÃ¶netmesini saÄŸlarken, mÃ¼ÅŸteriler iÃ§in de akÄ±cÄ± bir deneyim sunar.

### ğŸš€ Proje KapsamÄ± ve Yetenekleri

#### 1. Kimlik YÃ¶netimi ve YÃ¶nlendirme
- **Kimlik TabanlÄ± YÃ¶nlendirme (Identity Routing):** ASP.NET Core Identity ile gÃ¼Ã§lendirilmiÅŸ akÄ±llÄ± yÃ¶nlendirme. GiriÅŸ yapan yetkili kullanÄ±cÄ±lar admin paneline yÃ¶nlendirilirken, standart kullanÄ±cÄ±lar anasayfaya yÃ¶nlendirilir.
- **KullanÄ±cÄ± Ä°ÅŸlemleri:** GÃ¼venli kayÄ±t olma, giriÅŸ yapma ve hesap yÃ¶netimi.

#### 2. KullanÄ±cÄ± ArayÃ¼zÃ¼ (Ã–n YÃ¼z)
- **KullanÄ±cÄ± AnasayfasÄ±:** MÃ¼ÅŸterilerin gÃ¶rebildiÄŸi; film, dizi ve tiyatro oyunlarÄ±nÄ±n listelendiÄŸi dinamik ve modern anasayfa.
- **Alan BazlÄ± Combobox Arama:** Combobox menÃ¼sÃ¼ ile entegre edilmiÅŸ geliÅŸmiÅŸ arama Ã¶zelliÄŸi. KullanÄ±cÄ±lar kategori, ad veya ID gibi belirli alanlarÄ± (field) seÃ§erek nokta atÄ±ÅŸÄ± filtrelemeler yapabilirler.

![KullanÄ±cÄ± AnasayfasÄ±](docs/images/homepage-placeholder.png)
*> Ekran gÃ¶rÃ¼ntÃ¼sÃ¼ (Placeholder): KullanÄ±cÄ±larÄ±n gÃ¶rdÃ¼ÄŸÃ¼ dinamik anasayfa*

![Alan BazlÄ± Arama](docs/images/search-module-placeholder.png)
*> Ekran gÃ¶rÃ¼ntÃ¼sÃ¼ (Placeholder): Combobox ile alan bazlÄ± arama modÃ¼lÃ¼*

#### 3. Medya Ä°Ã§erik Motoru
- **BÃ¼tÃ¼nleÅŸik Medya KataloÄŸu:** Filmler, Diziler ve Tiyatro OyunlarÄ±nÄ±n iliÅŸkisel bir veritabanÄ± yapÄ±sÄ±yla yÃ¶netilmesi.
- **QR Kod ModÃ¼lÃ¼:** Biletler, etkinlik bilgileri veya hÄ±zlÄ± iÃ§erik paylaÅŸÄ±mÄ± iÃ§in taranabilir QR kodlarÄ±n Ã¼retildiÄŸi entegre modÃ¼l.

![QR Kod ModÃ¼lÃ¼](docs/images/qrcode-module-placeholder.png)
*> Ekran gÃ¶rÃ¼ntÃ¼sÃ¼ (Placeholder): QR Kod oluÅŸturma ve detay arayÃ¼zÃ¼*

#### 4. Analitik ve Veri DÄ±ÅŸa AktarÄ±mÄ±
- **GÃ¶rsel Analitikler:** Ä°Ã§erik daÄŸÄ±lÄ±mÄ± hakkÄ±nda gerÃ§ek zamanlÄ± veriler sunan `Chart.js` grafikleri.
- **PDF ve Excel RaporlarÄ±:** 
  - **PDF Ã‡Ä±ktÄ±larÄ±:** `QuestPDF` altyapÄ±sÄ±yla kategoriler, filmler ve diÄŸer iÃ§erikler iÃ§in yazdÄ±rÄ±labilir PDF raporlarÄ±nÄ±n alÄ±nmasÄ±.
  - **Excel Export:** `EPPlus` kullanÄ±larak verilerin standart Excel (.xlsx) formatÄ±nda tablo halinde dÄ±ÅŸa aktarÄ±lmasÄ±.

![Analitik ve Raporlar](docs/images/reporting-charts-placeholder.png)
*> Ekran gÃ¶rÃ¼ntÃ¼sÃ¼ (Placeholder): PDF ve Excel dÄ±ÅŸa aktarÄ±m butonlarÄ± ve tablolar*

### âš™ï¸ GeliÅŸtirme OrtamÄ± Kurulumu

Projeyi yerel ortamÄ±nÄ±zda Ã§alÄ±ÅŸtÄ±rmak iÃ§in **.NET SDK**'nÄ±n kurulu olduÄŸundan emin olun.

1. **Repoyu KlonlayÄ±n:**
   ```bash
   git clone https://github.com/melisyanik/SoftITO-Backend.git
   cd BiletSinema
   ```

2. **VeritabanÄ± YapÄ±landÄ±rmasÄ±:**
   `appsettings.json` dosyasÄ±ndaki `DefaultConnection` baÄŸlantÄ± dizesini kendi SQL Server sunucunuza (veya LocalDB) gÃ¶re gÃ¼ncelleyin.

3. **Migration'larÄ± UygulayÄ±n:**
   ```bash
   dotnet ef database update
   ```

4. **UygulamayÄ± BaÅŸlatÄ±n:**
   ```bash
   dotnet run
   ```
