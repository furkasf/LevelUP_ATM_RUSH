
# LevelUp_ATM_Rush

Level_up akademi bünyesinde 3 arkadaşım ile yaptığım projenin 
kaynak kodları.




## Ekip üyeleri

- furkan (https://github.com/furkasf)
- hakan (https://github.com/melenglobal)
- salih (https://github.com/OncuMehmet)


## UML

Atm Rush için proje başlamdan önce yaptığımız UML diagramı sürecde
kodu olabildiğince moduler ve dependency'i azaltmak adına bazı
değişililer yaptık managerların funsıyonve sinyalarini command'a
çevirmek gibi uml günçel değildir ama kod yapısı hakında genel bir fikir
almak için referans olarak kullanılabir.

NOT: UML güncel değildir.

 
## Kullanılan Unity Paketleri

- Toony Color
- DOTween
- Easy Save
- GUI Packages
- Volume profiler
- Cinemachine (State Driven Camera)


## Projede kullanılan Patternler

- Oberserver => genelikle maneerlar arasında iletişimi kurmak için
kullanıldı

- Singleton => Singletonı sade sinyaler ve object pool'u çağırmak
için kullandık

- ObjectPool => Pool'u oyunda level içinde atm'ye giren paraları
toplatıp mini game'de kullabılmek için kulandık bu şekilde her
mini game başladığıda instantiate ve destroydan kacındık oyunda
bu ikisi sade level'i load ve clear etmek için kullandık

- Command => managerlerın funksiyonların birbirlerine olan dependencylerini engellemek , managerların modüllerliğini arttırmak ve son olarakta 
    managerı kod sayısını minimize edip genel olarak kodu daha rahat maintain
    etmek için kullandık 



