# 👔 Gardrobum (My Wardrobe) - Monolithic Architecture & ADO.NET (PROJECT 4)

![.NET Core](https://img.shields.io/badge/.NET%20Core%209.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ADO.NET](https://img.shields.io/badge/ADO.NET-00599C?style=for-the-badge&logo=c-sharp&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQLServer-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

[🇺🇸 Read in English](#-english-documentation) | [🇹🇷 Türkçe Dokümantasyon](#-türkçe-dokümantasyon)

---

## 🇺🇸 English Documentation

### 🎯 Project Overview
Gardrobum (My Wardrobe) is a web application designed to help users digitally organize, track, and report on their personal clothing, shoe, and jewelry collections. Built on the ASP.NET Core Razor Pages framework utilizing a **Monolithic Architecture** and native **ADO.NET** with SQL Server, this system allows items to be categorized by type, color, or brand, and easily retrieved through advanced search options.

![Project Overview Placeholder](https://via.placeholder.com/1200x600?text=Project+Overview+Screenshot)

### 🚀 Scope & Capabilities

#### 1. Comprehensive Management (CRUD Operations)
* **Clothes, Shoes, and Jewelry Management:** Add new items to the system, update details (color, brand, size, etc.) of existing items, or delete them (CRUD).
* **Dynamic Data Flow:** Each module operates independently and is listed in real-time synchronization with the database.

![CRUD Operations Placeholder](https://via.placeholder.com/1200x600?text=CRUD+Operations+Screenshot)

#### 2. Advanced Search & Filtering
* **Field-Based Dynamic Search:** Users can perform specific queries not just with a single keyword, but based on a selected field (e.g., search for "Nike" only within "Brand", or "Black" only within "Color").
* **Fast Results:** Thanks to the secure and fast dynamic filtering structure on the SQL side, the searched item is listed in seconds.

![Search & Filtering Placeholder](https://via.placeholder.com/1200x600?text=Search+and+Filtering+Screenshot)

#### 3. Visual Statistics & Dashboard (Reporting)
* **Instant Summary Screen:** A detailed summary of all items in the wardrobe is presented on the main page (Dashboard).
* **Categorical Distribution:** Data such as the distribution of clothes by type and color, and the distribution of shoes by brand and size, are presented as lists.
* *Note: The project has the infrastructure to integrate PDF and Excel export modules (QuestPDF / EPPlus) in the future.*

![Dashboard Placeholder](https://via.placeholder.com/1200x600?text=Dashboard+Statistics+Screenshot)

#### 4. Technical Infrastructure
* **ASP.NET Core Razor Pages:** Fast and Page-Focused web development.
* **Native ADO.NET (SqlDataReader & SqlCommand):** Direct and high-performance communication with the database without an ORM.
* **Responsive Design (Bootstrap 5):** A user interface that works flawlessly across all mobile and desktop devices.

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
Gardrobum (My Wardrobe), kullanıcıların kişisel kıyafet, ayakkabı ve takı koleksiyonlarını dijital ortamda düzenlemesi, takip etmesi ve raporlaması için geliştirilmiş bir web uygulamasıdır. ASP.NET Core Razor Pages **Monolitik Mimarisi** üzerinde, native **ADO.NET** ve SQL Server kullanılarak inşa edilen bu sistem; kıyafetlerin türüne, rengine veya markasına göre kategorize edilmesini ve gelişmiş arama seçenekleriyle kolayca bulunmasını sağlar.

![Proje Özeti Görseli](https://via.placeholder.com/1200x600?text=Proje+Ozet+Ekrani)

### 🚀 Kapsam ve Yetenekler

#### 1. Kapsamlı Yönetim (CRUD İşlemleri)
* **Kıyafet, Ayakkabı ve Takı Yönetimi:** Sisteme yeni ürünler ekleme, mevcut ürünlerin detaylarını (renk, marka, numara, beden vb.) güncelleme veya silme işlemleri (CRUD).
* **Dinamik Veri Akışı:** Her bir modül kendi içerisinde bağımsız olarak çalışır ve veritabanı ile eşzamanlı olarak listelenir.

![CRUD İşlemleri Görseli](https://via.placeholder.com/1200x600?text=CRUD+Islemleri+Ekrani)

#### 2. Gelişmiş Arama ve Filtreleme
* **Alan Bazlı Dinamik Arama:** Kullanıcılar sadece tek bir kelime ile değil, seçtikleri belirli bir alana göre (Örn: Sadece "Marka" içerisinde "Nike" ara veya sadece "Renk" içerisinde "Siyah" ara) spesifik sorgular yapabilirler.
* **Hızlı Sonuçlar:** SQL tarafında güvenli ve hızlı çalışan dinamik filtreleme yapısı sayesinde aranan ürün saniyeler içinde listelenir.

![Arama ve Filtreleme Görseli](https://via.placeholder.com/1200x600?text=Arama+ve+Filtreleme+Ekrani)

#### 3. Görsel İstatistikler ve Dashboard (Raporlama)
* **Anlık Özet Ekranı:** Ana sayfada (Dashboard) gardroptaki tüm ürünlerin detaylı bir özeti sunulur.
* **Kategorik Dağılım:** Kıyafetlerin türüne ve rengine göre dağılımı, ayakkabıların markalarına ve numaralarına göre dağılımı gibi veriler liste halinde yöneticinin karşısına çıkar.
* *Note: PDF ve Excel formatında dışa aktarım modülleri (QuestPDF / EPPlus) projeye entegre edilebilir altyapıya sahiptir.*

![Dashboard Görseli](https://via.placeholder.com/1200x600?text=Dashboard+Ozet+Ekrani)

#### 4. Teknik Altyapı
* **ASP.NET Core Razor Pages:** Hızlı ve sayfa odaklı (Page-Focused) web geliştirme.
* **Native ADO.NET (SqlDataReader & SqlCommand):** Veritabanı ile doğrudan ve yüksek performanslı iletişim (ORM kullanılmadan).
* **Responsive Tasarım (Bootstrap 5):** Mobil ve masaüstü tüm cihazlarda kusursuz çalışan kullanıcı arayüzü.