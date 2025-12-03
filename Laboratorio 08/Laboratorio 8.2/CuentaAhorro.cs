using System;

public class CuentaAhorro : Cuenta
{
    public CuentaAhorro(string prmtIdCuenta) : base(prmtIdCuenta)
    {
    }
    public override void CalcularInteres()
    {
        System.Console.WriteLine("CuentaAhorro.CalcularIntereses() efectuado para " + "la cuenta {0}", getIdCuenta());
    }
}