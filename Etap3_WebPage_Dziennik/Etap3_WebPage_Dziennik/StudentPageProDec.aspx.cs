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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string queryStatement = "SELECT PROJEKTY.Nazwa_projektu, tematy_projektow.Nazwa_tematu_projektu, ZATWIERDZENIE_PROJEKTOW.Deklaracja_prowadzacego, ZATWIERDZENIE_PROJEKTOW.Deklaracja_studenta, prowadzacy.Imie_prowadzacego, prowadzacy.Nazwisko_prowadzacego FROM zatwierdzenie_projektow, tematy_projektow, prowadzacy, studenci, PROJEKTY WHERE studenci.ID_studenta = zatwierdzenie_projektow.ID_studenta AND prowadzacy.ID_prowadzacego = zatwierdzenie_projektow.ID_prowadzacego AND zatwierdzenie_projektow.ID_tematu_projektu = tematy_projektow.ID_tematu_projektu AND ZATWIERDZENIE_PROJEKTOW.ID_projektu = PROJEKTY.ID_projektu AND STUDENCI.ID_studenta = " + studentID;
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
    }
}