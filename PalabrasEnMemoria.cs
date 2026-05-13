using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _palabrasPorCategoria = new()
        {
            { "Arquitectura", new List<string> { "arquitectura", "componente", "descomposición", "dependencia", "acoplamiento" } },
            { "POO", new List<string> { "polimorfismo", "encapsulamiento", "herencia", "abstracción", "clase" } },
            { ".NET", new List<string> { "ensamblado", "namespace", "interfaz", "delegado", "middleware" } }
        };

        public string ObtenerPalabraAleatoria(string categoria)
        {
            var random = new Random();
            if (_palabrasPorCategoria.ContainsKey(categoria))
            {
                var palabras = _palabrasPorCategoria[categoria];
                return palabras[random.Next(palabras.Count)];
            }
            return "error";
        }
    }
}