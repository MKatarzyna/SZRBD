using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Etap3_WebPage_Dziennik
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String strConnection = "Data Source=KATE-LAPTOP;Initial Catalog=Dziennik;User ID=Kate;Password=baza";
        SqlConnection _con;
      //  String loginOnLoginPage = "student1@dziennk.com";
      //  String passwordOnLoginPage = "haslo1";

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            String user = "";
            user = TextBoxUsername.Text;

            String password = "";
            password = TextBoxPassword.Text;

            // Sprawdz czy uzytkownik istnieje
            string queryStatement =
                "SELECT COUNT(*) FROM UZYTKOWNICY_SYSTEMU WHERE Login_uzytkownika LIKE '" + user + "' AND Haslo_uzytkownika like '" + password + "'";
            SqlCommand _cmd = new SqlCommand(queryStatement, _con);

            _con.Open();
            int userCount = (int)_cmd.ExecuteScalar();
            if (userCount > 0)
            {
                queryStatement =
               "SELECT ID_uzytkownika FROM UZYTKOWNICY_SYSTEMU WHERE Login_uzytkownika LIKE '" + user + "' AND Haslo_uzytkownika like '" + password + "'";
                _cmd = new SqlCommand(queryStatement, _con);
                int userID = (int)_cmd.ExecuteScalar();
               // Console.WriteLine(userID);

                Console.WriteLine("USER EXISTS");
                if (RadioButtonList1.SelectedIndex == 2)
                {
                    queryStatement = "SELECT COUNT(*) FROM ADMINISTRATOR WHERE ID_uzytkownika = '" + userID + "'";
                    _cmd = new SqlCommand(queryStatement, _con);
                    int isUserExists = (int)_cmd.ExecuteScalar();
                    if (isUserExists > 0)
                    {
                        queryStatement = "SELECT ID_administrator FROM ADMINISTRATOR WHERE ADMINISTRATOR.ID_uzytkownika = " + userID;
                        _cmd = new SqlCommand(queryStatement, _con);
                        int administratorID = (int)_cmd.ExecuteScalar();
                        Response.Redirect("AdminPage.aspx?ID=" + administratorID);
                    }

                }
                else if (RadioButtonList1.SelectedIndex == 0)
                {
                    queryStatement = "SELECT COUNT(*) FROM STUDENCI WHERE ID_uzytkownika = '" + userID + "'";
                    _cmd = new SqlCommand(queryStatement, _con);
                    int isUserExists = (int)_cmd.ExecuteScalar();
                    if (isUserExists > 0)
                    {
                        queryStatement = "SELECT ID_studenta FROM STUDENCI WHERE STUDENCI.ID_uzytkownika = " + userID;
                        _cmd = new SqlCommand(queryStatement, _con);
                        int studentID = (int)_cmd.ExecuteScalar();
                        Response.Redirect("StudentPage.aspx?ID=" + studentID);
                    }
                }
                else if (RadioButtonList1.SelectedIndex == 1)
                {
                    queryStatement = "SELECT COUNT(*) FROM PROWADZACY WHERE ID_uzytkownika = '" + userID + "'";
                    _cmd = new SqlCommand(queryStatement, _con);
                    int isUserExists = (int)_cmd.ExecuteScalar();
                    if (isUserExists > 0)
                    {
                        queryStatement = "SELECT ID_prowadzacego FROM PROWADZACY WHERE PROWADZACY.ID_uzytkownika = " + userID;
                        _cmd = new SqlCommand(queryStatement, _con);
                        int prowadzacyID = (int)_cmd.ExecuteScalar();
                        Response.Redirect("TeacherPage.aspx?ID=" + prowadzacyID);
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please, select type of user.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('This user doesn't exists.')</script>");
            }
            _con.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _con = new SqlConnection(strConnection);
            // TextBoxUsername.Text = loginOnLoginPage;
           // TextBoxPassword.Text = passwordOnLoginPage;
        }
    }
}