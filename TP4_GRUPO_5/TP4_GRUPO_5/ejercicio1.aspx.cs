using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_GRUPO_5
{
    public partial class ejercicio1 : System.Web.UI.Page
    {
        private const string servidorLocal = @"";
        private const string urlBD = @"Data Source="+servidorLocal+";Initial Catalog=Viajes;Integrated Security=True";
        private string getProvincias = "SELECT * FROM Provincias";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /// Conexion a Base de Datos

                SqlConnection connection = new SqlConnection(urlBD);
                connection.Open();

                /// Consulta Provincias Inicial

                SqlCommand sqlCommand = new SqlCommand(getProvincias, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                /// Cargar el DropDownList Inicial

                ddlProvinciaPartida.DataSource = sqlDataReader;
                ddlProvinciaPartida.DataTextField = "NombreProvincia";
                ddlProvinciaPartida.DataValueField = "IdProvincia";
                ddlProvinciaPartida.DataBind();

                connection.Close();
            }
        }
    }
}