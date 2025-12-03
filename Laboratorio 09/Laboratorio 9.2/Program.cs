using System;

class Program
{
    static void Main(string[] args)
    {
        for(int i = 1; i <= 100; i++)
        {
            if(i % 2 == 0 || i % 3 == 0) //Para mostrar numeros divisibles entre 3 usar i % 3.
            {
                Console.WriteLine(i);
            }
        }
    }
}