using System;

namespace Laboratorio22
{
    public class Program
    {
        public static void Main()
        {
            MyClass.Valor = 37;
            Console.WriteLine(MyClass.Valor);
        }
    }

    public class MyClass
    {
        public static int Valor;
    }
}