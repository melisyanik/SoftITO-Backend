# BiletSinema

## Türkçe

### Proje Hakkında

BiletSinema, ASP.NET Core MVC ve Entity Framework Core kullanılarak geliştirilmiş bir içerik yönetim sistemidir. Proje kapsamında filmler, diziler, tiyatrolar ve kategoriler için CRUD işlemleri gerçekleştirilmekte, çeşitli raporlama ekranları ve veri analizleri sunulmaktadır.

### Özellikler

#### Film Yönetimi

* Film listeleme
* Film ekleme
* Film güncelleme
* Film silme
* Filtreleme ve arama işlemleri
* PDF ve Excel çıktısı alma

#### Dizi Yönetimi

* Dizi listeleme
* Dizi ekleme
* Dizi güncelleme
* Dizi silme
* Filtreleme ve arama işlemleri
* PDF ve Excel çıktısı alma

#### Tiyatro Yönetimi

* Tiyatro listeleme
* Tiyatro ekleme
* Tiyatro güncelleme
* Tiyatro silme
* Filtreleme ve arama işlemleri
* PDF ve Excel çıktısı alma

#### Kategori Yönetimi

* Kategori listeleme
* Kategori ekleme
* Kategori güncelleme
* Kategori silme
* PDF ve Excel çıktısı alma

#### Raporlama Sistemi

* Film ve kategori ilişkileri
* Kategori bazlı analizler
* LINQ Join sorguları
* LINQ Group By sorguları
* Grafik destekli rapor ekranları
* İstatistiksel veri görüntüleme

### Kullanılan Teknolojiler

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* LINQ
* Bootstrap 5
* Chart.js
* QuestPDF
* EPPlus

### Veritabanı

Projede Code First yaklaşımı kullanılmıştır.

Migration işlemleri:

```powershell
Add-Migration InitialCreate
Update-Database
```

### Kurulum

1. Projeyi klonlayın.
2. appsettings.json dosyasındaki bağlantı cümlesini kendi SQL Server ortamınıza göre düzenleyin.
3. Migration işlemlerini çalıştırın.
4. Projeyi başlatın.

---

## English

### About The Project

BiletSinema is a content management system developed using ASP.NET Core MVC and Entity Framework Core. The project provides CRUD operations for movies, TV series, theaters, and categories, along with reporting screens and data analysis features.

### Features

#### Movie Management

* List movies
* Add movies
* Update movies
* Delete movies
* Search and filtering
* PDF and Excel export

#### TV Series Management

* List TV series
* Add TV series
* Update TV series
* Delete TV series
* Search and filtering
* PDF and Excel export

#### Theater Management

* List theaters
* Add theaters
* Update theaters
* Delete theaters
* Search and filtering
* PDF and Excel export

#### Category Management

* List categories
* Add categories
* Update categories
* Delete categories
* PDF and Excel export

#### Reporting System

* Movie and category relationship reports
* Category-based analysis
* LINQ Join queries
* LINQ Group By queries
* Chart-based reporting screens
* Statistical data visualization

### Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* LINQ
* Bootstrap 5
* Chart.js
* QuestPDF
* EPPlus

### Database

The project uses the Code First approach.

Migration commands:

```powershell
Add-Migration InitialCreate
Update-Database
```

### Installation

1. Clone the repository.
2. Configure the connection string in appsettings.json.
3. Run the migrations.
4. Start the application.

### Purpose

This project was developed for educational, learning, and portfolio purposes.
