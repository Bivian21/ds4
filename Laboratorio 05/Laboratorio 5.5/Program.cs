using System;
using System.Collections.Generic;

class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

class Program
{
    static void Main()
    {
        var estudiantes = new List<Estudiante>
        {
            new Estudiante { Nombre = "Ana", Edad = 12 },
            new Estudiante { Nombre = "Juan", Edad = 10 },
            new Estudiante { Nombre = "Sofia", Edad = 11 }
        };

        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine($"Nombre: {estudiante.Nombre}, Edad: {estudiante.Edad}");
        }
    }
}