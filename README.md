#### Sakarya Üniversitesi 2020 Yaz Okulu İşletim Sistemleri Dersi Proje Ödevi

## Deadlock (Ölümcül Kilitlenme) Nedir?

İki veya daha fazla işlemin karşılıklı olarak birbirlerini kilitlediği kaynaklara erişmek istemesiyle oluşur. Her iki işlem de sürekli birbirlerini beklediği için sistem kaynakları olumsuz yönde etkilenir. Özellikle sunucunun işlemci değeri boşuna harcanmış olur. Bu da, sunucunun performansını olumsuz yönde etkiler ve sunucuyu cevap veremez duruma getirebilir.

## Deadlock (Ölümcül Kilitlenme) Nasıl Oluşur?

P1 ve P2 isminde iki işlem bulunsun. P1 işlemi P2’yi, P2 işlemi ise P1’i bekliyor olsun. Bu durumda ikisi de birbirini sonsuza dek bekleyecek ve kilitlenme oluşacaktır.

A ve B isminde iki işlem bulunsun. A işlemi X kaynağını kendisine almış ve Y kaynağı için sıra bekliyor olsun. B işlemi ise Y kaynağını kendisine almış ve X kaynağı için sıra bekliyor olsun. Bu durumda A işlemi, Y kaynağını almadan X kaynağını bırakmayacaktır, benzer şekilde B işlemi de X kaynağına erişmeden Y kaynağını bırakmayacaktır. Dolayısıyla bu iki işlem kilitlenmeye sebep olacaktır.

## Banker's Algorithm (Banker Algoritması) Nedir?

Bilgisayar bilimlerinde işletim sistemi tasarımı konusunda geçen ve kaynaklar üzerindeki kilitlenmeyi (deadlock)engelleme amaçlı algoritmadır. Algoritma Dijkstra tarafından geliştirilmiştir.

Algoritmanın temel 3 durumu ve 2 şartı bulunur:

Bilmesi gerekenler:

Her işlem (process) ne kadar kaynağa ihtiyaç duyar?

Her işlem (process) şu anda ne kadar kaynağı elinde tutmaktadır?

Şu anda ne kadar kaynak ulaşılabilir durumdadır?

Yukarıdaki bu bilgileri bildikten sonra kaynak ayrılması sırasında aşağıdaki şartları uygular:

Şayet talep edilen kaynak, azami kaynaktan (maximum) fazla ise izin verme

Şayet talep edilen kaynak eldeki kaynaktan fazla ise, kaynak boşalana kadar işlemi (process) beklet.

Yukarıdaki algoritma detayında, kaynak olarak geçen değer, işletim sistemi için herhangi bir şey olabilir (hafıza (RAM), giriş çıkış işlemleri (I/O), gerçek sistemler için çalışma zamanı gibi)

Banker algoritması ayrıca çalışması sırasında yukarıdaki takipleri yapabilmek için bazı veri yapılarına ihtiyaç duyar. Aşağıdaki veri yapıları için n, sistemdeki işlem (process) sayısı ve m birbirinden farklı kaynak sayısı (resource) olmak üzere:

Müsait : m adet elemanı olan bir dizidir. Dizinin her elemanı o kaynak tipinden ne kadar müsait olduğunu tutar. Örneğin M[i] = 5 değerinin anlamı, i kaynak tipinden beşinin müsait olduğudur.

Azami : iki boyutlu dizi ile tutulur ve n x m boyutlarındadır. Her işlem için ilgili kaynaktan ne kadar ayrım yapıldığı dizide işaretlenir. Örneğin Az[2][3]=5 gösteriminin anlamı, 2. işlemin 3. kaynak üzerinde 5 birimlik ayrım hakkı olduğudur. Diğer bir deyişle 2. işlem, 3. kaynaktan 5 birimden fazla kullanmaz, kullanmak istemez, kullanamaz.

Ayrım : yine iki boyutlu bir dizidir ve yine boyutu n x m olarak tutulur. Her işlemin her kaynağın ne kadarını kullandığını gösterir. Örneğin Ay[2][3] = 4 gösteriminin anlamı, o anda, 2. işlemin 3. kaynaktan 4 birim kullanıyor olduğudur (ayırmış olduğudur).

İhtiyaç: Benzer şekilde nxm boyutlarında bir dizi olarak tutulur ve her işlemin her kaynaktan ne kadar ihtiyaç duyduğunu tutar. Örneğin İ[2][3] = 1 gösteriminin anlamı, 2. işlemin, 3. kaynaktan 1 birim ihtiyacı olduğudur.

Algoritmanın çıktısı güvenli veya değildir (safe state, unsafe state). Buna göre algoritma, işlemlerin çalışıp bitme ihtimali varsa güvenli sonucunu döndürürken, işlemler, birbirini kilitliyorsa bu durumda güvensiz sonucunu döndürür.

Hesaplama:

Algoritma, güveni veya güvensiz sonucuna ulaşmak için adıma bağlı olarak, aşağıdaki hesaplamaları yapar:

Müsait = Müsait – İhtiyaç

Ayrım = Ayrım + İhtiyaç

