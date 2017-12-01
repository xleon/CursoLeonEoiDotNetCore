# Curso León EOI 2017 C# y DotNetCore
Introducción al lenguaje C# y .NET Core por Diego Ponce de León para la EOI

## Herramientas utilizadas

- Dotnet CLI
- Visual Studio Code
- Visual Studio Community edition
- Nuget
- Git por línea de comandos
- Git desde Visual Studio Code
- Git desde Visual Studio
- Github
- GitKraken
- Postman

## Conceptos aprendidos durante el desarrollo

### .NET Core

- Introducción a .NET Framework
- Introducción a .NET Core
- Diferencias entre .NET Framework y .NET Core
- Instalación entorno de trabajo para .NET Core (SDK)
- Crear proyectos de consola, librería NET Standard y Web API con .NET Core desde línea de comandos (CLI) y desde Visual Studio
- Instalación, configuración y uso de Visual Studio Code para editar proyectos C#
- Instalación, configuración y uso de Visual Studio Community para editar proyectos C#
- Crear dependencias entre proyectos dentro de una misma solución
- Añadir paquetes nuget a un proyecto
- Utilización de librerías de terceros a través de nuget
- Depurar código C# en Visual Studio Code
- Depurar código C# en Visual Studio Community
- Interacción de usuario (entrada y salida de datos) en un proyecto de Consola

### Git

- Comandos básicos de Git desde la línea de comandos (add, status, commit, remote add, pull, push)
- Operaciones básicas de Git desde Visual Studio Community
- Creación de repositorio Git en GitHub
- Vincular un repositorio Git local con uno remoto en GitHub

### C#

- Value types
- Declaración y utilización de variables
- Comandos de selección (if, else if, switch)
- Operadores comunes
- Operador ternario
- Comandos de iteración (while, do while, for, foreach)
- Comandos de salto (break, continue)
- Declaración y utilización de propiedades de clase
- Métodos de clase
- Parámetros de método
- Arrays
- Colecciones
- LINQ + Lambda
- Clases y objetos
- Herencia
- Polimorfismo
- Encapsulación
- Métodos estáticos
- Async, await, Task
- Lanzamiento y manejo de excepciones

### REST y Web API

- Introducción a REST
- Métodos básicos REST (get, post, put, delete)
- Probar una API REST con Postman
- Consumir una API REST desde C# con `HttpClient`
- Crear una API REST con Asp.NET Core y Visual Studio
- Usar respuestas de Web API: BadRequest, NoContent, Ok, ServerError, CreatedAtRoute, etc
- Crear un modelo de datos relacional
- Usar inyección de dependencias para el uso de servicios en controladores Web API
- Introducción a ORM (Object Relatioinal Mapper)
- Introducción al ORM Entity Framework
- Usar base de datos en memoria
- Consultas a la base de datos de forma síncrona con LINQ
- Consultas a la base de datos de forma asíncrona con LINQ


# Ejercicios

## Fight Game

Mini juego de peleas por turnos desarrollado durante las clases. Se trata de una aplicación de consola que descarga lista de personajes desde la API REST de StarWars. 
Cada vez que se teclea la función "Luchar", se eligen dos contrincantes aleatoriamente. El daño que ocasionan o reciben también es aleatorio. Todos van perdiedo poder y vidas. 
Cuando se agotan sus vidas quedan fuera de juego. Así sucesivamente hasta que queda un único superviviente o ganador.
Tiene otra función "Estatus" con la cuál podemos ver una tabla de texto de los jugadores y el detalle de cada uno.

La lógica del juego es muy simplista y esta aplicación ha servido básicamente para tocar varios puntos importantes del lenguaje C#, al mismo tiempo que hemos aprendido a manejar entrada y salida de datos en aplicaciones de consola.

![Game screenshot 1](https://raw.githubusercontent.com/xleon/FightGame/master/Screenshot_1.png)
![Game screenshot](https://raw.githubusercontent.com/xleon/FightGame/master/image.png)

## TO DO web API (Lista de tareas)

Se trata de una API REST muy simple, desarrollada en Visual Studio, con dos modelos de datos (lista de tareas y tarea) que están relacionados entre sí. 
Hemos hecho un recorrido por los métodos REST más relevantes para entender el concepto CRUD (Create Retrieve Update Delete). Para ello hemos utilizado un servicio que se utiliza en el controlador mediante inyección de dependencias.
En dichos métodos se controlan errores y que los parámetros recibidos en la llamada sean correctos. También se consulta una base de datos con LINQ 
y finalmente se devuelven las respuestas correspondientes y típicas de REST, con su código de estado y su cuerpo en formato json. Toda la API web ha sido probada con Postman.

