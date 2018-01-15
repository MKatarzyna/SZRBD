using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etap3_WebPage_Dziennik
{
    public partial class AdminPage : System.Web.UI.Page
    {
       // string ID = "";

        String strConnection = "Data Source=KATE-LAPTOP;Initial Catalog=Dziennik;User ID=Kate;Password=baza";
        SqlConnection _con;
        string adminID = "";
        int idUzytkownika = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*  ID = Request.QueryString["ID"];
              System.Diagnostics.Debug.WriteLine("id: " + ID);
              Response.Write("<script>alert('Admin succesfully logged. Admin ID: " + ID + "')</script>");
              */
            _con = new SqlConnection(strConnection);
            adminID = Request.QueryString["ID"];
            System.Diagnostics.Debug.WriteLine("id: " + adminID);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string queryStatement = "SELECT ADMINISTRATOR.Imie_admin, ADMINISTRATOR.Nazwisko_admin, UZYTKOWNICY_SYSTEMU.Login_uzytkownika, UZYTKOWNICY_SYSTEMU.Haslo_uzytkownika FROM ADMINISTRATOR INNER JOIN UZYTKOWNICY_SYSTEMU ON ADMINISTRATOR.ID_uzytkownika = UZYTKOWNICY_SYSTEMU.ID_uzytkownika WHERE ADMINISTRATOR.ID_administrator = " + adminID;
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                TextBox1.Text = (string)rdr["Imie_admin"];
                TextBox2.Text = (string)rdr["Nazwisko_admin"];
                TextBox7.Text = (string)rdr["Login_uzytkownika"];
                TextBox8.Text = (string)rdr["Haslo_uzytkownika"];
            }
            _con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!TextBox7.Text.Equals("") && !TextBox8.Text.Equals(""))
            {
                string queryStatement = "SELECT UZYTKOWNICY_SYSTEMU.ID_uzytkownika FROM ADMINISTRATOR, UZYTKOWNICY_SYSTEMU WHERE ADMINISTRATOR.ID_uzytkownika = UZYTKOWNICY_SYSTEMU.ID_uzytkownika AND ADMINISTRATOR.ID_administrator =" + adminID;
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
    }
}