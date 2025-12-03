using System;

internal class Programa 
{ 
    private static void Main(string[] args) 
    {
        Empleado empleado = new Empleado();
        empleado.Nombre = "John Doe";
        Console.WriteLine($"Nombre del Empleado: {empleado.Nombre}");

        CuentaBancaria cta = new CuentaBancaria();
        cta.Saldo = 100;
        Console.WriteLine($"Saldo de la Empleado: {cta.Saldo}"); //Probar con saldo negatico para ver la excecpcion

        Cobertura c = new Cobertura(5);
        Console.WriteLine($"Con una Cobertura de: {c.Radio}");
    }   
}