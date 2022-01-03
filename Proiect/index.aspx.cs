using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proiect
{
    public partial class index : System.Web.UI.Page

    {
        CurrentAccount acc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] != null)
            {
                acc = (CurrentAccount)Session["acc"];
                LoadWelcome();
                // Response.Write($"Hello {acc.Name} {acc.Surname}");

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void LoadWelcome()
        {
            lblWelcome.Text = $"Bine ai venit, {acc.Name}";
        }

        protected void DisplayInLabel()
        {
            /*
            Connection conn = new Connection();
            DataTable data = conn.TblExtract("SELECT * FROM tblUsers");
            lblDisplay.Text = "";
            foreach(DataRow dr in data.Rows)
            {
                lblDisplay.Text = lblDisplay.Text + $"{dr["name"].ToString()} {dr["surname"].ToString()} {dr["email"].ToString()} {dr["psw"].ToString() } <br/>";
            }
            */
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchInDB(txtSearch.Text);
        }

        protected void SearchInDB(string text)
        {
            Connection conn = new Connection();
            DataTable data = conn.TblExtract($"SELECT * FROM tblUsers WHERE name='{text}' OR surname='{text}' OR email='{text}'");
            if (data.Rows.Count > 0)
            {
                lblResult.Text = "Textul cautat exista in baza de date";
            } else
            {
                lblResult.Text = "Textul cautat NU exista in baza de date";
            }
        }

        protected void btnExitSession_Click(object sender, EventArgs e)
        {
            Session.Remove("acc");
            Response.Redirect("login.aspx");
        }

        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string cmdTxt = $"DELETE FROM tblUsers WHERE id='{lblID.Text}'";
            conn.TblAction(cmdTxt);
            // to update the GridView data
            GridView1.DataBind();
            resetFields();

        }

        protected void btnUpdateConfirm_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            updateRecord();
            resetFields();
        }

        protected void updateRecord()
        {
            Connection conn = new Connection();
            string cmdText = $"UPDATE tblUsers SET name='{txtNameUpdate.Text}', surname='{txtSurnameUpdate.Text}', email='{txtEmailUpdate.Text}' WHERE id='{lblID.Text}'";
            conn.TblAction(cmdText);
            Response.Write("Action completed");
            GridView1.DataBind();
        }

        protected void resetFields()
        {
            lblID.Text = "";
            txtNameUpdate.Text = "";
            txtSurnameUpdate.Text = "";
            txtEmailUpdate.Text = "";
            btnDeleteRecord.Enabled = false;
            btnUpdateRecord.Enabled = false;
        }
        protected void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add current data to text boxes
            lblID.Text = GridView1.SelectedRow.Cells[1].Text;
            txtNameUpdate.Text = GridView1.SelectedRow.Cells[2].Text;
            txtSurnameUpdate.Text = GridView1.SelectedRow.Cells[3].Text;
            txtEmailUpdate.Text = GridView1.SelectedRow.Cells[4].Text;
            btnDeleteRecord.Enabled = true;
            btnUpdateRecord.Enabled = true;

        }

        protected void btnUpdateConfirm_Click1(object sender, EventArgs e)
        {
            updateRecord();
        }
    }
}