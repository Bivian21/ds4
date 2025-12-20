using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio154
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            int num1, num2, resul;

            num1= int.Parse(txtNumero1.Text);
            num2= int.Parse(txtNumero2.Text);

            resul = num1 + num2;

            lblResultado.Text = $"El resultado de la suma es: {resul.ToString()}";
        }
    }
}