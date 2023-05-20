using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace WebApplication2
{
    public partial class SportsAssociationManagerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (String)Session["username"];
            usernameSAM.Text = "Welcome "+ username + " :)";
            HelperMethodUpcomingMatches();
            HelperMethodPlayedMatches();
            HelperMethodNeverClubs();
        }
        protected void BackToLogi(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", "2;URL=Login.aspx");
        }
        protected void AddMatch(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String host_club = host_name.Text;
            String guest_club = guest_name.Text;
            String startTime = start_time.Text;
            String endTime = end_time.Text;
            if (host_club.Length == 0 || guest_club.Length == 0 || startTime.Length == 0 || endTime.Length == 0)
            {
                addMatchError.Text = "Make sure you have entered all fields";

            }
            else
            {
                String host_id = "SELECT cid FROM Club WHERE name='" + host_club + "'";
                String guest_id = "SELECT cid FROM Club WHERE name='" + guest_club + "'";
                SqlDataAdapter sqlData8 = new SqlDataAdapter(host_id, conn);
                SqlDataAdapter sqlData9 = new SqlDataAdapter(guest_id, conn);
                DataTable data8 = new DataTable();
                DataTable data9 = new DataTable();
                sqlData8.Fill(data8);
                sqlData9.Fill(data9);
                if (data8.Rows.Count == 0)
                {
                    addMatchError.Text = "Invalid host club";
                }
                else if (data9.Rows.Count == 0)
                {
                    addMatchError.Text = "Invalid guest club";
                }
                else
                {
                    DateTime out1;
                    DateTime out2;
                    if (DateTime.TryParse(startTime, out out1))
                    {
                        if (DateTime.TryParse(endTime, out out2))
                        {
                            SqlCommand parsing = new SqlCommand(host_id, conn);
                            String a = parsing.ExecuteScalar() + "";
                            int host_cid1 = Int16.Parse(a);
                            SqlCommand parsing2 = new SqlCommand(guest_id, conn);
                            String b = parsing2.ExecuteScalar() + "";
                            int guest_cid1 = Int16.Parse(b);
                            String match_exists = "SELECT * FROM Match WHERE host_cid='" + host_cid1 + "'AND guest_cid='" + guest_cid1 + "'AND start_time='" + startTime + "'AND end_time='" + endTime + "'";
                            String match_exists2 = "SELECT * FROM Match WHERE host_cid='" + guest_cid1 + "'AND guest_cid='" + host_cid1 + "'AND start_time='" + startTime + "'AND end_time='" + endTime + "'";
                            String match_existsAtSameTime = "SELECT * FROM Match WHERE host_cid='" + host_cid1 + "'AND start_time='" + startTime + "'AND end_time='" + endTime + "'";
                            String match_existsAtSameTime2 = "SELECT * FROM Match WHERE host_cid='" + guest_cid1 + "'AND start_time='" + startTime + "'AND end_time='" + endTime + "'";
                            String match_existsAtSameTime3 = "SELECT * FROM Match WHERE guest_cid='" + guest_cid1 + "'AND start_time='" + startTime + "'AND end_time='" + endTime + "'";
                            String match_existsAtSameTime4 = "SELECT * FROM Match WHERE guest_cid='" + host_cid1 + "'AND start_time='" + startTime + "'AND end_time='" + endTime + "'";
                            SqlDataAdapter sqlData = new SqlDataAdapter(match_exists, conn);
                            SqlDataAdapter sqlData2 = new SqlDataAdapter(match_exists2, conn);
                            SqlDataAdapter sqlData3 = new SqlDataAdapter(match_existsAtSameTime, conn);
                            SqlDataAdapter sqlData4 = new SqlDataAdapter(match_existsAtSameTime2, conn);
                            SqlDataAdapter sqlData5 = new SqlDataAdapter(match_existsAtSameTime3, conn);
                            SqlDataAdapter sqlData6 = new SqlDataAdapter(match_existsAtSameTime4, conn);
                            DataTable data = new DataTable();
                            DataTable data2 = new DataTable();
                            DataTable data3 = new DataTable();
                            DataTable data4 = new DataTable();
                            DataTable data5 = new DataTable();
                            DataTable data6 = new DataTable();
                            sqlData.Fill(data);
                            sqlData2.Fill(data2);
                            sqlData3.Fill(data3);
                            sqlData4.Fill(data4);
                            sqlData5.Fill(data5);
                            sqlData6.Fill(data6);
                            if (data2.Rows.Count > 0 || data.Rows.Count > 0)
                                addMatchError.Text = "This match is already scheduled";
                            else if (data3.Rows.Count > 0 || data6.Rows.Count > 0)
                                addMatchError.Text = "Host club is scheduled at the same time for another match";
                            else if (data4.Rows.Count > 0 || data5.Rows.Count > 0)
                                addMatchError.Text = "Guest club is scheduled at the same time for another match";
                            else
                            {
                                if (out2 < out1)
                                    addMatchError.Text = "End time of match cannot be before start time";
                                else
                                {
                                    SqlCommand addMatchProc = new SqlCommand("addNewMatch", conn);
                                    addMatchProc.CommandType = CommandType.StoredProcedure;
                                    addMatchProc.Parameters.Add(new SqlParameter("@host_club", host_club));
                                    addMatchProc.Parameters.Add(new SqlParameter("@guest_club", guest_club));
                                    addMatchProc.Parameters.Add(new SqlParameter("@datetime_start", startTime));
                                    addMatchProc.Parameters.Add(new SqlParameter("@datetime_end", endTime));
                                    addMatchProc.ExecuteNonQuery();
                                    HelperMethodUpcomingMatches();
                                    HelperMethodPlayedMatches();
                                    HelperMethodNeverClubs();
                                    addMatchError.Text = "Match scheduled successfully";
                                    conn.Close();


                                }
                            }
                        }
                        else addMatchError.Text = "Make sure end time is in correct format";

                    }
                    else
                        addMatchError.Text = "Make sure start time is in correct format";
                }
            }
        }
        protected void DeleteMatch(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String host_club = host_name.Text;
            String guest_club = guest_name.Text;
            String startTime = start_time.Text;
            String endTime = end_time.Text;
            if (host_club.Length == 0 || guest_club.Length == 0 || startTime.Length == 0 || endTime.Length == 0)
            {
                addMatchError.Text = "Make sure you have entered all fields";

            }
            else
            {
                DateTime out1;
                DateTime out2;
                if (DateTime.TryParse(startTime, out out1))
                {
                    if (DateTime.TryParse(endTime, out out2))
                    {
                        String host_id = "SELECT cid FROM Club WHERE name='" + host_club + "'";
                        String guest_id = "SELECT cid FROM Club WHERE name='" + guest_club + "'";
                        SqlDataAdapter sqlData8 = new SqlDataAdapter(host_id, conn);
                        SqlDataAdapter sqlData9 = new SqlDataAdapter(guest_id, conn);
                        DataTable data8 = new DataTable();
                        DataTable data9 = new DataTable();
                        sqlData8.Fill(data8);
                        sqlData9.Fill(data9);
                        if (data8.Rows.Count == 0)
                        {
                            addMatchError.Text = "Invalid host club";
                        }
                        else if (data9.Rows.Count == 0)
                        {
                            addMatchError.Text = "Invalid guest club";
                        }
                        else
                        {
                            SqlCommand parsing = new SqlCommand(host_id, conn);
                            String a = parsing.ExecuteScalar() + "";
                            int host_cid1 = Int16.Parse(a);
                            SqlCommand parsing2 = new SqlCommand(guest_id, conn);
                            String b = parsing2.ExecuteScalar() + "";
                            int guest_cid1 = Int16.Parse(b);
                            String match_exists = "SELECT * FROM Match WHERE host_cid='" + host_cid1 + "'AND guest_cid='" + guest_cid1 + "'AND start_time='" + startTime + "'AND end_time='" + endTime + "'";
                            SqlDataAdapter sqlData = new SqlDataAdapter(match_exists, conn);
                            DataTable data = new DataTable();
                            sqlData.Fill(data);
                            if (data.Rows.Count > 0)
                            {
                                SqlCommand deleteMatchProc = new SqlCommand("deleteMatch", conn);
                                deleteMatchProc.CommandType = CommandType.StoredProcedure;
                                deleteMatchProc.Parameters.Add(new SqlParameter("@host_name", host_club));
                                deleteMatchProc.Parameters.Add(new SqlParameter("@guest_name", guest_club));
                                deleteMatchProc.ExecuteNonQuery();
                                HelperMethodUpcomingMatches();
                                HelperMethodPlayedMatches();
                                HelperMethodNeverClubs();
                                addMatchError.Text = "Match removed successfully";
                                conn.Close();

                            }
                            else
                            {
                                addMatchError.Text = "This match already doesn't exist";
                            }
                        }
                    }
                    else
                        addMatchError.Text = "Make sure end time of match is in correct form";
               
                }
                else
                    addMatchError.Text = "Make sure start time of match is in correct form";
            }
        }

        public void HelperMethodUpcomingMatches()
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String query = "SELECT C.name AS HostClub, C2.name AS GuestClub, M.start_time AS start_time, M.end_time AS end_time FROM Match M INNER JOIN Club C ON M.host_cid = C.cid INNER JOIN Club C2 ON C2.cid = M.guest_cid WHERE M.start_time>CURRENT_TIMESTAMP";
            SqlDataAdapter sql = new SqlDataAdapter(query, conn);
            DataTable d1 = new DataTable();
            sql.Fill(d1);
            if (d1.Rows.Count == 0)
            {
                None.Text = "None";
                upcomingMatches.DataSource = "";
                upcomingMatches.DataBind();
            }
            else
            {   None.Text = "";
                upcomingMatches.DataSource = d1;
                upcomingMatches.DataBind();
            }
            conn.Close();
        }

        public void HelperMethodPlayedMatches()
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String query = "SELECT C.name AS HostClub, C2.name AS GuestClub, M.start_time AS start_time, M.end_time AS end_time FROM Match M INNER JOIN Club C ON M.host_cid = C.cid INNER JOIN Club C2 ON C2.cid = M.guest_cid WHERE M.end_time<CURRENT_TIMESTAMP";
            SqlDataAdapter sql = new SqlDataAdapter(query, conn);
            DataTable d1 = new DataTable();
            sql.Fill(d1);
            if (d1.Rows.Count == 0)
            {
                None2.Text = "None";
                alreadyPlayed.DataSource = "";
                alreadyPlayed.DataBind();
            }
            else
            {
                None2.Text = "";
                alreadyPlayed.DataSource = d1;
                alreadyPlayed.DataBind();
            }
            conn.Close();
        }
        public void HelperMethodNeverClubs()
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String query = "SELECT C.name AS Club1, C2.name AS Club2 FROM Club C, Club C2 WHERE C.cid>C2.cid AND NOT EXISTS( (SELECT * FROM Match M INNER JOIN Club C3 ON M.host_cid = C3.cid INNER JOIN Club C4 ON C4.cid = M.guest_cid WHERE C3.cid<>C4.cid AND C3.cid=C.cid and C4.cid=C2.cid AND M.start_time<CURRENT_TIMESTAMP) UNION (SELECT * FROM Match M INNER JOIN Club C3 ON M.Guest_cid = C3.cid INNER JOIN Club C4 ON C4.cid = M.host_cid WHERE C3.cid<>C4.cid AND C3.cid=C.cid and C4.cid=C2.cid AND M.start_time<CURRENT_TIMESTAMP)) ";
            SqlDataAdapter sql = new SqlDataAdapter(query, conn);
            DataTable d1 = new DataTable();
            sql.Fill(d1);
            if (d1.Rows.Count == 0)
            {
                neverClubs2.Text = "None";
                NeverClubs.DataSource = "";
                NeverClubs.DataBind();
            }
            else
            {
                neverClubs2.Text = "";
                NeverClubs.DataSource = d1;
                NeverClubs.DataBind();
            }
            conn.Close();
        }




    }
}