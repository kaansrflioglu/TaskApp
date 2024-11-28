
# Görev Yönetim Uygulaması (Backend ve Frontend)

Bu proje, görev yönetimi için geliştirilmiş bir tam yığın web uygulamasıdır. **React tabanlı frontend** ve **ASP.NET Core tabanlı backend** ile SQL Server kullanılarak hazırlanmıştır. Kullanıcılar, görev oluşturabilir, listeleyebilir ve düzenleyebilir.

----------

## Kullanılan Teknolojiler

-   **Frontend**: React
-   **Backend**: ASP.NET Core
-   **Veritabanı**: SQL Server 
-   **ORM**: Entity Framework Core
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

## Kurulum Talimatları

### Backend Kurulumu (ASP.NET Core)

#### Gereksinimler

-   [.NET SDK](https://dotnet.microsoft.com/download) yükleyin.  
    Kurulum doğrulaması için:
    
    `dotnet --version` 
    
-   SQL Server yükleyin ve yapılandırın.
    

#### Backend Çalıştırma Adımları

1.  Proje dosyalarını klonlayın ve backend dizinine gidin ve bağımlılıkları yükleyin:
     
    `dotnet restore` 
    
2.  `appsettings.json` dosyasındaki bağlantı dizesini (connection string) SQL Server için uygun şekilde düzenleyin.
    
3.  Veritabanını oluşturmak için migration işlemini uygulayın:
  
    `dotnet ef database update` 
    
4.  Uygulamayı çalıştırın:
       
    `dotnet run` 
    
    Backend, `http://localhost:5000` adresinde (veya yapılandırmada belirtilen portta) çalışacaktır.
    

#### API Endpoints (Servisler)

-   `POST /api/tasks`: Yeni görev oluşturma.
-   `GET /api/tasks`: Tüm görevleri listeleme.
-   `GET /api/tasks/{id}`: Belirli bir görevi ID ile getirme.
-   `PUT /api/tasks/{id}`: Mevcut bir görevi düzenleme.

### Frontend Kurulumu (React)

#### Gereksinimler

-   [Node.js](https://nodejs.org/) yükleyin.  
    Kurulum doğrulaması için:
    `node -v` 
    `npm -v` 

#### Frontend Çalıştırma Adımları

1.  Frontend dizinine gidin ve gerekli bağımlılıkları yükleyin:
     
    `npm install` 
       
2.  React uygulamasını başlatın:
        
    `npm start` 
    
    Frontend, `http://localhost:3000` adresinde çalışacaktır.