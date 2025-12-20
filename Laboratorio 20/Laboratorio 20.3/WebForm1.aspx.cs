using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_20._3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["db.Name"].ConnectionString;

        // Usamos ViewState para mantener el estado entre postbacks
        private bool nuevo
        {
            get { return ViewState["nuevo"] != null ? (bool)ViewState["nuevo"] : false; }
            set { ViewState["nuevo"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetFormState();
            }
        }

        private void ResetFormState()
        {
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = true;
            txtBuscar.Enabled = true;

            txtId.Enabled = false;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtBuscar.Text = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;
            txtBuscar.Enabled = false;

            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;

            // Limpiar campos para nuevo registro
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";

            nuevo = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas para todos los casos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                ShowAlert("El campo Nombre es obligatorio");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal precio))
            {
                ShowAlert("El Precio debe ser un número válido (ej: 15.50 o 15,50)");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                ShowAlert("El Stock debe ser un número entero válido");
                return;
            }

            if (nuevo)
            {
                // INSERTAR NUEVO REGISTRO
                string sql = "INSERT INTO LAPTOPS (NOMBRE, PRECIO, STOCK) VALUES (@Nombre, @Precio, @Stock)";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@Stock", stock);

                        con.Open();
                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                ShowAlert("Registro ingresado correctamente!");
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowAlert("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                // ACTUALIZAR REGISTRO EXISTENTE
                // Solo validamos si el txtId no está vacío y es numérico
                if (!string.IsNullOrEmpty(txtId.Text) && int.TryParse(txtId.Text, out int id))
                {
                    string sql = "UPDATE LAPTOPS SET NOMBRE = @Nombre, PRECIO = @Precio, STOCK = @Stock WHERE id = @Id";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@Precio", precio);
                            cmd.Parameters.AddWithValue("@Stock", stock);
                            cmd.Parameters.AddWithValue("@Id", id);

                            con.Open();
                            try
                            {
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    ShowAlert("Registro actualizado correctamente!");
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowAlert("Error: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    ShowAlert("No se puede actualizar: ID inválido o vacío");
                    return;
                }
            }

            ResetFormState();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ResetFormState();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Para eliminar necesitamos validar el ID
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                ShowAlert("ID inválido para eliminar");
                return;
            }

            string sql = "DELETE FROM LAPTOPS WHERE id = @Id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            ShowAlert("Registro eliminado correctamente!");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowAlert("Error: " + ex.Message);
                    }
                }
            }

            ResetFormState();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBuscar.Text, out int idBuscar))
            {
                ShowAlert("Ingrese un ID válido para buscar");
                return;
            }

            string sql = "SELECT * FROM LAPTOPS WHERE ID = @Id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", idBuscar);
                    con.Open();
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                btnNuevo.Enabled = false;
                                btnGuardar.Enabled = true;
                                btnCancelar.Enabled = true;
                                btnEliminar.Enabled = true;
                                btnBuscar.Enabled = false;
                                txtBuscar.Enabled = false;

                                txtNombre.Enabled = true;
                                txtPrecio.Enabled = true;
                                txtStock.Enabled = true;

                                txtId.Text = reader["id"].ToString();
                                txtNombre.Text = reader["nombre"].ToString();
                                txtPrecio.Text = reader["precio"].ToString();
                                txtStock.Text = reader["stock"].ToString();
                                nuevo = false; // Ahora es una actualización
                            }
                            else
                            {
                                ShowAlert("Ningún registro encontrado con el Id ingresado!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowAlert("Error: " + ex.Message);
                    }
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            string mensaje = "⚠️ No es una aplicación de Escritorio\\n\\n" +
                            "✅ Esta es una aplicación Web ASP.NET\\n" +
                            "📱 Puedes cerrar la pestaña del navegador\\n" +
                            "👋 ¡Gracias por probar la aplicación web!";

            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensaje}');", true);
        }

        private void ShowAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
        }
    }
}