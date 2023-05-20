using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class StadiumManagerRegPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SMReg(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String reg_name = SM_name.Text;
            String reg_username = SM_username.Text;
            String reg_password = SM_password.Text;
            String reg_stadium = SM_stadiumName.Text;
            if (reg_name.Length == 0 || reg_username.Length == 0 || reg_password.Length == 0 || reg_stadium.Length == 0)
            {
               SMRegError.Text = "Make sure you have entered all fields";

            }
            else
            {
                String username_exists = "SELECT * FROM SystemUser WHERE username='" + reg_username + "'";
                SqlDataAdapter sqlData = new SqlDataAdapter(username_exists, conn);
                DataTable data2 = new DataTable();
                sqlData.Fill(data2);
                if (data2.Rows.Count > 0)
                {
                    SMRegError.Text = "This username already exists";
                }
                else
                {
                    String stadium_exists = "SELECT * FROM Stadium WHERE name='" + reg_stadium + "'";
                    SqlDataAdapter sqlData2 = new SqlDataAdapter(stadium_exists, conn);
                    DataTable data = new DataTable();
                    sqlData2.Fill(data);
                    String stadium_hasmanager = "SELECT * FROM StadiumManager SM INNER JOIN Stadium S ON S.id=SM.sid WHERE S.name='" + reg_stadium + "'";
                    SqlDataAdapter sqlData3 = new SqlDataAdapter(stadium_hasmanager, conn);
                    DataTable data3 = new DataTable();
                    sqlData3.Fill(data3);
                    if (data.Rows.Count == 0)
                        SMRegError.Text = "This stadium doesn't exist";
                    else
                    {
                        if (data3.Rows.Count > 0)
                            SMRegError.Text = "This stadium already has a manager";
                        else
                        {
                            SqlCommand addSMProc = new SqlCommand("addStadiumManager", conn);
                            addSMProc.CommandType = CommandType.StoredProcedure;
                            addSMProc.Parameters.Add(new SqlParameter("@stadiumManagerName", reg_name));
                            addSMProc.Parameters.Add(new SqlParameter("@stadium_name", reg_stadium));
                            addSMProc.Parameters.Add(new SqlParameter("@user_name", reg_username));
                            addSMProc.Parameters.Add(new SqlParameter("@password", reg_password));
                            addSMProc.ExecuteNonQuery();
                            SMRegError.Text = "You are now successfully registered";
                            Response.AddHeader("REFRESH", "2;URL=Login.aspx");
                            conn.Close();

                        }
                    }
                }
            }
        }

    }
    }