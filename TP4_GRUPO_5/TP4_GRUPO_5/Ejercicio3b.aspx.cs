using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace TP4_GRUPO_5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string servidor = @"SANTIDEV\SQLEXPRESS";
        private const string urlBD = @"Data Source=" + servidor + ";Initial Catalog=Libreria;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar el parámetro del tema
                string idTema = Request.QueryString["idTema"];

                // Realizar  consulta
                DataTable libros = ObtenerLibrosPorTema(idTema);

                // Verificar si la consulta se ejecuto y asignar los resultados al GridView
                if (libros != null)
                {
                    gvLibros.DataSource = libros;
                    gvLibros.DataBind();
                }
            }
        }
        private DataTable ObtenerLibrosPorTema(string idTema)
        {
            DataTable Libros = new DataTable();
            SqlConnection connection = new SqlConnection(urlBD);

            string query = "SELECT * FROM Libros WHERE IdTema = @IdTema";

            // Crear el comando SQL
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdTema", idTema);

            // Abrir la conexión y ejecutar la consulta
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(Libros);

            return Libros;
        }

        protected void lbConsultarTema_Click(object sender, EventArgs e)
        {
            Response.Redirect("ejercicio3.aspx");
        }
    }
}