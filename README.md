# 🗓️ Etkinlik Yönetim Sistemi

Modern ve kullanıcı dostu bir etkinlik yönetim sistemi. ASP.NET Core MVC kullanılarak geliştirilmiş, etkinlikleri oluşturma, düzenleme ve takip etme imkanı sunan web uygulaması.

## ✨ Özellikler

### 🎯 Ana Özellikler
- **Etkinlik Oluşturma**: Yeni etkinlikler oluşturma ve yönetme
- **Takvim Görünümü**: FullCalendar.js ile interaktif takvim
- **Kullanıcı Yönetimi**: Kayıt olma, giriş yapma ve profil yönetimi
- **Admin Paneli**: Etkinlik yönetimi ve sistem kontrolü
- **Responsive Tasarım**: Mobil ve masaüstü uyumlu

### 🎨 Modern UI/UX
- **Glassmorphism Tasarım**: Cam görünümlü modern kartlar
- **Gradient Arka Planlar**: Mor-mavi geçişli modern renkler
- **Smooth Animasyonlar**: Hover efektleri ve geçişler
- **Google Fonts**: Inter font ailesi
- **Font Awesome**: Modern ikonlar

## 🚀 Teknolojiler

### Backend
- **ASP.NET Core 8.0** - Web framework
- **Entity Framework Core** - ORM
- **SQL Server** - Veritabanı
- **BCrypt.Net-Next** - Şifre hashleme

### Frontend
- **Bootstrap 5** - CSS framework
- **jQuery** - JavaScript kütüphanesi
- **FullCalendar.js** - Takvim bileşeni
- **Font Awesome 6** - İkon kütüphanesi
- **Google Fonts** - Tipografi

## 📋 Gereksinimler

- .NET 8.0 SDK
- SQL Server (LocalDB veya SQL Server Express)
- Visual Studio 2022 veya VS Code

## 🛠️ Kurulum

### 1. Repository'yi Klonlayın
```bash
git clone https://github.com/kullaniciadi/etkinlik-yonetim-sistemi.git
cd etkinlik-yonetim-sistemi
```

### 2. Veritabanını Hazırlayın
```bash
cd EventManagement.Web
dotnet ef database update
```

### 3. Uygulamayı Çalıştırın
```bash
dotnet run
```

### 4. Tarayıcıda Açın
- **Ana Sayfa**: `https://localhost:5001`
- **Alternatif**: `http://localhost:5000`

## 📁 Proje Yapısı

```
EventManagement.Web/
├── Controllers/          # MVC Controllers
├── Models/              # Veri modelleri
├── Views/               # Razor view'ları
├── Services/            # İş mantığı servisleri
├── Data/                # Entity Framework context
├── ViewModels/          # View modelleri
└── wwwroot/             # Statik dosyalar
    ├── css/             # CSS dosyaları
    ├── js/              # JavaScript dosyaları
    └── lib/             # Kütüphane dosyaları
```

## 🎯 Kullanım

### Kullanıcı İşlemleri
1. **Kayıt Ol**: Yeni hesap oluşturma
2. **Giriş Yap**: Mevcut hesapla giriş
3. **Profil Yönetimi**: Bilgileri güncelleme

### Etkinlik Yönetimi
1. **Etkinlik Oluştur**: Yeni etkinlik ekleme
2. **Etkinlik Düzenle**: Mevcut etkinlikleri güncelleme
3. **Etkinlik Sil**: Etkinlikleri kaldırma
4. **Takvim Görünümü**: Etkinlikleri takvimde görüntüleme

### Admin Paneli
1. **Dashboard**: Genel istatistikler
2. **Etkinlik Yönetimi**: Tüm etkinlikleri yönetme
3. **Kullanıcı Yönetimi**: Kullanıcı hesaplarını yönetme

## 🎨 Tasarım Özellikleri

### Modern CSS
- **Gradient Arka Planlar**: `linear-gradient(135deg, #667eea 0%, #764ba2 100%)`
- **Glassmorphism**: `backdrop-filter: blur(10px)`
- **Smooth Animasyonlar**: `transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1)`
- **Custom Scrollbar**: Özel tasarlanmış kaydırma çubuğu

### Responsive Tasarım
- **Mobile First**: Mobil öncelikli tasarım
- **Bootstrap Grid**: Responsive grid sistemi
- **Flexbox**: Modern layout teknikleri

## 🔧 Geliştirme

### Yeni Özellik Ekleme
1. Model sınıfını oluşturun
2. Controller action'larını ekleyin
3. View'ları oluşturun
4. CSS stillerini ekleyin

### Veritabanı Değişiklikleri
```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

## 📸 Ekran Görüntüleri

### Ana Sayfa
- Modern hero section
- İstatistik kartları
- Etkinlik listesi

### Takvim Görünümü
- FullCalendar.js entegrasyonu
- Etkinlik detayları
- Responsive tasarım

### Admin Paneli
- Dashboard kartları
- Hızlı işlemler
- İstatistikler

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Commit yapın (`git commit -m 'Add some AmazingFeature'`)
4. Push yapın (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakın.

## 👨‍💻 Geliştirici

**Esat Berat** - [GitHub](https://github.com/kullaniciadi)

## 🙏 Teşekkürler

- [Bootstrap](https://getbootstrap.com/) - CSS Framework
- [Font Awesome](https://fontawesome.com/) - İkonlar
- [FullCalendar](https://fullcalendar.io/) - Takvim bileşeni
- [Google Fonts](https://fonts.google.com/) - Tipografi

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın! 