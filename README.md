
#Evaluaci�n Vueling
La evaluaci�n consiste en usuarios filtrados por id segun su rol que puede ser "user" o "admin"
 adem�s de tambi�n persistir los datos en un fichero, tambien puede ser una base de datos.
Para seguir con las pautas del cometido de la evaluaci�n se tendr� en cuenta la arquitectura DDD 
separando por capas las diferentes funcionalidades que debe realizar el web service y 
no conjuntarlo todo en un solo proyecto.

La evaluaci�n ser� capaz de registrar todas las acciones que har� el usuario, tanto de informaci�n 
as� como de las excepciones que se vayan produciendo.

La capa de servicios llamar� a la web service cedida por Vueling desde una clase HttpClient.

Las pautas a seguir ser�n dadas por los principios SOLID as� tener un c�digo estable a la larga.

Implementar todos los tests: UnitTest, IntegrationTest y BehaviorTest para un seguimiento funcional correcto.

Utilizar JWT (Json Web Token) para la implementaci�n de autorizaci�n y autenticaci�n de usuario.

Para una actualizaci�n de los datos se utilizar� Quartz que automatizar� en un periodo de una hora 
la petici�n de datos si ha habido algun cambio.

![Estructura N-capas](Structure.png)

#Log4net
Para la repeticion de c�digo se ha puesto esta librer�a en la capa CommonLayer ya que se piensa registrar cada
acci�n del usuario, recibiendo por par�metro el mensaje para que lo guarde en un fichero segun su nivel de importancia,
se guardar�n en ficheros distintos depenediendo si son de informaci�n o de errores que se registran
las excepciones capturadas.

#NewtonSoft
Para la serializaci�n y desearializaci�n se usa esta libreria tanto para la lectura del web service como para 
la persistencia.

Esta libreria est� en la capa de infraestructura que trata con los datos directamente. Los ficheros json que generan se guardan en
la carpeta principal del proyecto, muestra los listados de los clientes y las polizas.

#Excepciones personalidas
Todas las excepciones ser�n emitidas desde VuelingException que est� en el proyecto common as� puede ser usado 
por todo el web service.

#StrongTypes
Separar en la capa de infraestructura funcionalidades correctas a su cometido, captura y devoluci�n de datos, y no quitar el NewtonSoft 
de la capa de apliaci�n.

Para evitar strings en todo el web service se ha a�adido un fichero de recursos en cada proyecto, adem�s de a�adir al web.config 
 variables de configuraci�n.
 
#Aspectos a mejorar
Generar la persistencia de los datos a la hora de ejecutar la aplicaci�n para tener la informaci�n 
almacenada desde un principio, y ademas que esta petici�n la haga cada hora con ayuda de Quartz.

Por falta de tiempo se ha descuidado los tests que son importantes para el correcto funcionamiento
 del web service.
 
Devolver los errores resultantes de los Http Errors del las peticiones lanzadas desde HttpClient.

Tener desde el principio un esquema estable que permitiera un repartici�n de funcionalidades m�s sencillo, ya que al ir 
a�adiendo funcionalidades se ha ido complicando. 
