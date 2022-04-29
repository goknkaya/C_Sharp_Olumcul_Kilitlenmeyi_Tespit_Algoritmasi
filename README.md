#### Sakarya Üniversitesi 2020 Yaz Okulu İşletim Sistemleri Dersi Proje Ödevi

## Deadlock (Ölümcül Kilitlenme) Nedir?

İki veya daha fazla işlemin karşılıklı olarak birbirlerini kilitlediği kaynaklara erişmek istemesiyle oluşur. Her iki işlem de sürekli birbirlerini beklediği için sistem kaynakları olumsuz yönde etkilenir. Özellikle sunucunun işlemci değeri boşuna harcanmış olur. Bu da, sunucunun performansını olumsuz yönde etkiler ve sunucuyu cevap veremez duruma getirebilir.

## Deadlock (Ölümcül Kilitlenme) Nasıl Oluşur?

P1 ve P2 isminde iki işlem bulunsun. P1 işlemi P2’yi, P2 işlemi ise P1’i bekliyor olsun. Bu durumda ikisi de birbirini sonsuza dek bekleyecek ve kilitlenme oluşacaktır.

A ve B isminde iki işlem bulunsun. A işlemi X kaynağını kendisine almış ve Y kaynağı için sıra bekliyor olsun. B işlemi ise Y kaynağını kendisine almış ve X kaynağı için sıra bekliyor olsun. Bu durumda A işlemi, Y kaynağını almadan X kaynağını bırakmayacaktır, benzer şekilde B işlemi de X kaynağına erişmeden Y kaynağını bırakmayacaktır. Dolayısıyla bu iki işlem kilitlenmeye sebep olacaktır.

## Banker's Algorithm (Banker Algoritması) Nedir?

Kaynaklar üzerindeki kilitlenmeyi (deadlock) engellemek amacıyla kullanılan algoritmalardan birisidir.

https://www.youtube.com/watch?v=ZirAP4BlB2I

# Proje: Ölümcül Kilitlenmeyi Tespit Algoritması

Her bir kaynaktan tek örnek olması durumuna göre Ölümcül Kilitlenmeyi Tespit  Algoritmasını (Banker Algoritması değil) kodladık. Program, Atanmış ve Max. İstek matrislerini giriş olarak alacak, güvenli durum olup olmadığını ve proseslerin çalışma sırasını, kilitli olup olmadığını vs. çıkış olarak verecektir.

<img src="https://i.hizliresim.com/jz4l4fi.jpg"></img>

## Kaynakça:
• İTÜ - BİDB
