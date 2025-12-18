using System;

class Template : iTemplate
{
    public void ponerVariable(string nombre, string var)
    {
        Console.WriteLine($"Metodo poner Variable {nombre} : {var}");
    }
    public void verHtml(string template)
    {
        Console.WriteLine(template);
    }
}