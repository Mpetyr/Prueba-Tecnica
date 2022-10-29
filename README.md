# Prueba-Tecnica Api Productos
Prueba técnica realizada en .Net

## Tecnologías utilizadas

.Net 5
Sql Server

## Instalación del proyecto

De la página oficial de [Visual Studio]([https://nodejs.org/es/download/](https://visualstudio.microsoft.com/es/)) descargar el programa.

Descargar el repositorio con git a través del siguiente comando:
**git clone https://github.com/Mpetyr/Prueba-Tecnica.git**

*(O descargarlo como archivo comprimido en un zip)*

## Ejecución del programa

Estando dentro del Ide de Visual Studio damos click en el boton IIS Express

## Estructura de base de datos requerida

Dentro de este mismo repositorio hay un archivo llamado **Script-Database.sql** que contiene las líneas requeridas para la creación de la base de datos en limpio.

## Variables de conexión con la base de datos

Dentro del proyecto **PruebaTecnica.AplicacionWeb** existe un archivo llamado **appsettings.json** que contiene la siguiente cadena de conexion:

 "ConnectionStrings": {
    "cadenaSQL": "Server=DESKTOP-JBKO4GR\\SQLEXPRESS; Database=PruebaTecnicaDB2;Integrated Security=true"
  }
  
  Luego de haber creado previavemente la base de datos, ajustar la cadena de conexion a los establecidos en su computador para Sql Server
  
  ## FIN DE LA DOCUMENTACIÓN
