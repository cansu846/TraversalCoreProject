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
```
---

## 📸 Görseller
![Screenshot 2025-06-17 110602](https://github.com/user-attachments/assets/280ce89a-f703-4f42-85a8-bf4452967d28)
![Screenshot 2025-06-17 110607](https://github.com/user-attachments/assets/66c2d1f3-ff8e-4b94-9391-12e513797c63)
![Screenshot 2025-06-17 110624](https://github.com/user-attachments/assets/f548bbf1-2604-4746-83bb-aeaa55ebd57d)
![Screenshot 2025-06-17 111219](https://github.com/user-attachments/assets/34637b64-cdd1-4842-9a0f-50cbf63071fe)
![Screenshot 2025-06-17 111224](https://github.com/user-attachments/assets/910ec835-acf4-4a3b-a0b1-bc2a17dfe308)
![Screenshot 2025-06-17 111310](https://github.com/user-attachments/assets/4b067fa5-876c-4ecd-a484-421e5d37f074)
![Screenshot 2025-06-17 111316](https://github.com/user-attachments/assets/00aa9ed1-34d7-4497-8b19-f2d5c6260da4)
![Screenshot 2025-06-17 111324](https://github.com/user-attachments/assets/0e14065b-519e-4512-a571-cdffb181fdc3)
![Screenshot 2025-06-17 111334](https://github.com/user-attachments/assets/83440a1c-122e-42b3-a943-b6516e41cad7)
![Screenshot 2025-06-17 111345](https://github.com/user-attachments/assets/be440c01-03b3-4ab3-be30-643585667366)
![Screenshot 2025-06-17 111353](https://github.com/user-attachments/assets/fb443120-951d-4cf0-ac69-0f6b93a571ef)
![Screenshot 2025-06-17 111400](https://github.com/user-attachments/assets/a6f336d2-c34d-4a74-858f-07ebfd6e5a3f)
![Screenshot 2025-06-17 111406](https://github.com/user-attachments/assets/a0cbc77d-85e1-4926-b8ea-3b7d641314b8)
![Screenshot 2025-06-17 111417](https://github.com/user-attachments/assets/11033d1d-762b-48d1-bcc0-6017e99c86e5)
![Screenshot 2025-06-17 111426](https://github.com/user-attachments/assets/1094191a-ebb0-4495-bc82-0172add11698)
![Screenshot 2025-06-17 111431](https://github.com/user-attachments/assets/93d06c19-1921-47e4-af32-39a307cf870c)
![Screenshot 2025-06-17 111436](https://github.com/user-attachments/assets/a5586851-1dac-4f47-8aff-4221698b06df)
![Screenshot 2025-06-17 111449](https://github.com/user-attachments/assets/0a3554ee-1292-472c-a6b5-97b415aa7dfb)
![Screenshot 2025-06-17 111608](https://github.com/user-attachments/assets/c711a115-4b95-425e-9d91-8e6a6dff6d2b)
![Screenshot 2025-06-17 111701](https://github.com/user-attachments/assets/ee5e3cf3-ad83-40d8-874b-1512dce4ef4d)
![Screenshot 2025-06-17 111724](https://github.com/user-attachments/assets/b4a42d8f-4525-4dde-98aa-eb22a6e33b5d)
![Screenshot 2025-06-17 111757](https://github.com/user-attachments/assets/b8c98d3b-38d8-4409-9255-0d01b2c5fff1)
![Screenshot 2025-06-17 111854](https://github.com/user-attachments/assets/90129a33-89df-4ea6-aa00-be58467b6e2a)
![Screenshot 2025-06-17 121250](https://github.com/user-attachments/assets/08148a9e-4c12-4668-8470-f01909bb9a2a)
![Screenshot 2025-06-17 121335](https://github.com/user-attachments/assets/7774fa41-52a1-4231-a6b5-f9cc7cec9725)
![Screenshot 2025-06-17 121355](https://github.com/user-attachments/assets/3cf3c43d-0c12-4f06-9ad1-4b1d938fc891)
![Screenshot 2025-06-17 131445](https://github.com/user-attachments/assets/74fe8cd1-5b40-4eed-924d-1b45b75b032f)
![Screenshot 2025-06-17 121404](https://github.com/user-attachments/assets/22346e63-9a46-425a-ba34-4ce931130f9e)
![Screenshot 2025-06-17 121412](https://github.com/user-attachments/assets/ee7b8632-c2c1-4e9c-8025-da43869725b0)

📬 İletişim
Projeyle ilgili geri bildirimde bulunmak için Issues kısmını kullanabilirsiniz.
