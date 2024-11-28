
# Görev Yönetim Uygulaması (Backend ve Frontend)

Bu proje, görev yönetimi için geliştirilmiş bir tam yığın web uygulamasıdır. **React tabanlı frontend** ve **ASP.NET Core tabanlı backend** ile SQL Server kullanılarak hazırlanmıştır. Kullanıcılar, görev oluşturabilir, listeleyebilir ve düzenleyebilir.

----------

## Kullanılan Teknolojiler

-   **Frontend**: React
-   **Backend**: ASP.NET Core
-   **Veritabanı**: SQL Server
-   **ORM**: Entity Framework Core
-   **Test Framework**: xUnit
-   **Paket Yöneticisi**: npm (frontend için)

----------

## Uygulama Hakkında

Bu web uygulaması, kullanıcıların görevlerini yönetmelerini sağlar. Görev ekleme, görüntüleme ve düzenleme gibi işlemler kullanıcı dostu bir arayüz ve sağlam bir API altyapısı ile gerçekleştirilir.

### Temel Özellikler

-   **Görev Ekleme**: Başlık ve isteğe bağlı açıklama ile yeni görev ekleyin.
-   **Görev Listeleme**: Tüm görevleri başlık, açıklama ve oluşturulma tarihi ile görüntüleyin.
-   **Görev Düzenleme**: Mevcut bir görevin başlığını ve açıklamasını güncelleyin.
-   **Gerçek Zamanlı Güncelleme**: Görev listesi, ekleme veya düzenleme işlemleri sonrası dinamik olarak güncellenir.
-   **Hata Yönetimi**: Görev ekleme veya düzenleme gibi işlemler sonrası başarı veya hata mesajları gösterilir.

----------

## Kurulum Talimatları

### Backend Kurulumu (ASP.NET Core)

#### Gereksinimler

-   [.NET SDK](https://dotnet.microsoft.com/download)
-   SQL Server

#### Backend Çalıştırma Adımları

1.  Proje dosyalarını klonlayın ve backend dizinine gidin.
2.  `appsettings.json` dosyasındaki bağlantı dizesini düzenleyerek SQL Server yapılandırmasını yapın.
3.  Veritabanını oluşturmak için migration işlemini uygulayın:  
    `dotnet ef database update`
4.  Backend API'sini çalıştırın:  
    `dotnet run`

#### API Endpoints (Servisler)

-   `POST /api/tasks`: Yeni görev oluşturma.
-   `GET /api/tasks`: Tüm görevleri listeleme.
-   `GET /api/tasks/{id}`: Belirli bir görevi ID ile getirme.
-   `PUT /api/tasks/{id}`: Mevcut bir görevi düzenleme.

----------

### Frontend Kurulumu (React)

#### Gereksinimler

-   [Node.js](https://nodejs.org/)

#### Frontend Çalıştırma Adımları

1.  Proje dosyalarını klonlayın ve frontend dizinine gidin.
2.  Gerekli bağımlılıkları yüklemek için:  
    `npm install`
3.  React uygulamasını başlatın:  
    `npm start`
----------

## Testler

Bu proje, backend tarafında CRUD işlemleri için xUnit tabanlı bir test altyapısına sahiptir. Testler, uygulamanın temel API işlevlerinin doğru çalıştığını doğrular.

#### Test Edilen İşlevler

-   **Görev Listeleme**: Tüm görevlerin başarıyla listelendiğini doğrular.
-   **Görev Ekleme**: Geçerli verilerle yeni görev ekleme işlemini test eder.
-   **Görev Getirme**: Belirli bir görevi ID ile getirme işlemini doğrular.
-   **Görev Güncelleme**: Mevcut bir görevin başarılı bir şekilde güncellendiğini doğrular.
-   **Hata Yönetimi**: Geçersiz verilerle yapılan işlemler sonrası beklenen hata mesajlarının döndüğünü test eder.

#### Testlerin Çalıştırılması

Testleri çalıştırmak için backend dizininde aşağıdaki komutu kullanın:  
    `dotnet test`