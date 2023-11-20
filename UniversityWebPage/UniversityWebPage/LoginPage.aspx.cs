using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//libreria para usar bbdd sqlite
using System.Data.SQLite;

namespace UniversityWebPage
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e) //cuando apretamos el botón cancelar: 
        {
            //se vacía lo que haya escrito el usuario en los inputs
            txtLoginID.Text = string.Empty; 
            txtLoginPass.Text = string.Empty;

            //y se vuelve a la home page.
            //Response.Redirect(HomePage.aspx);

        }

        protected void btnEnter_Click(object sender, EventArgs e) //cuando apretamos el botón enter:
        {
            //se recogen los datos de los inputs
            String insertedIDNumber = txtLoginID.Text;
            String insertedPass = txtLoginPass.Text;

            //se busca el la base de datos el ID y se comprueba si la contraseña es la misma

                //localización del archivo de la base de datos:
            string DBPath = Server.MapPath("database.db");

                //abriendo conexión con la base de datos, usamos using para que se cierre la conexión correctamente cuando salgamos del bloque:
            using(SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBPath + ";Version=3;"))
            {
                conn.Open();

                string[] loginDataList = new string[3]; //creamos el array donde vamos a recoger los datos

                string query = "SELECT ID, Password, Category FROM Users WHERE ID='" + insertedIDNumber +"'"; //hacemos un Select con el ID de usuario

                //metemos lo que seleccione en un DataReader:

                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataReader reader = comm.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                foreach(DataRow row in dt.Rows)
                {
                    loginDataList[0] = row[0].ToString();
                    loginDataList[1] = row[1].ToString();
                    loginDataList[2] = row[2].ToString();
                }

                lblPrueba.Text = "'" + loginDataList[0] + "'" + loginDataList[1] + "'" + loginDataList[2] + "'";

            }


            /*
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBPath + ";Version=3;"))
            {
                conn.Open();

                string[] loginDataList = new string[2];

                string Username = txtLoginName.Text;
                string Userpass = txtLoginPass.Text;

                string query = "SELECT username, password, profile FROM Users WHERE username='" + Username + "' AND password='" + Userpass + "'";

                SQLiteCommand comm = new SQLiteCommand(query, conn);

                SQLiteDataReader reader = comm.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                foreach (DataRow dr in dt.Rows)
                {
                    loginDataList[0] = dr[0].ToString();
                    loginDataList[1] = dr[2].ToString();
                }

                Session["dbInfo"] = loginDataList;
            }


            Response.Redirect("UnsecuredPage.aspx");

            */

        }
    }
}