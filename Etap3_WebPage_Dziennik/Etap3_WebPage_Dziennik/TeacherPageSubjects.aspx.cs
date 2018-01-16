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
    public partial class TeacherPageSubjects : System.Web.UI.Page
    {
        String strConnection = "Data Source=KATE-LAPTOP;Initial Catalog=Dziennik;User ID=Kate;Password=baza";
        SqlConnection _con;
        string teacherID = "";
        int idUzytkownika = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            _con = new SqlConnection(strConnection);
            teacherID = Request.QueryString["ID"];
            System.Diagnostics.Debug.WriteLine("id: " + teacherID);
        }

        protected void ButtonYourData_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPage.aspx?ID=" + teacherID);
        }

        protected void ButtonSubjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageSubjects.aspx?ID=" + teacherID);
        }

        protected void ButtonProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageProjects.aspx?ID=" + teacherID);
        }

        protected void ButtonGrSub_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageGrSub.aspx?ID=" + teacherID);
        }

        protected void ButtonGrProj_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageGrProj.aspx?ID=" + teacherID);
        }

        protected void ButtonProjDec_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageProjDec.aspx?ID=" + teacherID);
        }

        protected void ButtonBackLP_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string queryStatement = "SELECT PRZEDMIOTY.Nazwa_przedmiotu FROM PRZEDMIOTY INNER JOIN PROWADZACY ON PRZEDMIOTY.ID_prowadzacego = PROWADZACY.ID_prowadzacego";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            DataTable table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                // System.Diagnostics.Debug.WriteLine(table.Rows[i][0].ToString());
                DropDownList1.Items.Add(table.Rows[i][0].ToString());
            }

            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}