Imports System

Module area
    Sub Main()
        Dim radio As Single
        Dim area As Single
        Dim circunferencia As Single
        Const pi = 3.1415926

        Console.WriteLine("Ingrese el radio: ")
        radio = Console.ReadLine()

        area = pi * radio * radio
        circunferencia = 2 * pi * radio

        Console.WriteLine("El area es= {0}", area)
        Console.WriteLine("La circunsferencia es= {0}", circunferencia)

        Console.ReadKey()
    End Sub
End Module
