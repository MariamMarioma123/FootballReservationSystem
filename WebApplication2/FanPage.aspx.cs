using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace WebApplication2
{
    public partial class FanPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String fan_user = (String)Session["username"];
            fanUser.Text = "Hello " + fan_user + " :)";


        }
        protected void BackTo(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", "2;URL=Login.aspx");

        }

        protected void CheckTime(object sender, EventArgs e)
        {
            String time = timeMatchStart.Text;
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            DateTime time2;
            if (DateTime.TryParse(time, out time2)){
                String query = "SELECT DISTINCT C.name AS host_club, C2.name AS guest_club, S.name AS stadium, S.location AS location FROM Match M INNER JOIN Stadium S ON S.id=M.sid INNER JOIN Club C ON C.cid=M.host_cid INNER JOIN Ticket T ON T.mid=M.mid INNER JOIN Club C2 ON C2.cid=M.guest_cid WHERE T.status='1' AND M.start_time='" + time2 + "'";
                SqlDataAdapter sql = new SqlDataAdapter(query, conn);
                DataTable d1 = new DataTable();
                sql.Fill(d1);
                if (time.Length == 0)
                {
                    error1.Text = "Please make sure you have entered all fields";
                }
                else if (d1.Rows.Count == 0)
                {
                    nullCase.Text = "There are no matches available for this time.";
                    searchResu.DataSource = "";
                    searchResu.DataBind();
                }
                else
                {
                    nullCase.Text = "";
                    searchResu.DataSource = d1;
                    searchResu.DataBind();
                    conn.Close();
                }
            }
            else
                error1.Text = "Make sure you enter start time in correct format";
        }  
        protected void ReservePlace(object sender, EventArgs e)
        {
            String Fan_user = (String)Session["username"];
            String host_name = host_names.Text;
            String guest_name = guest_names.Text;
            String start_time = time_ss.Text;
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if (host_name.Length == 0 || guest_name.Length == 0 || start_time.Length == 0)
                purchaseStatus.Text = "Make sure you have entered all fields";
            else
            {
                String n_ID = "SELECT nID FROM Fans WHERE username='" + Fan_user + "'";
                SqlCommand sql3 = new SqlCommand(n_ID, conn);
                String n_ID2 = (String)sql3.ExecuteScalar();
                String validClub1 = "SELECT * FROM Club WHERE name='" + host_name + "'";
                String validClub2 = "SELECT * FROM Club WHERE name='" + guest_name + "'";
                SqlDataAdapter sqlCheck1 = new SqlDataAdapter(validClub1, conn);
                SqlDataAdapter sqlCheck2 = new SqlDataAdapter(validClub2, conn);
                DataTable d2 = new DataTable();
                DataTable d3 = new DataTable();
                sqlCheck1.Fill(d2);
                sqlCheck2.Fill(d3);
                if (d2.Rows.Count == 0)
                {
                    purchaseStatus.Text = "Invalid host club name";
                }
                else if (d3.Rows.Count == 0)
                {
                    purchaseStatus.Text = "Invalid guest club name";
                }
                else
                {

                    DateTime outCheck;
                    if (DateTime.TryParse(start_time, out outCheck))
                    {
                       
                        String query = "SELECT DISTINCT C1.name, C2.name FROM Club C1 INNER JOIN Match M ON C1.cid = M.host_cid INNER JOIN Club C2 ON M.guest_cid = C2.cid INNER JOIN Ticket T ON T.mid = M.mid WHERE C1.name ='" + host_name + "' AND C2.name='" + guest_name + "'AND T.status='1' AND M.start_time ='" + outCheck + "'";
                        SqlDataAdapter sql = new SqlDataAdapter(query, conn);
                        DataTable d1 = new DataTable();
                        sql.Fill(d1);
                        if (d1.Rows.Count == 0)
                        {
                            purchaseStatus.Text = "No tickets available for given data";
                        }
                        else
                        {
                            SqlCommand purTicket = new SqlCommand("purchaseTicket", conn);
                            purTicket.CommandType = CommandType.StoredProcedure;
                            purTicket.Parameters.Add(new SqlParameter("@nid", n_ID2));
                            purTicket.Parameters.Add(new SqlParameter("@hostname", host_name));
                            purTicket.Parameters.Add(new SqlParameter("@guestname", guest_name));
                            purTicket.Parameters.Add(new SqlParameter("@start_time", outCheck));
                            purTicket.ExecuteNonQuery();
                            purchaseStatus.Text = "Ticket purchased successfully";
                            conn.Close();

                        }
                    }
                    else
                        purchaseStatus.Text = "Make sure start time is in expected format";


                }
            }
        }
    }
}