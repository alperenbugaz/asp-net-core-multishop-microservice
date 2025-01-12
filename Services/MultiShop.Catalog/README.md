dependency injection (DI) mekanizması, nesnelerin yaşam döngüsünü kontrol etmek için kullanılan bir yöntemdir. AddScoped, AddSingleton, ve AddTransient bu mekanizmanın en sık kullanılan üç kapsam ayarıdır. Her biri nesnelerin yaşam döngüsünü farklı şekilde yönetir.

1- AddSingleton: Uygulama Süresince Tek Bir Nesne
Tanım: AddSingleton ile kayıtlı bir nesne, uygulama başlatıldığında oluşturulur ve tüm yaşam döngüsü boyunca aynı nesne kullanılır.

Kullanım: Uygulama boyunca değişmeyen ve paylaşılan bir durum veya hizmet için uygundur.

Yaşam Döngüsü: Uygulama kapanana kadar sürer.

Kullanım Alanları:

Konfigürasyon servisleri
Cache (önbellek) yönetimi
Uzun ömürlü bağlantılar (ör. bir veritabanı bağlantısı)

2-AddScoped: Her İstek İçin Yeni Nesne
Tanım: AddScoped, bir HTTP isteği boyunca aynı nesneyi kullanır. Yeni bir HTTP isteği geldiğinde, yeni bir nesne oluşturulur.

Kullanım: Her istemciye özel durum veya işlem için uygundur.

Yaşam Döngüsü: Her HTTP isteği ile sınırlıdır.
Kullanım Alanları:

Veritabanı bağlamları (DbContext)
Kullanıcıya özel işlemler

3.AddTransient: Her Kullanım İçin Yeni Nesne
Tanım: AddTransient, her kullanım için yeni bir nesne oluşturur. Her çağrıldığında taze bir örnek döner.

Kullanım: Hafif hizmetler veya kısa ömürlü nesneler için uygundur.

Yaşam Döngüsü: Nesneye her ihtiyaç duyulduğunda yeniden oluşturulur.
Kullanım Alanları:

Hafif işlem sınıfları
Kısa süreli mantık uygulamaları
Yan etkisiz işlemler

Kapsam	            Yaşam Döngüsü	                    Kullanım Alanları
Singleton	        Uygulama kapanana kadar	            Paylaşılan ve statik verilere erişim
Scoped	            HTTP isteği süresince	            Kullanıcıya özel durumlar
Transient	        Her kullanımda yeni bir örnek	    Kısa ömürlü ve hafif hizmetler

Ne Zaman Hangisini Kullanmalıyım?
Singleton: Eğer nesneniz paylaşılabilir ve uygulama genelinde durumunu koruması gerekiyorsa.

Örnek: ILogger, IMemoryCache
Scoped: HTTP istekleri süresince aynı nesneye ihtiyaç duyuluyorsa.

Örnek: DbContext gibi veritabanı işlemleri.
Transient: Hafif hizmetleriniz sıkça oluşturuluyorsa ve nesnenin yeniden oluşturulmasında bir sakınca yoksa.

Örnek: E-posta gönderme servisi.