using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

namespace BibliotecaWEB
{
    public partial class WebForm12 : System.Web.UI.Page
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
            OracleCommand comando = new OracleCommand("INSERT INTO CATEGORIA VALUES (:id,:categoria)", conexion);
            comando.Parameters.Add(":id", TextBox1.Text);
            comando.Parameters.Add(":categoria", TextBox2.Text);

            OracleDataReader lector = comando.ExecuteReader();
            DropDownList1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conexion.Open();

            OracleCommand comando = new OracleCommand("DELETE FROM CATEGORIA where ID = :id", conexion);
            comando.Parameters.Add(":id", TextBox1.Text);

            OracleDataReader lector = comando.ExecuteReader();
        }
    }
}