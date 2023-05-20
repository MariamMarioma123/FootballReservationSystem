using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login2(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String login_username = username.Text;
            String login_password = password.Text;
            if (login_username.Length == 0 || login_password.Length == 0)
            {
                errorMessage.Text = "Make sure you have entered all fields";

            }
            else
            {
                String validUser = "SELECT * FROM SystemUser WHERE username='" + login_username + "'";
                String inCorrect= "SELECT * FROM SystemUser WHERE username='"+login_username+"'AND password='" + login_password + "'";
                SqlDataAdapter sqlData = new SqlDataAdapter(validUser, conn);
                DataTable data3 = new DataTable();
                SqlDataAdapter sqlData2 = new SqlDataAdapter(inCorrect, conn);
                DataTable data2 = new DataTable();
                sqlData.Fill(data2);
                sqlData2.Fill(data3);
                if (data2.Rows.Count == 0)
                {
                    errorMessage.Text = "This account doesn't exist";
                }
                else if (data3.Rows.Count == 0)
                {
                    errorMessage.Text = "Password incorrect";
                }
                else
                if (data2.Rows.Count > 0) { 
       
                    Session["username"] = login_username;
                    String isUserSystemAdmin = "SELECT * FROM SystemAdmin WHERE username='" + login_username + "'";
                    SqlDataAdapter SystemAdminUser = new SqlDataAdapter(isUserSystemAdmin, conn);
                    DataTable SA = new DataTable();
                    SystemAdminUser.Fill(SA);
                    if (SA.Rows.Count > 0)
                    {
                        HelperMethodCR(login_username);
                        Response.Redirect("AdminPage.aspx");
                        conn.Close();

                        
                    }
                    String isUserSam = "SELECT * FROM SportsAssociationManager WHERE username='" + login_username + "'";
                    SqlDataAdapter SportsAM = new SqlDataAdapter(isUserSam, conn);
                    DataTable SAM = new DataTable();
                    SportsAM.Fill(SAM);
                    if (SAM.Rows.Count > 0)
                    {
                        Response.Redirect("SportsAssociationManagerPage.aspx");
                        conn.Close();
                    }

                    String isUserFan = "SELECT * FROM Fans WHERE username='" + login_username + "'";
                    String isUserFan2 = "SELECT * FROM Fans WHERE status='0' and username='" + login_username + "'";
                    SqlDataAdapter Fans2 = new SqlDataAdapter(isUserFan2, conn);
                    SqlDataAdapter Fans = new SqlDataAdapter(isUserFan, conn);
                    DataTable fanTable = new DataTable();
                    DataTable fanTable2 = new DataTable();
                    Fans2.Fill(fanTable2);
                    Fans.Fill(fanTable);
                    if (fanTable.Rows.Count > 0 && fanTable2.Rows.Count==0)
                    {
                        Response.Redirect("FanPage.aspx");
                        conn.Close();
                    }
                    if(fanTable.Rows.Count > 0 && fanTable2.Rows.Count > 0)
                        errorMessage.Text = "Fan is blocked";

                    String isUserRepresentative = "SELECT * FROM Representative WHERE username='" + login_username + "'";
                    SqlDataAdapter isRep = new SqlDataAdapter(isUserRepresentative, conn);
                    DataTable RepTable = new DataTable();
                    isRep.Fill(RepTable);
                    if (RepTable.Rows.Count > 0)
                    { 
                        Response.Redirect("ClubRepresentativePage.aspx");
                        conn.Close();
                    }

                    String isUserStadiuManager = "SELECT * FROM StadiumManager WHERE username='" + login_username + "'";
                    SqlDataAdapter isSM = new SqlDataAdapter(isUserStadiuManager, conn);
                    DataTable SmTable = new DataTable();
                    isSM.Fill(SmTable);
                    if (SmTable.Rows.Count > 0)
                    {
                        Response.Redirect("StadiumManagerPage.aspx");
                        conn.Close();
                    }
                }
            }

               
        }


        protected void Register(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        public void HelperMethodCR(String username)
        {
         

        }
    }
}