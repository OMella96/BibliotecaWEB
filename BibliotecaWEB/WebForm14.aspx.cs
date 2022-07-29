using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaWEB
{
    public partial class WebForm14 : System.Web.UI.Page
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
    }
}