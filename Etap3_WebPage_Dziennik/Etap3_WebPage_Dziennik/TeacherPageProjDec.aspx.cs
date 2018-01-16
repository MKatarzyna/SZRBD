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
    public partial class TeacherPageProjDec : System.Web.UI.Page
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
            DropDownList1.Items.Clear();
            string queryStatement = "SELECT PROJEKTY.Nazwa_projektu, TEMATY_PROJEKTOW.Nazwa_tematu_projektu, STUDENCI.Imie_studenta, STUDENCI.Nazwisko_studenta, STUDENCI.Numer_indeksu_studenta, ZATWIERDZENIE_PROJEKTOW.Deklaracja_studenta, ZATWIERDZENIE_PROJEKTOW.Deklaracja_prowadzacego FROM PROJEKTY, PROWADZACY, STUDENCI, TEMATY_PROJEKTOW, ZATWIERDZENIE_PROJEKTOW WHERE PROJEKTY.ID_prowadzacego = PROWADZACY.ID_prowadzacego AND STUDENCI.ID_studenta = ZATWIERDZENIE_PROJEKTOW.ID_studenta AND ZATWIERDZENIE_PROJEKTOW.ID_prowadzacego = PROWADZACY.ID_prowadzacego AND PROJEKTY.ID_projektu = ZATWIERDZENIE_PROJEKTOW.ID_projektu AND ZATWIERDZENIE_PROJEKTOW.ID_tematu_projektu = TEMATY_PROJEKTOW.ID_tematu_projektu";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            DataTable table = new DataTable();
            _dap.Fill(table);
            _con.Close();
            
            for (int i = 0; i < table.Rows.Count; i++)
            {
                // System.Diagnostics.Debug.WriteLine(table.Rows[i][0].ToString());
                DropDownList1.Items.Add(i.ToString()); //table.Rows[i][1].ToString()
            }

            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        protected void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
            int idProjektu = -1;
            int idStudenta = -1;
            int idProwadzacego = -1;
            //System.Diagnostics.Debug.WriteLine("0_0: " + GridView1.Rows[0].Cells[0].Text);

            string queryStatement = "SELECT PROJEKTY.ID_projektu FROM PROJEKTY WHERE PROJEKTY.Nazwa_projektu LIKE '" + GridView1.Rows[DropDownList1.SelectedIndex].Cells[0].Text + "'";
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

            //*******************************************************

            queryStatement = "SELECT ID_prowadzacego FROM PROJEKTY WHERE ID_projektu =" + idProjektu;
            _cmd = new SqlCommand(queryStatement, _con);

            _con.Open();
            rdr = _cmd.ExecuteReader();
            while (rdr.Read())
            {
                idProwadzacego = (int)rdr["ID_prowadzacego"];
                System.Diagnostics.Debug.WriteLine("S2: " + idProwadzacego);
            }
            _con.Close();
            System.Diagnostics.Debug.WriteLine("idProwadzacego: " + idProwadzacego);

            //*********************************************************

            queryStatement = "SELECT ID_studenta FROM STUDENCI WHERE STUDENCI.Imie_studenta LIKE '" + GridView1.Rows[Int32.Parse(DropDownList1.SelectedItem.Text)].Cells[2].Text + "' AND STUDENCI.Nazwisko_studenta LIKE '" + GridView1.Rows[Int32.Parse(DropDownList1.SelectedItem.Text)].Cells[3].Text + "' AND STUDENCI.Numer_indeksu_studenta LIKE '" + GridView1.Rows[Int32.Parse(DropDownList1.SelectedItem.Text)].Cells[4].Text +"'";
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
            

            System.Diagnostics.Debug.WriteLine("CheckBox: " + CheckBox1.Checked);
            int value = CheckBox1.Checked ? 1 : 0;
            System.Diagnostics.Debug.WriteLine("teacherID: " + teacherID);
            queryStatement = "UPDATE ZATWIERDZENIE_PROJEKTOW SET Deklaracja_prowadzacego = " + value + " WHERE ID_projektu ='" + idProjektu + "' AND ID_prowadzacego ='" + idProwadzacego + "' AND ID_studenta ='" + idStudenta + "'";
            System.Diagnostics.Debug.WriteLine("queryStatement: " + queryStatement);
            _cmd = new SqlCommand(queryStatement, _con);
            _con.Open();
            rdr = _cmd.ExecuteReader();
            _con.Close();
            
        }
    }
}