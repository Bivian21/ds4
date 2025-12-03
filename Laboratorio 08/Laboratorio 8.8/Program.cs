using System;

internal class Program
{
    private static void Main(string[] args)
    {
        ClaseConcreta1 concreta1 = new ClaseConcreta1();
        concreta1.printOut(); // Output: ClaseConcreta1
        Console.WriteLine(concreta1.prefixValor("ES_")); // Output: Prefijo_ClaseConcreta1

        ClaseConcreta2 concreta2 = new ClaseConcreta2();
        concreta2.printOut(); // Output: ClaseConcreta2
        Console.WriteLine(concreta2.prefixValor("ES_")); // Output: Prefijo_ClaseConcreta2
    }
}