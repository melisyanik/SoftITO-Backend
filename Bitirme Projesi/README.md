# 🏛️ Smart Municipality (Akıllı Belediye) - Hybrid ORM & AI Assistant (GRADUATION PROJECT / BİTİRME PROJESİ)

![.NET Core](https://img.shields.io/badge/.NET%20Core%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-E34F26?style=for-the-badge&logo=dapper&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=json-web-tokens&logoColor=white)
![Serilog](https://img.shields.io/badge/Serilog-3772FF?style=for-the-badge&logo=serilog&logoColor=white)

[🇺🇸 Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

---

## 🇺🇸 English Documentation

### 🎯 Project Overview
Smart Municipality is a graduation project featuring a comprehensive municipal administration and citizen communication platform. Built on **.NET 8.0**, it features a **Hybrid ORM (EF Core & Dapper)** architecture to optimize database writes and read queries. It includes an **AI Chatbot** helper (Gemini & OpenAI client integration) to help citizens with municipal inquiries and complaint submissions.

---

### 🚀 Scope & Capabilities

#### 1. Security & Identity Management
* **Role-Based Authentication**: Secure sign-in using **ASP.NET Core Identity** and **JWT Bearer Token** authorization.
* **Smart Dashboards**: Citizens and operators are automatically routed to their custom interfaces based on their role claims.
<!-- SCREENSHOT PLACEHOLDER: Login and Registration Screen -->
<!-- <img width="1919" height="910" alt="Login Screen" src="YOUR_GITHUB_ASSET_URL_HERE" /> -->

---

#### 2. Citizen Services & Portal
* **Subscriptions Panel**: Request new water, gas, electricity, or waste subscriptions and track approval state.
* **Billing & Payments**: List bills, view consumption details, and perform simulated credit card payments.
* **Complaints Management**: Create location-based complaint records, select categories, and track responses.
<!-- SCREENSHOT PLACEHOLDER: Citizen Dashboard & Bill Payments -->
<!-- <img width="1919" height="910" alt="Citizen Dashboard" src="YOUR_GITHUB_ASSET_URL_HERE" /> -->

---

#### 3. Operator Administrative Panel
* **Complaint Resolution Pipeline**: View, categorize, search, and respond to incoming citizen complaints.
* **Billing Administration**: Generate bills for citizens and log manual meter readings.
* **Subscription Auditing**: Review and approve/reject pending citizen subscription requests.
<!-- SCREENSHOT PLACEHOLDER: Operator Dashboard & Complaint Management -->
<!-- <img width="1919" height="910" alt="Operator Panel" src="YOUR_GITHUB_ASSET_URL_HERE" /> -->

---

#### 4. AI Chatbot Assistant
* **Smart Municipal Advisor**: Powered by Google Gemini 1.5 Flash (with fallback to OpenAI API and local rule-based fallback).
* **Complaint Drafting**: Drafts complaint templates and answers generic inquiries about municipal bylaws.
<!-- SCREENSHOT PLACEHOLDER: AI Chatbot Interface -->
<!-- <img width="1919" height="910" alt="AI Chatbot" src="YOUR_GITHUB_ASSET_URL_HERE" /> -->

---

#### 5. Architectural Engine
* **Hybrid Data Layer**: 
  - **Entity Framework Core**: Utilized for standard CRUD operations, database migrations, and structural relational mapping.
  - **Dapper**: Employed for heavy read queries, reporting, and dashboard statistics to ensure maximum performance.
* **Unit of Work & Repository Pattern**: Clean abstraction layer decoupling database drivers from business controllers.
* **Serilog Logging**: Diagnostics logged synchronously to the Console and Daily rolling file outputs.

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
Akıllı Belediye (Smart Municipality), vatandaşlar ile yerel yönetim arasındaki iletişimi dijitalleştiren kapsamlı bir belediye yönetim sistemidir. **.NET 8.0** üzerinde koşan sistem, okuma ve yazma işlemlerini optimize etmek amacıyla **Hibrit ORM (EF Core ve Dapper)** mimarisine sahiptir. Ayrıca vatandaşların şikayet oluşturma ve bilgi edinme süreçlerini kolaylaştırmak adına **Yapay Zeka Destekli Belediye Asistanı** (Gemini ve OpenAI entegrasyonu) içermektedir.

---

### 🚀 Kapsam ve Yetenekler

#### 1. Kimlik Yönetimi ve Güvenlik
* **Rol Tabanlı Yetkilendirme**: **ASP.NET Core Identity** ve **JWT Bearer Token** entegrasyonu ile güvenli oturum yönetimi.
* **Akıllı Yönlendirme**: Vatandaşlar ve Belediye Operatörleri rollerine göre otomatik olarak kendi yetkili panellerine yönlendirilir.
<!-- EKRAN GÖRÜNTÜSÜ YER TUTUCU: Giriş ve Kayıt Ekranı -->
<!-- <img width="1919" height="910" alt="Giris Ekrani" src="YOUR_GITHUB_ASSET_URL_HERE" /> -->

---

#### 2. Vatandaş Hizmetleri Portalı
* **Abonelik Yönetimi**: Su, doğalgaz, elektrik gibi belediye abonelikleri için yeni başvurular yapma ve onay sürecini takip etme.
* **Fatura Ödeme**: Fatura detaylarını inceleme, tüketim miktarlarını görüntüleme ve sanal POS simülasyonu ile fatura ödeme.
* **Şikayet Bildirimi**: Kategori seçerek konum bazlı şikayet oluşturma ve operatör yanıtlarını anlık takip etme.
<!-- EKRAN GÖRÜNTÜSÜ YER TUTUCU: Vatandaş Paneli ve Fatura Ödeme -->
<!-- <img width="1919" height="910" alt="Vatandas Paneli" src="YOUR_GITHUB_ASSET_URL_HERE" /> -->

---

#### 3. Operatör Yönetim Paneli
* **Şikayet Değerlendirme Hattı**: Vatandaşlardan gelen şikayetleri inceleme, yanıtlama ve durum güncellemesi yapma.
* **Fatura ve Sayaç Yönetimi**: Manuel sayaç okuma kaydı girme ve vatandaşlar adına faturalandırılma yapılması.
* **Abonelik Onaylama**: Gelen abonelik taleplerini inceleme, onaylama veya reddetme.
<!-- EKRAN GÖRÜNTÜSÜ YER TUTUCU: Operatör Paneli ve Sayaç Okuma -->
<!-- <img width="1919" height="910" alt="Operator Paneli" src="YOUR_GITHUB_ASSET_URL_HERE" /> -->

---

#### 4. Yapay Zeka Destekli Belediye Asistanı
* **Akıllı Chatbot**: Google Gemini 1.5 Flash API (hata durumunda OpenAI ve yerel kural tabanlı motor fallback mekanizması) ile entegre.
* **Şikayet Taslağı Hazırlama**: Vatandaşların sorunlarını dinleyerek otomatik şikayet dilekçesi taslağı oluşturur ve belediye kuralları hakkında bilgi verir.
<!-- EKRAN GÖRÜNTÜSÜ YER TUTUCU: Yapay Zeka Sohbet Arayüzü -->
<!-- <img width="1919" height="910" alt="Yapay Zeka Chatbot" src="YOUR_GITHUB_ASSET_URL_HERE" /> -->

---

#### 5. Teknik Altyapı ve Mimari
* **Hibrit Veri Katmanı**:
  - **Entity Framework Core**: Standart CRUD işlemleri, veritabanı şeması oluşturma ve ilişkisel eşlemeler için kullanıldı.
  - **Dapper**: Raporlama, istatistikler ve yoğun veri okuması gerektiren gösterge panellerinde maksimum sorgu performansı için kullanıldı.
* **Unit of Work & Repository Pattern**: İş mantığı katmanı ile veri tabanını birbirinden bağımsız hale getiren temiz mimari.
* **Serilog Günlükleme (Logging)**: Konsol ve günlük dönen dosyalara (rolling files) hata ve bilgi logları kaydı.