İhtiyaç = Azami – Ayrım

Bu durumu bir örnek üzerinden açıklayalım. Örneğin A,B,C isimli üç kaynağımız olsun ve bu kaynakların müsaitlik durumları aşağıdaki şekilde olsun:

Kaynaklar
 A B C
10 5 7
Ayrıca 5 adet işlemimiz olsun ve bu işlemlerin anlık olarak azami ihtiyaçları, ayrılmış olan kaynaklar ve ihtiyaçları aşağıda verildiği gibi olsun:

     Azami       Ayrım
     A B C       A B C
P0   7 5 3       0 1 0
P1   3 2 2       2 0 0
P2   9 0 2       3 0 2
P3   2 2 2       2 1 1
P4   4 3 3       0 0 2
Soru bu durumun güvenli bir durum olup olmadığıdır. Diğer bir deyişle acaba bir kilitlenme riski bulunur mu? Öncelikle yukarıdaki ayrım tablosunda bulunan kaynakları toplayalım:

A kaynağı için : 0 + 2 + 3 + 2 + 0 = 7

B kaynağı için : 1 + 0 + 0 + 1 + 0 = 2

C kaynağı için : 0 + 0 + 2 + 1 + 2 = 5

yukarıdaki toplama işlemleri, ilgili kayakatan, başlangıçta ayrılmış miktarların toplamıdır ve kaynağın bulunduğu kolonun toplanması ile bulunabilir.

Şimdi başlangıçtaki kaynak miktarından bu toplamları çıkararak başlangıçta bir işlemin çalışması için müsait kaynakları bulalım:

A : 10 – 7 = 3

B : 5 – 2 = 3

C: 7 – 5 = 2

Bu kaynaklarla başlayarak acaba sistem kilitlenme olmadan çalışabilir mi?

Yukarıda verilen değerlerin üzerinden ihtiyaç tablomuzu hesaplayalım:

     Azami   -   Ayrım    =  İhtiyaç
     A B C       A B C       A B C
P0   7 5 3       0 1 0       7 4 3
P1   3 2 2       2 0 0       1 2 2
P2   9 0 2       3 0 2       6 0 0
P3   2 2 2       2 1 1       0 1 1
P4   4 3 3       0 0 2       4 3 1
Yukarıdaki işlemden anlaşılacağı üzere Azami tablosundan, Ayrım tablosu çıkarılmış ve ihtiyaçlar bulunmuştur.

Bu durumda, sistem güvenli denilebilir çünkü ihtiyaç tablosundaki hiçbir değer, müsait dizimizdeki değeri geçmemektedir. Demek ki sistem bütün ihtiyaçlara cevap verebilecek kapasitededir.

Bu durumun daha iyi anlaşılması için P1, P2, P3, P4, P0 sırası ile çalışmayı görelim:

     Azami   -   Ayrım  =    İhtiyaç Müsait
     A B C       A B C       A B C            A B C
P1   3 2 2       2 0 0       1 2 2    3 3 2   3 3 2
P3   2 2 2       2 1 1       0 1 1    5 3 2
P4   4 3 3       0 0 2       4 3 1    7 4 3
P2   9 0 2       3 0 2       6 0 0    7 4 5
P0   7 5 3       0 1 0       7 4 3   10 4 7
                                     10 5 7<<< Kaynaklar
Görüldüğü üzere işlemlerin sonucunda ilk kaynak değerlerine geri dönülmüştür (aslında bütün işlemler bitince müsait olan kaynak değeri, başlangıçtaki değerdir).
Yukarıdaki çalışma sırası (yani P1, P2, P3, P4, P0 sırası) güvenli çalışma olarak kabul edilir. Örneğimizi biraz daha ilerletelim :
Acaba P1 işlemi (1,0,2) ihtiyacında olsaydı yine de güvenli durumda olur muyduk?
İhtiyaç kontrolümüz (1,0,2)
<=
(1,2,2) olacaktı
ve müsait durumumuz : (1,0,2)
<=
(3 3 2) olacaktı
Bu durumda tablomuz aşağıdaki şekilde olabilirdi:

      Azami      Ayrım      İhtiyaç  Müsait
      A B C       A B C     A B C    A B C
P0   7 5 3       0 1 0       7 4 3     2 3 0<<<
P1   3 2 2       3 0 2<<<    0 2 0<<<
P2   9 0 2       3 0 2       6 0 0
P3   2 2 2       2 1 1       0 1 1
P4   4 3 3       0 0 2       4 3 1

# Proje: Ölümcül Kilitlenmeyi Tespit Algoritması

Her bir kaynaktan tek örnek olması durumuna göre Ölümcül Kilitlenmeyi Tespit  Algoritmasını (Banker Algoritması değil) kodladık. Program, Atanmış ve Max. İstek matrislerini giriş olarak alacak, güvenli durum olup olmadığını ve proseslerin çalışma sırasını, kilitli olup olmadığını vs. çıkış olarak verecektir.

## Kaynakça:
• İTÜ - BİDB
• Şadi Evren Şeker - bilgisayarkavramlari.com
