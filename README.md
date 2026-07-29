# ShopApp

ShopApp, ASP.NET Core ile geliştirilmiş çok katmanlı bir e-ticaret uygulamasıdır. Proje; web arayüzü, REST API, iş katmanı, veri erişim katmanı ve domain modellerinden oluşmaktadır.

## Özellikler

* Ürün listeleme ve detay sayfaları
* Kategoriye göre filtreleme
* Ürün arama
* Sepet işlemleri
* Sipariş oluşturma altyapısı
* Kullanıcı kayıt ve giriş sistemi
* E-posta doğrulama
* Şifre sıfırlama
* Yönetici paneli
* Ürün ve kategori yönetimi
* Kullanıcı ve rol yönetimi
* REST API üzerinden ürün işlemleri

## Kullanılan Teknolojiler

* ASP.NET Core 3.1
* C#
* ASP.NET Core MVC
* ASP.NET Core Identity
* Entity Framework Core
* SQL Server
* SQLite
* Newtonsoft.Json
* CKEditor

## Proje Yapısı

```text
ShopApp/
├── ShopApp.WebUI/        # MVC Web Arayüzü
├── ShoppApp.WebApi/      # REST API
├── ShopApp.Business/     # İş katmanı
├── ShopApp.Data/         # Veri erişim katmanı
├── ShopApp.Entity/       # Domain modelleri
└── ShopApp.sln
```

## Kurulum

### Gereksinimler

* Visual Studio 2019 veya üzeri
* .NET Core 3.1 SDK
* SQL Server

### Adımlar

1. Repoyu klonlayın.

```bash
git clone https://github.com/kullaniciadi/ShopApp.git
```

2. Projeyi Visual Studio ile açın.

```text
ShopApp.sln
```

3. `ShopApp.WebUI/appsettings.json` ve `ShoppApp.WebApi/appsettings.json` dosyalarında veritabanı bağlantı bilgilerini düzenleyin.

4. Gerekli NuGet paketlerini yükleyin.

5. Projeyi derleyin.

```bash
dotnet restore ShopApp.sln
dotnet build ShopApp.sln
```

6. Web uygulamasını çalıştırın.

```bash
dotnet run --project ShopApp.WebUI/ShopApp.WebUI.csproj
```

7. API'yi çalıştırmak için ayrı bir terminal açın.

```bash
dotnet run --project ShoppApp.WebApi/ShoppApp.WebApi.csproj
```

> Her iki proje varsayılan olarak aynı portları kullandığı için birlikte çalıştırılacaksa `launchSettings.json` dosyalarındaki portların değiştirilmesi gerekebilir.

## API

Ürün işlemleri için temel endpoint:

```text
/api/products
```

Desteklenen istekler:

* `GET /api/products/{id}`
* `POST /api/products`
* `PUT /api/products/{id}`
* `DELETE /api/products/{id}`

## Veritabanı

* Entity Framework Core Code First yaklaşımı kullanılmaktadır.
* Uygulama açılışında migration işlemleri uygulanır.
* Örnek ürün ve kategori verileri otomatik olarak eklenebilir.
* Roller ve kullanıcılar başlangıçta oluşturulabilir.

## Notlar

* Web arayüzü ve REST API ayrı projeler olarak geliştirilmiştir.
* Kimlik doğrulama işlemleri ASP.NET Core Identity ile gerçekleştirilmektedir.
* Projede CKEditor metin düzenleyicisi kullanılmaktadır.
* Bu depoda test projesi bulunmamaktadır.

## Geliştirici

**hincim**
