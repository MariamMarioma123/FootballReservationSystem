using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;

namespace WebApplication2
{
    public partial class ClubRepresentativePage : System.Web.UI.Page
    {   protected void BackToLo(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", "2;URL=Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            String username2 = (String)Session["username"];
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String query = "SELECT C.cid AS cID, C.name AS name, C.location AS location FROM Club C INNER JOIN Representative R ON R.cid= C.cid WHERE R.username='" + username2 + "'";
            SqlDataAdapter sql = new SqlDataAdapter(query, conn);
            DataTable d1 = new DataTable();
            sql.Fill(d1);
            if (d1.Rows.Count == 0)
            {
                NoClub.Text = "None";
                ClubRepresentedGrid.DataSource = "";
                ClubRepresentedGrid.DataBind();
            }
            else
            {
                NoClub.Text = "";
                ClubRepresentedGrid.DataSource = d1;
                ClubRepresentedGrid.DataBind();
            }
            String query2 = "SELECT C.name AS host_club, C2.name AS guest_club, M.start_time AS start_time, M.end_time AS end_time, S.name AS stadium_name FROM Representative R, Club C,Club C2,Stadium S,Match M WHERE (R.cid=C.cid OR R.cid=C2.cid) AND C.cid=M.host_cid AND C2.cid=M.guest_cid AND M.sid=S.id AND M.start_time>CURRENT_TIMESTAMP AND R.username='" + username2 + "'";
            SqlDataAdapter sql2 = new SqlDataAdapter(query2, conn);
            DataTable d2 = new DataTable();
            sql2.Fill(d2);
            if (d2.Rows.Count == 0)
            {
                noMatchesClub.Text = "None";
                upComingClubMatches.DataSource = "";
                upComingClubMatches.DataBind();
            }
            else
            {
                noMatchesClub.Text = "";
                upComingClubMatches.DataSource = d2;
                upComingClubMatches.DataBind();
            }

            conn.Close();



        }

        protected void TimeStad(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            String time2 = Request.Form["time"];
            if (time2.Length == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Alert", "alert('Please choose a VALID date');", true);
                return;
            }
            DateTime time = DateTime.Parse(time2);
            String sqlQuery = "SELECT DISTINCT S.name AS stadium_name, S.location AS location, S.capacity AS capacity FROM Stadium S LEFT OUTER JOIN Match M ON S.id=M.sid WHERE S.status='1' AND NOT EXISTS(SELECT * FROM Match M2 WHERE (M2.start_time<='" + time + "'AND M2.end_time>='" + time + "')AND M2.sid=S.id)";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(sqlCommand);
            DataTable d2 = new DataTable();
            adap.Fill(d2);
            if (d2.Rows.Count == 0)
            {
                noStad.Text = "No available stadiums for that date";
                AllAvailableFinds.DataSource = "";
                AllAvailableFinds.DataBind();
            }
            else
            {
                noStad.Text = "";
                AllAvailableFinds.DataSource = d2;
                AllAvailableFinds.DataBind();
            }


        }
        protected void RequestSM(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String time = timeBox.Text;
            String stad_name = stadiumName.Text;

            if (stad_name.Length == 0 || time.Length == 0)
            {
                ErrorMsgDisplay.Text = "Make sure you have entered all fields";

            }
            else
            {
                String username2 = (String)Session["username"];
                String club_exists = "SELECT C.name FROM CLUB C INNER JOIN Representative R ON R.cid=C.cid WHERE R.username='" + username2 + "'";
                SqlDataAdapter sqlData = new SqlDataAdapter(club_exists, conn);
                DataTable data2 = new DataTable();
                sqlData.Fill(data2);
                if (data2.Rows.Count != 1)
                    ErrorMsgDisplay.Text = "A problem occurred. Please make sure your club is still registered.";
                else
                {
                    String stad_check = "SELECT * FROM Stadium WHERE name='" + stad_name + "'";
                    SqlDataAdapter sqlData2 = new SqlDataAdapter(stad_check, conn);
                    DataTable data3 = new DataTable();
                    sqlData2.Fill(data3);
                    if (data3.Rows.Count == 0)
                        ErrorMsgDisplay.Text = "Stadium doesn't exist. Please make sure you enter the name of an existing stadium.";

                    else
                    {

                        String hasMan = "SELECT * FROM Stadium S INNER JOIN StadiumManager M ON S.id=M.sid WHERE S.name='" + stad_name + "'";
                        SqlDataAdapter sql3 = new SqlDataAdapter(hasMan, conn);
                        DataTable d9 = new DataTable();
                        sql3.Fill(d9);
                        if (d9.Rows.Count == 0)
                            ErrorMsgDisplay.Text = "Request cannot be made since stadium hasn't been assigned a manager yet";
                        else
                        {
                            SqlCommand sql2 = new SqlCommand(club_exists, conn);
                            String club_name = (String)sql2.ExecuteScalar();
                            String match_check = "SELECT * FROM Match M INNER JOIN Club C ON C.cid=M.host_cid WHERE M.start_time='" + time + "'AND C.name='" + club_name + "'";
                            SqlDataAdapter sqlData3 = new SqlDataAdapter(match_check, conn);
                            DataTable data4 = new DataTable();
                            sqlData3.Fill(data4);
                            if (data4.Rows.Count == 0)
                                ErrorMsgDisplay.Text = "Match doesn't exist. Please make sure your match is already scheduled before requesting stadium.";

                            else
                            {
                                SqlCommand addHostRequest2 = new SqlCommand("addHostRequest", conn);
                                addHostRequest2.CommandType = CommandType.StoredProcedure;
                                addHostRequest2.Parameters.Add(new SqlParameter("@clubName", club_name));
                                addHostRequest2.Parameters.Add(new SqlParameter("@stadiumName", stad_name));
                                addHostRequest2.Parameters.Add(new SqlParameter("@start_time", time));
                                addHostRequest2.ExecuteNonQuery();
                                ErrorMsgDisplay.Text = "Request sent successfully";
                            }

                        }
                    }
                }
            }
                conn.Close();
            }

        }
    
}



      
