using System;

public class Aleatorios
{
    private Random generador;

    public Aleatorios()
    {
        generador = new Random();
    }

    // Método i: Generar un número entre dos valores
    public int GenerarEntre(int min, int max)
    {
        return generador.Next(min, max + 1);
    }

    // Método ii: Generar un arreglo de números entre dos valores aleatorios
    public int[] GenerarArreglo(int cantidad, int min, int max)
    {
        int[] arreglo = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = GenerarEntre(min, max);
        }
        return arreglo;
    }
}
