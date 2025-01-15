# Mediator 
- CQRS (Command Query Responsibility Segregation) mimarisinde sýkça kullanýlýr. 
- Ýþ mantýðýnýn ayrýlmasýný ve baðýmlýlýklarýn azaltýlmasýný saðlar.
- Bir nesne ile diðer nesneler arasýndaki iletiþimi merkezi bir Mediator aracýlýðýyla saðlamak için kullanýlýr. 
- Nesneler birbirleriyle doðrudan iletiþim kurmaz; bunun yerine tüm iletiþim Mediator üzerinden yapýlýr.
- Sistemdeki bileþenlerin birbirleriyle baðýmlý olmadan iletiþim kurmasýna olanak tanýr.



###  Problem: 
Birçok sýnýf arasýnda doðrudan iletiþim ve baðýmlýlýk olabilir, bu da kodun bakýlabilirliðini ve test edilebilirliðini zorlaþtýrýr.

### Çözüm: 
Mediator deseni, sýnýflar arasýndaki baðýmlýlýklarý ortadan kaldýrýr ve iletiþimi merkezi bir sýnýf aracýlýðýyla gerçekleþtirir.
 
Veritabanýndan veri almak için kullanýlýr. Geriye sadece belirtilen modeli döner ve veri üzerinde herhangi bir deðiþiklik yapmaz. Oluþturacaðýmýz Query’lerimiz genellikle ‘Get’ ön eki ile isimlendirilir.

## Program.cs MediatR ile Yapýlandýrma

```csharp
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
```
### IRepository<>:
Bu, generic bir interface’tir. Belirli bir entity (varlýk) türü üzerinde CRUD iþlemlerini (Create, Read, Update, Delete) tanýmlayan bir sözleþmedir.

### Repository<>:
Bu, IRepository<> interface'ini implement eden bir generic repository sýnýfýdýr. CRUD iþlemlerinin gerçek implementasyonu burada yapýlýr.

### typeof(IRepository<>) ve typeof(Repository<>):
Bu iki ifade, generic bir interface ile onun implementasyonunun tip bilgilerini ifade eder.

IMediator, MediatR kütüphanesinin merkezi arayüzüdür. Uygulama içindeki Command (Komut) ve Query (Sorgu) iþlemlerini düzenli bir þekilde yönetmek için kullanýlýr. IMediator, bileþenler arasýnda doðrudan baðýmlýlýk oluþturmak yerine bir aracýlýk görevi (mediator pattern) yapar. IMediator kullanýmý sayesinde Controller içerisinde her bir Command ve Query için ayrý ayrý sýnýf türetilmez; bu iþlemler merkezi bir yapý üzerinden yönetilerek kod karmaþasý ve baðýmlýlýklar azaltýlýr.



## MediatR'ýn Temel Bileþenleri: 
### IRequest
IRequest<TResponse> veya IRequest arayüzü, MediatR'da bir sorgu (Query) ya da komutun (Command) tanýmlanmasýný saðlar. Bu arayüz, iþlemin hangi türde bir sonuç döndüreceðini belirtir.

- `IRequest<TResponse>:` Bir iþlem sonucunda bir veri döndürür. (Query)
- `IRequest:` Herhangi bir veri döndürmeyen iþlemler için kullanýlýr.(Command)

### IRequestHandler
IRequestHandler arayüzü, IRequest ile tanýmlanan bir sorgu veya komutun nasýl ele alýnacaðýný belirler. Ýþ mantýðýný içeren bu sýnýflar, sorgu ya da komutun iþlenmesini saðlar.

- `IRequestHandler<TRequest, TResponse>:` Bir sonuç döndüren iþlemleri iþler.(Query)

- `IRequestHandler<TRequest>:` Sonuç döndürmeyen iþlemleri iþler. (Command)

### Send Metodu
IMediator arayüzünün bir parçasýdýr ve bir Command ya da Query'yi uygun Handler sýnýfýna yönlendirmek için kullanýlýr.

- Controller veya baþka bir katmandan, Command ya da Query nesnesini gönderir.
- Gönderilen nesneye uygun Handler sýnýfýný otomatik olarak bulur ve çalýþtýrýr.


```csharp
[HttpPost]
public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
{
    // CreateOrderingCommand komutunu gönderir.
    await _mediator.Send(command);
    return Ok("Sipariþ baþarýyla eklendi");
}
```

## Kaynakça
[Sefik Can Kanber - medium.com/CQRS (Command Query Responsibility Segregation) Nedir?](https://sefikcankanber.medium.com/cqrs-command-query-responsibility-segregation-nedir-16b196376389)


