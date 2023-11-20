using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityWebPage
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e) //cuando apretamos el botón cancelar 
        {
            //se vacía lo que haya escrito el usuario en los inputs
            txtLoginID.Text = string.Empty; 
            txtLoginPass.Text = string.Empty;

            //y se vuelve a la home page.
            //Response.Redirect(HomePage.aspx);

        }
    }
}