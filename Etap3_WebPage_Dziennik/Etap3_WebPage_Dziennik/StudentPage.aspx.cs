using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etap3_WebPage_Dziennik
{
    public partial class StudentPage : System.Web.UI.Page
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
            //Response.Write("<script>alert('Student succesfully logged. Student ID: " + ID + "')</script>");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string queryStatement =
                "SELECT STUDENCI.Numer_indeksu_studenta, STUDENCI.Imie_studenta, STUDENCI.Nazwisko_studenta, GRUPA.Nazwa_grupy, WYDZIAL.Nazwa_wydzialu, KIERUNEK.Nazwa_kierunku, UZYTKOWNICY_SYSTEMU.Login_uzytkownika, UZYTKOWNICY_SYSTEMU.Haslo_uzytkownika FROM  STUDENCI INNER JOIN GRUPA ON STUDENCI.ID_grupy = GRUPA.ID_grupy INNER JOIN KIERUNEK ON GRUPA.ID_kierunku = KIERUNEK.ID_kierunku INNER JOIN WYDZIAL ON KIERUNEK.ID_wydzialu = WYDZIAL.ID_wydzialu INNER JOIN UZYTKOWNICY_SYSTEMU ON STUDENCI.ID_uzytkownika = UZYTKOWNICY_SYSTEMU.ID_uzytkownika WHERE STUDENCI.ID_studenta = " + studentID;
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                TextBox1.Text = (string)rdr["Imie_studenta"];
                TextBox2.Text = (string)rdr["Nazwisko_studenta"];
                TextBox3.Text = (string)rdr["Numer_indeksu_studenta"];
                TextBox4.Text = (string)rdr["Nazwa_kierunku"];
                TextBox5.Text = (string)rdr["Nazwa_wydzialu"];
                TextBox6.Text = (string)rdr["Nazwa_grupy"];
                TextBox7.Text = (string)rdr["Login_uzytkownika"];
                TextBox8.Text = (string)rdr["Haslo_uzytkownika"];
            }
            _con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!TextBox7.Text.Equals("") && !TextBox8.Text.Equals(""))
            {
                string queryStatement = "SELECT UZYTKOWNICY_SYSTEMU.ID_uzytkownika FROM STUDENCI, UZYTKOWNICY_SYSTEMU WHERE STUDENCI.ID_uzytkownika = UZYTKOWNICY_SYSTEMU.ID_uzytkownika AND STUDENCI.ID_studenta =" + studentID;
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