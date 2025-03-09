# Resumen del Avance en la Actividad de API y Conexión con el Juego

A lo largo de la actividad, he realizado diversas pruebas con respecto a la persistencia de datos. A continuación, se presenta un resumen de las distintas soluciones implementadas y sus respectivas características.

## 1. API con Guardado en JSON

La primera solución consistió en utilizar un archivo JSON para guardar la información. Esta opción resultó ser práctica y sencilla, pero presentaba varias limitaciones. En primer lugar, la seguridad de los datos era nula, ya que cualquier persona con acceso al archivo JSON podría modificarlo fácilmente. Además, no requería de una gran complejidad técnica, ya que simplemente con tener el archivo JSON era posible realizar cualquier operación de lectura y escritura sobre los datos.

## 2. API con Guardado en Base de Datos SQL Local

En esta segunda etapa, se implementó un sistema de almacenamiento utilizando una base de datos SQL local. Esta solución fue más compleja, ya que requería realizar un respaldo completo de la base de datos para poder ejecutarla dentro de un contenedor Docker. Tras realizar varias pruebas, logré enlazar correctamente la base de datos y hacerla funcionar dentro del contenedor. Sin embargo, este enfoque me parecía menos adecuado, ya que mantener información local siempre no era la opción más eficiente ni práctica para el escenario propuesto.

## 3. API con Guardado en MongoDB

La opción más reciente y popular fue la integración con MongoDB. Este sistema de bases de datos nos proporcionó varias ventajas, ya que las colecciones de MongoDB son más escalables y fáciles de manejar. A diferencia de la base de datos SQL, MongoDB no requiere cargar datos locales antes de iniciar el contenedor Docker, ya que las colecciones se encuentran almacenadas en un clúster en la nube. Además, la seguridad se ve mejorada, ya que se requiere autenticación para modificar los documentos dentro de las colecciones, lo que ofrece un nivel de control y protección superior.

## 4. Conclusión

En resumen, la implementación de la API con MongoDB ha demostrado ser la opción más robusta y eficiente para el escenario en el que nos encontramos. Las ventajas de escalabilidad, facilidad de uso y seguridad en la nube hacen que este enfoque sea el más adecuado, superando los inconvenientes de las soluciones anteriores.

## 5. Juego con la conexión

Cabe aclarar que el juego se encuentra en la rama master : 

  (Enlace gitJuego)[https://github.com/fbatlos/godot-Prueba.git]
