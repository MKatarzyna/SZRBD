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
    public partial class AdminPageGroups : System.Web.UI.Page
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
            string queryStatement = "SELECT GRUPA.Nazwa_grupy, KIERUNEK.Nazwa_kierunku, WYDZIAL.Nazwa_wydzialu FROM GRUPA INNER JOIN KIERUNEK ON GRUPA.ID_kierunku = KIERUNEK.ID_kierunku INNER JOIN WYDZIAL ON KIERUNEK.ID_wydzialu = WYDZIAL.ID_wydzialu";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            DataTable table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                // System.Diagnostics.Debug.WriteLine(table.Rows[i][0].ToString());
                DropDownList1.Items.Add(table.Rows[i][1].ToString());
            }

            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            /*
             SEZON nowy = new SEZON();
            nowy.SEZ_ROK = int.Parse(tbxSezonRok.Text);
            db.SEZON.Add(nowy);
            db.SaveChanges();
            Response.Redirect("/Administrator.aspx");
             */
           // GRUPA grupa = new GRUPA();
        }
    }
}