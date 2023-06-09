# Requisitos previos
* Visual Studio Code
* .NET Core 7.0

# Cómo usar esta API
* Clonar el repositorio en alguna carpeta local
* Abrir la carpeta del proyecto con VS Code

# Editar conexión a BD
* Se debe editar en appsetings.json "DefaultConnection": con la cadena de conexión a su base de datos local en SQL server (en este caso)

# Cargar datos semilla en la BD
* En la terminal ejecutar el siguiente comando:
```
dotnet ef database update
```

# Correr la API
* En la terminal ejecutar el siguiente comando:
```
dotnet run
```

# Utilizar API
* Se puede testear la API con Postman utilizando la colección adjunta en la carpeta
```
Evaluacion-3.postman_collection.json
```

* Se puede testear con Swagger en la siguiente url
```
http://localhost:5204/swagger/index.html
```