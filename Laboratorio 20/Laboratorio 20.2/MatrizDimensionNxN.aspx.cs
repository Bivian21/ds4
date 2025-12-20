using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_20._2
{
    public partial class MatrizDimensionNxN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int N = int.Parse(txtN.Text);
            string html = "<table border='1' style='border-collapse:collapse;'>";

            for (int i = 0; i < N; i++)
            {
                html += "<tr>";
                for (int j = 0; j < N; j++)
                {
                    // condición para la diagonal inversa
                    if (i + j == N - 1)
                        html += "<td>1</td>";
                    else
                        html += "<td>0</td>";
                }
                html += "</tr>";
            }

            html += "</table>";
            litTabla.Text = html;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            litTabla.Text = "";
            txtN.Text = "";
        }
    }
}