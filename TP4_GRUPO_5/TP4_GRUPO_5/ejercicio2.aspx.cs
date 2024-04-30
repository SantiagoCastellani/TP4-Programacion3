using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP4_GRUPO_5
{
    public partial class ejercicio2 : System.Web.UI.Page
    {
        private const string servidor = @"AXEL\SQLEXPRESS";
        private const string urlBD = @"Data Source="+servidor+";Initial Catalog=Neptuno;Integrated Security=True";
        private string getProductos = "SELECT IdProducto,NombreProducto,IdCategoría,CantidadPorUnidad,PrecioUnidad FROM Productos";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /// Conexión a Base de Datos
                SqlConnection connection = new SqlConnection(urlBD);
                connection.Open();

                /// Get Productos
                SqlCommand sqlCommand = new SqlCommand(getProductos, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                /// LLenar GridView
                gvProductos.DataSource = sqlDataReader;
                gvProductos.DataBind();
                connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            filtrarProductos();
        }

        private void filtrarProductos()
        {
            string filtro = string.Empty;
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                filtro = "WHERE IdProducto = @IdProducto";
            }

            string consulta = getProductos + " " + filtro;

            SqlConnection sqlConnection = new SqlConnection(urlBD);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                sqlCommand.Parameters.AddWithValue("@IdProducto", TextBox1.Text);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            gvProductos.DataSource = dataTable;
            gvProductos.DataBind();

            sqlConnection.Close();
        }

    }
}