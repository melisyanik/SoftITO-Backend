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
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 035548" src="https://github.com/user-attachments/assets/feddf7a6-c40e-4d80-ac71-88d1f572bf97" />

#### 2. Public User Experience
* **Interactive Homepage:** A dynamic, user-facing homepage displaying a feed of available posts. Users can create new posts directly from the homepage.
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-04 035114" src="https://github.com/user-attachments/assets/e2cba380-81ba-4cd5-8ac0-dfef9d857bb4" />

Adding a new post:
<img width="1919" height="916" alt="Ekran görüntüsü 2026-07-04 035252" src="https://github.com/user-attachments/assets/92154f29-c668-46a9-9c87-177eb6210098" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 035303" src="https://github.com/user-attachments/assets/177d8a36-4c8d-47e3-b646-e7a31c734502" />

* **Search Functionality:** Users can easily search through posts using keywords (e.g., Title, Content, Tag, Author) to quickly find relevant content.
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-04 035127" src="https://github.com/user-attachments/assets/5e3a4fb8-06b7-49ad-a379-2e79b6fe4560" />
<img width="1919" height="916" alt="Ekran görüntüsü 2026-07-04 035150" src="https://github.com/user-attachments/assets/100311de-2831-4486-b23c-08a1e493e259" />

* **Content Reporting System:** Users can report inappropriate posts by submitting complaints with specific reasons, ensuring a safe community environment.

Post reporting:
<img width="1919" height="849" alt="Ekran görüntüsü 2026-07-04 035338" src="https://github.com/user-attachments/assets/d9b7c352-a2d8-483e-b443-27bba3fd232c" />
<img width="1919" height="724" alt="Ekran görüntüsü 2026-07-04 035350" src="https://github.com/user-attachments/assets/d0faa0cf-bcf9-4bfa-b389-8b8830c85bc1" />

Reporting for another reasons:
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-04 035413" src="https://github.com/user-attachments/assets/74bfa059-789b-4ee4-afce-7ce1af3cff66" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 035428" src="https://github.com/user-attachments/assets/334dc746-d6fc-4c0f-a445-76ce80d86ca7" />


#### 3. Content Engine & Admin Management
* **Comprehensive CRUD Operations:** Full lifecycle management (Create, Read, Update, Delete) for Posts, Complaints, and Activity Logs.
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-04 035622" src="https://github.com/user-attachments/assets/0abf4ff8-4795-44f3-9b60-bb7e350af5a4" />

* **Complaint Resolution System:** Admins can view incoming reports from users and toggle their resolution status (e.g., Pending, Resolved).
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 035654" src="https://github.com/user-attachments/assets/087f7dea-c3ed-4ef2-8b45-9fcfaf4b3889" />

* **Field-Based Combobox Search (Admin):** Advanced search filtering is provided in the admin panels to easily find specific posts, complaints, or activity logs by selecting fields such as ID, Reason, Reporter, or Status.
<img width="1919" height="906" alt="Ekran görüntüsü 2026-07-04 035710" src="https://github.com/user-attachments/assets/889c2e1f-edc1-4e38-89e3-11473326e19d" />
<img width="1919" height="905" alt="Ekran görüntüsü 2026-07-04 035747" src="https://github.com/user-attachments/assets/df214146-6e4e-49a3-b891-4661523b0230" />

#### 4. Analytics & Export Pipeline
* **Visual Telemetry:** Real-time dashboard providing administrators with key metrics such as Total Posts, Total Complaints, and Total Logs.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 035557" src="https://github.com/user-attachments/assets/ad1d28aa-7d8f-4fe4-9ddb-1527ca6535a9" />

* **Document Generation:**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for Posts, Complaints, and Activity Logs.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets into standard Excel formats.
<img width="1065" height="457" alt="Ekran görüntüsü 2026-07-04 035800" src="https://github.com/user-attachments/assets/32fd144f-69d6-4da9-b4cd-bae1bb4d4f04" />
<img width="780" height="220" alt="Ekran görüntüsü 2026-07-04 035853" src="https://github.com/user-attachments/assets/840fc918-8ad3-46af-9844-d257a4db80ba" />
<img width="1068" height="443" alt="Ekran görüntüsü 2026-07-04 035812" src="https://github.com/user-attachments/assets/8874df7a-90e4-42dc-bcb5-39271c12762e" />
<img width="769" height="229" alt="Ekran görüntüsü 2026-07-04 035831" src="https://github.com/user-attachments/assets/400b477f-f54c-4baa-b188-60f2d6fa07df" />


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
