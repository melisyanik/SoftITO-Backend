🎓 EduMaster - N-Tier Architecture & Code First (LMS Project)
.NET Entity Framework Bootstrap License

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-339933?style=for-the-badge&logo=entity-framework&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Serilog](https://img.shields.io/badge/Serilog-F46513?style=for-the-badge&logo=serilog&logoColor=white)

[🇺🇸 Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

---

## 🇺🇸 English Documentation

### 🎯 Project Overview
EduMaster is a comprehensive, N-Tier (Multi-Layered) Learning Management System (LMS) designed to manage the entire lifecycle of digital courses, enrollments, and educational content. Built on the robust ASP.NET Core MVC framework with a strictly separated architecture (Data, Models, and Web layers), it serves as a centralized hub for administrators to oversee courses, instructors, categories, and student enrollments, while providing an interactive learning catalog and community experience for students.

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
* **Secure Authentication, Login and Sign Up Screen:** A dedicated, fully functional login and registration interface ensuring robust session management, completely integrated with ASP.NET Core Identity.
<!-- PLACEHOLDER: Login/Register Screenshot -->
<img width="1919" height="910" alt="Login Screen Screenshot Placeholder" src="https://via.placeholder.com/1919x910.png?text=Login+Screen" />
<img width="1919" height="907" alt="Register Screen Screenshot Placeholder" src="https://via.placeholder.com/1919x907.png?text=Register+Screen" />

* **Role-Based Routing:** Smart routing powered by ASP.NET Core Identity. Admins are redirected to the management dashboard upon login, while regular users are routed to the public homepage and their enrolled courses.
* **Account Administration:** Full lifecycle management of user accounts, enabling users to register, log in, and track their course enrollments.
* **Admin Management:** Secure backend access specifically for Administrator accounts.
<!-- PLACEHOLDER: Admin Dashboard Screenshot -->
<img width="1919" height="910" alt="Admin Dashboard Screenshot Placeholder" src="https://via.placeholder.com/1919x910.png?text=Admin+Dashboard" />

#### 2. Public User Experience
* **Interactive Homepage (Course Catalog):** A dynamic, user-facing homepage displaying the catalog of available educational courses, complete with high-quality imagery, instructor details, and categories.
<!-- PLACEHOLDER: Homepage / Course Catalog Screenshot -->
<img width="1919" height="910" alt="Homepage Screenshot Placeholder" src="https://via.placeholder.com/1919x910.png?text=Interactive+Homepage" />

* **Course Enrollment & Quota Management:** Users can easily enroll in courses. The system automatically tracks the total enrolled count against the course's maximum quota. If a course is full, enrollments are prevented.
<!-- PLACEHOLDER: Course Detail & Enrollment Screenshot -->
<img width="1919" height="908" alt="Course Enrollment Placeholder" src="https://via.placeholder.com/1919x908.png?text=Course+Detail+%26+Enrollment" />
<!-- PLACEHOLDER: Course Quota Full Screenshot -->
<img width="1919" height="708" alt="Quota Full Placeholder" src="https://via.placeholder.com/1919x708.png?text=Quota+Full+Warning" />

* **Community Comments:** Students can leave reviews and comments on course pages, and manage (edit/delete) their own comments.
<!-- PLACEHOLDER: Course Comments Screenshot -->
<img width="1919" height="912" alt="Comments Section Placeholder" src="https://via.placeholder.com/1919x912.png?text=Course+Comments+Section" />

#### 3. N-Tier Architecture & Content Engine
* **Multi-Layered Design:** The codebase is strictly separated into `EduMaster.Data`, `EduMaster.Models`, and the main `EduMaster` Web project, utilizing the Repository Pattern and Unit of Work for high scalability and maintainability.
* **Unified LMS Catalog:** Relational management of Courses, Categories, Instructors, and Enrollments using Entity Framework Core.
* **Advanced Admin Controls:** Admins have full CRUP (Create, Read, Update, Delete) access over the entire catalog. Includes image uploading features for course thumbnails and instructor profiles with unique GUID naming.
<!-- PLACEHOLDER: Course CRUP Screenshot -->
<img width="1919" height="911" alt="Course CRUP Placeholder" src="https://via.placeholder.com/1919x911.png?text=Course+Creation/Edit" />
<!-- PLACEHOLDER: Instructor Management Screenshot -->
<img width="1919" height="907" alt="Instructor Management Placeholder" src="https://via.placeholder.com/1919x907.png?text=Instructor+Management" />
<!-- PLACEHOLDER: Category Management Screenshot -->
<img width="1919" height="611" alt="Category Management Placeholder" src="https://via.placeholder.com/1919x611.png?text=Category+Management" />

#### 4. Analytics & Export Pipeline
* **Document Generation (PDF & Excel):**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for the entire course catalog, including quotas and instructor assignments.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets (Courses, Enrollments) into standard Excel formats for deep data analysis.
<!-- PLACEHOLDER: PDF Export Screenshot -->
<img width="1124" height="358" alt="PDF Export Placeholder" src="https://via.placeholder.com/1124x358.png?text=QuestPDF+Export+Example" />
<!-- PLACEHOLDER: Excel Export Screenshot -->
<img width="1108" height="223" alt="Excel Export Placeholder" src="https://via.placeholder.com/1108x223.png?text=EPPlus+Excel+Export+Example" />

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
EduMaster, dijital kursların, kayıtların ve eğitim içeriklerinin tüm yaşam döngüsünü yönetmek için tasarlanmış kapsamlı, Çok Katmanlı (N-Tier) bir Öğrenim Yönetim Sistemidir (LMS). Güçlü ASP.NET Core MVC altyapısı üzerine kesin hatlarla ayrılmış katmanlı mimariyle (Veri, Model ve Web katmanları) inşa edilen bu sistem; yöneticilerin kursları, eğitmenleri, kategorileri ve öğrenci kayıtlarını merkezi bir noktadan yönetmesini sağlarken, öğrenciler için de etkileşimli bir kurs kataloğu ve topluluk deneyimi sunar.

### 🚀 Kapsam ve Yetenekler

#### 1. Kimlik Yönetimi ve Yönlendirme
* **Güvenli Kimlik Doğrulama, Giriş ve Kayıt Ekranı:** ASP.NET Core Identity altyapısına tam entegre, güçlü oturum yönetimi sağlayan özel ve tam işlevli giriş ve kayıt arayüzü.
<!-- PLACEHOLDER: Login/Register Screenshot -->
<img width="1919" height="910" alt="Login Screen Screenshot Placeholder" src="https://via.placeholder.com/1919x910.png?text=Login+Screen" />
<img width="1919" height="907" alt="Register Screen Screenshot Placeholder" src="https://via.placeholder.com/1919x907.png?text=Register+Screen" />

* **Rol Tabanlı Yönlendirme:** ASP.NET Core Identity ile desteklenen akıllı yönlendirme. Yöneticiler giriş yaptıklarında yönetim paneline yönlendirilirken, standart kullanıcılar herkese açık anasayfaya ve kayıtlı oldukları kurslara yönlendirilir.
* **Hesap Yönetimi:** Kullanıcı hesaplarının tam yaşam döngüsü yönetimi; kullanıcıların kayıt olmalarını, giriş yapmalarını ve kurs kayıtlarını takip etmelerini sağlar.
* **Yönetici Yönetimi:** Yalnızca Yönetici hesapları için güvenli arka plan erişimi.
<!-- PLACEHOLDER: Admin Dashboard Screenshot -->
<img width="1919" height="910" alt="Admin Dashboard Screenshot Placeholder" src="https://via.placeholder.com/1919x910.png?text=Admin+Dashboard" />

#### 2. Herkese Açık Kullanıcı Deneyimi
* **Etkileşimli Anasayfa (Kurs Kataloğu):** Mevcut eğitim kurslarının kataloğunu yüksek kaliteli görseller, eğitmen detayları ve kategorilerle listeleyen dinamik, kullanıcılara yönelik anasayfa.
<!-- PLACEHOLDER: Homepage / Course Catalog Screenshot -->
<img width="1919" height="910" alt="Homepage Screenshot Placeholder" src="https://via.placeholder.com/1919x910.png?text=Interactive+Homepage" />

* **Kurs Kaydı ve Kontenjan Yönetimi:** Kullanıcılar kurslara kolayca kayıt olabilir. Sistem, kursun maksimum kontenjanına karşı toplam kayıtlı kişi sayısını otomatik olarak takip eder. Bir kurs tamamen dolduğunda yeni kayıtlar otomatik olarak engellenir.
<!-- PLACEHOLDER: Course Detail & Enrollment Screenshot -->
<img width="1919" height="908" alt="Course Enrollment Placeholder" src="https://via.placeholder.com/1919x908.png?text=Course+Detail+%26+Enrollment" />
<!-- PLACEHOLDER: Course Quota Full Screenshot -->
<img width="1919" height="708" alt="Quota Full Placeholder" src="https://via.placeholder.com/1919x708.png?text=Quota+Full+Warning" />

* **Topluluk Yorumları:** Öğrenciler kurs sayfalarında değerlendirmeler ve yorumlar bırakabilir, kendi yorumlarını yönetebilir (düzenle/sil).
<!-- PLACEHOLDER: Course Comments Screenshot -->
<img width="1919" height="912" alt="Comments Section Placeholder" src="https://via.placeholder.com/1919x912.png?text=Course+Comments+Section" />

#### 3. Çok Katmanlı Mimari ve İçerik Motoru
* **Çok Katmanlı (N-Tier) Yapı:** Kod tabanı `EduMaster.Data`, `EduMaster.Models` ve ana `EduMaster` Web projesi olarak katmanlara ayrılmış olup, yüksek ölçeklenebilirlik ve sürdürülebilirlik için Repository Pattern ve Unit of Work yapısı kullanılmıştır.
* **Bütünleşik LMS Kataloğu:** Entity Framework Core kullanılarak Kurslar, Kategoriler, Eğitmenler ve Kayıtların ilişkisel yönetimi.
* **Gelişmiş Yönetici Kontrolleri:** Yöneticiler tüm katalog üzerinde tam CRUP (Oluşturma, Okuma, Güncelleme, Silme) erişimine sahiptir. Kurs küçük resimleri ve eğitmen profilleri için benzersiz GUID isimlendirmeli resim yükleme özelliklerini içerir.
<!-- PLACEHOLDER: Course CRUP Screenshot -->
<img width="1919" height="911" alt="Course CRUP Placeholder" src="https://via.placeholder.com/1919x911.png?text=Course+Creation/Edit" />
<!-- PLACEHOLDER: Instructor Management Screenshot -->
<img width="1919" height="907" alt="Instructor Management Placeholder" src="https://via.placeholder.com/1919x907.png?text=Instructor+Management" />
<!-- PLACEHOLDER: Category Management Screenshot -->
<img width="1919" height="611" alt="Category Management Placeholder" src="https://via.placeholder.com/1919x611.png?text=Category+Management" />

#### 4. Analitik ve Dışa Aktarım Süreçleri
* **Belge Oluşturma (PDF & Excel):**
  * **PDF Raporları:** Kontenjanlar ve eğitmen atamaları dahil olmak üzere tüm kurs kataloğu için baskıya hazır, piksel mükemmelliğinde idari raporlar oluşturmak amacıyla `QuestPDF` kullanımı.
  * **Excel Tabloları:** Ham veri setlerini (Kurslar, Kayıtlar) detaylı veri analizi için standart Excel formatlarında dışa aktarmak amacıyla `EPPlus` kullanımı.
<!-- PLACEHOLDER: PDF Export Screenshot -->
<img width="1124" height="358" alt="PDF Export Placeholder" src="https://via.placeholder.com/1124x358.png?text=QuestPDF+Export+Example" />
<!-- PLACEHOLDER: Excel Export Screenshot -->
<img width="1108" height="223" alt="Excel Export Placeholder" src="https://via.placeholder.com/1108x223.png?text=EPPlus+Excel+Export+Example" />
