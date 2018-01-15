﻿using System;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string queryStatement = "SELECT PROJEKTY.Nazwa_projektu, TEMATY_PROJEKTOW.Nazwa_tematu_projektu, STUDENCI.Imie_studenta, STUDENCI.Nazwisko_studenta, ZATWIERDZENIE_PROJEKTOW.Deklaracja_studenta, ZATWIERDZENIE_PROJEKTOW.Deklaracja_prowadzacego FROM PROJEKTY, PROWADZACY, STUDENCI, TEMATY_PROJEKTOW, ZATWIERDZENIE_PROJEKTOW WHERE PROJEKTY.ID_prowadzacego = PROWADZACY.ID_prowadzacego AND STUDENCI.ID_studenta = ZATWIERDZENIE_PROJEKTOW.ID_studenta AND ZATWIERDZENIE_PROJEKTOW.ID_prowadzacego = PROWADZACY.ID_prowadzacego AND PROJEKTY.ID_projektu = ZATWIERDZENIE_PROJEKTOW.ID_projektu AND ZATWIERDZENIE_PROJEKTOW.ID_tematu_projektu = TEMATY_PROJEKTOW.ID_tematu_projektu";
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