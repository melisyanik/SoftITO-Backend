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

### 🚀 Scope & Capabilities

#### 1. Comprehensive Management & Search (Search + CRUD)
* **Clothes, Shoes, and Jewelry Management:** Add new items to the system, update details (color, brand, size, etc.) of existing items, or delete them (CRUD).
* **Field-Based Dynamic Search:** Users can perform granular searches by selecting specific fields via a combobox (e.g., search for "Nike" only within "Brand", or "Black" only within "Color").
* **Fast Results:** Thanks to the secure and fast dynamic filtering structure on the SQL side, the searched item is listed in seconds, synchronized with the CRUD operations.

Adding new clothes:
<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 023815" src="https://github.com/user-attachments/assets/55ee217f-98a4-437a-a0fc-d7147dd0ae81" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 023905" src="https://github.com/user-attachments/assets/3c7e595d-0034-4ef4-8468-46bccf2dfbdd" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 023913" src="https://github.com/user-attachments/assets/2ab23577-8ccb-416d-a6ba-1baacbf45d71" />

Searching for shoes:
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 023926" src="https://github.com/user-attachments/assets/23033b0a-9525-42ae-b669-c86a8845d2ad" />
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 023944" src="https://github.com/user-attachments/assets/3523a979-3545-4903-a826-9aeee879e83b" />
<img width="1919" height="911" alt="Ekran görüntüsü 2026-07-04 024052" src="https://github.com/user-attachments/assets/befc7613-4ca4-4767-a839-615bbdf41d85" />

Updating accessory:
<img width="1919" height="910" alt="Ekran görüntüsü 2026-07-04 024118" src="https://github.com/user-attachments/assets/f836f2d9-6ea6-4714-ab96-ca13e2fedd1f" />
<img width="1919" height="913" alt="Ekran görüntüsü 2026-07-04 024147" src="https://github.com/user-attachments/assets/0f62f45d-bb0c-4e94-9047-d464102f10ac" />
Searching according to feature:
<img width="1919" height="907" alt="Ekran görüntüsü 2026-07-04 024230" src="https://github.com/user-attachments/assets/a0019025-2b96-42cd-a3bc-beddf358eea9" />

#### 2. Visual Statistics & Dashboard (Reporting)
* **Instant Summary Screen:** A detailed summary of all items in the wardrobe is presented on the main page (Dashboard).
* **Categorical Distribution:** Data such as the distribution of clothes by type and color, and the distribution of shoes by brand and size, are presented as lists.

<img width="1919" height="912" alt="Ekran görüntüsü 2026-07-04 023803" src="https://github.com/user-attachments/assets/19f51e47-d8d9-44b9-9821-cf0673dd0fd6" />

#### 3. Technical Infrastructure
* **ASP.NET Core Razor Pages:** Fast and Page-Focused web development.
* **Native ADO.NET (SqlDataReader & SqlCommand):** Direct and high-performance communication with the database without an ORM.
* **Responsive Design (Bootstrap 5):** A user interface that works flawlessly across all mobile and desktop devices.

---

## 🇹🇷 Türkçe Dokümantasyon

### 🎯 Proje Özeti
Gardrobum (My Wardrobe), kullanıcıların kişisel kıyafet, ayakkabı ve takı koleksiyonlarını dijital ortamda düzenlemesi, takip etmesi ve raporlaması için geliştirilmiş bir web uygulamasıdır. ASP.NET Core Razor Pages **Monolitik Mimarisi** üzerinde, native **ADO.NET** ve SQL Server kullanılarak inşa edilen bu sistem; kıyafetlerin türüne, rengine veya markasına göre kategorize edilmesini ve gelişmiş arama seçenekleriyle kolayca bulunmasını sağlar.

![Proje Özeti Görseli](https://via.placeholder.com/1200x600?text=Proje+Ozet+Ekrani)

### 🚀 Kapsam ve Yetenekler

#### 1. Kapsamlı Yönetim ve Arama (Search + CRUD)
* **Kıyafet, Ayakkabı ve Takı Yönetimi:** Sisteme yeni ürünler ekleme, mevcut ürünlerin detaylarını (renk, marka, numara, beden vb.) güncelleme veya silme işlemleri (CRUD).
* **Alan Bazlı Dinamik Arama:** Kullanıcılar sadece tek bir kelime ile değil, açılır kutu (combobox) üzerinden seçtikleri belirli bir alana göre (Örn: Sadece "Marka" içerisinde "Nike" ara veya sadece "Renk" içerisinde "Siyah" ara) detaylı sorgular yapabilirler.
* **Hızlı Sonuçlar:** SQL tarafında güvenli ve hızlı çalışan dinamik filtreleme yapısı sayesinde, CRUD işlemleriyle eşzamanlı olarak aranan ürün saniyeler içinde listelenir.

![Arama ve CRUD İşlemleri Görseli](https://via.placeholder.com/1200x600?text=Arama+ve+CRUD+Islemleri+Ekrani)

#### 2. Görsel İstatistikler ve Dashboard (Raporlama)
* **Anlık Özet Ekranı:** Ana sayfada (Dashboard) gardroptaki tüm ürünlerin detaylı bir özeti sunulur.
* **Kategorik Dağılım:** Kıyafetlerin türüne ve rengine göre dağılımı, ayakkabıların markalarına ve numaralarına göre dağılımı gibi veriler liste halinde yöneticinin karşısına çıkar.

![Dashboard Görseli](https://via.placeholder.com/1200x600?text=Dashboard+Ozet+Ekrani)

#### 3. Analitik ve Dışa Aktarım Süreçleri
* **PDF Raporları:** Kıyafet, ayakkabı ve takılar için baskıya hazır idari raporlar oluşturmak amacıyla `QuestPDF` entegrasyonu.
* **Excel Tabloları:** Tüm koleksiyon verilerini standart Excel formatlarında dışa aktarmak için `EPPlus` entegrasyonu.

![PDF ve Excel Modülleri Görseli](https://via.placeholder.com/1200x600?text=PDF+ve+Excel+Modulleri+Ekrani)

#### 4. Teknik Altyapı
* **ASP.NET Core Razor Pages:** Hızlı ve sayfa odaklı (Page-Focused) web geliştirme.
* **Native ADO.NET (SqlDataReader & SqlCommand):** Veritabanı ile doğrudan ve yüksek performanslı iletişim (ORM kullanılmadan).
* **Responsive Tasarım (Bootstrap 5):** Mobil ve masaüstü tüm cihazlarda kusursuz çalışan kullanıcı arayüzü.
