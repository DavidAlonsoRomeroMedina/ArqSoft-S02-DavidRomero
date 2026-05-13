using System;
using System.Threading;

Console.WriteLine("¿Qué juego quieres jugar?");
Console.WriteLine("  1 — Ahorcado");
Console.WriteLine("  2 — Viborita");
Console.Write("Opción: ");
var opcion = Console.ReadLine();

if (opcion == "2")
{
    var motor = new Ahorcado.MotorViborita();
    var ui = new Ahorcado.ConsolaUIViborita(motor);

    Console.CursorVisible = false;

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();
        var tecla = ui.LeerTecla();

        if (tecla == ConsoleKey.Q) break;
        if (tecla != ConsoleKey.NoName)
            motor.CambiarDireccion(tecla);

        motor.Avanzar();
        Thread.Sleep(150);
    }

    ui.MostrarTablero();
    ui.MostrarMensaje(motor.Ganado() ? "\n¡Ganaste! Llegaste a 10 puntos." : "\nGame over.");
}
else
{
    Console.WriteLine("\nElige una categoría para jugar:");
    Console.WriteLine("  1 — Arquitectura");
    Console.WriteLine("  2 — POO");
    Console.WriteLine("  3 — .NET");
    Console.Write("Opción: ");
    var opcionCat = Console.ReadLine();

    string categoriaElegida = "Arquitectura";
    if (opcionCat == "2") categoriaElegida = "POO";
    if (opcionCat == "3") categoriaElegida = ".NET";

    var repositorio = new Ahorcado.PalabrasEnMemoria();
    var motor = new Ahorcado.MotorAhorcado(repositorio, categoriaElegida);
    var ui = new Ahorcado.ConsolaUI(motor);

    Console.WriteLine("=== AHORCADO ===");
    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();
        char letra = ui.PedirLetra();

        if (motor.LetraYaUsada(letra))
        {
            ui.MostrarMensaje("Ya usaste esa letra.");
            continue;
        }

        motor.RegistrarLetra(letra);
    }

    ui.MostrarTablero();
    if (motor.Ganado())
        ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
    else
        ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

    if (ui.PreguntarOtraVez())
    {
        var nuevoMotor = new Ahorcado.MotorAhorcado(repositorio, categoriaElegida);
        var nuevaUI = new Ahorcado.ConsolaUI(nuevoMotor);
    }
}