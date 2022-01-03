using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proiect
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("acc");
        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            // check if email already exists
            Connection conn = new Connection();

            string email = txtEmail.Text;
            DataTable data = conn.TblExtract($"SELECT * FROM tblUsers WHERE email='{email}'");

            if (data.Rows.Count > 0)
            {
                bottomBarText.Text = "Aceasta adresa a fost deja inregistrata. <a class=\"switch-page-link\" href=\"login.aspx\">Intra aici</a>";
            } else
            {
                // if not, add new user to db
                string cmdText = "INSERT INTO tblUsers (name,surname,email,psw) VALUES ('" + txtName.Text + "','" + txtSurname.Text + "','" + txtEmail.Text + "','" + txtPsw.Text + "')";
                conn.TblAction(cmdText);
                Response.Redirect("login.aspx");
            }
            
        }

        protected void ChangeBottomBarText(string response)
        {
           bottomBarText.Text = response;
        }
    }
}