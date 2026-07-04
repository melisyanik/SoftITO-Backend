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
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-05 013138" src="https://github.com/user-attachments/assets/1acd4616-d58d-40b3-b7ea-71071765725c" />

<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-05 013127" src="https://github.com/user-attachments/assets/b5e372ce-0e0b-4275-b824-3ffee4345cb4" />

Admin can change the status of the appointment:
<img width="1919" height="915" alt="Ekran görüntüsü 2026-07-05 013155" src="https://github.com/user-attachments/assets/4c1281d8-78b4-4b0f-9784-2e180e0bfa3c" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 013207" src="https://github.com/user-attachments/assets/e9ab98bb-e555-43e3-be61-c5315eeffed9" />

Adding new patient:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 013253" src="https://github.com/user-attachments/assets/1eb76526-a504-4a6f-8a33-f225a240b909" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 013301" src="https://github.com/user-attachments/assets/07a71c76-63ac-44c2-810b-e0ab9ef0d326" />



* **Search & Filtering:** Advanced search functionality allowing admin to perform granular searches by selecting specific fields (e.g., Pet Name, Species) for accurate results in their library.
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-05 021115" src="https://github.com/user-attachments/assets/6b3ee11a-6efe-4bbf-9050-ab7c90396f9a" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 021127" src="https://github.com/user-attachments/assets/c96bf06e-c412-4cfc-83e9-facb65914a79" />


#### 2. User Experience & Pet Management

* **Vaccination & Appointment Management:** Users can easily schedule new appointments, add vaccination records for their pets, and seamlessly track upcoming dates and medical history.

Arranging an appointment:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 011059" src="https://github.com/user-attachments/assets/b76a67cb-7980-4858-b541-6c628ac5ebe6" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-05 011232" src="https://github.com/user-attachments/assets/3b5e68a3-29bf-4056-b9b7-a8fb17eb5826" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-05 011242" src="https://github.com/user-attachments/assets/56eda092-a61e-4ed6-b3e8-96de7e5bd624" />

Arranging vaccination recod:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 011254" src="https://github.com/user-attachments/assets/6f853c16-58fb-421c-9f36-08813a840e39" />
<img width="1919" height="906" alt="Ekran görüntüsü 2026-07-05 011337" src="https://github.com/user-attachments/assets/5ad3822f-6633-495f-9851-3d0f8eb77589" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 011346" src="https://github.com/user-attachments/assets/6cbcc3af-67a0-4e3d-af45-7f11efcecbc7" />

Following the status of appointments:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-05 013613" src="https://github.com/user-attachments/assets/1f2be0b3-d1e3-4f31-8236-49c6b401a639" />


#### 3. Architecture & Data Engine
* **API & Stored Procedure Design:** The codebase is heavily reliant on a Dapper-based Repository pattern communicating with MS SQL Server through highly optimized Stored Procedures.
* **Database Indexing:** B-Tree Indexes on critical columns (UserId, PetId, Dates) to prevent full table scans and maximize query speeds.
* **Unified Healthcare Catalog:** Relational management of Users, Pets, Vaccinations, and Appointments.

#### 4. Analytics & Export Pipeline
* **Document Generation:**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for pets, vaccinations, and appointments.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets (Pets, Appointments) into standard Excel formats.

PDF Generation:
<img width="1036" height="258" alt="Ekran görüntüsü 2026-07-05 013504" src="https://github.com/user-attachments/assets/461d0611-bf88-48bd-bd00-99364b93b1de" />


Excel Generation:
<img width="612" height="128" alt="Ekran görüntüsü 2026-07-05 013526" src="https://github.com/user-attachments/assets/d0745eb3-839a-4fd3-b1bf-6edc9d9c4a5b" />


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

* **Aşı ve Randevu Yönetimi:** Kullanıcılar kendi hayvanları için yeni aşı kayıtları oluşturabilir, veteriner randevuları ayarlayabilir ve yaklaşan aşı takvimlerini eksiksiz şekilde yönetebilirler.
<img width="1919" height="911" alt="Randevu Listesi" src="URL_HERE" />
<img width="1919" height="907" alt="Aşı Listesi" src="URL_HERE" />

#### 3. Mimari ve Veri Motoru
* **API ve Stored Procedure (SP) Mimarisi:** Kod tabanı, MS SQL Server ile yüksek oranda optimize edilmiş Stored Procedure'ler aracılığıyla haberleşen Dapper tabanlı Repository desenine dayanmaktadır.
* **Veritabanı İndeksleme (Indexing):** Tam tablo taramalarını (Table Scan) önlemek ve sorgu hızlarını maksimuma çıkarmak için kritik kolonlarda (UserId, PetId, Tarihler vb.) B-Tree İndeks yapıları kullanıldı.
* **Bütünleşik Sağlık Kataloğu:** Kullanıcılar, Evcil Hayvanlar, Aşılar ve Randevuların ilişkisel yönetimi.

#### 4. Analitik ve Dışa Aktarım Süreçleri
* **Görsel İstatistikler (Dashboard):** Yöneticilere Toplam Hayvan, Toplam Aşı ve Yaklaşan Randevular gibi kilit metrikleri anlık sunan gösterge paneli.
<img width="1919" height="910" alt="Analitik Dashboard" src="URL_HERE" />

* **Belge Oluşturma:**
  * **PDF Raporları:** Hayvanlar, aşılar ve randevular için baskıya hazır, piksel mükemmelliğinde raporlar oluşturmak için `QuestPDF` kullanımı.
  * **Excel Tabloları:** Ham veri setlerini (Evcil Hayvanlar, Randevular) standart Excel formatlarında dışa aktarmak için `EPPlus` kullanımı.
<img width="1124" height="358" alt="Excel Çıktısı" src="URL_HERE" />
<img width="1108" height="223" alt="PDF Çıktısı" src="URL_HERE" />
