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
    public partial class ClubRepRegPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void ClubRepReg(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String reg_name = Rep_name.Text;
            String reg_username = Rep_username.Text;
            String reg_password = Rep_password.Text;
            String reg_club = Rep_clubName.Text;
            if (reg_name.Length == 0 || reg_username.Length == 0 || reg_password.Length == 0 || reg_club.Length == 0)
            {
                RepRegError.Text = "Make sure you have entered all fields";

            }
            else
            {
                String username_exists = "SELECT * FROM SystemUser WHERE username='" + reg_username + "'";
                SqlDataAdapter sqlData = new SqlDataAdapter(username_exists, conn);
                DataTable data2 = new DataTable();
                sqlData.Fill(data2);
                if (data2.Rows.Count > 0)
                {
                    RepRegError.Text = "This username already exists";
                }
                else
                {   
                String club_exists = "SELECT * FROM Club WHERE name='" + reg_club + "'";
                    SqlDataAdapter sqlData2 = new SqlDataAdapter(club_exists, conn);
                    DataTable data = new DataTable();
                    sqlData2.Fill(data);
                    String club_has_rep = "SELECT * FROM Representative R INNER JOIN Club C ON C.cid=R.cid WHERE C.name='" + reg_club + "'";
                    SqlDataAdapter sqlData3 = new SqlDataAdapter(club_has_rep, conn);
                    DataTable data5 = new DataTable();
                    sqlData3.Fill(data5);
                    sqlData2.Fill(data);
                    if (data.Rows.Count == 0)
                        RepRegError.Text = "This club doesn't exist";
                    else if(data5.Rows.Count>0)
                    { RepRegError.Text = "This club already has a representative"; }
                    else
                    {
                        SqlCommand addRepProc = new SqlCommand("addRepresentative", conn);
                        addRepProc.CommandType = CommandType.StoredProcedure;
                        addRepProc.Parameters.Add(new SqlParameter("@name", reg_name));
                        addRepProc.Parameters.Add(new SqlParameter("@clubName", reg_club));
                        addRepProc.Parameters.Add(new SqlParameter("@username", reg_username));
                        addRepProc.Parameters.Add(new SqlParameter("@password", reg_password));
                        addRepProc.ExecuteNonQuery();
                        RepRegError.Text = "You are now successfully registered";
                        Response.AddHeader("REFRESH", "5;URL=Login.aspx");
                        conn.Close();

                    }
                }
            }
        }
    }
    }
