using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etap3_WebPage_Dziennik
{
    public partial class StudentPage : System.Web.UI.Page
    {
        string ID = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = Request.QueryString["ID"];
            System.Diagnostics.Debug.WriteLine("id: " + ID);
            Response.Write("<script>alert('Student succesfully logged. Student ID: " + ID + "')</script>");

        }
    }
}