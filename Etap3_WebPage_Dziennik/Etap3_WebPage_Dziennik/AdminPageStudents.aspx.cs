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
    public partial class AdminPageStudents : System.Web.UI.Page
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
            string queryStatement = "SELECT STUDENCI.Imie_studenta, STUDENCI.Nazwisko_studenta, STUDENCI.Numer_indeksu_studenta, WYDZIAL.Nazwa_wydzialu, KIERUNEK.Nazwa_kierunku, GRUPA.Nazwa_grupy,  UZYTKOWNICY_SYSTEMU.Login_uzytkownika, UZYTKOWNICY_SYSTEMU.Haslo_uzytkownika FROM STUDENCI INNER JOIN UZYTKOWNICY_SYSTEMU ON STUDENCI.ID_uzytkownika = UZYTKOWNICY_SYSTEMU.ID_uzytkownika INNER JOIN GRUPA ON STUDENCI.ID_grupy = GRUPA.ID_grupy INNER JOIN KIERUNEK ON GRUPA.ID_kierunku = KIERUNEK.ID_kierunku INNER JOIN WYDZIAL ON KIERUNEK.ID_wydzialu = WYDZIAL.ID_wydzialu";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            DataTable table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                // System.Diagnostics.Debug.WriteLine(table.Rows[i][0].ToString());
                DropDownList1.Items.Add(i.ToString());
            }

            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            //if (!TextBox2.Text.Equals("") && !TextBox3.Text.Equals("") && !TextBox4.Text.Equals("") && !TextBox5.Text.Equals("") && !TextBox6.Text.Equals("") && !TextBox7.Text.Equals(""))
            //{
            int idUzytkownika = -1;
            int idStudenta = -1;

            string queryStatement = "SELECT ID_uzytkownika FROM UZYTKOWNICY_SYSTEMU WHERE Login_uzytkownika LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[4].Text + "' AND Haslo_uzytkownika LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[5].Text + "'";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idUzytkownika = (int)rdr["ID_uzytkownika"];
            }
            _con.Close();
            //System.Diagnostics.Debug.WriteLine("idUzytkownika: " + idUzytkownika);

            queryStatement = "SELECT ID_studenta FROM STUDENCI WHERE Imie_studenta LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[0].Text + "' AND Nazwisko_studenta LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[1].Text + "'";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idStudenta = (int)rdr["ID_studenta"];
            }
            _con.Close();
            //System.Diagnostics.Debug.WriteLine("idProwadzacego: " + idProwadzacego);

            //update
            System.Diagnostics.Debug.WriteLine("login: " + TextBox6.Text);
            System.Diagnostics.Debug.WriteLine("pass: " + TextBox7.Text);
            queryStatement = "UPDATE UZYTKOWNICY_SYSTEMU SET Login_uzytkownika = '" + TextBox6.Text + "', Haslo_uzytkownika = '" + TextBox7.Text + "' WHERE ID_uzytkownika LIKE " + idUzytkownika;
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();

            //update
            queryStatement = "UPDATE STUDENCI SET Imie_studenta = '" + TextBox2.Text + "', Nazwisko_studenta = '" + TextBox3.Text + "', Numer_indeksu_studenta = '" + TextBox4.Text + "', Nazwa_wydzialu = '" + TextBox5.Text + "', Nazwa_kierunku = '" + TextBoxDirection.Text + "', Nazwa_grupy = '" + TextBoxGroup + " WHERE ID_studenta LIKE " + idStudenta + " AND ID_uzytkownika LIKE " + idUzytkownika;
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();

            Label1.Text = "Student data updated";
            Button1_Click(sender, e);
            /*} else
            {
                Label1.Text = "Please select Row AND load data by using 'Read data' button";
            }*/
        }

        protected void ButtonReadData1_Click(object sender, EventArgs e)
        {
            TextBox2.Text = GridView1.Rows[DropDownList1.SelectedIndex].Cells[0].Text;
            TextBox3.Text = GridView1.Rows[DropDownList1.SelectedIndex].Cells[1].Text;
            TextBox4.Text = GridView1.Rows[DropDownList1.SelectedIndex].Cells[2].Text;
            TextBox5.Text = GridView1.Rows[DropDownList1.SelectedIndex].Cells[3].Text;
            TextBoxDirection.Text = GridView1.Rows[DropDownList1.SelectedIndex].Cells[4].Text;
            TextBoxGroup.Text = GridView1.Rows[DropDownList1.SelectedIndex].Cells[5].Text;
            TextBox6.Text = GridView1.Rows[DropDownList1.SelectedIndex].Cells[6].Text;
            TextBox7.Text = GridView1.Rows[DropDownList1.SelectedIndex].Cells[7].Text;
            }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string queryStatement = "SELECT MAX(ID_uzytkownika) FROM UZYTKOWNICY_SYSTEMU";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            int maxIDuzytkownika = (int)_cmd.ExecuteScalar();
            _con.Close();

            queryStatement = "INSERT INTO uzytkownicy_systemu(ID_uzytkownika, Login_uzytkownika, Haslo_uzytkownika) VALUES (" + (maxIDuzytkownika + 1) + ",'" + TextBox6.Text + "','" + TextBox7.Text + "')";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            _con.Close();

            // maxIDuzytkownika
            queryStatement = "SELECT ID_uzytkownika FROM UZYTKOWNICY_SYSTEMU WHERE Login_uzytkownika LIKE '" + TextBox6.Text + "' AND Haslo_uzytkownika LIKE '" + TextBox7.Text + "'; ";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                maxIDuzytkownika = (int)rdr["ID_uzytkownika"];
            }
            _con.Close();

            queryStatement = "SELECT MAX(ID_studenta) FROM STUDENCI";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            int maxIDStudenci = (int)_cmd.ExecuteScalar();
            _con.Close();

            queryStatement = "INSERT INTO studenci(ID_studenta, ID_uzytkownika, Imie_studenta, Nazwisko_studenta, Numer_indeksu_studenta, Nazwa_wydzialu, Nazwa_kierunku, Nazwa_grupy) VALUES(" + (maxIDStudenci + 1) + ", " + maxIDuzytkownika + ", '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + TextBoxDirection.Text + "', '" + TextBoxGroup.Text + "')";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();

            Label1.Text = "New student created";
            Button1_Click(sender, e);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            // id prowadzacy, delete 1
            // id uzykownika, delte 2
            int idUzytkownika = -1;
            int idStudenta = -1;

            string queryStatement = "SELECT ID_uzytkownika FROM UZYTKOWNICY_SYSTEMU WHERE Login_uzytkownika LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[4].Text + "' AND Haslo_uzytkownika LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[5].Text + "'";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idUzytkownika = (int)rdr["ID_uzytkownika"];
            }
            _con.Close();

            queryStatement = "SELECT ID_studenta FROM STUDENCI WHERE Imie_studenta LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[0].Text + "' AND Nazwisko_studenta LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[1].Text + "'";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idStudenta = (int)rdr["ID_studenta"];
            }
            _con.Close();

            queryStatement = "DELETE FROM STUDENCI WHERE ID_studenta LIKE " + idStudenta + " AND ID_uzytkownika LIKE " + idUzytkownika;
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();

            queryStatement = "DELETE FROM UZYTKOWNICY_SYSTEMU WHERE ID_uzytkownika LIKE " + idUzytkownika;
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();

            Label1.Text = "Student removed from system.";
            Button1_Click(sender, e);
        }

    }
}