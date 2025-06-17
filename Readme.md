# 🌍 Traversal Core Project

**Traversal Core**, modern web teknolojileri kullanılarak ASP.NET Core 5 ile geliştirilen, kullanıcıların seyahat destinasyonlarını keşfedip yorum bırakabileceği, yönetici ve üye alanları bulunan, çok katmanlı ve gelişmiş bir turizm uygulamasıdır.

## 🚀 Teknolojiler ve Mimariler

### 🔧 Backend
- **ASP.NET Core 5**
- **Entity Framework Core**
- **MSSQL Database**
- **Fluent Validation** — Server-side validasyon kuralları
- **Client-Side Validation** — jQuery Unobtrusive ile canlı doğrulama
- **AutoMapper & DTO Katmanı** — Veri aktarımını izole ve güvenli yapar
- **CQRS + MediatR** — Komut ve sorguların ayrılmasıyla temiz mimari
- **Unit of Work Design Pattern** — Veritabanı işlemlerinde bütünlük sağlar
- **SignalR** — Gerçek zamanlı bildirim sistemi (örneğin mesaj bildirimi)
- **MailKit** — Şifre sıfırlama ve bildirim amaçlı e-posta gönderimi
- **RapidAPI Entegrasyonu** — Dış servislerle etkileşim (ör. hava durumu, kur bilgisi)
- **ASP.NET Identity** — Kullanıcı yönetimi, roller ve kimlik doğrulama

### 🎨 Frontend
- **Razor View Engine**
- **Bootstrap 4/5**
- **AJAX ile Dinamik İşlemler** — Sayfa yenilenmeden veri güncelleme, silme vb.
- **SweetAlert & Toast** — Kullanıcı dostu bildirim sistemi

---

## 🔐 Giriş & Yetkilendirme

- **Login / Register** işlemleri
- **E-posta ile şifre sıfırlama** özelliği
- **Rol bazlı yetkilendirme** (Admin / Member / SuperAdmin vb.)
- **Rol oluşturma, silme ve atama** paneli

---

## 👥 Uygulama Alanları

Traversal Core projesi, farklı kullanıcı yetkilerine göre bölümlenmiş 3 ana alandan oluşur: **Admin**, **Member**, ve **Default (Genel Kullanıcı)**. Her alan, kullanıcının rolüne göre özel olarak yapılandırılmıştır.

---

### 🔒 Admin Area

Yalnızca yöneticilerin erişebildiği gelişmiş yönetim panelidir. Aşağıdaki işlemler yapılabilir:

- **Kullanıcı Yönetimi** – Üyelerin görüntülenmesi ve düzenlenmesi  
- **Account** – Yönetici hesap ayarları  
- **Announcement** – Duyuru ekleme ve listeleme  
- **API Movie** – Film verilerinin RapidAPI üzerinden alınması  
- **Booking** – Rezervasyon yönetimi  
- **City (AJAX ile)** – Şehir işlemleri dinamik olarak gerçekleştirilir  
- **Comment** – Kullanıcı yorumlarını inceleme ve silme  
- **Contact** – İletişim mesajlarını görüntüleme  
- **Dashboard** – Genel istatistik ve yönetim ekranı  
- **Destination** – Destinasyon ekleme, silme, güncelleme  
- **Guide** – Rehber bilgilerini yönetme  
- **Mail** – Kullanıcılara e-posta gönderimi  
- **Visitor API** – Ziyaretçi verilerinin API ile entegrasyonu  
- **Rol Yönetimi** – Rol ekleme, silme, kullanıcıya rol atama  
- **Gerçek Zamanlı Bildirim** – SignalR ile anlık bildirimler  

---

### 👤 Member Area

Giriş yapmış üyelere özel kullanıcı panelidir. Aşağıdaki işlemler yapılabilir:

- **Dashboard** – Kullanıcıya özel özet ekran  
- **Comment** – Yorum ekleme ve silme  
- **Destination** – Gezilecek yerleri listeleme  
- **Message** – Kullanıcılar arası mesajlaşma  
- **Profile** – Kişisel bilgileri güncelleme  
- **Rezervation** – Yeni rezervasyon oluşturma, geçmiş rezervasyonları görüntüleme  

---

### 🌐 Default (Genel Kullanıcı Alanı)

Giriş yapmamış ziyaretçiler için açık olan genel site alanıdır:

- **Login** – Kullanıcı girişi  
- **Guide** – Rehberleri listeleme  
- **Destination Listesi** – Seyahat rotalarını gezme  
- **Comment** – Genel yorum görüntüleme  
- **Contact** – İletişim formu ile mesaj gönderme  
- **Information** – Hakkımızda / Bilgi sayfaları  
- **Şifre Değiştirme ve Profil** – (Giriş sonrası) kullanıcı bilgilerini güncelleme  

---
## 💬 Özellikler

- ✅ Kullanıcılar destinasyonlara **yorum bırakabilir**, listeleyebilir
- ✅ **Ajax** ile form gönderimi ve yorum silme işlemleri
- ✅ **DTO yapısı** sayesinde veri güvenliği ve hızı
- ✅ **CQRS & MediatR** ile yazılım sorumlulukları ayrıştırılmıştır
- ✅ **Fluent Validation** ile model düzeyinde kurallar uygulanır
- ✅ **SignalR ile gerçek zamanlı bildirim** gönderilebilir
- ✅ **E-posta doğrulama ve şifre sıfırlama** işlemleri
- ✅ **Unit of Work** ile repository işlemleri yönetilir

---

## 🧪 Kurulum

1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/kullaniciadi/traversal-core.git

2. appsettings.json dosyasındaki ConnectionString ve Mail ayarlarını güncelleyin.

3. Database oluşturmak için:
 ```bash
	Update-Database 

4. Uygulamayı çalıştırın:
 ```bash
	dotnet run

📸 Görseller



📬 İletişim
Projeyle ilgili geri bildirimde bulunmak için Issues kısmını kullanabilirsiniz.