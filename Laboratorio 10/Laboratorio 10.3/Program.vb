Imports System

Module Peso
    Sub Main()
        'Declaracion de variables
        Dim M As Double
        Dim G As Double
        Dim P As Double

        'Ingesar valor a las variables
        G = 9.8
        Console.WriteLine("Ingrese la masa del objeto: ")
        M = Console.ReadLine()

        'Realizar el calculo
        P = M * G

        'Mostrar el resultado
        Console.WriteLine("Peso del objeto: {0}", P)
        Console.ReadKey()
    End Sub
End Module
