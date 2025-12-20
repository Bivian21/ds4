using System;

class PruebaVector
{
    private int[] sueldos; // Declaramos el vector

    public void Cargar()
    {
        sueldos = new int[6]; // Inicializamos el vector con 5 elementos

        for (int f = 0; f < sueldos.Length; f++)
        {
            Console.Write($"Ingrese sueldo del operario #{f + 1}: ");
            string linea = Console.ReadLine();
            sueldos[f] = int.Parse(linea); // Asignamos el sueldo al vector
        }
    }

    public void Imprimir()
    {
        Console.WriteLine("\nLos 5 sueldos de los operarios son:");
        for (int f = 0; f < sueldos.Length; f++)
        {
            Console.Write($"[{sueldos[f]}] ");
        }
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        PruebaVector pv = new PruebaVector();
        pv.Cargar();
        pv.Imprimir();
    }
}
