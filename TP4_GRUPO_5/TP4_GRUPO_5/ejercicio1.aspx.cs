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
    public partial class ejercicio1 : System.Web.UI.Page
    {
        private const string servidorLocal = @"SANTIDEV\SQLEXPRESS";
        private const string urlBD = @"Data Source=" + servidorLocal + ";Initial Catalog=Viajes;Integrated Security=True";
        private string getProvincias = "SELECT * FROM Provincias";
        private string getLocalidades = "SELECT * FROM Localidades WHERE IdProvincia = @IdProvincia";

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
                cargarLocalidadesPartida();
                int provinciaSeleccionada = Convert.ToInt32(ddlProvinciaPartida.SelectedItem.Value);
                cargarProvinciaDestinoExcepto(provinciaSeleccionada);
                cargarLocalidadesDestino();
            }

        }

        private void cargarLocalidadesPartida()
        {
            int idProvincia = Convert.ToInt32(ddlProvinciaPartida.SelectedValue);


            SqlConnection connection = new SqlConnection(urlBD);

            connection.Open();

            //crear comando sql

            SqlCommand sqlCommand = new SqlCommand(getLocalidades, connection);
            sqlCommand.Parameters.AddWithValue("@IdProvincia", idProvincia);

            //ejecutar consulta
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlLocalidadPartida.Items.Clear();

            // Asignar los resultados al ddlLocalidad

            if (sqlDataReader.HasRows)
            {
                ddlLocalidadPartida.DataSource = sqlDataReader;
                ddlLocalidadPartida.DataTextField = "NombreLocalidad";
                ddlLocalidadPartida.DataValueField = "IdLocalidad";
                ddlLocalidadPartida.DataBind();
            }
            sqlDataReader.Close();

        }
        
        protected void ddlProvinciaPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarLocalidadesPartida();
            int idProvincia = Convert.ToInt32(ddlProvinciaPartida.SelectedValue);
            cargarProvinciaDestinoExcepto(idProvincia);
            cargarLocalidadesDestino();
        }

        protected void ddlProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarLocalidadesDestino();
        }

        private void cargarProvinciaDestinoExcepto(int idProvincia)
        {
            SqlConnection connection = new SqlConnection(urlBD);
            connection.Open();

            string getProvinciasFiltradas = getProvincias + " WHERE IdProvincia<>" + idProvincia;
            SqlCommand sqlCommand = new SqlCommand(getProvinciasFiltradas, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlProvinciaDestino.Items.Clear();

            if (sqlDataReader.HasRows)
            {
                ddlProvinciaDestino.DataSource = sqlDataReader;
                ddlProvinciaDestino.DataTextField = "NombreProvincia";
                ddlProvinciaDestino.DataValueField = "IdProvincia";
                ddlProvinciaDestino.DataBind();
            }
            sqlDataReader.Close();
        }

        private void cargarLocalidadesDestino()
        {
            int idProvincia = Convert.ToInt32(ddlProvinciaDestino.SelectedValue);

            SqlConnection connection = new SqlConnection(urlBD);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(getLocalidades, connection);
            sqlCommand.Parameters.AddWithValue("@IdProvincia", idProvincia);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlLocalidadDestino.Items.Clear();

            if (sqlDataReader.HasRows)
            {
                ddlLocalidadDestino.DataSource = sqlDataReader;
                ddlLocalidadDestino.DataTextField = "NombreLocalidad";
                ddlLocalidadDestino.DataValueField = "IdLocalidad";
                ddlLocalidadDestino.DataBind();
            }
            sqlDataReader.Close();
        }

        protected void btnComprar_Click1(object sender, EventArgs e)
        {
            string provinciaPartida = ddlProvinciaPartida.SelectedItem.Text;
            string localidadPartida = ddlLocalidadPartida.SelectedItem.Text;
            string provinciaDestino = ddlProvinciaDestino.SelectedItem.Text;
            string localidadDestino = ddlLocalidadDestino.SelectedItem.Text;
            lblMensajeCompra.Text = "BOLETO a PAGAR:";
            lblDetalleMensaje.Text = "PARTIDA: " + localidadPartida + " ( " + provinciaPartida + " )";
            lblDetalleMensaje2.Text = "DESTINO: " + localidadDestino + " ( " + provinciaDestino + " )";
        }
    }
}
