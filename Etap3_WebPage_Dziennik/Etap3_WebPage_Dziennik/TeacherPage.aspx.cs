using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etap3_WebPage_Dziennik
{
    public partial class TeacherPage : System.Web.UI.Page
    {
        // string ID = "";
        String strConnection = "Data Source=KATE-LAPTOP;Initial Catalog=Dziennik;User ID=Kate;Password=baza";
        SqlConnection _con;
        string teacherID = "";
        int idUzytkownika = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            _con = new SqlConnection(strConnection);
            teacherID = Request.QueryString["ID"];
            System.Diagnostics.Debug.WriteLine("id: " + teacherID);

            /*   ID = Request.QueryString["ID"];
               System.Diagnostics.Debug.WriteLine("id: " + ID);
               Response.Write("<script>alert('Teacher succesfully logged. Teacher ID: " + ID + "')</script>");
               */
        }

        protected void ButtonYourData_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPage.aspx");
        }

        protected void ButtonSubjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageSubjects.aspx");
        }

        protected void ButtonProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageProjects.aspx");
        }

        protected void ButtonGrSub_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageGrSub.aspx");
        }

        protected void ButtonGrProj_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageGrProj.aspx");
        }

        protected void ButtonProjDec_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPageProjDec.aspx");
        }

        protected void ButtonBackLP_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string queryStatement =
               "SELECT PROWADZACY.Imie_prowadzacego, PROWADZACY.Nazwisko_prowadzacego, PROWADZACY.Tytul_prowadzacego, PROWADZACY.Katedra_prowadzacego, UZYTKOWNICY_SYSTEMU.Login_uzytkownika, UZYTKOWNICY_SYSTEMU.Haslo_uzytkownika FROM PROWADZACY INNER JOIN UZYTKOWNICY_SYSTEMU ON PROWADZACY.ID_uzytkownika = UZYTKOWNICY_SYSTEMU.ID_uzytkownika WHERE PROWADZACY.ID_prowadzacego = " + teacherID;
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                TextBox1.Text = (string)rdr["Imie_prowadzacego"];
                TextBox2.Text = (string)rdr["Nazwisko_prowadzacego"];
                TextBox3.Text = (string)rdr["Tytul_prowadzacego"];
                TextBox4.Text = (string)rdr["Katedra_prowadzacego"];
                TextBox7.Text = (string)rdr["Login_uzytkownika"];
                TextBox8.Text = (string)rdr["Haslo_uzytkownika"];
            }
            _con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!TextBox7.Text.Equals("") && !TextBox8.Text.Equals(""))
            {
                string queryStatement = "SELECT UZYTKOWNICY_SYSTEMU.ID_uzytkownika FROM PROWADZACY, UZYTKOWNICY_SYSTEMU WHERE PROWADZACY.ID_uzytkownika = UZYTKOWNICY_SYSTEMU.ID_uzytkownika AND PROWADZACY.ID_prowadzacego =" + teacherID;
                SqlCommand _cmd = new SqlCommand(queryStatement, _con);

                _con.Open();
                SqlDataReader rdr = _cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idUzytkownika = (int)rdr["ID_uzytkownika"];
                }
                _con.Close();


                queryStatement = "UPDATE UZYTKOWNICY_SYSTEMU SET Login_uzytkownika = '" + TextBox7.Text + "', Haslo_uzytkownika = '" + TextBox8.Text + "' WHERE ID_uzytkownika = " + idUzytkownika;
                _cmd = new SqlCommand(queryStatement, _con);

                _con.Open();
                rdr = _cmd.ExecuteReader();
                _con.Close();
            }
            else
            {
                Response.Write("<script>alert('Do not leave empty boxes! You must enter your login details and password.')</script>");
            }
        }

        
    }
}