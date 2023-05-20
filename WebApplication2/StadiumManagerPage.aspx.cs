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
using System.Web.DynamicData;
using System.ComponentModel.Design.Serialization;

namespace WebApplication2
{
    public partial class StadiumManagerPage : System.Web.UI.Page
    {

        protected void BackTologin(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", "2;URL=Login.aspx");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String username2 = (String)Session["username"];
            Labelxxx.Text = "WELCOME " + username2 + " :)";
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String query = "SELECT S.id, S.name, S.location,S.capacity FROM Stadium S INNER JOIN StadiumManager M ON M.sid=S.id WHERE M.username='" + username2 + "'";
            SqlDataAdapter sql = new SqlDataAdapter(query, conn);
            DataTable d1 = new DataTable();
            sql.Fill(d1);
            if (!(d1.Rows.Count == 0))
            {
                StadiumManaged.DataSource = d1;
                StadiumManaged.DataBind();
            }
            else
            {
                StadiumManaged.DataSource = "";
                StadiumManaged.DataBind();

            }
            helperMethod2();
            conn.Close();
        }

        public void helperMethod2()
        {


            String username2 = (String)Session["username"];
            Labelxxx.Text = "WELCOME " + username2 + " :)";
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String query2 = "SELECT R.name AS clubRep,C.name AS host_club,C2.name AS guest_club, M.start_time, M.end_time, H.status FROM Host_request H INNER JOIN StadiumManager SM ON SM.id=H.manager_id INNER JOIN Match M ON M.mid=H.mid INNER JOIN Representative R ON R.id=H.rid INNER JOIN Club C ON C.cid=R.cid INNER JOIN Club C2 ON C2.cid=M.guest_cid WHERE C.cid=M.host_cid AND SM.username='" + username2 + "'";
            SqlDataAdapter sql2 = new SqlDataAdapter(query2, conn);
            DataTable d2 = new DataTable();
            sql2.Fill(d2);
            if (d2.Rows.Count == 0)
            {
                noRequests.Text = "None";
                RequestTable.DataSource = "";
                RequestTable.DataBind();
            }
            else
            {
                RequestTable.DataSource = d2;
                RequestTable.DataBind();

            }
            conn.Close();
        }

        protected void AcceptRequest2(object sender, EventArgs e) {
            String username2 = (String)Session["username"];
            String host = hostcName.Text;
            String guest = guestcName.Text;
            String time = matchTime.Text;
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            DateTime out2;
            if (host.Length == 0 || guest.Length == 0 || time.Length == 0)
                ErrorMsgDisplay2.Text = "Please make sure you have entered all fields";
           else if (DateTime.TryParse(time, out out2)) {
                String query = "SELECT * FROM Host_request H INNER JOIN StadiumManager SM ON SM.id=H.manager_id INNER JOIN Match M ON M.mid=H.mid INNER JOIN Representative R ON R.id=H.rid INNER JOIN Club C ON C.cid=R.cid INNER JOIN Club C2 ON C2.cid=M.guest_cid WHERE C.cid=M.host_cid  AND H.status='unhandled' AND SM.username='" + username2 + "'AND C.name='" + host + "'AND C2.name='" + guest + "'AND M.start_time='" + time + "'";
                SqlDataAdapter sql = new SqlDataAdapter(query, conn);
                DataTable d1 = new DataTable();
                sql.Fill(d1);
               
               if (d1.Rows.Count == 0)
                {
                    ErrorMsgDisplay2.Text = "Cannot accept request because it's already handled or doesn't exist";
                }
                else
                {

                    SqlCommand acceptReq = new SqlCommand("acceptRequest", conn);
                    acceptReq.CommandType = CommandType.StoredProcedure;
                    acceptReq.Parameters.Add(new SqlParameter("@username", username2));
                    acceptReq.Parameters.Add(new SqlParameter("@hostname", host));
                    acceptReq.Parameters.Add(new SqlParameter("@guestname", guest));
                    acceptReq.Parameters.Add(new SqlParameter("@start_time", time));
                    acceptReq.ExecuteNonQuery();
                    helperMethod2();
                    ErrorMsgDisplay2.Text = "Request accepted successfully";
                    conn.Close();
                } }
            else
                ErrorMsgDisplay2.Text = "Make sure time is in correct format";

        }

        protected void RejectRequest2(object sender, EventArgs e)
        {
            String username2 = (String)Session["username"];
            String host = hostcName.Text;
            String guest = guestcName.Text;
            String time = matchTime.Text;
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            DateTime out2;
            if (host.Length == 0 || guest.Length == 0 || time.Length == 0)
                ErrorMsgDisplay2.Text = "Please make sure you have entered all fields";
            else if (DateTime.TryParse(time, out out2))
            {
                String query = "SELECT * FROM Host_request H INNER JOIN StadiumManager SM ON SM.id=H.manager_id INNER JOIN Match M ON M.mid=H.mid INNER JOIN Representative R ON R.id=H.rid INNER JOIN Club C ON C.cid=R.cid INNER JOIN Club C2 ON C2.cid=M.guest_cid WHERE C.cid=M.host_cid  AND H.status='unhandled' AND SM.username='" + username2 + "'AND C.name='" + host + "'AND C2.name='" + guest + "'AND M.start_time='" + time + "'";
                SqlDataAdapter sql = new SqlDataAdapter(query, conn);
                DataTable d1 = new DataTable();
                sql.Fill(d1);

                if (d1.Rows.Count == 0)
                {
                    ErrorMsgDisplay2.Text = "Cannot reject request because it's already handled or doesn't exist";
                }
                else
                {

                    SqlCommand rejReq = new SqlCommand("rejectRequest", conn);
                    rejReq.CommandType = CommandType.StoredProcedure;
                    rejReq.Parameters.Add(new SqlParameter("@username", username2));
                    rejReq.Parameters.Add(new SqlParameter("@host_name", host));
                    rejReq.Parameters.Add(new SqlParameter("@guest_name", guest));
                    rejReq.Parameters.Add(new SqlParameter("@start_time", time));
                    rejReq.ExecuteNonQuery();
                    helperMethod2();
                    ErrorMsgDisplay2.Text = "Request rejected successfully";
                    conn.Close();
                }
            }
            else
                ErrorMsgDisplay2.Text = "Make sure time is in correct format";
        }


        }
    } 