using System;

class CalculosMatematicos
{
    public int Calcular(int a, int b)
    {
        return (a + b) * (a - b);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el primer número: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        int b = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calc = new CalculosMatematicos();
        int resultado = calc.Calcular(a, b);

        Console.WriteLine($"El resultado es: {resultado}");
    }
}
