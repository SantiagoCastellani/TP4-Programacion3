using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_GRUPO_5
{
    public partial class ejercicio2 : System.Web.UI.Page
    {
        private const string servidor = @"";
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
    }
}