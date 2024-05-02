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
    public partial class ejercicio3 : System.Web.UI.Page
    {
        private const string servidor = @"AXEL\SQLEXPRESS";
        private const string urlBD = @"Data Source=" + servidor + ";Initial Catalog=Libreria;Integrated Security=True";
        private string getTemas = "SELECT IdTema,Tema FROM Temas";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /// Conexion a Base de Datos

                SqlConnection connection = new SqlConnection(urlBD);
                connection.Open();

                /// Consulta Temas

                SqlCommand sqlCommand = new SqlCommand(getTemas, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                /// Cargar el DropDownList

                ddlTemas.DataSource = sqlDataReader;
                ddlTemas.DataTextField = "Tema";
                ddlTemas.DataValueField = "IdTema";
                ddlTemas.DataBind();

                connection.Close();
            }
        }
        protected void ddlTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void lbLibros_Click(object sender, EventArgs e)
        {
            Response.Redirect("ejercicio3b.aspx?idTema=" + ddlTemas.SelectedValue);

        }
    }
}