using System;

class CalculosMatematicos
{
    public double CalculoArea(double radio)
    {
        return Math.PI * radio * radio;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el radio del círculo: ");
        double radio = Convert.ToDouble(Console.ReadLine());

        CalculosMatematicos calc = new CalculosMatematicos();
        double area = calc.CalculoArea(radio);

        Console.WriteLine($"El área del círculo es: {area}");
    }
}
