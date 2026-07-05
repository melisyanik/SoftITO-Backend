# 🎓 EduMaster - N-Tier Architecture & Code First (LMS Project)
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
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 033601" src="https://github.com/user-attachments/assets/6cd9da34-d988-452f-a5e9-b15096d0a3d5" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-05 032714" src="https://github.com/user-attachments/assets/85dd3851-271f-44ef-9518-82575dde2f87" />

* **Role-Based Routing:** Smart routing powered by ASP.NET Core Identity. Admins are redirected to the management dashboard upon login, while regular users are routed to the public homepage and their enrolled courses.
* **Account Administration:** Full lifecycle management of user accounts, enabling users to register, log in, and track their course enrollments.
* **Admin Management:** Secure backend access specifically for Administrator accounts.
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-05 031906" src="https://github.com/user-attachments/assets/064024fd-1223-47d1-ab3d-15be1f69fbef" />


#### 2. Public User Experience
* **Interactive Homepage (Course Catalog):** A dynamic, user-facing homepage displaying the catalog of available educational courses, complete with high-quality imagery, instructor details, and categories.

Screen without login:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 032204" src="https://github.com/user-attachments/assets/163c83e4-9451-4019-ae22-9dd7d94e2a36" />

Screen with user authentication:
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-05 031956" src="https://github.com/user-attachments/assets/45311a14-8f36-40a2-abde-10f9bda582a3" />


* **Course Enrollment & Quota Management:** Users can easily enroll in courses. The system automatically tracks the total enrolled count against the course's maximum quota. If a course is full, enrollments are prevented.

Case: Students want to enroll a course that has 2-student quota:

Student 1:
<img width="1919" height="914" alt="Ekran görüntüsü 2026-07-05 031956" src="https://github.com/user-attachments/assets/34922128-e153-4621-ac66-67dde73c937f" />
<img width="1919" height="916" alt="Ekran görüntüsü 2026-07-05 032014" src="https://github.com/user-attachments/assets/5c1c7ee8-4712-4de1-a9cb-ecb9b5351b87" />

Student 2:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 032152" src="https://github.com/user-attachments/assets/95868738-c50d-405d-8105-6ab1cb0e5513" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 032245" src="https://github.com/user-attachments/assets/0843ef1d-e9b4-42a6-bdd2-4c7aeea1a35a" />

Finally, quota is full and no more students can enroll:

<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 032204" src="https://github.com/user-attachments/assets/d54aef9a-ce59-4b43-904a-6da3194aefc0" />

* **Community Comments:** Students can leave reviews and comments on course pages, and manage (edit/delete) their own comments.
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-05 032043" src="https://github.com/user-attachments/assets/3525eb1b-8723-44cd-845f-ad340cb3ee10" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 032050" src="https://github.com/user-attachments/assets/662391f1-348e-4bcf-9953-92b8085510e1" />


#### 3. N-Tier Architecture & Content Engine
* **Multi-Layered Design:** The codebase is strictly separated into `EduMaster.Data`, `EduMaster.Models`, and the main `EduMaster` Web project, utilizing the Repository Pattern and Unit of Work for high scalability and maintainability.
* **Unified LMS Catalog:** Relational management of Courses, Categories, Instructors, and Enrollments using Entity Framework Core.
* **Advanced Admin Controls:** Admins have full CRUP (Create, Read, Update, Delete) access over the entire catalog. Includes image uploading features for course thumbnails and instructor profiles with unique GUID naming.

Adding new instructor:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-05 031551" src="https://github.com/user-attachments/assets/98faab48-406c-47d3-91b9-edea8962823a" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 031702" src="https://github.com/user-attachments/assets/c2e0dc43-58cb-45a3-9f38-61bb376bb0bd" />
<img width="1919" height="916" alt="Ekran görüntüsü 2026-07-05 031708" src="https://github.com/user-attachments/assets/2ee73248-3484-4447-8013-0d44ab80c2d8" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 031740" src="https://github.com/user-attachments/assets/5527c8c8-4221-4d81-b15f-ab2134058241" />

Searching for instructor:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-05 031750" src="https://github.com/user-attachments/assets/f7203c88-f75f-4635-8c3c-6e064f9d67c0" />

Searching for courses according to field combobox:
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-05 035753" src="https://github.com/user-attachments/assets/70215541-d40c-4614-a24b-121badbf2641" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-05 035817" src="https://github.com/user-attachments/assets/4ab11851-d063-40a5-aefc-deeb09ca79e3" />


Updating an instructor:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 032331" src="https://github.com/user-attachments/assets/205ff9b8-0086-4f38-b0da-75b777a6f31f" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-05 032601" src="https://github.com/user-attachments/assets/a467900a-052d-468d-a6b0-69f77af7eb7a" />

Adding new course:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 031500" src="https://github.com/user-attachments/assets/0df26569-0ff7-4f4b-8586-4850140326f2" />
<img width="1919" height="915" alt="Ekran görüntüsü 2026-07-05 031509" src="https://github.com/user-attachments/assets/cd0ead8b-ac36-4d94-8c2c-e7759b6565ea" />
<img width="1919" height="905" alt="Ekran görüntüsü 2026-07-05 031844" src="https://github.com/user-attachments/assets/7d5639f5-3dc5-486d-ad9d-75ff9067f75b" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-05 031853" src="https://github.com/user-attachments/assets/a16771cf-ea2a-4e6f-9738-e4496a49ab4e" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-05 031906" src="https://github.com/user-attachments/assets/9a25f562-ddc4-4308-af7c-e674cf284978" />

Viewing details of the full quota course:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-05 032305" src="https://github.com/user-attachments/assets/489227f6-34d8-43f6-a2a1-967803bc158e" />

Viewving comments of the course:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-05 032312" src="https://github.com/user-attachments/assets/8b1366ca-0a75-4889-87c8-7361272788c3" />


#### 4. Analytics & Export Pipeline
* **Document Generation (PDF & Excel):**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable administrative reports for the entire course catalog, including quotas and instructor assignments.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting raw datasets (Courses, Enrollments) into standard Excel formats for deep data analysis.

PDF Generation:
<img width="1035" height="293" alt="Ekran görüntüsü 2026-07-05 040207" src="https://github.com/user-attachments/assets/dddf1ab8-b0fd-4930-877b-3c53472977f6" />


Excel Generation:

<img width="795" height="120" alt="Ekran görüntüsü 2026-07-05 040222" src="https://github.com/user-attachments/assets/e01e0f72-db11-4564-905b-272b707e91de" />

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
