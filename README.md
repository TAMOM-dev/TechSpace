# 🖥️ Computer Parts Inventory API

**APIRESTful** for cumputer's parts management and their categories (**GPU, RAM, Motherboard, CPU, Storage, PSU, Case, Peripherals**).

## 🚀 Features

- CRUD for **Products**.
- CRUD for **Categories**.
- **Clean Architecture** (layer separation: **Domain**, **Application**, **Persistence** and **API**).
- **CQRS** and **MediatR** for command and consults.
- **Entity Framework Core** for persistence in Database.
- **AutoMapper** to mapping entities and Dtos.
- **OpenApi** for interactive documentation and endpoints.

## 🛠️ Technologies Used

- **.NET 9**
- **Entity Framework Core**
- **MediatR**
- **AutoMapper**
- **SQLServer**
- **OpenApi**

## 📦 Project Structure

```bash
src/
 ├── Api                  -> Api Layer (controllers, configuration)
 ├── Core                 -> Domain and Application Layer (Entities, business logic)
 ├── Infrastructure       -> Persistence (EF Core, repositorios)
 └── UI                   -> Presentation 
```

# ⚡ Installation and Excecution

## Clone the repository

```bash
git clone https://github.com/TAMOM-dev/TechSpace.git
```

## Config string connection (API Project) 

Change the "**Data Source=**" and "**Initial Catalog=**" section.

```json
"ConnectionStrings": {
    "TechSpaceProductManagerStringConnection":
"Data Source=WIN-PSBA3HG7A8V\\SQLEXPRESS;Initial Catalog=TechSpace;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
```

## Add migrations

Open the **terminal** and copy this:

```bash
dotnet ef migrations add InitialCreate -p src/Core/TechSpace.ProductManager.Persistence/TechSpace.ProductManager.Persistence.csproj -s src/Api/TechSpace.ProductsManage.Api/TechSpace.ProductsManage.Api.csproj
```

Then

```bash
dotnet ef database update -p src/Core/TechSpace.ProductManager.Persistence/TechSpace.ProductManager.Persistence.csproj -s src/Api/TechSpace.ProductsManage.Api/TechSpace.ProductsManage.Api.csproj
```

## Run the project (API project)

<img width="703" height="521" alt="image" src="https://github.com/user-attachments/assets/4ce7bdaf-12d7-4aad-a39a-d253b37d95b2" />

and open your localhost adding this way to use **OpenApi** interface.

<img width="1170" height="353" alt="image" src="https://github.com/user-attachments/assets/24634c97-5305-47bb-a67b-ba94bc38a618" />

<img width="506" height="44" alt="image" src="https://github.com/user-attachments/assets/3617b396-3961-4dab-929f-ca2fd8b6fc0e" />

Now you can test the **endpoint** freely

<img width="1907" height="999" alt="image" src="https://github.com/user-attachments/assets/edc0459b-d7c4-4ca8-8bf1-fbf0a3ebbbd3" />

# 👨‍💻 Author

## API Developed by Efrain Feliz de la Cruz.
## Alias T A M O M.
www.linkedin.com/in/tamomdev


