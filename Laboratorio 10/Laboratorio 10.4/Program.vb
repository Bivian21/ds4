Imports System

Public Module Program
    Public Sub Main(Args() As String)
        Dim perrito As Perro = New Perro()
        perrito.nombre = "Chizu"
        perrito.raza = "Pastor Alemán"
        perrito.altura = "0.70cm"

        Console.WriteLine(perrito.comer("carne"))

        Dim perrito2 As Perro = New Perro()
        perrito2.nombre = "Lazy"
        perrito2.altura = "0.60cm"

        Console.WriteLine(perrito2.comer("Pollo"))

        Dim perrito3 As Perro = New Perro("Peluchin", "Poodle", "0.50cm")

        Console.WriteLine(perrito3.comer("Pan"))
    End Sub
End Module
