using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_20._1
{
    public partial class TablaMultiplicar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTabla_Click(object sender, EventArgs e)
        {
            lstTabla.Items.Clear();

            int numero;
            if (int.TryParse(txtNumero.Text, out numero))
            {
                for (int i = 1; i <= 25; i++)
                {
                    int resultado = numero * i;
                    lstTabla.Items.Add($"{numero} x {i} = {resultado}");
                }
            }
            else
            {
                lstTabla.Items.Add("Por favor ingrese un valor numerico valido.");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            lstTabla.Items.Clear();
            txtNumero.Text = "";
        }
    }
}