# 📱 Post Management System (PROJECT 5)

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-339933?style=for-the-badge&logo=entity-framework&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

[us Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

---

## 🇺🇸 English Documentation

### 🎯 Project Overview
Post Management is a comprehensive web application built with ASP.NET Core MVC, Entity Framework Core, and JavaScript. It utilizes a robust Controller + JavaScript architecture to manage posts, handle user complaints, and track system activities efficiently. The platform offers a centralized hub for administrators to oversee the entire content ecosystem while providing an interactive and seamless experience for users to share and report content.

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
* **Admin Login & Dashboard:** A dedicated login screen for administrators. Once authenticated, admins are routed directly to the management dashboard.
`[PLACEHOLDER FOR ADMIN LOGIN IMAGE]`
`[PLACEHOLDER FOR ADMIN DASHBOARD IMAGE]`

#### 2. Public User Experience
* **Interactive Homepage:** A dynamic, user-facing homepage displaying a feed of available posts. Users can create new posts directly from the homepage.
`[PLACEHOLDER FOR HOMEPAGE IMAGE]`
`[PLACEHOLDER FOR CREATE POST IMAGE]`

* **Search Functionality:** Users can easily search through posts using keywords (e.g., Title, Content, Tag, Author) to quickly find relevant content.
`[PLACEHOLDER FOR SEARCH FUNCTIONALITY IMAGE]`

* **Content Reporting System:** Users can report inappropriate posts by submitting complaints with specific reasons, ensuring a safe community environment.
`[PLACEHOLDER FOR REPORT POST IMAGE]`

#### 3. Content Engine & Admin Management
* **Comprehensive CRUD Operations:** Full lifecycle management (Create, Read, Update, Delete) for Posts, Complaints, and Activity Logs.
* **Complaint Resolution System:** Admins can view incoming reports from users and toggle their resolution status (e.g., Pending, Resolved).
`[PLACEHOLDER FOR COMPLAINTS MANAGEMENT IMAGE]`

* **Field-Based Combobox Search (Admin):** Advanced search filtering is provided in the admin panels to easily find specific posts, complaints, or activity logs by selecting fields such as ID, Reason, Reporter, or Status.
`[PLACEHOLDER FOR ADMIN SEARCH IMAGE]`
`[PLACEHOLDER FOR LOGS MANAGEMENT IMAGE]`

#### 4. Analytics & Export Pipeline
* **Visual Telemetry:** Real-time dashboard providing administrators with key metrics such as Total Posts, Total Complaints, and Total Logs.
`[PLACEHOLDER FOR DASHBOARD METRICS IMAGE]`

* **Document Generation:**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for Posts, Complaints, and Activity Logs.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets into standard Excel formats.
`[PLACEHOLDER FOR PDF EXPORT IMAGE]`
`[PLACEHOLDER FOR EXCEL EXPORT IMAGE]`

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
Post Yönetim Sistemi (Post Management), ASP.NET Core MVC, Entity Framework Core ve JavaScript ile geliştirilmiş kapsamlı bir web uygulamasıdır. Gönderileri yönetmek, kullanıcı şikayetlerini incelemek ve sistem aktivitelerini takip etmek amacıyla güçlü bir Controller + JavaScript mimarisi kullanır. Platform, yöneticilerin tüm içerik ekosistemini denetlemesi için merkezi bir yönetim alanı sunarken; kullanıcılara da içerik paylaşmak ve şikayet bildirmek için etkileşimli ve kesintisiz bir deneyim sağlar.

### 🚀 Kapsam ve Yetenekler

#### 1. Kimlik Yönetimi ve Yönlendirme
* **Yönetici Girişi ve Panel (Dashboard):** Yöneticiler için özel olarak tasarlanmış giriş ekranı. Başarılı bir kimlik doğrulamanın ardından yöneticiler doğrudan yönetim paneline yönlendirilir.
`[YÖNETİCİ GİRİŞ EKRANI GÖRSELİ İÇİN YER TUTUCU]`
`[YÖNETİCİ PANELİ GÖRSELİ İÇİN YER TUTUCU]`

#### 2. Herkese Açık Kullanıcı Deneyimi
* **Etkileşimli Anasayfa:** Mevcut gönderilerin akışını listeleyen dinamik, kullanıcılara yönelik anasayfa. Kullanıcılar doğrudan anasayfa üzerinden yeni gönderiler oluşturabilir.
`[ANASAYFA GÖRSELİ İÇİN YER TUTUCU]`
`[GÖNDERİ OLUŞTURMA GÖRSELİ İÇİN YER TUTUCU]`

* **Arama İşlevi:** Kullanıcılar gönderiler arasında kelime bazlı aramalar yaparak (örn. Başlık, İçerik, Etiket, Yazar) ilgili içerikleri hızlıca bulabilir.
`[ARAMA İŞLEVİ GÖRSELİ İÇİN YER TUTUCU]`

* **İçerik Şikayet Sistemi:** Kullanıcılar uygunsuz buldukları gönderileri belirli bir neden belirterek şikayet edebilir ve topluluğun güvenli kalmasını sağlayabilirler.
`[ŞİKAYET BİLDİRİMİ GÖRSELİ İÇİN YER TUTUCU]`

#### 3. İçerik Motoru ve Yönetim
* **Kapsamlı CRUD İşlemleri:** Gönderiler (Posts), Şikayetler (Complaints) ve Aktivite Logları (Activity Logs) için tam yaşam döngüsü yönetimi (Oluşturma, Okuma, Güncelleme, Silme).
* **Şikayet Çözüm Sistemi:** Yöneticiler, kullanıcılardan gelen şikayetleri görüntüleyebilir ve çözüm durumlarını (Bekliyor, Çözüldü) güncelleyebilir.
`[ŞİKAYET YÖNETİMİ GÖRSELİ İÇİN YER TUTUCU]`

* **Alan Adı Tabanlı Açılır Kutu (Combobox) Araması (Yönetici):** Yönetim panellerinde gönderileri, şikayetleri veya log kayıtlarını ID, Sebep, Şikayet Eden veya Durum gibi belirli alanlara göre filtreleyerek kolayca bulmak için gelişmiş arama seçenekleri sunulmaktadır.
`[YÖNETİCİ ARAMA GÖRSELİ İÇİN YER TUTUCU]`
`[LOG YÖNETİMİ GÖRSELİ İÇİN YER TUTUCU]`

#### 4. Analitik ve Dışa Aktarım Süreçleri
* **Görsel İstatistikler (Dashboard):** Yöneticilere Toplam Gönderi, Toplam Şikayet ve Toplam Log Sayısı gibi kilit metrikleri anlık sunan gösterge paneli.
`[İSTATİSTİK (METRİK) GÖRSELİ İÇİN YER TUTUCU]`

* **Belge Oluşturma:**
  * **PDF Raporları:** Gönderiler, şikayetler ve loglar için baskıya hazır idari raporlar oluşturmak amacıyla `QuestPDF` kullanımı.
  * **Excel Tabloları:** Tüm tablo verilerini standart Excel formatlarında dışa aktarmak için `EPPlus` kullanımı.
`[PDF ÇIKTISI GÖRSELİ İÇİN YER TUTUCU]`
`[EXCEL ÇIKTISI GÖRSELİ İÇİN YER TUTUCU]`
