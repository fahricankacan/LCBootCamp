# LCBootCamp 1. Hafta Ödevim

Bir internet sitesindeki tshirt kategorisini örnek alarak bir web api oluşturdum.

## Run 
    dotnet watch run
## Paketler 
    dotnet add package FluentValidation -v 10.4.0
    dotnet add package Swashbuckle.AspNetCore -v 5.6.3
    dotnet add package Microsoft.EntityFrameworkCore.InMemory -v 5.0.6
    dotnet add package Microsoft.EntityFrameworkCore -v 5.0.6
    dotnet add package AutoMapper -v 10.1.1
    dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection -v 8.1.1

# Endpoints
|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:44348/api/v1/Tshirt |GetTshirts|
|GET| https://localhost:44348/api/v1/Tshirt/{id} |GetTshirtById|
|GET| https://localhost:44348/api/v1/Tshirt/search?Title={title}&Category={category}&Price={price}&Color={color}&Explanation={explanation}&Size={size} |GetSearchedTshirt|
|PUT| https://localhost:44348/api/v1/Tshirt?id={id} |UpdateTshirt|
|POST| https://localhost:44348/api/v1/Tshirt |CreateThirt|
|DELETE| https://localhost:44348/api/v1/Tshirt?id={id} |DeleteTshirt|



# API 

## GetTshirts
![GetTshirtPicture](photo/getall.png)

## GetTshirtById
![GetTshirtByIdPicture](photo/getbyid.png)

## GetSearchedTshirt
![GetSearchedTshirt](photo/1search.png)
![GetSearchedTshirt2](photo/2search.png)


## UpdateTshirt
![UpdateTshirt](photo/put.png)
 
## CreateTshirt
![UpdateTshirt](photo/create.png)
## DeleteTshirt
![UpdateTshirt](photo/delete.png)


## Entites
![entity1](photo/entity1.png)
![entity1](photo/entity2.png)

