# 🌟 AstroComment - Astrology & Horoscope Platform (MVC & Dapper) (PROJECT 8)
.NET 9 | Dapper | SQL Server | Bootstrap

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-FE0902?style=for-the-badge&logo=dapper&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

[🇺🇸 Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

---

## 🇺🇸 English Documentation

### 🎯 Project Overview
**AstroComment** is a fast and responsive web application built with ASP.NET Core MVC and Dapper. It serves as an interactive platform where users can read their daily/weekly horoscopes, discover zodiac traits, and engage by leaving comments. For administrators, it offers a powerful backend to manage content (CRUD operations via Stored Procedures), moderate user comments, and generate detailed PDF and Excel reports.

### 🚀 Scope & Capabilities

#### 1. Identity & Session Management
* **Custom Authentication:** Secure Login and Registration system utilizing `HttpContext.Session` for lightweight and fast user state management.
<img width="1919" height="900" alt="Login Screen Placeholder" src="https://via.placeholder.com/1919x900?text=Login+Screen" />

* **Role-Based Access Control:** Distinct roles for Administrators and Standard Users. Admins are granted access to a dedicated dashboard for content moderation, while standard users can interact with horoscopes and their own profiles.
<img width="1919" height="900" alt="Admin Dashboard Placeholder" src="https://via.placeholder.com/1919x900?text=Admin+Dashboard" />

#### 2. Public User Experience
* **Interactive Zodiac Interface:** Users can navigate through different Zodiac signs (Burçlar) to read daily content and detailed astrological insights.
<img width="1919" height="900" alt="Zodiac List Placeholder" src="https://via.placeholder.com/1919x900?text=Zodiac+List+Screen" />

* **Engagement & Commenting System:** Users can leave comments on specific horoscopes. The system tracks user interactions and displays admin replies directly under user comments.
<img width="1919" height="900" alt="Horoscope Detail and Comments Placeholder" src="https://via.placeholder.com/1919x900?text=Horoscope+Detail+%26+Comments" />

#### 3. High-Performance Data Layer (Dapper & Stored Procedures)
* **Dapper Integration:** Replaced traditional heavy ORMs with Dapper for raw SQL performance.
* **Stored Procedure Driven CRUD:** All core operations (Create, Read, Update, Delete) for Horoscopes, Zodiac Signs, and Comments are executed via SQL Server Stored Procedures, ensuring maximum database security and performance.
* **Admin Content Management:** Admins can effortlessly create new horoscope entries, edit existing ones, and manage the zodiac catalog.
<img width="1919" height="900" alt="Admin CRUD Placeholder" src="https://via.placeholder.com/1919x900?text=Admin+CRUD+Operations" />

* **Comment Moderation:** Admins have full control to approve, reply to, edit, or delete user comments.
<img width="1919" height="900" alt="Comment Moderation Placeholder" src="https://via.placeholder.com/1919x900?text=Comment+Moderation+Screen" />

#### 4. Advanced Reporting (PDF & Excel)
* **Visual Telemetry:** The admin dashboard displays quick statistics regarding total comments, active zodiacs, and user engagement rates.
* **Document Generation:**
  * **PDF Reports (`QuestPDF`):** Generate pixel-perfect, printable reports showcasing user activity, comment history, and system statistics.
  * **Excel Spreadsheets (`EPPlus`):** Export raw data for Zodiacs, Users, and Comments directly into standard Excel formats for external analysis.
<img width="1919" height="900" alt="Excel Export Placeholder" src="https://via.placeholder.com/1919x900?text=Excel+Export+View" />
<img width="1919" height="900" alt="PDF Export Placeholder" src="https://via.placeholder.com/1919x900?text=PDF+Report+View" />

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
**AstroComment**, ASP.NET Core MVC ve Dapper kullanılarak geliştirilmiş, yüksek performanslı ve interaktif bir astroloji platformudur. Kullanıcıların günlük burç yorumlarını okuyup yorum yapabildiği bu sistem; yöneticilere ise Stored Procedure'ler (Saklı Yordamlar) üzerinden CRUD işlemleri yapma, kullanıcı yorumlarını denetleme ve detaylı PDF/Excel raporları alma imkanı sunan güçlü bir altyapı sağlar.

### 🚀 Kapsam ve Yetenekler

#### 1. Kimlik ve Oturum Yönetimi
* **Özel Kimlik Doğrulama:** Hafif ve hızlı durum yönetimi için `HttpContext.Session` kullanan güvenli Giriş (Login) ve Kayıt (Register) sistemi.
<img width="1919" height="900" alt="Login Screen Placeholder" src="https://via.placeholder.com/1919x900?text=Giris+Ekrani" />

* **Rol Tabanlı Erişim:** Yöneticiler (Admin) ve Standart Kullanıcılar için ayrılmış yetkilendirme. Yöneticiler içerik moderasyonu için özel yönetim paneline erişirken, standart kullanıcılar burçlarla etkileşime girer.
<img width="1919" height="900" alt="Admin Dashboard Placeholder" src="https://via.placeholder.com/1919x900?text=Yonetici+Paneli" />

#### 2. Herkese Açık Kullanıcı Deneyimi
* **Etkileşimli Burç Arayüzü:** Kullanıcılar tüm burçlar (Zodiac) arasında gezinebilir, günlük/haftalık içeriklere ve astrolojik detaylara ulaşabilir.
<img width="1919" height="900" alt="Zodiac List Placeholder" src="https://via.placeholder.com/1919x900?text=Burclar+Listesi" />

* **Yorum ve Etkileşim Sistemi:** Kullanıcılar okudukları burç yorumlarına kendi düşüncelerini yazabilirler. Sistem, admin cevaplarını doğrudan ilgili kullanıcı yorumunun altında hiyerarşik olarak gösterir.
<img width="1919" height="900" alt="Horoscope Detail and Comments Placeholder" src="https://via.placeholder.com/1919x900?text=Burc+Detayi+ve+Yorumlar" />

#### 3. Yüksek Performanslı Veri Katmanı (Dapper & Stored Procedures)
* **Dapper Entegrasyonu:** Yüksek SQL performansı elde etmek için ağır ORM'ler yerine Dapper Micro-ORM tercih edilmiştir.
* **Stored Procedure (SP) ile CRUD İşlemleri:** Burçlar, Yorumlar ve İçerikler üzerindeki tüm Ekleme, Okuma, Güncelleme ve Silme (CRUD) işlemleri, güvenlik ve hızı maksimize etmek adına SQL Server **Stored Procedure**'leri üzerinden gerçekleştirilmektedir.
* **İçerik Yönetimi:** Yöneticiler kolayca yeni burç yorumları (Horoscope) ekleyebilir, mevcutları güncelleyebilir veya silebilir. Arama filtreleri sayesinde veritabanındaki kayıtlar kolayca bulunur.
<img width="1919" height="900" alt="Admin CRUD Placeholder" src="https://via.placeholder.com/1919x900?text=Yonetici+CRUD+Islemleri" />

* **Yorum Moderasyonu:** Yöneticiler gelen yorumları inceleyebilir, yorumlara admin olarak "Cevap (Reply)" yazabilir ve uygunsuz yorumları sistemden kaldırabilir.
<img width="1919" height="900" alt="Comment Moderation Placeholder" src="https://via.placeholder.com/1919x900?text=Yorum+Moderasyon+Ekrani" />

#### 4. Gelişmiş Raporlama (PDF & Excel)
* **Görsel İstatistikler (Dashboard):** Yönetici paneli, sistemdeki toplam yorum sayısı, aktif burçlar ve kullanıcı etkileşim oranları gibi istatistikleri hızlıca sunar.
* **Belge ve Rapor Üretimi:**
  * **PDF Raporları (`QuestPDF`):** Kullanıcı aktiviteleri, yorum geçmişleri ve sistem istatistiklerini içeren, baskıya hazır, profesyonel PDF raporları üretilir.
  * **Excel Tabloları (`EPPlus`):** Burçlar, Kullanıcılar ve Yorumlara ait ham veriler, harici analizler yapılabilmesi için doğrudan standart Excel (.xlsx) formatında dışa aktarılır.
<img width="1919" height="900" alt="Excel Export Placeholder" src="https://via.placeholder.com/1919x900?text=Excel+Raporlama+Ciktisi" />
<img width="1919" height="900" alt="PDF Export Placeholder" src="https://via.placeholder.com/1919x900?text=PDF+Raporlama+Ciktisi" />
