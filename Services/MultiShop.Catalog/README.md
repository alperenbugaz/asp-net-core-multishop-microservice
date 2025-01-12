# MongoDB 


## NoSQL Nedir ?

NoSQL, son yıllarda artan veri miktarı ve hızı nedeniyle geleneksel ilişkisel veritabanı sistemlerine alternatif olarak geliştirilmiştir. İlişkisel veritabanları verileri tablo ve sütunlarla ilişkili bir yapıda saklarken, NoSQL sistemleri genellikle JSON formatında tutar. 

NoSQL'in avantajları arasında daha yüksek performans (okuma ve yazma işlemlerinde hız) ve yatay ölçeklenebilirlik (binlerce sunucunun birlikte çalışarak büyük veri işlemesi) öne çıkar. Ayrıca, Büyük Veri alanında NoSQL sistemler yoğun bir şekilde tercih edilmektedir.

# Dependency injection (DI) 

Dependency injection (DI) mekanizması, nesnelerin yaşam döngüsünü kontrol etmek için kullanılan bir yöntemdir. AddScoped, AddSingleton, ve AddTransient bu mekanizmanın en sık kullanılan üç kapsam ayarıdır. Her biri nesnelerin yaşam döngüsünü farklı şekilde yönetir.

## 1- AddSingleton: Uygulama Süresince Tek Bir Nesne

- AddSingleton ile kayıtlı bir nesne, uygulama başlatıldığında oluşturulur ve tüm yaşam döngüsü boyunca aynı nesne kullanılır.
- Uygulama boyunca değişmeyen ve paylaşılan bir durum veya hizmet için uygundur.
- Kullanım Alanları:

  - 1- Konfigürasyon servisleri
  - 2- Cache (önbellek) yönetimi 
  - 3- Uzun ömürlü bağlantılar (ör. bir veritabanı bağlantısı)

## 2- AddScoped: Her İstek İçin Yeni Nesne

- AddScoped, bir HTTP isteği boyunca aynı nesneyi kullanır. Yeni bir HTTP isteği geldiğinde, yeni bir nesne oluşturulur.
- Her istemciye özel durum veya işlem için uygundur.
- Her HTTP isteği ile sınırlıdır.
- Kullanım Alanları:

  - 1- Veritabanı bağlamları (DbContext)
  - 2- Kullanıcıya özel işlemler (Kullanıcının profil verilerini işleyen bir servis.)

## 3- AddTransient: Her Kullanım İçin Yeni Nesne

- AddTransient, her kullanım için yeni bir nesne oluşturur. Her çağrıldığında taze bir örnek döner.
- Hafif hizmetler veya kısa ömürlü nesneler için uygundur.
- Nesneye her ihtiyaç duyulduğunda yeniden oluşturulur.
- Kullanım Alanları:

  - 1- Hafif işlem sınıfları
  - 2- Kısa süreli mantık uygulamaları
  - 3- Yan etkisiz işlemler

| Kapsam | Yaşam Döngüsü| Kullanım Alanları|
| :-------- | :------- | :-------------------------------- |
| Singleton     | Uygulama kapanana kadar	|	Paylaşılan ve statik verilere erişim|
| Scoped     |HTTP isteği süresince	| Kullanıcıya özel durumlar|
| Transient     | Her kullanımda yeni bir örnek |Kısa ömürlü ve hafif hizmetler|


# DTO (Data Transfer Object) 
- DTO (Data Transfer Object), veri taşımak için kullanılan nesnelerdir.
- Genellikle farklı katmanlar arasında veya istemci (client) ve sunucu (server) arasında veri transferi yapmak amacıyla kullanılır. 
- DTO'lar, yalnızca veri taşır; herhangi bir iş mantığı veya davranış içermezler.
- DTO sayesinde, gereksiz veri taşımaktan kaçınılarak performans artırılır.
- İstemcinin yalnızca izin verilen verilere erişmesini sağlar böylece güvenliği de arttırır.

# AutoMapper

- Farklı türdeki nesneler arasında veri aktarımını hızlı ve kolay bir şekilde sağlamaktadır. 
- Bu, genellikle bir DTO (Data Transfer Object) ile bir iş modeli (Business Model) arasında veri taşırken veya katmanlar arasındaki bağımlılığı azaltırken kullanılır.