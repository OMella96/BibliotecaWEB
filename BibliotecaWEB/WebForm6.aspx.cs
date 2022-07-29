using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

namespace BibliotecaWEB
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NOMBRE"] != null)
            {
                Label1.Text = Session["NOMBRE"].ToString();

            }
            else
            {
                Label1.Text = "No se creo bro";
            }
        }

        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=biblioteca; USER ID = BIBLIOTECA");
        protected void Button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("INSERT INTO LIBROSS VALUES (:id,:nombre,:editorial,:portada,:categoria,:cantidad)", conexion);
            comando.Parameters.Add(":id", TextBox1.Text);
            comando.Parameters.Add(":nombre", TextBox2.Text);
            comando.Parameters.Add(":editorial", TextBox4.Text);
            comando.Parameters.Add(":portada", TextBox5.Text);
            comando.Parameters.Add(":categoria", TextBox6.Text);
            comando.Parameters.Add(":cantidad", TextBox7.Text);

            OracleDataReader lector = comando.ExecuteReader();
 

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conexion.Open();

            OracleCommand comando = new OracleCommand("DELETE FROM LIBROSS where ID = :id", conexion);
            comando.Parameters.Add(":id", TextBox1.Text);

            OracleDataReader lector = comando.ExecuteReader();
        }

    }
}