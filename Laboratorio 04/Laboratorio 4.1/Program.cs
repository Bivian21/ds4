using System;

class Program
{
    static void Main(string[] args)
    {
        int n, x;
        Console.Write("Ingrese el valor de n: ");

        n = int.Parse(Console.ReadLine());
        x = 1;

        while (x <= n)
        {
            Console.Write(x + " , ");
            x++;
        }

        Console.ReadKey();
    }
}

