using System;

class Program
{
    static void Main(string[] args)
    {
        Template temp1 = new Template();
        temp1.ponerVariable("var1", "valor2");
        temp1.ponerVariable("var2", "valor2");
        temp1.ponerVariable("var3", "valor3");
        temp1.verHtml("<br> Texto de Prueba </br>");
    }
}