using System;

public class Cuenta{

    private string idCuenta;

    public Cuenta(string prmtIdCuentea){
        this.idCuenta = prmtIdCuentea;
        System.Console.WriteLine("Constructor clase base para cuenta {0}" + prmtIdCuentea);
    }

    public virtual void CalcularInteres(){
        System.Console.WriteLine("Cuenta.CalcularIntereses() efectuado para la cuenta {0}", this.idCuenta);
    }

    public string getIdCuenta(){
        return this.idCuenta;
    }
}