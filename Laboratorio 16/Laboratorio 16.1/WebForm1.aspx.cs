using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_16._1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        static float a, c, d;
        static char b;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Botones Numerico 1
        protected void b1_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b1.Text;
            }
            else
                t.Text = t.Text + b1.Text;

        }

        //Botones Numerico 2
        protected void b2_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b2.Text;
            }
            else
                t.Text = t.Text + b2.Text;
        }

        //Botones Numerico 3
        protected void b3_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b3.Text;
            }
            else
                t.Text = t.Text + b3.Text;
        }

        //Boton Suma
        protected void add_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(t.Text);
            t.Text = "";
            b = '+';
            t.Text += b;
        }

        //Botones Numerico 4
        protected void b4_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b4.Text;
            }
            else
                t.Text = t.Text + b4.Text;
        }

        // Botones Numerico 5
        protected void b5_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b5.Text;
            }
            else
                t.Text = t.Text + b5.Text;
        }

        // Botones Numerico 6
        protected void b6_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b6.Text;
            }
            else
                t.Text = t.Text + b6.Text;
        }

        // Boton Resta
        protected void sub_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(t.Text);
            t.Text = "";
            b = '-';
            t.Text += b;
        }

        // Botones Numerico 7
        protected void b7_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b7.Text;
            }
            else
                t.Text = t.Text + b7.Text;
        }

        // Botones Numerico 8
        protected void b8_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b8.Text;
            }
            else
                t.Text = t.Text + b8.Text;
        }

        // Botones Numerico 9
        protected void b9_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b9.Text;
            }
            else
                t.Text = t.Text + b9.Text;
        }

        // Boton Multiplicacion
        protected void mul_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(t.Text);
            t.Text = "";
            b = '*';
            t.Text += b;
        }

        // Botones Numerico 0
        protected void b0_Click(object sender, EventArgs e)
        {
            if ((t.Text == "+") || (t.Text == "-") || (t.Text == "*") || (t.Text == "/"))
            {
                t.Text = "";
                t.Text = t.Text + b0.Text;
            }
            else
                t.Text = t.Text + b0.Text;
        }

        // Boton Limpiar Tablero
        protected void clr_Click(object sender, EventArgs e)
        {
            t.Text = "";
        }

        // Boton Igual
        protected void eql_Click(object sender, EventArgs e)
        {
            c = Convert.ToInt32(t.Text);
            t.Text = "";
            if (b == '/')
            {
                d = a / c;
                t.Text += d;
                a = d;
            } else if (b == '+')
            {
                d = a + c;
                t.Text += d;
                a = d;
            } else if (b == '-')
            {
                d = a - c;
                t.Text += d;
                a = d;
            }
            else
            {
                d = a * c;
                t.Text += d;
                a = d;
            }
        }

        // Boton Division
        protected void div_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(t.Text);
            t.Text = "";
            b = '/';
            t.Text += b;
        }
    }
}