using System;

class Program
{
    static void Main(string[] args)
    {
        Aleatorios aleatorio = new Aleatorios();

        // Generar dos números aleatorios como límites
        int min = aleatorio.GenerarEntre(1, 50);
        int max = aleatorio.GenerarEntre(min + 10, 100); // Asegura que haya al menos 10 números posibles

        Console.WriteLine($"Generando arreglo sin repetidos entre {min} y {max}");

        int cantidad = 10;
        int rango = max - min + 1;

        if (cantidad > rango)
        {
            Console.WriteLine("No hay suficientes números únicos en el rango para generar el arreglo.");
            return;
        }

        int[] arreglo = new int[cantidad];
        bool[] usados = new bool[rango];

        int index = 0;
        while (index < cantidad)
        {
            int num = aleatorio.GenerarEntre(min, max);
            if (!usados[num - min])
            {
                arreglo[index] = num;
                usados[num - min] = true;
                index++;
            }
        }

        Console.WriteLine("Arreglo generado:");
        foreach (int n in arreglo)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }
}
