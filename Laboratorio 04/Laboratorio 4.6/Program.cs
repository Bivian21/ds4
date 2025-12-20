using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite el radio del círculo:");
        double radio = double.Parse(Console.ReadLine());

        double area = Math.Pow(radio, 2) * Math.PI;

        Console.WriteLine($"El área del círculo es: {area}");
        Console.ReadKey();
    }
}
