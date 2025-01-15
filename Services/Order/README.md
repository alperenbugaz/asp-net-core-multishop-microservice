# Onion Architecture
- So�an Mimarisi (Onion Architecture), yaz�l�m projelerinde katmanl� bir yakla��m sunan bir mimari tasar�m paradigmas�d�r. 2008 y�l�nda Jeffrey Palermo taraf�ndan tasarlanm��t�r. Bu mimarinin en temel �zelli�i ba��ml�l���n, d��ar�dan i�eri do�ru katmanlar halinde s�ralanmas�d�r.
- So�an Mimarisi, geleneksel katmanl� mimariden (�rn: N-TIER ARCH) baz� �nemli y�nlerden farkl�d�r.
**Ba��ml�l�k y�n�**: Katmanl� mimaride, her katman hem i� hem de d�� katmanlara ba�l� olabilir. Bu, katmanlar aras� daha g��l� bir ba�lanma olu�turur ve katmanlar�n birbirinden ba��ms�z olarak geli�tirilmesini ve test edilmesini zorla�t�rabilir. So�an Mimarisi�nde ise her katman yaln�zca i� katmanlara ba�l�d�r, bu da gev�ek bir ba�lanma ve daha fazla ba��ms�zl�k sa�lar.
 
 
 **Veri katman� konumu**: Katmanl� mimaride, veri katman� genellikle en i� katmand�r. So�an Mimarisi�nde ise veri katman� en d�� katmand�r. Bu, veriye eri�imin farkl� katmanlardan soyutlanmas�n� ve uygulaman�n farkl� veri kaynaklar�yla kolayca de�i�tirilmesini sa�lar.
 
 **Odak noktas�:** Katmanl� mimari, genellikle i�levselli�e odaklan�rken, So�an Mimarisi domain modeline odaklan�r. Bu, domain modelinin daha net ve merkezi bir rol oynamas�n� ve uygulaman�n temel i�levlerinin daha iyi anla��lmas�n� sa�lar.


 ![Onion Architecture](ProjectImg/onionarch.png)

**�ekirdek Katman� (Core Layer):** Uygulaman�n en temel i�levlerini i�eren en i� katmand�r. Bu katmanda, domain nesneleri, arabirimler ve servisler gibi uygulamaya �zg� ��eler bulunur. �ekirdek katman�, di�er katmanlardan ba��ms�zd�r ve herhangi bir d�� kayna�a veya �er�eveye ba�l� de�ildir.

**Depo Katman� (Repository Layer):** �ekirdek katman� ile veri eri�imi katman� aras�nda bir soyutlama katman� g�revi g�r�r. Bu katmanda, veri taban�na veya di�er veri kaynaklar�na eri�imi sa�layan arabirimler ve somut s�n�flar bulunur. Depo katman�, �ekirdek katman�na veri modelleri arac�l���yla veri sa�lar ve �ekirdek katman�n�n veri eri�iminin nas�l ger�ekle�ti�ine dair ayr�nt�lar� gizler.

**Uygulama Katman� (Application Layer):** �ekirdek katman�n�n i�levlerini kullanarak i� mant���n� uygular. Bu katmanda, use case�ler, i� ak��lar� ve kurallar gibi uygulamaya �zg� mant�k bulunur. Uygulama katman�, �ekirdek katman�na ve depo katman�na ba�l�d�r, ancak di�er katmanlardan ba��ms�zd�r.

**Sunum Katman� (Presentation Layer):** Uygulaman�n kullan�c� aray�z�n� (UI) ve kullan�c� etkile�imini ele al�r. Bu katmanda, denetleyiciler, g�r�n�mler ve rotalar gibi UI ��eleri bulunur. Sunum katman�, uygulama katman�na ba�l�d�r, ancak di�er katmanlardan ba��ms�zd�r.

**Altyap� Katman� (Infrastructure Layer):** Uygulaman�n �al��mas� i�in gerekli olan temel altyap� hizmetlerini sa�lar. Bu katmanda, g�ncelleme, a�, mesajla�ma ve g�nl�k gibi hizmetler bulunur. Altyap� katman�, di�er t�m katmanlardan ba��ms�zd�r.

**So�an Mimarisi�nin temel prensipleri �unlard�r:**
- **Ba��ml�l�k ters �evirme:** Her katman, kendinden daha i�teki katmanlara ba�l�d�r. Bu, katmanlar aras� gev�ek bir ba��ml�l�k (Loosely Coupled) olu�turur ve katmanlar�n birbirinden ba��ms�z olarak geli�tirilmesine ve test edilmesine olanak tan�r.
- **Soyutlama:** Her katman, di�er katmanlardan soyutlanm�� bir �ekilde tasarlan�r. Bu, katmanlar aras� g��l� bir ba�lanma olu�turmay� �nler ve kodun yeniden kullan�labilirli�ini ve s�rd�r�lebilirli�ini art�r�r.
- **Tek bir sorumluluk ilkesi:** Her katman�n tek bir sorumlulu�u olmal�d�r. Bu, kodun daha mod�ler ve anla��l�r olmas�n� sa�lar ve de�i�ikliklerin yap�lmas�n� kolayla�t�r�r

**So�an Mimarisi�nin faydalar� �unlard�r:**

- **Artan esneklik:** Katmanlar aras�ndaki gev�ek ba��ml�l�k, uygulaman�n yeni �zelliklerle kolayca geni�letilmesini ve mevcut i�levlerin de�i�tirilmesini sa�lar.

- **Geli�tirilmi� test edilebilirlik:** Her katman ba��ms�z olarak test edilebilir, bu da birim testlerinin yaz�lmas�n� ve hata ay�klamas�n� kolayla�t�r�r.

- **Artan s�rd�r�lebilirlik:** Kodun mod�ler yap�s�, kodun anla��lmas�n� ve bak�m�n� kolayla�t�r�r.

- **Daha az hata:** Katmanlar aras�ndaki g��l� ba�lanma eksikli�i, hatalar�n bir katmandan di�erine yay�lmas�n� �nler.


**So�an Mimarisi�nin baz� dezavantajlar� �unlard�r:**

- **Karma��kl�k:** Katmanlar aras�ndaki ba��ml�l�klar, �zellikle b�y�k ve karma��k projelerde uygulamay� anlamak ve y�netmek zorla�t�rabilir.
- **Test zorlu�u:** Katmanlar aras�ndaki entegrasyonu test etmek, birim testlerinden daha karma��k olan entegrasyon testlerini gerektirir.
- **Performans:** Bir�ok katmandan ge�mek, uygulama performans�n� olumsuz etkileyebilir.

- **A��r� soyutlama:** Soyutlamaya a��r� odaklanmak, kodun gereksiz yere karma��k hale gelmesine neden olabilir.

## Kaynak�a
[Cengiz Akarsu - medium.com/Nedir bu Onion Architecture?](https://cengizakarsu.medium.com/nedir-bu-onion-architecture-so�an-mimarisi-5b3e5e08f0ce)


