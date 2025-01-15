# Mediator 
- CQRS (Command Query Responsibility Segregation) mimarisinde s�k�a kullan�l�r. 
- �� mant���n�n ayr�lmas�n� ve ba��ml�l�klar�n azalt�lmas�n� sa�lar.
- Bir nesne ile di�er nesneler aras�ndaki ileti�imi merkezi bir Mediator arac�l���yla sa�lamak i�in kullan�l�r. 
- Nesneler birbirleriyle do�rudan ileti�im kurmaz; bunun yerine t�m ileti�im Mediator �zerinden yap�l�r.
- Sistemdeki bile�enlerin birbirleriyle ba��ml� olmadan ileti�im kurmas�na olanak tan�r.



###  Problem: 
Bir�ok s�n�f aras�nda do�rudan ileti�im ve ba��ml�l�k olabilir, bu da kodun bak�labilirli�ini ve test edilebilirli�ini zorla�t�r�r.

### ��z�m: 
Mediator deseni, s�n�flar aras�ndaki ba��ml�l�klar� ortadan kald�r�r ve ileti�imi merkezi bir s�n�f arac�l���yla ger�ekle�tirir.
 
Veritaban�ndan veri almak i�in kullan�l�r. Geriye sadece belirtilen modeli d�ner ve veri �zerinde herhangi bir de�i�iklik yapmaz. Olu�turaca��m�z Query�lerimiz genellikle �Get� �n eki ile isimlendirilir.

## Program.cs MediatR ile Yap�land�rma

```csharp
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
```
### IRepository<>:
Bu, generic bir interface�tir. Belirli bir entity (varl�k) t�r� �zerinde CRUD i�lemlerini (Create, Read, Update, Delete) tan�mlayan bir s�zle�medir.

### Repository<>:
Bu, IRepository<> interface'ini implement eden bir generic repository s�n�f�d�r. CRUD i�lemlerinin ger�ek implementasyonu burada yap�l�r.

### typeof(IRepository<>) ve typeof(Repository<>):
Bu iki ifade, generic bir interface ile onun implementasyonunun tip bilgilerini ifade eder.

IMediator, MediatR k�t�phanesinin merkezi aray�z�d�r. Uygulama i�indeki Command (Komut) ve Query (Sorgu) i�lemlerini d�zenli bir �ekilde y�netmek i�in kullan�l�r. IMediator, bile�enler aras�nda do�rudan ba��ml�l�k olu�turmak yerine bir arac�l�k g�revi (mediator pattern) yapar. IMediator kullan�m� sayesinde Controller i�erisinde her bir Command ve Query i�in ayr� ayr� s�n�f t�retilmez; bu i�lemler merkezi bir yap� �zerinden y�netilerek kod karma�as� ve ba��ml�l�klar azalt�l�r.



## MediatR'�n Temel Bile�enleri: 
### IRequest
IRequest<TResponse> veya IRequest aray�z�, MediatR'da bir sorgu (Query) ya da komutun (Command) tan�mlanmas�n� sa�lar. Bu aray�z, i�lemin hangi t�rde bir sonu� d�nd�rece�ini belirtir.

- `IRequest<TResponse>:` Bir i�lem sonucunda bir veri d�nd�r�r. (Query)
- `IRequest:` Herhangi bir veri d�nd�rmeyen i�lemler i�in kullan�l�r.(Command)

### IRequestHandler
IRequestHandler aray�z�, IRequest ile tan�mlanan bir sorgu veya komutun nas�l ele al�naca��n� belirler. �� mant���n� i�eren bu s�n�flar, sorgu ya da komutun i�lenmesini sa�lar.

- `IRequestHandler<TRequest, TResponse>:` Bir sonu� d�nd�ren i�lemleri i�ler.(Query)

- `IRequestHandler<TRequest>:` Sonu� d�nd�rmeyen i�lemleri i�ler. (Command)

### Send Metodu
IMediator aray�z�n�n bir par�as�d�r ve bir Command ya da Query'yi uygun Handler s�n�f�na y�nlendirmek i�in kullan�l�r.

- Controller veya ba�ka bir katmandan, Command ya da Query nesnesini g�nderir.
- G�nderilen nesneye uygun Handler s�n�f�n� otomatik olarak bulur ve �al��t�r�r.


```csharp
[HttpPost]
public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
{
    // CreateOrderingCommand komutunu g�nderir.
    await _mediator.Send(command);
    return Ok("Sipari� ba�ar�yla eklendi");
}
```

## Kaynak�a
[Sefik Can Kanber - medium.com/CQRS (Command Query Responsibility Segregation) Nedir?](https://sefikcankanber.medium.com/cqrs-command-query-responsibility-segregation-nedir-16b196376389)


