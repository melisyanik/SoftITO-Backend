🎬 Oyun Evreni - N-Tier Architecture & Code First (PROJECT 3)
![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-339933?style=for-the-badge&logo=entity-framework&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

🇬🇧 Read in English | 🇹🇷 Türkçe Dokümantasyon

---

## 🇬🇧 English Documentation

### 🎯 Project Overview
Oyun Evreni (Game Universe) is a comprehensive, N-Tier (Multi-Layered) web application designed to manage the entire lifecycle of digital game sales and content. Built on the robust ASP.NET Core MVC framework with a strictly separated architecture (Data, Model, and Web layers), it serves as a centralized hub for administrators to oversee games, customers, orders, and their associated metadata, while providing a seamless purchasing and library management experience for users.

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
* **Secure Authentication & Login Screen:** A dedicated, fully functional login and registration interface ensuring robust session management, completely integrated with ASP.NET Core Identity.
* **Role-Based Routing:** Smart routing powered by ASP.NET Core Identity. Admins are redirected to the management dashboard upon login, while regular users are routed to their personal game library or the public homepage.
* **Account Administration:** Full lifecycle management of user accounts, enabling users to register, log in, and track their game orders.
* **Admin Management:** Secure backend access specifically for Administrator accounts.
![Login Interface for admins](https://via.placeholder.com/800x450?text=Login+Interface)

#### 2. Public User Experience
* **Interactive Homepage:** A dynamic, user-facing homepage displaying the catalog of available video games, complete with high-quality imagery and pricing.
![Public Homepage and Catalog](https://via.placeholder.com/800x450?text=Public+Homepage)
* **My Games (Oyunlarım) & Order Tracking:** Users can easily buy games. Once approved by an admin, the game appears in their personal digital library. Order statuses are visible via color-coded badges.
![My Games Library](https://via.placeholder.com/800x450?text=My+Games+Library)
* **Field-Based Combobox Search:** Advanced search functionality utilizing a combobox interface. Users can perform granular searches by selecting specific fields (e.g., Game Name, Genre) for accurate results in their library.
![Search Module](https://via.placeholder.com/800x450?text=Search+Module)

#### 3. N-Tier Architecture & Content Engine
* **Multi-Layered Design:** The codebase is separated into `OyunSatinAlma.DATA`, `OyunSatinAlma.MODEL`, and the main Web project, ensuring high scalability and maintainability.
* **Unified Game Catalog:** Relational management of Games, Customers, and Orders using Entity Framework Core.
* **Order Approval System:** Admins can view incoming orders from users and change their status (e.g., Pending, Approved, Rejected).
![Admin Order Management](https://via.placeholder.com/800x450?text=Admin+Order+Management)
* **Field-Based Combobox Search (Admin):** Advanced search filtering is also provided in the admin panels to easily find customers, specific games, or orders by ID and name.

#### 4. Analytics & Export Pipeline
* **Visual Telemetry:** Real-time dashboard providing administrators with key metrics such as Total Games, Total Customers, Total Revenue, and Recent Orders.
![Admin Dashboard](https://via.placeholder.com/800x450?text=Admin+Dashboard)
* **Document Generation:**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for games, customers, and orders.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets (Games, Customers, Orders) into standard Excel formats.
![PDF and Excel Export Interface](https://via.placeholder.com/800x450?text=PDF+and+Excel+Exports)

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
Oyun Evreni, dijital oyun satış ve içerik süreçlerinin tüm yaşam döngüsünü yönetmek için tasarlanmış Çok Katmanlı (N-Tier Architecture) ve kapsamlı bir web uygulamasıdır. Güçlü ASP.NET Core MVC altyapısı üzerine katmanlı (Data, Model, Web) mimariyle inşa edilen bu sistem; yöneticilerin oyunları, müşterileri, siparişleri ve bunlara ait meta verileri merkezi bir noktadan yönetmesini sağlarken, müşteriler için de kesintisiz bir oyun satın alma ve kütüphane deneyimi sunar.

### 🚀 Proje Kapsamı ve Yetenekleri

#### 1. Kimlik Yönetimi ve Yönlendirme
* **Güvenli Kimlik Doğrulama ve Giriş Ekranı:** ASP.NET Core Identity altyapısına tam entegre, güçlü oturum yönetimi sağlayan şık, "Glassmorphism" temalı giriş ve kayıt arayüzü.
* **Rol Tabanlı Yönlendirme:** ASP.NET Core Identity ile desteklenen akıllı yönlendirme. Yöneticiler giriş yaptıklarında yönetim paneline (dashboard) yönlendirilirken, standart kullanıcılar kendi oyun kütüphanelerine veya herkese açık anasayfaya yönlendirilir.
* **Hesap Yönetimi:** Kullanıcı hesaplarının tam yaşam döngüsü yönetimi; kayıt olma, giriş yapma ve sipariş takibi.
* **Yönetici (Admin) Erişimi:** Yalnızca yönetici yetkisine sahip hesaplar için güvenli arka plan paneli erişimi.
![Yöneticiler için giriş arayüzü](https://via.placeholder.com/800x450?text=Giris+Arayuzu)

#### 2. Kullanıcı Arayüzü (Ön Yüz)
* **Etkileşimli Anasayfa:** Mevcut video oyunlarının kataloğunu fiyatlar ve kaliteli görsellerle listeleyen dinamik, kullanıcılara yönelik anasayfa.
![Herkese Açık Anasayfa ve Katalog](https://via.placeholder.com/800x450?text=Anasayfa+ve+Katalog)
* **Oyunlarım & Sipariş Takibi:** Kullanıcılar oyun satın alabilir. Yönetici onayından sonra oyunlar dijital kütüphaneye ("Oyunlarım") eklenir. Siparişlerin güncel statüsü renkli etiketlerle (badge) anlık olarak gösterilir.
![Kullanıcı Kütüphanesi](https://via.placeholder.com/800x450?text=Oyunlarim+Kutuphanesi)
* **Açılır Kutu (Combobox) Tabanlı Arama:** Kullanıcıların kendi kütüphanelerinde Oyun Adı ve Tür bazlı detaylı arama yapabilmesine imkan tanıyan gelişmiş arama modülü.
![Herkese açık anasayfa için arama modülü](https://via.placeholder.com/800x450?text=Arama+Modulu)

#### 3. Çok Katmanlı Mimari ve İçerik Motoru
* **Çok Katmanlı (N-Tier) Yapı:** Kod tabanı `OyunSatinAlma.DATA`, `OyunSatinAlma.MODEL` ve ana web projesi olarak katmanlara ayrılmış olup, yüksek ölçeklenebilirlik ve sürdürülebilirlik sağlar.
* **Bütünleşik Katalog Yönetimi:** Entity Framework Core (Code-First) kullanılarak Oyunlar, Müşteriler ve Siparişlerin ilişkisel yönetimi.
* **Sipariş Onay Sistemi:** Yöneticiler, gelen siparişleri inceleyip durumlarını (Beklemede, Onaylandı vb.) anlık olarak güncelleyebilirler.
![Sipariş Yönetim Ekranı](https://via.placeholder.com/800x450?text=Siparis+Yonetimi)
* **Yönetim Paneli İçi Arama:** Müşterileri, oyunları veya siparişleri ID ve ada göre kolayca bulmak için panellerde sunulan detaylı combobox filtreleme özellikleri.

#### 4. Analitik ve Dışa Aktarım Süreçleri
* **Görsel İstatistikler (Dashboard):** Yöneticilere Toplam Oyun, Toplam Müşteri, Toplam Gelir ve Son Siparişler gibi kilit metrikleri anlık sunan gösterge paneli.
![Yöneticiler için raporlar ve görseller](https://via.placeholder.com/800x450?text=Yonetim+Dashboard)
* **Belge Oluşturma (Export):**
  * **PDF Raporları:** Oyunlar, müşteriler ve siparişler için baskıya hazır, piksel mükemmelliğinde idari raporlar oluşturmak için `QuestPDF` kullanımı.
  * **Excel Tabloları:** Ham veri setlerini (Oyunlar, Müşteriler, Siparişler) standart Excel formatlarında dışa aktarmak için `EPPlus` entegrasyonu.
![Yöneticiler için PDF ve Excel Dışa Aktarım Arayüzü](https://via.placeholder.com/800x450?text=PDF+ve+Excel+Ciktisi)