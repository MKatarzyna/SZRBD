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
    public partial class TeacherPageProjects : System.Web.UI.Page
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
            Button1_Click(sender, e);
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
            string queryStatement = "SELECT PROJEKTY.Nazwa_projektu, TEMATY_PROJEKTOW.Nazwa_tematu_projektu, TEMATY_PROJEKTOW.Ilosc_osob_w_projekcie, TEMATY_PROJEKTOW.Pozostala_ilosc_osob FROM zatwierdzenie_projektow, tematy_projektow, prowadzacy, PROJEKTY WHERE PROWADZACY.ID_prowadzacego = PROJEKTY.ID_prowadzacego AND ZATWIERDZENIE_PROJEKTOW.ID_prowadzacego = ZATWIERDZENIE_PROJEKTOW.ID_prowadzacego AND ZATWIERDZENIE_PROJEKTOW.ID_tematu_projektu = TEMATY_PROJEKTOW.ID_tematu_projektu AND ZATWIERDZENIE_PROJEKTOW.ID_projektu = PROJEKTY.ID_projektu AND PROWADZACY.ID_prowadzacego =" + teacherID;
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
            _con.Open();
            DataTable table = new DataTable();
            _dap.Fill(table);
            _con.Close();

            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}