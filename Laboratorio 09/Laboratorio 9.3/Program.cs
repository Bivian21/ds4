using System;

class Program
{
    private int[] numero;

    static void Main(string[] args)
    {
        Program triangulo = new Program();
        triangulo.cargarNumero();
        triangulo.claseTriangulo();
    }

    public void cargarNumero()
    {
        numero = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingrese el lado {i + 1}: ");
            numero[i] = int.Parse(Console.ReadLine());
        }
    }

    public void claseTriangulo()
    {
        int a = numero[0], b = numero[1], c = numero[2];

        if (a + b > c && a + c > b && b + c > a)
        {
            if (a == b && b == c)
                Console.WriteLine("El triángulo es equilátero");
            else if (a == b || b == c || a == c)
                Console.WriteLine("El triángulo es isósceles");
            else
                Console.WriteLine("El triángulo es escaleno");
        }
        else
        {
            Console.WriteLine("Los lados ingresados no forman un triángulo válido.");
        }
    }
}
