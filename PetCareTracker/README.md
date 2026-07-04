# 🐾 Pet Care Tracker - API & Stored Procedure Architecture (PROJECT 9)
.NET Dapper Bootstrap License

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-E34F26?style=for-the-badge&logo=dapper&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

[🇺🇸 Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

---

## 🇺🇸 English Documentation

### 🎯 Project Overview
Pet Care Tracker is a comprehensive web application designed to manage the entire lifecycle of veterinary clinics and pet owners. Built on the robust ASP.NET Core MVC framework with a strictly separated architecture (API, Repository, and UI layers), it serves as a centralized hub for managing pets, tracking vaccination schedules, and booking appointments, while providing a seamless tracking experience for users.

API Interface:
<img width="1919" height="629" alt="Ekran görüntüsü 2026-07-05 010428" src="https://github.com/user-attachments/assets/cd1d996e-975a-4a1f-b00b-89c032b2152c" />
<img width="1919" height="847" alt="Ekran görüntüsü 2026-07-05 010439" src="https://github.com/user-attachments/assets/5967e1a8-2cf5-4c26-87ee-7c8f7eb4d8a2" />
<img width="1919" height="493" alt="Ekran görüntüsü 2026-07-05 010455" src="https://github.com/user-attachments/assets/87eab7ea-de0a-461b-abd1-d49b63ac169f" />

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
* **Secure Authentication & Login and Sign Up Screen:** A dedicated, fully functional login and registration interface ensuring robust session management, completely integrated with Cookie Authentication.

Opening page:
<img width="1919" height="906" alt="Ekran görüntüsü 2026-07-05 010729" src="https://github.com/user-attachments/assets/46f80d2b-b279-4534-866c-6a8a931accf4" />

Admin Login and register for users:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 011007" src="https://github.com/user-attachments/assets/951a478b-a3fe-448c-87ce-76f913bb46a1" />

<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-05 011027" src="https://github.com/user-attachments/assets/72063335-d735-4017-b37d-33184d061157" />

* **Role-Based Routing:** Smart routing where users and admins are directed to their respective dashboards based on their privileges.
* **Account Administration:** Full lifecycle management of user accounts, enabling users to register, log in, and track their pets.
* **Admin Management:** Secure backend access specifically for Administrator accounts to oversee the entire system.
<img width="1919" height="910" alt="Admin Dashboard" src="URL_HERE" />

#### 2. User Experience & Pet Management
* **Interactive Dashboard:** A dynamic, user-facing dashboard displaying the summary of pets, upcoming vaccinations, and appointments.
<img width="1919" height="910" alt="User Dashboard" src="URL_HERE" />

* **My Pets & CRUD Operations:** Users can easily add, update, and manage their pets. Complete CRUD functionality is provided for pet records.
<img width="1919" height="908" alt="Pet Listing" src="URL_HERE" />
<img width="1919" height="909" alt="Pet Add/Edit" src="URL_HERE" />

* **Search & Filtering:** Advanced search functionality allowing users to perform granular searches by selecting specific fields (e.g., Pet Name, Species) for accurate results in their library.
<img width="1919" height="912" alt="Search Interface" src="URL_HERE" />

#### 3. Architecture & Data Engine
* **API & Stored Procedure Design:** The codebase is heavily reliant on a Dapper-based Repository pattern communicating with MS SQL Server through highly optimized Stored Procedures.
* **Database Indexing:** B-Tree Indexes on critical columns (UserId, PetId, Dates) to prevent full table scans and maximize query speeds.
* **Unified Healthcare Catalog:** Relational management of Users, Pets, Vaccinations, and Appointments.
* **Vaccination & Appointment System:** Users and Admins can view incoming appointments, track past vaccinations, and see upcoming scheduled tasks.
<img width="1919" height="911" alt="Appointments List" src="URL_HERE" />
<img width="1919" height="907" alt="Vaccinations List" src="URL_HERE" />

#### 4. Analytics & Export Pipeline
* **Visual Telemetry:** Real-time dashboard providing administrators with key metrics such as Total Pets, Total Vaccinations, and Upcoming Appointments.
<img width="1919" height="910" alt="Analytics Dashboard" src="URL_HERE" />

* **Document Generation:**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for pets, vaccinations, and appointments.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets (Pets, Appointments) into standard Excel formats.
<img width="1124" height="358" alt="Excel Export" src="URL_HERE" />
<img width="1108" height="223" alt="PDF Export" src="URL_HERE" />

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
Pet Care Tracker, veteriner klinikleri ve evcil hayvan sahiplerinin tüm süreçlerini yönetmek için tasarlanmış kapsamlı bir web uygulamasıdır. Güçlü ASP.NET Core MVC altyapısı üzerine API ve Repository katmanlarıyla inşa edilen bu sistem; evcil hayvanların yönetilmesini, aşı takvimlerinin izlenmesini ve randevuların organize edilmesini sağlarken, kullanıcılar için de kesintisiz bir takip deneyimi sunar.

### 🚀 Kapsam ve Yetenekler

#### 1. Kimlik Yönetimi ve Yönlendirme
* **Güvenli Kimlik Doğrulama, Giriş ve Kayıt Ekranı:** Cookie tabanlı yetkilendirme altyapısına tam entegre, güçlü oturum yönetimi sağlayan özel ve tam işlevli giriş ve kayıt arayüzü.
<img width="1919" height="910" alt="Giriş Ekranı" src="URL_HERE" />
<img width="1919" height="907" alt="Kayıt Ekranı" src="URL_HERE" />

* **Rol Tabanlı Yönlendirme:** Kullanıcıların ve yöneticilerin yetkilerine göre ilgili panellere yönlendirildiği akıllı yönlendirme sistemi.
* **Hesap Yönetimi:** Kullanıcı hesaplarının tam yaşam döngüsü yönetimi; kullanıcıların kayıt olmalarını, giriş yapmalarını ve kendi hayvanlarını takip etmelerini sağlar.
* **Yönetici Paneli:** Tüm sistemi denetlemek için yalnızca Yönetici hesaplarına özel güvenli arka plan erişimi.
<img width="1919" height="910" alt="Yönetici Paneli" src="URL_HERE" />

#### 2. Kullanıcı Deneyimi ve Evcil Hayvan Yönetimi
* **Etkileşimli Gösterge Paneli (Dashboard):** Evcil hayvan özetlerini, yaklaşan aşıları ve randevuları listeleyen dinamik, kullanıcılara yönelik gösterge paneli.
<img width="1919" height="910" alt="Kullanıcı Paneli" src="URL_HERE" />

* **Evcil Hayvanlarım ve CRUD İşlemleri:** Kullanıcılar evcil hayvanlarını kolayca sisteme ekleyebilir, güncelleyebilir ve yönetebilirler. Tüm kayıtlar için tam kapsamlı CRUD işlevleri sunulmaktadır.
<img width="1919" height="908" alt="Evcil Hayvan Listesi" src="URL_HERE" />
<img width="1919" height="909" alt="Hayvan Ekle/Düzenle" src="URL_HERE" />

* **Arama ve Filtreleme:** Kullanıcıların doğru sonuçlar elde etmek için belirli alanları (örn. Hayvan Adı, Türü) seçerek detaylı aramalar yapabilmesini sağlayan gelişmiş arama işlevi.
<img width="1919" height="912" alt="Arama Arayüzü" src="URL_HERE" />

#### 3. Mimari ve Veri Motoru
* **API ve Stored Procedure (SP) Mimarisi:** Kod tabanı, MS SQL Server ile yüksek oranda optimize edilmiş Stored Procedure'ler aracılığıyla haberleşen Dapper tabanlı Repository desenine dayanmaktadır.
* **Veritabanı İndeksleme (Indexing):** Tam tablo taramalarını (Table Scan) önlemek ve sorgu hızlarını maksimuma çıkarmak için kritik kolonlarda (UserId, PetId, Tarihler vb.) B-Tree İndeks yapıları kullanıldı.
* **Bütünleşik Sağlık Kataloğu:** Kullanıcılar, Evcil Hayvanlar, Aşılar ve Randevuların ilişkisel yönetimi.
* **Aşı ve Randevu Sistemi:** Kullanıcılar ve yöneticiler, yaklaşan randevuları görebilir, geçmiş aşıları takip edebilir ve planlanmış görevleri izleyebilirler.
<img width="1919" height="911" alt="Randevu Listesi" src="URL_HERE" />
<img width="1919" height="907" alt="Aşı Listesi" src="URL_HERE" />

#### 4. Analitik ve Dışa Aktarım Süreçleri
* **Görsel İstatistikler (Dashboard):** Yöneticilere Toplam Hayvan, Toplam Aşı ve Yaklaşan Randevular gibi kilit metrikleri anlık sunan gösterge paneli.
<img width="1919" height="910" alt="Analitik Dashboard" src="URL_HERE" />

* **Belge Oluşturma:**
  * **PDF Raporları:** Hayvanlar, aşılar ve randevular için baskıya hazır, piksel mükemmelliğinde raporlar oluşturmak için `QuestPDF` kullanımı.
  * **Excel Tabloları:** Ham veri setlerini (Evcil Hayvanlar, Randevular) standart Excel formatlarında dışa aktarmak için `EPPlus` kullanımı.
<img width="1124" height="358" alt="Excel Çıktısı" src="URL_HERE" />
<img width="1108" height="223" alt="PDF Çıktısı" src="URL_HERE" />
