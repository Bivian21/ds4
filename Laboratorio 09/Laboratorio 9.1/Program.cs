using System;

class ProgramaPago
{
    static void Main()
    {
        Console.Write("Ingrese el precio del producto: ");
        string precioProducto = Console.ReadLine();
        decimal precio;

        if (!decimal.TryParse(precioProducto, out precio))
        {
            Console.WriteLine("Precio inválido.");
            return;
        }

        Console.Write("Seleccione la forma de pago (efectivo/tarjeta): ");
        string formaPago = Console.ReadLine()?.ToLower();

        if (formaPago == "efectivo")
        {
            Console.WriteLine($"Pago en efectivo registrado. Total: ${precio}");
        }
        else if (formaPago == "tarjeta")
        {
            Console.Write("Ingrese el número de cuenta (16 dígitos): ");
            string cuenta = Console.ReadLine();

            if (cuenta.Length == 16 && long.TryParse(cuenta, out _))
            {
                Console.WriteLine($"Pago con tarjeta registrado. Total: ${precio}");
                Console.WriteLine($"Número de cuenta: {cuenta}");
            }
            else
            {
                Console.WriteLine("Número de cuenta inválido. Debe tener 16 dígitos numéricos.");
            }
        }
        else
        {
            Console.WriteLine("Forma de pago no reconocida.");
        }
    }
}
