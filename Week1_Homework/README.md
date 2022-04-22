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
![GetTshirtPicture](/image/getall.png)

## GetTshirtById
![GetTshirtByIdPicture](/image/getbyid.png)

## GetSearchedTshirt
![GetSearchedTshirt](/image/1search.png)
![GetSearchedTshirt2](/image/2search.png)


## UpdateTshirt
![UpdateTshirt](/image/put.png)
 
## CreateTshirt
![UpdateTshirt](/image/create.png)
## DeleteTshirt
![UpdateTshirt](/image/delete.png)


## Entites
![entity1](image/entity1.png)
![entity1](image/entity2.png)

