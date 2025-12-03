using System;

class Program
{
    static void Main(string[] args)
    {
        Trabajador trabajador = new Trabajador("Juan", 30, "12345678A", 2000);
        Console.WriteLine($"Nombre: {trabajador.Nombre}");
        Console.WriteLine($"Edad: {trabajador.Edad}");
        Console.WriteLine($"NIF: {trabajador.NIF}");
        Console.WriteLine($"Sueldo: {trabajador.Sueldo}");
    }
}