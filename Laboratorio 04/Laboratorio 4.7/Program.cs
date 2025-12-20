using System;

class Program
{
    static void Main(string[] args)
    {
        int numeroUno = 70;
        double numeroDos = 67.89;
        double numeroTres = 67.89;

        // Llamada con dos parámetros (z toma el valor por defecto 0)
        Console.WriteLine(Suma(numeroUno, numeroDos));

        // Llamada con tres parámetros
        Console.WriteLine(Suma(numeroUno, numeroDos, numeroTres));
    }

    // Método con parámetro opcional z
    static double Suma(int x, double y, double z = 0)
    {
        return x + y + z;
    }
}
