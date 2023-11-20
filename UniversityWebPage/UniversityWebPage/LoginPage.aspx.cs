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
            //se vacía lo que haya escrito el usuario en los inputs y se ocultan los label de errores:
            txtLoginID.Text = string.Empty; 
            txtLoginPass.Text = string.Empty;
            lblErrorID.Visible = false;
            lblErrorPass.Visible = false;

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

                string query = "SELECT Users.ID, Users.Password, UserCategories.Name FROM Users, UserCategories WHERE Users.ID ='" + insertedIDNumber +"' AND Users.Category = UserCategories.ID"; //hacemos un Select con el ID de usuario

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

                //lblPrueba.Text = "'" + loginDataList[0] + "'" + loginDataList[1] + "'" + loginDataList[2] + "'";

                if (loginDataList[0] == null) //si no ha encontrado el dni del usuario:
                {
                    lblErrorID.Visible = true; //se muestra el error de ID incorrecto
                }
                else //si ha encontrado el dni del usuario:
                {
                    lblErrorID.Visible = false; //se esconde el error del ID incorrecto
                    if(insertedPass == loginDataList[1]) //si la contraseña de la bbdd es la misma que la que ha escrito el usuario:
                    {
                        //ocultamos el label del error de password:
                        lblErrorPass.Visible = false;

                        //guardamos el ID y la categoria en Session, no guardamos la password para tener más seguridad y no tener la password todo el tiempo guardada.
                        Session["ID"] = loginDataList[0];
                        Session["Category"] = loginDataList[2];


                        /*
                        string stringprueba = Session["ID"] as string;
                        string stringprueba2 = Session["Category"] as string;

                        lblPrueba.Text = "'" + stringprueba +"'" + stringprueba2 + "'";
                        */


                        if (loginDataList[2] == "student") //si la category es student:
                        {
                            //Response.Redirect("StudentPage.aspx"); //se redirige a la pagina del estudiante.
                            lblPrueba2.Text = "Es estudiante!";
                        }

                        if (loginDataList[2] == "professor") //si la category es profesor:
                        {
                            Response.Redirect("ProfessorsPage.aspx"); //se redirige a la pagina del profesor.  
                        }

                        if (loginDataList[2] == "administrator") //si la category es admin:
                        {
                            Response.Redirect("AdministratorPage.aspx"); //se redirige a la pagina del admin.                           
                        }
                    }
                    else
                    {
                        lblErrorPass.Visible = true;
                    }
                }

            }


            

        }
    }
}