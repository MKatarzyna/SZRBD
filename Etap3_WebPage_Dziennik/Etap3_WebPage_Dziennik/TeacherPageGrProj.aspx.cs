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
    public partial class TeacherPageGrProj : System.Web.UI.Page
    {
        String strConnection = "Data Source=KATE-LAPTOP;Initial Catalog=Dziennik;User ID=Kate;Password=baza";
        SqlConnection _con;
        string teacherID = "";
        int idUzytkownika = -1;
        DateTime dateTime = DateTime.UtcNow.Date;

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
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();
            DropDownList5.Items.Clear();
            DropDownList6.Items.Clear();
            DropDownList7.Items.Clear();

            string queryStatement = "SELECT PROJEKTY.Nazwa_projektu, STUDENCI.Imie_studenta, STUDENCI.Nazwisko_studenta, STUDENCI.Numer_indeksu_studenta, OCENY_PROJEKT.Ocena_projekt, OCENY_PROJEKT.Uwagi_projekt FROM PROJEKTY, PROWADZACY, STUDENCI, OCENY_PROJEKT WHERE PROJEKTY.ID_prowadzacego = PROWADZACY.ID_prowadzacego AND STUDENCI.ID_studenta = OCENY_PROJEKT.ID_studenta AND OCENY_PROJEKT.ID_prowadzacego = PROWADZACY.ID_prowadzacego AND PROJEKTY.ID_projektu = OCENY_PROJEKT.ID_projektu AND PROWADZACY.ID_prowadzacego =" + teacherID;
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
                DropDownList5.Items.Add(i.ToString());
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList6.Items.Add(i.ToString());
            }

            queryStatement = "SELECT Numer_indeksu_studenta, Imie_studenta, Nazwisko_studenta FROM STUDENCI";
            _cmd = new SqlCommand(queryStatement, _con);

            _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList1.Items.Add(table.Rows[i][0].ToString() + " " + table.Rows[i][1].ToString() + " " + table.Rows[i][2].ToString());
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList2.Items.Add(table.Rows[i][0].ToString());
            }

            DropDownList3.Items.Add("5");
            DropDownList3.Items.Add("4");
            DropDownList3.Items.Add("3");
            DropDownList3.Items.Add("2");
            DropDownList3.Items.Add("1");
            DropDownList3.Items.Add("NULL");

            DropDownList7.Items.Add("5");
            DropDownList7.Items.Add("4");
            DropDownList7.Items.Add("3");
            DropDownList7.Items.Add("2");
            DropDownList7.Items.Add("1");
            DropDownList7.Items.Add("NULL");

            queryStatement = "SELECT Nazwa_projektu FROM PROJEKTY WHERE ID_prowadzacego =" + teacherID;
            _cmd = new SqlCommand(queryStatement, _con);

            _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList4.Items.Add(table.Rows[i][0].ToString());
            }

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            //spawdzenie czy jest w bazie
            //id projektu
            //id studenta
            //id prowadzacego OK

            int idProjektu = -1;
            int idStudenta = -1;
           

            //System.Diagnostics.Debug.WriteLine("0_0: " + GridView1.Rows[0].Cells[0].Text);

            string queryStatement = "SELECT PROJEKTY.ID_projektu FROM PROJEKTY WHERE PROJEKTY.Nazwa_projektu LIKE '" + DropDownList4.SelectedValue + "'";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idProjektu = (int)rdr["ID_projektu"];
                System.Diagnostics.Debug.WriteLine("S1: " + idProjektu);
            }
            _con.Close();
            System.Diagnostics.Debug.WriteLine("idProjektu: " + idProjektu);

            queryStatement = "SELECT ID_studenta FROM STUDENCI WHERE STUDENCI.Numer_indeksu_studenta LIKE '" + DropDownList2.Items[DropDownList1.SelectedIndex].Text + "'";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idStudenta = (int)rdr["ID_studenta"];
                System.Diagnostics.Debug.WriteLine("S3: " + idStudenta);
            }
            _con.Close();
            System.Diagnostics.Debug.WriteLine("idStudenta: " + idStudenta);

            // SPRAWDZENIE CZY ISTNIEJE, bo unikalny wpis!!!!!

            queryStatement = "SELECT COUNT(*) FROM OCENY_PROJEKT WHERE ID_projektu LIKE "+idProjektu+" AND ID_prowadzacego LIKE "+teacherID+" AND ID_studenta LIKE "+idStudenta;
            _cmd = new SqlCommand(queryStatement, _con);

            _con.Open();
            int userCount = (int)_cmd.ExecuteScalar();
            _con.Close();
            if (userCount == 0)
            {
                queryStatement = "INSERT INTO OCENY_PROJEKT (ID_projektu, ID_prowadzacego, ID_studenta, Ocena_projekt, Data_projekt, Uwagi_projekt) VALUES (" + idProjektu + "," + teacherID + "," + idStudenta + "," + DropDownList3.SelectedValue + "," + (string)dateTime.ToString("yyyy-MM-dd") + ",'" + TextBox1.Text + "')";
                _cmd = new SqlCommand(queryStatement, _con);
                _con.Open();
                rdr = _cmd.ExecuteReader();
                _con.Close();
                Label1.Text = "Grade added successfully to student for selected project.";
                Button1_Click(sender, e);
            }
            else
            {
                Label1.Text = "This studnet has grade from selected project!";
            }
    
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int idProjektu = -1;
            int idStudenta = -1;

          //  System.Diagnostics.Debug.WriteLine("DDL: " + DropDownList5.SelectedIndex);
          //  System.Diagnostics.Debug.WriteLine("GridView: " + GridView1.Rows[DropDownList5.SelectedIndex].Cells[0].Text);
            
            string queryStatement = "SELECT PROJEKTY.ID_projektu FROM PROJEKTY WHERE PROJEKTY.Nazwa_projektu LIKE '" + GridView1.Rows[DropDownList5.SelectedIndex].Cells[0].Text + "'";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idProjektu = (int)rdr["ID_projektu"];
                System.Diagnostics.Debug.WriteLine("S1: " + idProjektu);
            }
            _con.Close();
            System.Diagnostics.Debug.WriteLine("idProjektu: " + idProjektu);

            queryStatement = "SELECT ID_studenta FROM STUDENCI WHERE STUDENCI.Numer_indeksu_studenta LIKE '" + GridView1.Rows[DropDownList5.SelectedIndex].Cells[3].Text + "'";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idStudenta = (int)rdr["ID_studenta"];
                System.Diagnostics.Debug.WriteLine("S3: " + idStudenta);
            }
            _con.Close();
            System.Diagnostics.Debug.WriteLine("idStudenta: " + idStudenta);

            queryStatement = "DELETE FROM OCENY_PROJEKT WHERE ID_projektu LIKE "+idProjektu+ " AND ID_prowadzacego LIKE "+teacherID+" AND ID_studenta LIKE "+idStudenta;
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();
            Label1.Text = "This studnet grade was removed!";

            Button1_Click(sender, e);
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            int idProjektu = -1;
            int idStudenta = -1;

            string queryStatement = "SELECT PROJEKTY.ID_projektu FROM PROJEKTY WHERE PROJEKTY.Nazwa_projektu LIKE '" + GridView1.Rows[DropDownList6.SelectedIndex].Cells[0].Text + "'";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            SqlDataReader rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idProjektu = (int)rdr["ID_projektu"];
                System.Diagnostics.Debug.WriteLine("S1: " + idProjektu);
            }
            _con.Close();
            System.Diagnostics.Debug.WriteLine("idProjektu: " + idProjektu);

            queryStatement = "SELECT ID_studenta FROM STUDENCI WHERE STUDENCI.Numer_indeksu_studenta LIKE '" + GridView1.Rows[DropDownList6.SelectedIndex].Cells[3].Text + "'";
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idStudenta = (int)rdr["ID_studenta"];
                System.Diagnostics.Debug.WriteLine("S3: " + idStudenta);
            }
            _con.Close();
            System.Diagnostics.Debug.WriteLine("idStudenta: " + idStudenta);

            queryStatement = "UPDATE OCENY_PROJEKT SET Ocena_projekt = " + DropDownList7.SelectedValue + ", Data_projekt = '" + (string)dateTime.ToString("yyyy-MM-dd") + "', Uwagi_projekt = '" + TextBox2.Text + "' WHERE ID_projektu LIKE "+ idProjektu +" AND ID_prowadzacego LIKE "+ teacherID +" AND ID_studenta LIKE " + idStudenta;
            _cmd = new SqlCommand(queryStatement, _con);

            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();
            Label1.Text = "This studnet grade was edited successfully!";

            Button1_Click(sender, e);
        }
    }
}