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
![Screenshot 2025-06-17 111426](https://github.com/user-attachments/assets/778209cd-f54e-4ca6-be70-bbd593e6c011)
![Screenshot 2025-06-17 111417](https://github.com/user-attachments/assets/09ba2c96-8865-4712-ad0b-cef4006c7e9a)
![Screenshot 2025-06-17 111406](https://github.com/user-attachments/assets/1c7e7c0d-0832-4df8-8856-4d14b6041490)
![Screenshot 2025-06-17 111400](https://github.com/user-attachments/assets/0b6a6ee9-faf9-421c-aea2-345ba4be7565)
![Screenshot 2025-06-17 111353](https://github.com/user-attachments/assets/3dd21af9-f8c6-4cef-9b6d-b45690ca743e)
![Screenshot 2025-06-17 111345](https://github.com/user-attachments/assets/49c2efe6-c015-4685-9a00-ea64276af43b)
![Screenshot 2025-06-17 111334](https://github.com/user-attachments/assets/22931b26-1149-4284-8743-9ee47c62025d)
![Screenshot 2025-06-17 111324](https://github.com/user-attachments/assets/3da863b5-abc7-4584-a20d-33412c7c5bd8)
![Screenshot 2025-06-17 111316](https://github.com/user-attachments/assets/c7a706d1-2aea-4f18-a668-207b6c5c3d08)
![Screenshot 2025-06-17 111310](https://github.com/user-attachments/assets/4ca25225-2056-4261-af02-cd3a86c440c8)
![Screenshot 2025-06-17 111224](https://github.com/user-attachments/assets/d41cf434-bac0-403e-a5f5-7fd28e35482c)
![Screenshot 2025-06-17 111219](https://github.com/user-attachments/assets/8bcba31f-c1a8-4489-b73e-fcd201b5ebe4)
![Screenshot 2025-06-17 110624](https://github.com/user-attachments/assets/fa951431-0b71-4e0a-a1fb-7de2901f5ceb)
![Screenshot 2025-06-17 110607](https://github.com/user-attachments/assets/95f7ba8d-2912-416a-8560-bc4b8cc72bd9)
![Screenshot 2025-06-17 110602](https://github.com/user-attachments/assets/3962ebef-a1e1-471f-81cc-47570f6c8507)
![Screenshot 2025-06-17 121412](https://github.com/user-attachments/assets/f36f1eb5-3c9f-405a-a314-50f4b76a1ec6)
![Screenshot 2025-06-17 121404](https://github.com/user-attachments/assets/0beadf65-26ba-49d5-b8af-4f6fe2b56411)
![Screenshot 2025-06-17 121355](https://github.com/user-attachments/assets/467f7753-b323-425f-868e-0b8559d0e28a)
![Screenshot 2025-06-17 121335](https://github.com/user-attachments/assets/8898b7d6-1af5-48c4-93c5-c7c9d12f49f0)
![Screenshot 2025-06-17 121250](https://github.com/user-attachments/assets/a3a1b71d-c5a4-47f9-b4a1-bc46c58017a2)
![Screenshot 2025-06-17 111854](https://github.com/user-attachments/assets/c2b85b34-2040-494a-8382-bd7ddb3c6012)
![Screenshot 2025-06-17 111757](https://github.com/user-attachments/assets/0e1e2c78-13ea-40ba-a106-0d35bccc2b80)
![Screenshot 2025-06-17 111724](https://github.com/user-attachments/assets/07944c02-2f1e-4ef4-8451-192e6287fb26)
![Screenshot 2025-06-17 111701](https://github.com/user-attachments/assets/987eff14-9dd5-4236-8423-6883d2be65e8)
![Screenshot 2025-06-17 111608](https://github.com/user-attachments/assets/b9ecb345-aed8-40d4-9e08-2a3bf1a51ebe)
![Screenshot 2025-06-17 111449](https://github.com/user-attachments/assets/d4da78b7-706f-43e2-98cb-c5825d640479)
![Screenshot 2025-06-17 111436](https://github.com/user-attachments/assets/b8d89535-249b-4097-ada1-904f3c38c1f2)
![Screenshot 2025-06-17 111431](https://github.com/user-attachments/assets/66be1f7b-7acc-4569-93c3-1ee346d4ea2a)


📬 İletişim
Projeyle ilgili geri bildirimde bulunmak için Issues kısmını kullanabilirsiniz.
