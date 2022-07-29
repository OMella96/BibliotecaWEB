using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

namespace BibliotecaWEB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }
        OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD=biblioteca; USER ID = BIBLIOTECA");

        protected void Button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM usuarios WHERE NOMBRE= :nombre AND PASSWORD= :password", conexion);
            comando.Parameters.Add(":nombre", TextBox1.Text);
            comando.Parameters.Add(":password", TextBox2.Text);
            OracleDataReader lector = comando.ExecuteReader();
            

            if (lector.Read())
            {
                if (lector["ROL"].ToString() == "admin")
                {
                    Session["NOMBRE"] = TextBox1.Text;
                    Server.Transfer("Webform2.aspx");
                    conexion.Close();
                }

                if (lector["ROL"].ToString() == "estudiante")
                {
                    Session["NOMBRE"] = TextBox1.Text;
                    Server.Transfer("Webform3.aspx");
                    conexion.Close();
                }
                if (lector["ROL"].ToString() == "profesor")
                {
                    Session["NOMBRE"] = TextBox1.Text;
                    Server.Transfer("Webform4.aspx");
                    conexion.Close();
                }
            }
            else
            {
                
                conexion.Close();
            }

        }
    }
}