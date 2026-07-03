🎬 Oyun Evreni - N-Tier Architecture & Code First (PROJECT 3)
.NET Entity Framework Bootstrap License

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-339933?style=for-the-badge&logo=entity-framework&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

[Read in English](#-english-documentation) | [Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

---

## 🇺🇸 English Documentation

### 🎯 Project Overview
Oyun Evreni (Game Universe) is a comprehensive, N-Tier (Multi-Layered) web application designed to manage the entire lifecycle of digital game sales and content. Built on the robust ASP.NET Core MVC framework with a strictly separated architecture (Data, Model, and Web layers), it serves as a centralized hub for administrators to oversee games, customers, orders, and their associated metadata, while providing a seamless purchasing and library management experience for users.

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
* **Secure Authentication & Login and Sign Up Screen:** A dedicated, fully functional login and registration interface ensuring robust session management, completely integrated with ASP.NET Core Identity.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 011323" src="https://github.com/user-attachments/assets/d7129792-392a-4f43-a28d-17c0fa6e8f07" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 011444" src="https://github.com/user-attachments/assets/e9e9b6a8-9285-4e4a-a189-2ac2f861a0ec" />

* **Role-Based Routing:** Smart routing powered by ASP.NET Core Identity. Admins are redirected to the management dashboard upon login, while regular users are routed to their personal game library or the public homepage.
* **Account Administration:** Full lifecycle management of user accounts, enabling users to register, log in, and track their game orders.
* **Admin Management:** Secure backend access specifically for Administrator accounts.
Admin interface:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 012920" src="https://github.com/user-attachments/assets/df137767-2fa7-4480-b044-0522f5a578c3" />

#### 2. Public User Experience
* **Interactive Homepage:** A dynamic, user-facing homepage displaying the catalog of available video games, complete with high-quality imagery and pricing.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 011457" src="https://github.com/user-attachments/assets/30d99da5-07ff-40f3-b76f-a6f84fd1d41e" />

* **My Games (Oyunlarım) & Order Tracking:** Users can easily buy games. Once approved by an admin, the game appears in their personal digital library. Order statuses are visible via color-coded badges.
First, ordering game for the user:
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 011520" src="https://github.com/user-attachments/assets/f593ec3d-bb44-4ff9-a809-48e363756bb5" />
Users can check their purchase history and states:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 011529" src="https://github.com/user-attachments/assets/4aca5f02-e364-4dd2-9d6e-29310bdf29f6" />
When the user checks if it is approved or not, they can see the difference:
<img width="1919" height="708" alt="Ekran görüntüsü 2026-07-04 013423" src="https://github.com/user-attachments/assets/5e4e6c14-e0d9-4853-85a7-ef20112cdbd4" />

* **Field-Based Combobox Search:** Advanced search functionality utilizing a combobox interface. Users can perform granular searches by selecting specific fields (e.g., Game Name, Genre) for accurate results in their library.
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 012816" src="https://github.com/user-attachments/assets/0ba1a56b-abae-414b-8156-9be8427d66bc" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 012834" src="https://github.com/user-attachments/assets/647760fe-cc5e-4a5a-aafa-1503cb65f877" />

#### 3. N-Tier Architecture & Content Engine
* **Multi-Layered Design:** The codebase is separated into `OyunSatinAlma.DATA`, `OyunSatinAlma.MODEL`, and the main Web project, ensuring high scalability and maintainability.
* **Unified Game Catalog:** Relational management of Games, Customers, and Orders using Entity Framework Core.
* **Order Approval System:** Admins can view incoming orders from users and change their status (e.g., Pending, Approved, Rejected).
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 012920" src="https://github.com/user-attachments/assets/b7f48406-d18f-4e44-8805-0d59d737048b" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 013028" src="https://github.com/user-attachments/assets/c78ea1d0-3dc7-490a-8825-ab75ab2aa45c" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 013039" src="https://github.com/user-attachments/assets/89a0cb23-03d5-49b6-9754-d3dc9dc1a325" />
<img width="1919" height="611" alt="Ekran görüntüsü 2026-07-04 013251" src="https://github.com/user-attachments/assets/da039a47-2af3-4269-9409-42298b472027" />
<img width="1919" height="583" alt="Ekran görüntüsü 2026-07-04 013355" src="https://github.com/user-attachments/assets/e51a07df-91ab-4362-8453-f5c672f7e480" />
* **Field-Based Combobox Search (Admin):** Advanced search filtering is also provided in the admin panels to easily find customers, specific games, or orders by ID and name.
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 012736" src="https://github.com/user-attachments/assets/f1b6d3ac-3e6e-4928-9f4c-126587c56800" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 012944" src="https://github.com/user-attachments/assets/80833501-58c2-4cf1-acb3-d0846aa01f2d" />

#### 4. Analytics & Export Pipeline
* **Visual Telemetry:** Real-time dashboard providing administrators with key metrics such as Total Games, Total Customers, Total Revenue, and Recent Orders.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 013106" src="https://github.com/user-attachments/assets/6a41b0b9-1b2b-40a1-a98d-6c2b25ebd9b8" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 013115" src="https://github.com/user-attachments/assets/bd5e286d-7bf7-4621-a28d-10f9c9f8c93c" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 013127" src="https://github.com/user-attachments/assets/14bc6df7-a7ea-4006-9a99-ffcbc098cce4" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 013135" src="https://github.com/user-attachments/assets/ce366d06-0ec9-4080-8395-4072b59ea969" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 013146" src="https://github.com/user-attachments/assets/a65c2cc7-179a-4e4b-af60-206877923db0" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 013159" src="https://github.com/user-attachments/assets/744a0b02-58b4-46b7-859a-9afb141cf8f4" />

* **Document Generation:**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for games, customers, and orders.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets (Games, Customers, Orders) into standard Excel formats.
<img width="1124" height="358" alt="Ekran görüntüsü 2026-07-04 013220" src="https://github.com/user-attachments/assets/d7fb2478-67b8-4057-8ec7-6ec0f6d4d4bf" />
<img width="488" height="134" alt="Ekran görüntüsü 2026-07-04 013236" src="https://github.com/user-attachments/assets/8fada9eb-513c-4e02-adc6-a06e0f4015d6" />
<img width="1108" height="223" alt="Ekran görüntüsü 2026-07-04 015222" src="https://github.com/user-attachments/assets/760465f5-c0e2-4ecc-9aaf-22641a96bc1d" />
<img width="834" height="114" alt="Ekran görüntüsü 2026-07-04 015242" src="https://github.com/user-attachments/assets/e70b0a3d-7604-4813-88be-2e90f448dd09" />

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
Oyun Evreni (Game Universe), dijital oyun satış ve içerik süreçlerinin tüm yaşam döngüsünü yönetmek için tasarlanmış kapsamlı, Çok Katmanlı (N-Tier) bir web uygulamasıdır. Güçlü ASP.NET Core MVC altyapısı üzerine kesin hatlarla ayrılmış katmanlı mimariyle (Veri, Model ve Web katmanları) inşa edilen bu sistem; yöneticilerin oyunları, müşterileri, siparişleri ve bunlara ait meta verileri merkezi bir noktadan yönetmesini sağlarken, kullanıcılar için de kesintisiz bir satın alma ve kütüphane yönetimi deneyimi sunar.

### 🚀 Kapsam ve Yetenekler

#### 1. Kimlik Yönetimi ve Yönlendirme
* **Güvenli Kimlik Doğrulama, Giriş ve Kayıt Ekranı:** ASP.NET Core Identity altyapısına tam entegre, güçlü oturum yönetimi sağlayan özel ve tam işlevli giriş ve kayıt arayüzü.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 011323" src="https://github.com/user-attachments/assets/d7129792-392a-4f43-a28d-17c0fa6e8f07" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 011444" src="https://github.com/user-attachments/assets/e9e9b6a8-9285-4e4a-a189-2ac2f861a0ec" />

* **Rol Tabanlı Yönlendirme:** ASP.NET Core Identity ile desteklenen akıllı yönlendirme. Yöneticiler giriş yaptıklarında yönetim paneline yönlendirilirken, standart kullanıcılar kendi oyun kütüphanelerine veya herkese açık anasayfaya yönlendirilir.
* **Hesap Yönetimi:** Kullanıcı hesaplarının tam yaşam döngüsü yönetimi; kullanıcıların kayıt olmalarını, giriş yapmalarını ve oyun siparişlerini takip etmelerini sağlar.
* **Yönetici Yönetimi:** Yalnızca Yönetici hesapları için güvenli arka plan erişimi.
Yönetici arayüzü:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 012920" src="https://github.com/user-attachments/assets/df137767-2fa7-4480-b044-0522f5a578c3" />

#### 2. Herkese Açık Kullanıcı Deneyimi
* **Etkileşimli Anasayfa:** Mevcut video oyunlarının kataloğunu fiyatlar ve yüksek kaliteli görsellerle listeleyen dinamik, kullanıcılara yönelik anasayfa.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 011457" src="https://github.com/user-attachments/assets/30d99da5-07ff-40f3-b76f-a6f84fd1d41e" />

* **Oyunlarım & Sipariş Takibi:** Kullanıcılar kolayca oyun satın alabilir. Bir yönetici tarafından onaylandıktan sonra oyunlar kişisel dijital kütüphanelerinde görünür. Sipariş durumları renk kodlu etiketlerle görünür haldedir.
İlk olarak, kullanıcı için oyun sipariş etme:
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 011520" src="https://github.com/user-attachments/assets/f593ec3d-bb44-4ff9-a809-48e363756bb5" />
Kullanıcılar satın alma geçmişlerini ve durumlarını kontrol edebilirler:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 011529" src="https://github.com/user-attachments/assets/4aca5f02-e364-4dd2-9d6e-29310bdf29f6" />
Kullanıcı onaylanıp onaylanmadığını kontrol ettiğinde, farkı görebilir:
<img width="1919" height="708" alt="Ekran görüntüsü 2026-07-04 013423" src="https://github.com/user-attachments/assets/5e4e6c14-e0d9-4853-85a7-ef20112cdbd4" />

* **Alan Adı Tabanlı Açılır Kutu (Combobox) Araması:** Bir açılır kutu arayüzü kullanan gelişmiş arama işlevi. Kullanıcılar kütüphanelerinde doğru sonuçlar elde etmek için belirli alanları (örn. Oyun Adı, Tür) seçerek detaylı aramalar yapabilirler.
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 012816" src="https://github.com/user-attachments/assets/0ba1a56b-abae-414b-8156-9be8427d66bc" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 012834" src="https://github.com/user-attachments/assets/647760fe-cc5e-4a5a-aafa-1503cb65f877" />

#### 3. Çok Katmanlı Mimari ve İçerik Motoru
* **Çok Katmanlı (N-Tier) Yapı:** Kod tabanı `OyunSatinAlma.DATA`, `OyunSatinAlma.MODEL` ve ana Web projesi olarak katmanlara ayrılmış olup, yüksek ölçeklenebilirlik ve sürdürülebilirlik sağlar.
* **Bütünleşik Katalog Yönetimi:** Entity Framework Core kullanılarak Oyunlar, Müşteriler ve Siparişlerin ilişkisel yönetimi.
* **Sipariş Onay Sistemi:** Yöneticiler, kullanıcılardan gelen siparişleri görüntüleyebilir ve durumlarını (örn. Beklemede, Onaylandı, Reddedildi) değiştirebilirler.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 012920" src="https://github.com/user-attachments/assets/b7f48406-d18f-4e44-8805-0d59d737048b" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 013028" src="https://github.com/user-attachments/assets/c78ea1d0-3dc7-490a-8825-ab75ab2aa45c" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 013039" src="https://github.com/user-attachments/assets/89a0cb23-03d5-49b6-9754-d3dc9dc1a325" />
<img width="1919" height="611" alt="Ekran görüntüsü 2026-07-04 013251" src="https://github.com/user-attachments/assets/da039a47-2af3-4269-9409-42298b472027" />
<img width="1919" height="583" alt="Ekran görüntüsü 2026-07-04 013355" src="https://github.com/user-attachments/assets/e51a07df-91ab-4362-8453-f5c672f7e480" />
* **Alan Adı Tabanlı Açılır Kutu (Combobox) Araması (Yönetici):** Yönetim panellerinde de, müşterileri, belirli oyunları veya siparişleri ID ve ada göre kolayca bulmak için gelişmiş arama filtrelemesi sağlanmaktadır.
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 012736" src="https://github.com/user-attachments/assets/f1b6d3ac-3e6e-4928-9f4c-126587c56800" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 012944" src="https://github.com/user-attachments/assets/80833501-58c2-4cf1-acb3-d0846aa01f2d" />

#### 4. Analitik ve Dışa Aktarım Süreçleri
* **Görsel İstatistikler (Dashboard):** Yöneticilere Toplam Oyun, Toplam Müşteri, Toplam Gelir ve Son Siparişler gibi kilit metrikleri anlık sunan gösterge paneli.
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 013106" src="https://github.com/user-attachments/assets/6a41b0b9-1b2b-40a1-a98d-6c2b25ebd9b8" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 013115" src="https://github.com/user-attachments/assets/bd5e286d-7bf7-4621-a28d-10f9c9f8c93c" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 013127" src="https://github.com/user-attachments/assets/14bc6df7-a7ea-4006-9a99-ffcbc098cce4" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 013135" src="https://github.com/user-attachments/assets/ce366d06-0ec9-4080-8395-4072b59ea969" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 013146" src="https://github.com/user-attachments/assets/a65c2cc7-179a-4e4b-af60-206877923db0" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 013159" src="https://github.com/user-attachments/assets/744a0b02-58b4-46b7-859a-9afb141cf8f4" />

* **Belge Oluşturma:**
  * **PDF Raporları:** Oyunlar, müşteriler ve siparişler için baskıya hazır, piksel mükemmelliğinde idari raporlar oluşturmak için `QuestPDF` kullanımı.
  * **Excel Tabloları:** Ham veri setlerini (Oyunlar, Müşteriler, Siparişler) standart Excel formatlarında dışa aktarmak için `EPPlus` kullanımı.
<img width="1124" height="358" alt="Ekran görüntüsü 2026-07-04 013220" src="https://github.com/user-attachments/assets/d7fb2478-67b8-4057-8ec7-6ec0f6d4d4bf" />
<img width="488" height="134" alt="Ekran görüntüsü 2026-07-04 013236" src="https://github.com/user-attachments/assets/8fada9eb-513c-4e02-adc6-a06e0f4015d6" />
<img width="1108" height="223" alt="Ekran görüntüsü 2026-07-04 015222" src="https://github.com/user-attachments/assets/760465f5-c0e2-4ecc-9aaf-22641a96bc1d" />
<img width="834" height="114" alt="Ekran görüntüsü 2026-07-04 015242" src="https://github.com/user-attachments/assets/e70b0a3d-7604-4813-88be-2e90f448dd09" />
