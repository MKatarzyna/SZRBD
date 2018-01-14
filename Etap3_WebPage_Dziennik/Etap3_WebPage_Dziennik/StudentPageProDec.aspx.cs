using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etap3_WebPage_Dziennik
{
    public partial class StudentPageProDec : System.Web.UI.Page
    {
        String strConnection = "Data Source=KATE-LAPTOP;Initial Catalog=Dziennik;User ID=Kate;Password=baza";
        SqlConnection _con;
        string studentID = "";
        int idUzytkownika = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            _con = new SqlConnection(strConnection);
            studentID = Request.QueryString["ID"];
            System.Diagnostics.Debug.WriteLine("id: " + studentID);
        }

        protected void ButtonYourData_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx?ID=" + studentID);
        }

        protected void ButtonSubjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPageSubjects.aspx?ID=" + studentID);
        }

        protected void ButtonProjDec_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPageProDec.aspx?ID=" + studentID);
        }

        protected void ButtonProjGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPageProGrades.aspx?ID=" + studentID);
        }

        protected void ButtonBackLP_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}