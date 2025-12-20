using System;

class Program
{
    public static void Main(string[] args)
    {
        int fac = 1, n;
        String linea;
        Console.Write("Ingrese un numero entero: ");
        linea = Console.ReadLine();
        n = int.Parse(linea);
        for (int i = 1; i <= n; i++)
        {
            fac = fac * i;
        }
        Console.Write("El factorial de " + n + " es: " + fac);
        Console.ReadKey();
    }
}