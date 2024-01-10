Million And UP
Proyecto realizado como parte del proceso de seleccion para ingresar a Million And Up

Estructura del Proyecto
|-- MU.API
|-- src
    |-- MU.Application
        |-- DomainEventHandlers
            |-- PropertyImageAddedEvent
        |-- Services
            |-- ImageService
            |-- JWTGenerator
        |-- UseCases
            |-- Owners
                |-- Commands
                    |-- Create
                |-- Queries
                    |-- GetAll
                    |-- GetById
            |-- Properties
                |-- Commands
                    |-- AddImage
                    |-- ChangeAddress
                    |-- ChangePrice
                    |-- Create
                    |-- Update
                |-- Queries
                    |-- List
                    |-- SearchPropertiesByFilters
                    |-- SearchPropertyById
            |-- Tokens
                |-- Queries
                    |-- GenerateToken
    |-- MU.Domain
        |-- Entities
            |-- Events
            |-- Owners
            |-- Properties
            |-- PropertyImages
            |-- PropertyTraces
        |-- Interfaces
            |-- Repositories
        |-- Primitives
        |-- ValueObjects
    |-- MU.Infrastructure
        |-- Persistence
            |-- Contexts
            |-- Metadata
            |-- Migrations
            |-- Repositories
        |-- Services
            |-- ImageStorage
            |-- JWTGenerator
            |-- TokenValidation
|-- tests
    |-- UnitTests
        |-- Application.Properties.UnitTests
            |-- AddImage
            |-- ChangeAddress
            |-- ChangePrice
            |-- Create
|-- docs
    |-- README.md
    |-- 
|-- .gitignore
|-- Scripts
|-- MyProject.sln

MU.Application
Descripción
Se uso una arquitectura hexagonal para la creación de este proyecto, el cual tiene 3 capas principales.
La capa de aplicación contiene los servicios de aplicación que orquestan la lógica de negocio utilizando los principios de DDD y el patrón CQRS, tambien contiene los manejadores de eventos proporcionados por la capa Dominio.

Tecnologías Utilizadas
C# .NET Core 6
MediatR para implementar CQRS y para manejar los eventos del dominio
ErrorOr para los problem details
EntityFrameworkCore para el procesamiento de querys


MU.Domain
La capa de dominio nos provee las entidades que son la razon de ser del negocio y por ende del proyecto, se crearon metodos en las entidades para poder agrear o crear nuevas entidades hijas y asi mismo si desea suscribir un evento de dominio 
como en el caso de property para crear una propertyImage, la cual suscribe un evento de dominio, este evento de dominio contiene un manejador en la capa Application el cual sube la imagen al storage.
Se hizo el uso tambien de valueObjects en este caso para los campos de Address y CodeInternal ya que se provee por medio de estos la logica necesaria para instanciar estos campos,
se creo una clase "AggregateRoot", la cual provee los eventos a la entidad que la herede.

Tecnologías Utilizadas
C# .NET Core 6
MediatR para implementar DDD y suscribir eventos
ErrorOr para los problemDetails

MU.Infrastructure
Descripción
En la capa de infraestructura se hizo implementacion de los "Adapters" para acceder a la base de datos con entityFrameworkCore y tambien para implementar el servicio de storage de las imagenes, aqui cabe recalcar que 
se implemento una carpeta en esta capa para el almacenamiento de las imagenes, esto es meramente simbolico a manera de simular un servicio de storage independiente a la aplicacion por lo cual no esta contemplado mostrar las imagenes
en el api del proyecto, de igual manera si se deseara se podrian retornar estas imagenes en base64 y asi mismo mostrarlas haciendo uso por ejemplo de JS para procesar el base64.

Tecnologías Utilizadas
C# .NET Core 6
MediatR para hacer la publicacion de los eventos de dominio
entityFrameworkCore para configuracion de la base de datos
AspNetCore.Authentication.JwtBearer para la generacon de tokens y servicio de autenticación

MyProject.API
Descripción
La API .NET Core expone los servicios de aplicación a través de controladores RESTful, con autenticación JWT.

Tecnologías Utilizadas
C# .NET Core 6
ASP.NET Core API
ErrorOr para problemsDetails
MediatR para la gestión de comandos y consultas
JWT para autenticación

Cómo Iniciar
Clona el repositorio: git clone https://github.com/chrisgzon/MillionAndUp.git.

Configuración
ubicar el archivo appsettings.json en el api y configurar las variables según sea necesario.
Abre la solución en Visual Studio o utiliza la CLI de .NET.
Restaura los paquetes: dotnet restore.
En la carpeta Scripts se encuentra el script SQL para la creación de la base de datos y tambien contiene un INSERT de un Owner necesario para probar el API ya que para la
autenticacion se solicita el Id de un Owner, por lo cual se recomienda preferiblemente usar este script
O tambien puedes ejecutar las migraciones con el comando: dotnet ef migrations add initialMigration -p MU.Infrastructure -s MU.WebApi -o Persistence/Migrations
y posteriormente generar el script SQL con el siguiente comando: dotnet ef migrations script -s MU.WebApi -p MU.Infrastructure
recurerda que si lo haces de esta forma sera necesario hacer el insert en base de datos del Owner para asi generar el token con este id

Ejecuta el proyecto de la API: dotnet run --project MyProject.API.


Para acceder a los controllers de Owner y Property se tendra que estar autenticado, para realizar la autenticacion se tiene que consultar el controller /Token/Generate el cual solicita el Id del Owner con el que se desea autenticar
este servicio de autenticacion es meramente de ejemplo por lo cual no requiere de credenciales de acceso, y las acciones referentes a realizar en los controllers no estaran limitadas unicamente a este Owner con el que se autentica, asi que 
podra crear propierties para cualquier Owner que desee y asi mismo modificarlas

por medio de Swagger se puede agregar el token a las solicitudes