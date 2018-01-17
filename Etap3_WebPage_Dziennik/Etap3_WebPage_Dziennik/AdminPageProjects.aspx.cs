using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etap3_WebPage_Dziennik
{
    public partial class AdminPageProjects : System.Web.UI.Page
    {
        String strConnection = "Data Source=KATE-LAPTOP;Initial Catalog=Dziennik;User ID=Kate;Password=baza";
        SqlConnection _con;
        string adminID = "";
        int idUzytkownika = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            _con = new SqlConnection(strConnection);
            adminID = Request.QueryString["ID"];
            System.Diagnostics.Debug.WriteLine("id: " + adminID);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx?ID=" + adminID);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageGroups.aspx?ID=" + adminID);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageSubjects.aspx?ID=" + adminID);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageProjects.aspx?ID=" + adminID);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageTeachers.aspx?ID=" + adminID);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageStudents.aspx?ID=" + adminID);
        }

        protected void ButtonBackLP_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();
            DropDownList5.Items.Clear();
            DropDownList6.Items.Clear();
            DropDownList11.Items.Clear();

            string queryStatement = "SELECT PROJEKTY.Nazwa_projektu, PROWADZACY.Imie_prowadzacego, PROWADZACY.Nazwisko_prowadzacego FROM PROWADZACY INNER JOIN PROJEKTY ON PROWADZACY.ID_prowadzacego = PROJEKTY.ID_prowadzacego";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            DataTable table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            GridView1.DataSource = table;
            GridView1.DataBind();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList11.Items.Add(i.ToString());
            }

            queryStatement = "SELECT PROJEKTY.Nazwa_projektu, PROJEKTY.ID_projektu FROM PROJEKTY";
            _cmd = new SqlCommand(queryStatement, _con);

            _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList1.Items.Add(table.Rows[i][0].ToString());
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList4.Items.Add(table.Rows[i][1].ToString());
            }

            //
            queryStatement = "SELECT Imie_prowadzacego, Nazwisko_prowadzacego, ID_prowadzacego FROM PROWADZACY";
            _cmd = new SqlCommand(queryStatement, _con);

            _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList2.Items.Add(table.Rows[i][0].ToString() + " " + table.Rows[i][1].ToString());
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList3.Items.Add(table.Rows[i][2].ToString());
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList5.Items.Add(table.Rows[i][0].ToString() + " " + table.Rows[i][1].ToString());
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList6.Items.Add(table.Rows[i][2].ToString());
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            string idProjektu = DropDownList4.Items[DropDownList1.SelectedIndex].Text;
            string idProwadzacego = DropDownList3.Items[DropDownList2.SelectedIndex].Text;

            string queryStatement = "UPDATE PROJEKTY SET ID_prowadzacego = " + idProwadzacego + " WHERE ID_projektu = " + idProjektu;
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            _con.Close();

            Label1.Text = "Teacher assigned to select project.";
            Button1_Click(sender, e);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            string idProwadzacego = DropDownList6.Items[DropDownList5.SelectedIndex].Text;
            string projectName = TextBox1.Text;

            string queryStatement = "SELECT MAX(ID_projektu) FROM PROJEKTY";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            int maxID = (int)_cmd.ExecuteScalar();
            _con.Close();

            queryStatement = "INSERT INTO PROJEKTY (ID_projektu, ID_prowadzacego ,Nazwa_projektu) VALUES(" + (maxID + 1) + ", " + idProwadzacego + ", '" + projectName + "'); ";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            _con.Close();

            Label1.Text = "Added new project.";
            Button1_Click(sender, e);
        }

        protected void ButtonRemove_Click(object sender, EventArgs e)
        {
            int idProjektu = -1;// DropDownList8.Items[DropDownList7.SelectedIndex].Text;
            int idProwadzacego = -1; //DropDownList10.Items[DropDownList9.SelectedIndex].Text;

            string queryStatement = "SELECT PROJEKTY.ID_projektu FROM PROJEKTY WHERE PROJEKTY.Nazwa_projektu LIKE '" + GridView1.Rows[DropDownList11.SelectedIndex].Cells[0].Text + "'";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idProjektu = (int)rdr["ID_projektu"];
            }
            _con.Close();

            queryStatement = "SELECT ID_prowadzacego FROM PROWADZACY WHERE Imie_prowadzacego LIKE '" + GridView1.Rows[DropDownList11.SelectedIndex].Cells[1].Text + "' AND Nazwisko_prowadzacego LIKE '" + GridView1.Rows[DropDownList11.SelectedIndex].Cells[2].Text + "'";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idProwadzacego = (int)rdr["ID_prowadzacego"];
                //   System.Diagnostics.Debug.WriteLine("S3: " + idStudenta);
            }
            _con.Close();

            queryStatement = "DELETE FROM PROJEKTY WHERE ID_projektu=" + idProjektu + " AND ID_prowadzacego=" + idProwadzacego;
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();

            Label1.Text = "Teacher assigned to select project.";
            Button1_Click(sender, e);
        }

    }
}