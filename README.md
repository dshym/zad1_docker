# Zadanie 1
## Dmytro Shymanskyi IIST 6.3
### Polecenia do zbudowania obrazu kontenera 
1. `cd zad1_docker`
2. `cd zad1`
3. `docker build -t zad1 .`
### Polecenia do uruchomienia kontenera na podstawie zbudowanego obrazu
1. `docker run -it -p 8080:80 zad1`
2. informacja z punktu 1.a będzie wyświetlona w konsoli
3. dla wyświetlenia informacji z punktu 1.b otwórz `localhost:8080/check`
4. dla sprawdzenia liczby warstw obrazu należy wykonać polecenia:
  - `docker images -a` na liście musi znaleźć się nasz obraz 'zad1'
  - `docker history zad1`
  
Zrzut ekranu okna przeglądarki

<img width="580" alt="image" src="https://user-images.githubusercontent.com/57046216/167293685-c84460e1-3849-4641-85cb-69f613b06021.png">

### Zbudowanie obrazów dla architektur linux/arm/v7, linux/arm64/v8 oraz linux/amd64

Budowanie za pomocą buildx

Polecenia:

1. `docker run --rm --privileged multiarch/qemu-user-static --help —reset -p yes` - pobranie obrazu quemu
2. `docker buildx create --driver docker-container` - utworzenie sterownika DRIVER/ENDPOINT=docker-container
3. `docker buildx use laughing_jennings ` - zastosowanie utworzonego sterownika
4. Budowanie dla **linux/arm/v7**
  - `docker buildx build -t dshym/lab:zad1_armv7 --platform  linux/arm/v7 --push .`
  - nie udało się znaleźć odpowiedniej wersji **mcr.microsoft.com/dotnet/aspnet:5.0** dla danej architektury
  <img width="713" alt="image" src="https://user-images.githubusercontent.com/57046216/167294010-bdd1f755-40e9-4536-bcf7-755c0b8f7430.png">
  
5. Budowanie dla **linux/arm64/v8**
  - `docker buildx build -t dshym/lab:zad1_arm64 --platform linux/arm64/v8 --push .`
  - [dshym/lab:zad1_arm64](https://hub.docker.com/layers/209810976/dshym/lab/zad1_arm64/images/sha256-91021858a5f7cda58381842e2440d970868d1c7d837ad3325082cd5c21e3ead6?context=repo)
  
6. Budowanie dla **linux/amd64**

  - należało zmienić wersję dotnet w Dockerfile na *mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim-amd64*
  - `docker buildx build -t dshym/lab:zad1_amd64 --platform linux/amd64 --push .`
  - [dshym/lab:zad1_amd64](https://hub.docker.com/layers/209810796/dshym/lab/zad1_amd64/images/sha256-ad2b368251c7b98b3308755aaa87cd1afdb7e4c1304fd32d001074fc734ce5cc?context=repo)
