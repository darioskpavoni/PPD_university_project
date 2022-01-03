using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proiect
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("acc");
        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string name = "";
            string surname = "";
            string psw = txtPsw.Text;

            Connection conn = new Connection();
            DataTable data  = conn.TblExtract($"SELECT * FROM tblUsers WHERE email='{email}' AND psw='{psw}'");
            if (data.Rows.Count > 0)
            {
                bottomBarText.Text = "Logging in...";
                // I need name, surname and email for the CurrentAccount instance
                // START (this can be modified I believe, since I know in advance it will be a single row --> no foreach needed
                foreach (DataRow row in data.Rows)
                {
                    name = row.Field<string>("name");
                    surname = row.Field<string>("surname");

                }
                // END

                // have to make this one a SessionState var
                Session["acc"] = new CurrentAccount(name, surname, email);
                
                Response.Redirect("index.aspx");
            } else
            {
                bottomBarText.Text = "Aceast cont nu exista. <a class=\"switch-page-link\" href=\"signup.aspx\">Creeaza-ti un cont aici</a>";
            }
    
        }

        protected void emailTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}