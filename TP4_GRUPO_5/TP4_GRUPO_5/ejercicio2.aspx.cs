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
        private const string servidor = @"\SQLEXPRESS";
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
            string filtroIdProducto = "";
            int selectProducto = int.Parse(ddlProducto.SelectedItem.Value);
            if (selectProducto == 0)
            {
                filtroIdProducto = "IdProducto = @IdProducto";
            }
            else if (selectProducto == 1)
            {
                filtroIdProducto = "IdProducto > @IdProducto";
            }
            else
            {
                filtroIdProducto = "IdProducto < @IdProducto";
            }
            string filtroIdCategoria = "";
            int selectCategoria = int.Parse(ddlCategoria.SelectedItem.Value);
            if (selectCategoria == 0)
            {
                filtroIdCategoria = "IdCategoría = @IdCategoria";
            }
            else if (selectCategoria == 1)
            {
                filtroIdCategoria = "IdCategoría > @IdCategoria";
            }
            else
            {
                filtroIdCategoria = "IdCategoría < @IdCategoria";
            }

            SqlConnection sqlConnection = new SqlConnection(urlBD);
            sqlConnection.Open();

            string consultaCompleta = " ";

            if (!string.IsNullOrEmpty(txtIdProducto.Text)|| !string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                consultaCompleta += "WHERE ";
            }
            if (!string.IsNullOrEmpty(txtIdProducto.Text))
            {
                consultaCompleta += filtroIdProducto;
            }
            if (!string.IsNullOrEmpty(txtIdProducto.Text) && !string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                consultaCompleta += " AND ";
            }
            if (!string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                consultaCompleta += filtroIdCategoria;
            }

            string consulta = getProductos + consultaCompleta;           

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            if (!string.IsNullOrEmpty(txtIdProducto.Text))
            {
                sqlCommand.Parameters.AddWithValue("@IdProducto", txtIdProducto.Text);
            }
            if (!string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                sqlCommand.Parameters.AddWithValue("@IdCategoria", txtIdCategoria.Text);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            gvProductos.DataSource = dataTable;
            gvProductos.DataBind();

            sqlConnection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtIdProducto.Text = "";
            txtIdCategoria.Text = "";
            filtrarProductos();


        }
    }
}