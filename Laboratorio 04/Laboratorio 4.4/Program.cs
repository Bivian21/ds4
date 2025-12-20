using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la nota del estudiante: ");
        float score = float.Parse(Console.ReadLine());

        if (score >= 70)
        {
            Console.WriteLine($"Su nota es {score} ha Aprobado");
        }
        else
        {
            Console.WriteLine($"Su nota es {score} ha Reprobado, debe repetir");
        }
    }
}