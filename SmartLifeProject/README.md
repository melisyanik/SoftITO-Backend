# 🌟 SmartLife - API & MVC N-Tier Architecture (PROJECT 7)

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-339933?style=for-the-badge&logo=entity-framework&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)

[🇺🇸 Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

---

## 🇺🇸 English Documentation

### 🎯 Project Overview
**SmartLife** is a comprehensive, multi-layered web application designed to help users manage their daily lives, goals, tasks, notes, and favorite quotes. Built on the robust ASP.NET Core framework, the project utilizes a strictly separated architecture consisting of an **ASP.NET Core MVC** frontend and an **ASP.NET Core Web API** backend. It operates using **two separate databases**, ensuring secure and isolated data management for user identities and application data.

API Interface:
<img width="1919" height="487" alt="Ekran görüntüsü 2026-07-04 173824" src="https://github.com/user-attachments/assets/dfb84b5c-671c-4204-89fb-45b14b1d30d5" />
<img width="1919" height="905" alt="Ekran görüntüsü 2026-07-04 173815" src="https://github.com/user-attachments/assets/d2c1205e-dc09-4ec1-a0f9-421d33552c35" />

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
* **Secure Authentication:** Fully functional Login and Sign Up screens completely integrated with ASP.NET Core Identity.
* **Dual Database Architecture:** 
  * `SmartLifeDbMvc`: Handles ASP.NET Core Identity (Users, Roles) and Goal tracking.
  * `SmartLifeDbApi`: Dedicated to the Web API for handling Tasks, Notes, and Quotes.
* **JWT Token Integration:** The MVC application communicates securely with the Web API. When a user logs in via cookies on the MVC side, a JWT (JSON Web Token) is generated in the background and attached to all API requests via a custom `DelegatingHandler`.

Register screen:
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 175005" src="https://github.com/user-attachments/assets/368a6fae-daa0-46ef-a909-69f9a54e22f0" />

Login screen:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 173851" src="https://github.com/user-attachments/assets/f1dd22f5-6813-4666-b265-b76fcddd9800" />

#### 2. Core Features (CRUD + Search)
* **Goals & Goal Progress:** Users can create personal goals and track their progress percentage over time. Includes advanced filtering by status (Active, In Progress, Done).
* **Tasks Management:** Complete CRUD operations for daily tasks, including an AJAX-friendly toggle to mark tasks as completed.
* **Notes & Quotes:** Dedicated sections for users to store personal notes and favorite quotes.
* **Advanced Search & Filtering:** Granular search functionality across all entities (e.g., searching Notes by keywords, filtering Goals by status).

Adding a Goal:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 173926" src="https://github.com/user-attachments/assets/f7a76328-d4e1-4fdc-b85f-bfa50abc4110" />
<img width="1919" height="903" alt="Ekran görüntüsü 2026-07-04 173955" src="https://github.com/user-attachments/assets/b30fb3cb-5b82-48d2-b70d-3879c142d620" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 174006" src="https://github.com/user-attachments/assets/7ddac56a-7605-439e-b7f4-13ada6f350be" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 174016" src="https://github.com/user-attachments/assets/bfac18c6-c929-422c-8752-94f4132fb2df" />

Updating progress percentage:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 174029" src="https://github.com/user-attachments/assets/4de1b583-a09c-4e9c-8d0e-0a21242ec6d1" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 174046" src="https://github.com/user-attachments/assets/49f58ace-c8f9-4d08-a120-912f42bb507b" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 174054" src="https://github.com/user-attachments/assets/475c1def-5e1e-48d1-843c-685018bcdd20" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 174104" src="https://github.com/user-attachments/assets/b128d7f7-6879-482b-bbb4-08f04e956c98" />
Then arranging percentage to 100%, changing the status to done:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-04 174130" src="https://github.com/user-attachments/assets/ab92bc6f-0e30-4f52-8deb-e115f996b641" />

Adding a Task:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174256" src="https://github.com/user-attachments/assets/4860cf52-a80c-4cf9-bb4c-33add97567d0" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174311" src="https://github.com/user-attachments/assets/c810a42b-099f-418c-9502-1eebec7643df" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 174320" src="https://github.com/user-attachments/assets/21cf4908-7981-484c-af11-b85d94de0805" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 174343" src="https://github.com/user-attachments/assets/7db00f6d-984a-4f09-8f29-b7d53b21531f" />

Adding Note:
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 174559" src="https://github.com/user-attachments/assets/54ca1726-a108-48d2-b8b6-1b2f2e831775" />

Updating Note:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174859" src="https://github.com/user-attachments/assets/2a6e3d44-2ab1-46cc-9ea5-f6e260729241" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 174909" src="https://github.com/user-attachments/assets/bc56de0f-e254-4a5d-8d5e-c87defb066cc" />

Adding Quote:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 174637" src="https://github.com/user-attachments/assets/925bff2d-0c02-4eca-bd3d-5274e353cb93" />

Searching Goal:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174207" src="https://github.com/user-attachments/assets/3c5fef74-a85e-40f3-a580-54876bd83f05" />
<img width="1919" height="904" alt="Ekran görüntüsü 2026-07-04 174220" src="https://github.com/user-attachments/assets/86a57ee1-9a23-4910-8c44-0770fa7c490f" />

Filtering Task:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 184950" src="https://github.com/user-attachments/assets/8d10d55e-e591-4704-92be-b9e29c265ce7" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174422" src="https://github.com/user-attachments/assets/39a801bf-50ec-4e37-88ad-6f66450af473" />

#### 3. Analytics & Export Pipeline
* **Document Generation:**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable reports summarizing a user's Goals, Tasks, Notes, and Quotes.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting datasets into standard `.xlsx` formats for easy data portability.

Analytics Page:
<img width="1919" height="728" alt="Ekran görüntüsü 2026-07-04 174714" src="https://github.com/user-attachments/assets/98f1c738-1721-4fd2-9fd0-e4bcae635951" />
<img width="1919" height="823" alt="Ekran görüntüsü 2026-07-04 174725" src="https://github.com/user-attachments/assets/828ea942-c43f-4606-b0c2-1c250b430a89" />

PDF Generation of reports:

![PDF Report Screenshot](https://github.com/user-attachments/assets/353fb607-9735-4700-8a6b-6791b81c2915)

Excel generation:

![Excel Report Screenshot](https://github.com/user-attachments/assets/1f3b0a7f-cbfb-4fec-bd56-fd30ea4b9a1a)

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
**SmartLife**, kullanıcıların günlük yaşamlarını, hedeflerini, görevlerini, notlarını ve favori alıntılarını yönetmelerine yardımcı olmak için tasarlanmış kapsamlı, çok katmanlı bir web uygulamasıdır. Güçlü ASP.NET Core altyapısı üzerine inşa edilen proje, **ASP.NET Core MVC** önyüzü (frontend) ve **ASP.NET Core Web API** arkayüzü (backend) olmak üzere kesin hatlarla ayrılmış bir mimari kullanır. Kullanıcı kimlikleri ve uygulama verileri için **iki ayrı veritabanı** kullanarak güvenli ve izole bir veri yönetimi sağlar.

API Arayüzü:
<img width="1919" height="487" alt="Ekran görüntüsü 2026-07-04 173824" src="https://github.com/user-attachments/assets/dfb84b5c-671c-4204-89fb-45b14b1d30d5" />
<img width="1919" height="905" alt="Ekran görüntüsü 2026-07-04 173815" src="https://github.com/user-attachments/assets/d2c1205e-dc09-4ec1-a0f9-421d33552c35" />

### 🚀 Kapsam ve Yetenekler

#### 1. Kimlik Yönetimi ve Mimari
* **Güvenli Kimlik Doğrulama:** ASP.NET Core Identity altyapısına tam entegre, giriş (Login) ve kayıt (Sign Up) ekranları.
* **Çift Veritabanı Mimarisi (Separate Databases):** 
  * `SmartLifeDbMvc`: ASP.NET Core Identity (Kullanıcılar, Roller) ve Hedef (Goal) takiplerini yönetir.
  * `SmartLifeDbApi`: Web API'ye özeldir; Görevler (Tasks), Notlar (Notes) ve Alıntıları (Quotes) yönetir.
* **JWT Entegrasyonu:** MVC uygulaması, Web API ile güvenli bir şekilde haberleşir. Kullanıcı MVC tarafında çerez (cookie) ile giriş yaptığında, arka planda bir JWT (JSON Web Token) üretilir ve özel bir `DelegatingHandler` aracılığıyla API'ye yapılan tüm isteklere otomatik olarak eklenir.

Kayıt Ekranı:
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 175005" src="https://github.com/user-attachments/assets/368a6fae-daa0-46ef-a909-69f9a54e22f0" />

Giriş Ekranı:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 173851" src="https://github.com/user-attachments/assets/f1dd22f5-6813-4666-b265-b76fcddd9800" />

#### 2. Temel Özellikler (CRUD + Arama)
* **Hedefler ve İlerleme Takibi (Goals):** Kullanıcılar kişisel hedefler oluşturabilir ve zaman içindeki ilerleme yüzdelerini takip edebilir. Duruma göre (Aktif, Devam Ediyor, Tamamlandı) gelişmiş filtreleme içerir.
* **Görev Yönetimi (Tasks):** Günlük görevler için tam CRUD işlemleri ve görevleri tamamlandı olarak işaretlemek için AJAX uyumlu hızlı durum değiştirme özelliği.
* **Notlar ve Alıntılar:** Kullanıcıların kişisel notlarını ve favori sözlerini saklayabilecekleri özel bölümler.
* **Gelişmiş Arama ve Filtreleme:** Tüm modüllerde detaylı arama işlevselliği (örneğin; anahtar kelime ile notlarda arama yapma, hedefleri durumuna göre filtreleme).

Hedef Ekleme:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 173926" src="https://github.com/user-attachments/assets/f7a76328-d4e1-4fdc-b85f-bfa50abc4110" />
<img width="1919" height="903" alt="Ekran görüntüsü 2026-07-04 173955" src="https://github.com/user-attachments/assets/b30fb3cb-5b82-48d2-b70d-3879c142d620" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 174006" src="https://github.com/user-attachments/assets/7ddac56a-7605-439e-b7f4-13ada6f350be" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 174016" src="https://github.com/user-attachments/assets/bfac18c6-c929-422c-8752-94f4132fb2df" />

İlerleme Yüzdesi Güncelleme:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 174029" src="https://github.com/user-attachments/assets/4de1b583-a09c-4e9c-8d0e-0a21242ec6d1" />
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 174046" src="https://github.com/user-attachments/assets/49f58ace-c8f9-4d08-a120-912f42bb507b" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 174054" src="https://github.com/user-attachments/assets/475c1def-5e1e-48d1-843c-685018bcdd20" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 174104" src="https://github.com/user-attachments/assets/b128d7f7-6879-482b-bbb4-08f04e956c98" />
Ardından yüzdeyi %100 yapıp durumu tamamlandı olarak değiştirme:
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-04 174130" src="https://github.com/user-attachments/assets/ab92bc6f-0e30-4f52-8deb-e115f996b641" />

Görev Ekleme:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174256" src="https://github.com/user-attachments/assets/4860cf52-a80c-4cf9-bb4c-33add97567d0" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174311" src="https://github.com/user-attachments/assets/c810a42b-099f-418c-9502-1eebec7643df" />
<img width="1919" height="908" alt="Ekran görüntüsü 2026-07-04 174320" src="https://github.com/user-attachments/assets/21cf4908-7981-484c-af11-b85d94de0805" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 174343" src="https://github.com/user-attachments/assets/7db00f6d-984a-4f09-8f29-b7d53b21531f" />

Not Ekleme:
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 174559" src="https://github.com/user-attachments/assets/54ca1726-a108-48d2-b8b6-1b2f2e831775" />

Not Güncelleme:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174859" src="https://github.com/user-attachments/assets/2a6e3d44-2ab1-46cc-9ea5-f6e260729241" />
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 174909" src="https://github.com/user-attachments/assets/bc56de0f-e254-4a5d-8d5e-c87defb066cc" />

Alıntı Ekleme:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 174637" src="https://github.com/user-attachments/assets/925bff2d-0c02-4eca-bd3d-5274e353cb93" />

Hedef Arama:
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174207" src="https://github.com/user-attachments/assets/3c5fef74-a85e-40f3-a580-54876bd83f05" />
<img width="1919" height="904" alt="Ekran görüntüsü 2026-07-04 174220" src="https://github.com/user-attachments/assets/86a57ee1-9a23-4910-8c44-0770fa7c490f" />

Görev Filtreleme:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 184950" src="https://github.com/user-attachments/assets/8d10d55e-e591-4704-92be-b9e29c265ce7" />
<img width="1919" height="909" alt="Ekran görüntüsü 2026-07-04 174422" src="https://github.com/user-attachments/assets/39a801bf-50ec-4e37-88ad-6f66450af473" />

#### 3. Analitik ve Dışa Aktarım Süreçleri
* **Belge Oluşturma (Export):**
  * **PDF Raporları:** Kullanıcının Hedef, Görev, Not ve Alıntılarını özetleyen baskıya hazır, kusursuz raporlar oluşturmak için `QuestPDF` kullanımı.
  * **Excel Tabloları:** Verilerin kolayca taşınabilmesi için standart `.xlsx` formatında dışa aktarım sağlayan `EPPlus` entegrasyonu.

Analitik Sayfası:
<img width="1919" height="728" alt="Ekran görüntüsü 2026-07-04 174714" src="https://github.com/user-attachments/assets/98f1c738-1721-4fd2-9fd0-e4bcae635951" />
<img width="1919" height="823" alt="Ekran görüntüsü 2026-07-04 174725" src="https://github.com/user-attachments/assets/828ea942-c43f-4606-b0c2-1c250b430a89" />

PDF Raporu Oluşturma:

![PDF Report Screenshot](https://github.com/user-attachments/assets/353fb607-9735-4700-8a6b-6791b81c2915)

Excel Tablosu Oluşturma:

![Excel Report Screenshot](https://github.com/user-attachments/assets/1f3b0a7f-cbfb-4fec-bd56-fd30ea4b9a1a)
