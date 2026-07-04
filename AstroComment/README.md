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
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 223834" src="https://github.com/user-attachments/assets/3fca0e1f-96ce-4a86-9b0a-73a6140120e7" />
<img width="1918" height="908" alt="Ekran görüntüsü 2026-07-04 224353" src="https://github.com/user-attachments/assets/e1618983-1281-46ab-bd51-cd3a8d19602e" />

* **Role-Based Access Control:** Distinct roles for Administrators and Standard Users. Admins are granted access to a dedicated dashboard for content moderation, while standard users can interact with horoscopes and their own profiles.

Admin acces main page:
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 223852" src="https://github.com/user-attachments/assets/bd81349a-6ae2-47bc-891f-6c3898c7a6de" />

User horoscope page:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 224511" src="https://github.com/user-attachments/assets/037a5da5-35f3-44b4-902b-b5e89f71525c" />

#### 2. Public User Experience
* **Interactive Zodiac Interface:** Users can navigate through different Zodiac signs (Burçlar) to read daily content and detailed astrological insights.
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 223643" src="https://github.com/user-attachments/assets/c1378119-508a-4a98-a3ca-d009452774b6" />

Also they can add their own zodiacs:
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 224740" src="https://github.com/user-attachments/assets/2c733b81-989e-44ea-bb90-86283cd8593d" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 225254" src="https://github.com/user-attachments/assets/35e54af5-25f5-47bb-9f33-1b970be3d345" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 225302" src="https://github.com/user-attachments/assets/2904facc-4f02-4acc-9f4f-b295d228663d" />

* **Engagement & Commenting System:** Users can leave comments on specific horoscopes. The system tracks user interactions and displays admin replies directly under user comments.
Adding a comment to a horoscope:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 224527" src="https://github.com/user-attachments/assets/8b54f73f-0354-4b56-a2f8-983e6e6a4b1e" />
<img width="1914" height="908" alt="Ekran görüntüsü 2026-07-04 224559" src="https://github.com/user-attachments/assets/f9e1e7ce-c2f1-425c-9665-c7bc425c3b18" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 224657" src="https://github.com/user-attachments/assets/4920edcb-670b-4871-b012-0e936b391ce5" />

#### 3. High-Performance Data Layer (Dapper & Stored Procedures)
* **Dapper Integration:** Replaced traditional heavy ORMs with Dapper for raw SQL performance.
* **Stored Procedure Driven CRUD:** All core operations (Create, Read, Update, Delete) for Horoscopes, Zodiac Signs, and Comments are executed via SQL Server Stored Procedures, ensuring maximum database security and performance.
* **Admin Content Management:** Admins can effortlessly create new horoscope entries, edit existing ones, and manage the zodiac catalog.
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 225007" src="https://github.com/user-attachments/assets/ad08ed38-56f6-4a1a-936a-129bd1fb5920" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-04 225051" src="https://github.com/user-attachments/assets/82244bf5-026d-4208-ab01-d71fa68b7961" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 225042" src="https://github.com/user-attachments/assets/58522083-e017-47d7-a08c-b28eebc2467d" />

Adding a zodiac sign from admin:
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-04 231422" src="https://github.com/user-attachments/assets/f4945e91-2c13-4cc1-b8f9-01b29aacf9f9" />
<img width="1919" height="903" alt="Ekran görüntüsü 2026-07-04 231430" src="https://github.com/user-attachments/assets/0c276494-d38d-4937-b01b-895458c35798" />

Also admin can view the users and change their status:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 231032" src="https://github.com/user-attachments/assets/05384fc9-8d0b-4636-9240-dabd75920810" />
<img width="1918" height="911" alt="Ekran görüntüsü 2026-07-04 231041" src="https://github.com/user-attachments/assets/368bcf2e-0e45-48f5-b25e-c7aff0d5bd3b" />


Search users according to the features:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 225347" src="https://github.com/user-attachments/assets/75da4e24-ee02-4b7c-a159-44efefbb1d24" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 225400" src="https://github.com/user-attachments/assets/95f9c01d-c0cb-4e0a-b7aa-9bfc1d5f76d0" />


* **Comment Moderation:** Admins have full control to approve, reply to, edit, or delete user comments.
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 224847" src="https://github.com/user-attachments/assets/b5ce0dbf-b695-42d6-95c1-b08574a6c653" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-04 224903" src="https://github.com/user-attachments/assets/f48da485-e6a5-454d-ba02-50cd18d7e679" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-04 224912" src="https://github.com/user-attachments/assets/f4288c63-04db-4624-8592-b67c7813c555" />
View of user for the comments after admin gives an answer:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 225154" src="https://github.com/user-attachments/assets/63159212-72c0-4315-a1d1-81356c3a483f" />


#### 4. Advanced Reporting (PDF & Excel)
* **Visual Telemetry:** The admin dashboard displays quick statistics regarding total comments, active zodiacs, and user engagement rates.
* **Document Generation:**
  * **PDF Reports (`QuestPDF`):** Generate pixel-perfect, printable reports showcasing user activity, comment history, and system statistics.
  * **Excel Spreadsheets (`EPPlus`):** Export raw data for Zodiacs, Users, and Comments directly into standard Excel formats for external analysis.
 
PDF report Generation for admin:

<img width="717" height="707" alt="Ekran görüntüsü 2026-07-04 225430" src="https://github.com/user-attachments/assets/9fb5bfe5-6cf7-42cb-abde-544b27a4aa17" />

Excel report generation for admin:
<img width="837" height="485" alt="Ekran görüntüsü 2026-07-04 225448" src="https://github.com/user-attachments/assets/20444193-f1b7-40a3-b4c9-841730e2fda0" />


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
