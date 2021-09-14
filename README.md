# WillDomTestFront
Aplicacion con un blog de articulos en asp.net core


## Article Local Storage
La pestaña de ¨Article Local Storage¨ contiene una lista de articulos simulados 
que se pueden administrar mediante el boton de ¨Administrar nuevos articulos¨, 
dentro de esa ventana se podra consultar, crear, editar y eliminar los articulos
para poder ser mostrados en la pestaña ¨Article Local Storage¨.

## Remote
Contiene una lista de articulos que se consumen de https://gnews.io/api/v4/search?q=watches&token=valor y son mostrados de manera paginada en la pestaña de ¨Articles Remote¨


## Remote+
Para poder mostrar datos en la pestaña de Remote+ se debe levantar primero el 
servicio que se encuentra en la siguiente url (https://github.com/liedsaal92/ApiWilldom) o caso contrario mostrara un mensaje de que no se encuentran registros. Los datos
que se muestran en esta ventana son simplmente de ejemplos para poder mostrar 
una tabla con registros.

## Articles DB
Esta pestaña contiene un crud con base de datos, migrando modelos de la solucion
a travez de consola para que el modelo se actualice a nivel de base de datos,
para el caso se utilizo una base de datos sql server.
Tomar en cuenta actualizar el archivo appsettings.json y modificar la cadena del
ConnectionStrings 
```json
 "ConnectionStrings": {
    "ConnectionWilldom": "Server=YOUR-SERVER;Database=CrudArticlesWilldom;Trusted_Connection=false;Integrated Security=true"
},
```
luego de eso a nivel de consola utilizar los comandos siguientes para la migracion:
1.- PM> add-migration MigracionInicial
2.- PM> update-database
