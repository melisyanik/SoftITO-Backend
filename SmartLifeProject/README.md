# 🌟 SmartLife - API & MVC N-Tier Architecture

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

### 🚀 Scope & Capabilities

#### 1. Identity & Routing Management
* **Secure Authentication:** Fully functional Login and Sign Up screens completely integrated with ASP.NET Core Identity.
* **Dual Database Architecture:** 
  * `SmartLifeDbMvc`: Handles ASP.NET Core Identity (Users, Roles) and Goal tracking.
  * `SmartLifeDbApi`: Dedicated to the Web API for handling Tasks, Notes, and Quotes.
* **JWT Token Integration:** The MVC application communicates securely with the Web API. When a user logs in via cookies on the MVC side, a JWT (JSON Web Token) is generated in the background and attached to all API requests via a custom `DelegatingHandler`.

![Login Screen Placeholder](https://placehold.co/1920x1080?text=Login+Screen+Screenshot)
![Register Screen Placeholder](https://placehold.co/1920x1080?text=Register+Screen+Screenshot)

#### 2. Core Features (CRUD + Search)
* **Goals & Goal Progress:** Users can create personal goals and track their progress percentage over time. Includes advanced filtering by status (Active, In Progress, Done).
* **Tasks Management:** Complete CRUD operations for daily tasks, including an AJAX-friendly toggle to mark tasks as completed.
* **Notes & Quotes:** Dedicated sections for users to store personal notes and favorite quotes.
* **Advanced Search & Filtering:** Granular search functionality across all entities (e.g., searching Notes by keywords, filtering Goals by status).

![Goals Dashboard Placeholder](https://placehold.co/1920x1080?text=Goals+Dashboard+Screenshot)
![Search & Filter Placeholder](https://placehold.co/1920x1080?text=Search+and+Filter+Screenshot)

#### 3. Analytics & Export Pipeline
* **Document Generation:**
  * **PDF Reports:** Utilizing `QuestPDF` for generating pixel-perfect, printable reports summarizing a user's Goals, Tasks, Notes, and Quotes.
  * **Excel Spreadsheets:** Utilizing `EPPlus` for exporting datasets into standard `.xlsx` formats for easy data portability.

![PDF Export Placeholder](https://placehold.co/1920x1080?text=PDF+Report+Screenshot)
![Excel Export Placeholder](https://placehold.co/1920x1080?text=Excel+Report+Screenshot)

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
**SmartLife**, kullanıcıların günlük yaşamlarını, hedeflerini, görevlerini, notlarını ve favori alıntılarını yönetmelerine yardımcı olmak için tasarlanmış kapsamlı, çok katmanlı bir web uygulamasıdır. Güçlü ASP.NET Core altyapısı üzerine inşa edilen proje, **ASP.NET Core MVC** önyüzü (frontend) ve **ASP.NET Core Web API** arkayüzü (backend) olmak üzere kesin hatlarla ayrılmış bir mimari kullanır. Kullanıcı kimlikleri ve uygulama verileri için **iki ayrı veritabanı** kullanarak güvenli ve izole bir veri yönetimi sağlar.

### 🚀 Kapsam ve Yetenekler

#### 1. Kimlik Yönetimi ve Mimari
* **Güvenli Kimlik Doğrulama:** ASP.NET Core Identity altyapısına tam entegre, giriş (Login) ve kayıt (Sign Up) ekranları.
* **Çift Veritabanı Mimarisi (Separate Databases):** 
  * `SmartLifeDbMvc`: ASP.NET Core Identity (Kullanıcılar, Roller) ve Hedef (Goal) takiplerini yönetir.
  * `SmartLifeDbApi`: Web API'ye özeldir; Görevler (Tasks), Notlar (Notes) ve Alıntıları (Quotes) yönetir.
* **JWT Entegrasyonu:** MVC uygulaması, Web API ile güvenli bir şekilde haberleşir. Kullanıcı MVC tarafında çerez (cookie) ile giriş yaptığında, arka planda bir JWT (JSON Web Token) üretilir ve özel bir `DelegatingHandler` aracılığıyla API'ye yapılan tüm isteklere otomatik olarak eklenir.

![Giriş Ekranı Placeholder](https://placehold.co/1920x1080?text=Giris+Ekrani+Screenshot)
![Kayıt Ekranı Placeholder](https://placehold.co/1920x1080?text=Kayit+Ekrani+Screenshot)

#### 2. Temel Özellikler (CRUD + Arama)
* **Hedefler ve İlerleme Takibi (Goals):** Kullanıcılar kişisel hedefler oluşturabilir ve zaman içindeki ilerleme yüzdelerini takip edebilir. Duruma göre (Aktif, Devam Ediyor, Tamamlandı) gelişmiş filtreleme içerir.
* **Görev Yönetimi (Tasks):** Günlük görevler için tam CRUD işlemleri ve görevleri tamamlandı olarak işaretlemek için AJAX uyumlu hızlı durum değiştirme özelliği.
* **Notlar ve Alıntılar:** Kullanıcıların kişisel notlarını ve favori sözlerini saklayabilecekleri özel bölümler.
* **Gelişmiş Arama ve Filtreleme:** Tüm modüllerde detaylı arama işlevselliği (örneğin; anahtar kelime ile notlarda arama yapma, hedefleri durumuna göre filtreleme).

![Hedefler Paneli Placeholder](https://placehold.co/1920x1080?text=Hedefler+Paneli+Screenshot)
![Arama ve Filtreleme Placeholder](https://placehold.co/1920x1080?text=Arama+Filtreleme+Screenshot)

#### 3. Analitik ve Dışa Aktarım Süreçleri
* **Belge Oluşturma (Export):**
  * **PDF Raporları:** Kullanıcının Hedef, Görev, Not ve Alıntılarını özetleyen baskıya hazır, kusursuz raporlar oluşturmak için `QuestPDF` kullanımı.
  * **Excel Tabloları:** Verilerin kolayca taşınabilmesi için standart `.xlsx` formatında dışa aktarım sağlayan `EPPlus` entegrasyonu.

![PDF Çıktısı Placeholder](https://placehold.co/1920x1080?text=PDF+Ciktisi+Screenshot)
![Excel Çıktısı Placeholder](https://placehold.co/1920x1080?text=Excel+Ciktisi+Screenshot)
