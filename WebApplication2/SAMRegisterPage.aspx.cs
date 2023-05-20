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
    public partial class SAMRegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SamReg(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String reg_name = Sam_Name.Text;
            String reg_username = Sam_username.Text;
            String reg_password = Sam_password.Text;
            if (reg_name.Length == 0 || reg_username.Length == 0 || reg_password.Length == 0)
            {
                SamRegError.Text = "Make sure you have entered all fields";

            }
            else
            {
                String username_exists = "SELECT * FROM SystemUser WHERE username='" + reg_username + "'";
                SqlDataAdapter sqlData = new SqlDataAdapter(username_exists, conn);
                DataTable data2 = new DataTable();
                sqlData.Fill(data2);
                if (data2.Rows.Count > 0)
                {
                    SamRegError.Text = "This username already exists";
                }
                else
                {
                    SqlCommand addAssociationProc= new SqlCommand("addAssociationManager", conn);
                    addAssociationProc.CommandType = CommandType.StoredProcedure;
                    addAssociationProc.Parameters.Add(new SqlParameter("@sm_name", reg_name));
                    addAssociationProc.Parameters.Add(new SqlParameter("@user_name",reg_username ));
                    addAssociationProc.Parameters.Add(new SqlParameter("@password",reg_password ));
                    addAssociationProc.ExecuteNonQuery();
                    SamRegError.Text = "You are now successfully registered";
                    Response.AddHeader("REFRESH", "2;URL=Login.aspx");
                    conn.Close();

                }
            }
        }
    }
}