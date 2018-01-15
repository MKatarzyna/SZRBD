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
    public partial class StudentPageSubjects : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string queryStatement = "SELECT PRZEDMIOTY.Nazwa_przedmiotu, OCENY_PRZEDMIOT.Uwagi_przedmiot, OCENY_PRZEDMIOT.Data_przedmiot, OCENY_PRZEDMIOT.Ocena_przedmiot, PROWADZACY.Imie_prowadzacego, PROWADZACY.Nazwisko_prowadzacego FROM PRZEDMIOTY INNER JOIN OCENY_PRZEDMIOT ON PRZEDMIOTY.ID_przedmiotu = OCENY_PRZEDMIOT.ID_przedmiotu INNER JOIN STUDENCI ON OCENY_PRZEDMIOT.ID_studenta = STUDENCI.ID_studenta INNER JOIN PROWADZACY ON PRZEDMIOTY.ID_prowadzacego = PROWADZACY.ID_prowadzacego WHERE STUDENCI.ID_studenta = " + studentID;
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