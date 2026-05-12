# Creación de la clase Dios
En este proyecto se creo la clase Dios llamada "Juego" que tiene un método llamado "CrearMundo" el cual se encarga de crear el mundo y sus elementos.

# Creación de la clase IRepositorioPalabras

# Analisis de Principios SOLID en juego.cs

Juego controla turnos, dibuja el tablero, muestra mensajes y elige la palabra
Esto Viola el principio Single Responsibility Principle (SRP) Porque Una clase debe tener una única razón para cambiar. Aquí, Juego mezcla lógica de negocio, manejo de interfaz de usuario (consola) y gestión de datos.

Las palabras están hardcodeadas dentro del constructor
Esto Viola el princio Dependency Inversion Principle (DIP) porque Las clases de alto nivel no deben depender de implementaciones concretas. Al tener las palabras fijas, el juego depende de una lista estática en lugar de una abstracción (como una base de datos o servicio externo).

Para agregar un segundo juego habría que modificar Juego directamente
Esto Viola el principio Open/Closed Principle (OCP) porque Las clases deben estar abiertas para extensión pero cerradas para modificación. Para agregar un nuevo juego, tendrías que modificar la clase Juego, lo que puede introducir errores y no es escalable.

# Creación de la clase MotorAhorcado

# Creación de la clase ConsolaUI

# Creación de la clase PalabrasEnMemoria

# Modificación de la clase Program.cs

Respuestas a los Retos del Profesor:

1. En la clase dios (Juego.cs), solo tuve que modificar 1 método (MostrarTablero).

2. En la clase MotorAhorcado.cs se agregró public bool MostrarPista => _intentosRestantes <= 3; junto con mis otras propiedades.

3. En la versión limpia, tuve que modificar 2 clases (MotorAhorcado para la regla de negocio y ConsolaUI para la visualización

Reflexión sobre la implementación de las pistas.

En la clase Dios (Juego.cs) fue más rápido porque solo tuve que modificar un método, pero en la versión refactorizada fue más fácil de entender y seguro a nivel arquitecto.