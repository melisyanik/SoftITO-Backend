# 🎮 Oyun Evreni (Game Universe)

Oyun Evreni, kullanıcıların oyunlara göz atıp satın alabildiği ve kütüphanelerinde (Oyunlarım) biriktirebildiği, yöneticilerin ise tüm sistemi kontrol edebildiği kapsamlı bir ASP.NET Core MVC web uygulamasıdır.

![Proje Kapak Görseli - Placeholder](https://via.placeholder.com/1200x600?text=Oyun+Evreni+Ana+Sayfa)

## 🌟 Proje Kapsamı ve Özellikler

Bu proje, bir e-ticaret (oyun satışı) sisteminin uçtan uca çalışır halini simüle eder. Modern web standartları, ASP.NET Core Identity güvenliği ve Entity Framework Core (Code-First) yapısı kullanılarak geliştirilmiştir.

### 👤 Kullanıcı Özellikleri (Müşteri)
* **Kayıt ve Giriş:** ASP.NET Core Identity tabanlı, güvenli şifreleme ile üyelik sistemi.
* **Oyun Keşfi:** Ana sayfada dinamik olarak oyunları listeleme, modern neon ve glassmorphism temalı kartlarla gösterim.
* **Satın Alma (Sipariş):** İstenen oyunu seçip tek tıkla sipariş verme.
* **Sipariş Takibi:** Siparişlerim menüsünden mevcut siparişlerin durumunu (Beklemede, Onaylandı vs.) takip edebilme.
* **Oyun Kütüphanesi (Oyunlarım):** Satın alınan oyunları tekil olarak kütüphanede görebilme, admin onayına bağlı statü renklerini (badge) anlık takip edebilme.

![Kullanıcı Paneli Görseli - Placeholder](https://via.placeholder.com/800x450?text=Kullanici+Paneli+Oyunlarim)

### 👑 Yönetici Özellikleri (Admin Panel)
* **Güvenli Erişim:** Sadece "Admin" rolüne sahip kullanıcıların erişebildiği tamamen ayrı, özel tasarımlı bir yönetim paneli.
* **Dashboard & Raporlar:** Toplam oyun sayısı, toplam müşteri, toplam gelir, son siparişler ve en çok satan oyunlar gibi verilerin yer aldığı dinamik istatistik paneli.
* **Oyun Yönetimi (CRUD):** Yeni oyun ekleme, güncelleme, silme ve listeleme.
* **Sipariş Yönetimi:** Kullanıcıların verdiği siparişleri görme, sipariş statülerini ("Onaylandı", "Beklemede" vb.) değiştirme.
* **Dışa Aktarım (Export):** QuestPDF ve EPPlus kütüphaneleri kullanılarak tüm raporları, müşteri ve sipariş listelerini **PDF** ve **Excel** formatında indirebilme.

![Admin Paneli Görseli - Placeholder](https://via.placeholder.com/800x450?text=Admin+Dashboard+ve+Raporlar)

## 🛠 Kullanılan Teknolojiler
* **Backend:** C# / .NET 9, ASP.NET Core MVC
* **Veritabanı:** Microsoft SQL Server
* **ORM:** Entity Framework Core (Code-First Migration)
* **Güvenlik:** ASP.NET Core Identity (Kullanıcı, Rol, Şifre Hashleme)
* **Frontend:** HTML5, CSS3, Bootstrap 5, Glassmorphism UI & Neon efektler
* **PDF / Excel Çıktısı:** QuestPDF, EPPlus

## 🚀 Kurulum ve Çalıştırma

1. Projeyi bilgisayarınıza klonlayın:
   ```bash
   git clone <repository_url>
   ```
2. Çözüm (Solution) dosyasını `OyunSatinAlma.sln` Visual Studio'da açın.
3. Gerekli paketleri indirmek için Package Manager Console'da veya terminalde:
   ```bash
   dotnet restore
   ```
4. `OyunSatinAlma` (Web Projesi) içerisindeki `appsettings.json` dosyasında bulunan **ConnectionStrings** yolunu kendi SQL Server ayarlarınıza göre düzenleyin.
5. Veritabanını oluşturmak için Entity Framework (Migration) komutlarını çalıştırın:
   ```bash
   dotnet ef database update --project OyunSatinAlma.DATA --startup-project OyunSatinAlma
   ```
6. Projeyi başlatın (`F5`). İlk açılışta sistem veritabanında standart bir Admin rolü ve hesabını oluşturacaktır:
   * **Admin E-posta:** `admin@admin.com`
   * **Admin Şifre:** `Admin123!`

---
*Geliştirilmiş ve tasarlanmış kullanıcı deneyimi odaklı, tam kapsamlı bir oyun satış platformu!*