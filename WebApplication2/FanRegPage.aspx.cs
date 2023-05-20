using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Security.Cryptography;

namespace WebApplication2
{
    public partial class FanRegPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void FanRegister(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String reg_name = fan_name.Text;
            String reg_username = fan_username.Text;
            String reg_password = fan_password.Text;
            String reg_nid = fan_nid.Text;
            String reg_birthdate = fan_birthdate.Text;
            String reg_phone = fan_number.Text;
            String reg_address = fan_address.Text;

            if (reg_name.Length == 0 || reg_username.Length == 0 || reg_password.Length == 0 || reg_nid.Length == 0 || reg_birthdate.Length == 0 || reg_address.Length == 0 || reg_phone.Length == 0)
            {
                FanRegError.Text = "Make sure you have entered all fields";

            }
            else
            {
                String username_exists = "SELECT * FROM SystemUser WHERE username='" + reg_username + "'";
                SqlDataAdapter sqlData = new SqlDataAdapter(username_exists, conn);
                DataTable data2 = new DataTable();
                sqlData.Fill(data2);
                if (data2.Rows.Count > 0)
                    FanRegError.Text = "This username already exists";
                else
                {
                    String FanExists = "SELECT * FROM Fans WHERE nID='" + reg_nid + "'";
                    SqlDataAdapter sqlData2 = new SqlDataAdapter(FanExists, conn);
                    DataTable data = new DataTable();
                    sqlData2.Fill(data);
                    if (data.Rows.Count > 0)
                        FanRegError.Text = "This national id is already registered";
                    else
                    {
                        DateTime outH;
                        if (DateTime.TryParse(reg_birthdate, out outH))
                        {
                            SqlCommand addFanProc = new SqlCommand("addFan", conn);
                            addFanProc.CommandType = CommandType.StoredProcedure;
                            addFanProc.Parameters.Add(new SqlParameter("@fan_name", reg_name));
                            addFanProc.Parameters.Add(new SqlParameter("@fan_username", reg_username));
                            addFanProc.Parameters.Add(new SqlParameter("@password", reg_password));
                            addFanProc.Parameters.Add(new SqlParameter("@nID", reg_nid));
                            addFanProc.Parameters.Add(new SqlParameter("@birthDate", reg_birthdate));
                            addFanProc.Parameters.Add(new SqlParameter("@address", reg_address));
                            addFanProc.Parameters.Add(new SqlParameter("@phone_no", reg_phone));
                            addFanProc.ExecuteNonQuery();
                            FanRegError.Text = "You are now successfully registered";
                            Response.AddHeader("REFRESH", "2;URL=Login.aspx");
                            conn.Close();
                        }
                        else
                            FanRegError.Text = "Please make sure you have entered date in correct format";
                    }
                }
 
            }
        }
    }
}

                 