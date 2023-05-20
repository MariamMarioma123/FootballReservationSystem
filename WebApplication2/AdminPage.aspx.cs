using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication2
{
    public partial class SystemAdminPage : System.Web.UI.Page
    {    protected void BackToLog(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", "2;URL=Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddClub(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String club_name = Name.Text;
            String club_location = Location.Text;
            String ClubExists = "SELECT * FROM Club WHERE name='" + club_name + "'AND location='" + club_location + "'";
            SqlDataAdapter sqlData = new SqlDataAdapter(ClubExists, conn);
            DataTable data = new DataTable();
            sqlData.Fill(data);
            if (club_name.Length == 0 || club_location.Length == 0)
            {
                alreadyExists.Text = "Please make sure you have entered all fields";
            }
            else if (data.Rows.Count > 0)
            {
                alreadyExists.Text = "This club already exists";
            }
            else
            {
                SqlCommand addClubProc = new SqlCommand("addClub", conn);
                addClubProc.CommandType = CommandType.StoredProcedure;
                addClubProc.Parameters.Add(new SqlParameter("@club_name", club_name));
                addClubProc.Parameters.Add(new SqlParameter("@club_location", club_location));
                addClubProc.ExecuteNonQuery();
                alreadyExists.Text = "Club added successfully";
                conn.Close();
            }
        }


        protected void RemoveClub(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            String club_name = DeleteName.Text;
            String ClubExists = "SELECT * FROM Club WHERE name='" + club_name + "'";
            SqlDataAdapter sqlData = new SqlDataAdapter(ClubExists, conn);
            DataTable data = new DataTable();
            sqlData.Fill(data);
            if (club_name.Length == 0)
            {
                ClubNotExist.Text = "Please make sure you have entered all fields";
            }
            else if (data.Rows.Count == 0)
            {
                ClubNotExist.Text = "This club already doesn't exist";
            }
            else
            {
                SqlCommand deleteClubProc = new SqlCommand("deleteClub", conn);
                deleteClubProc.CommandType = CommandType.StoredProcedure;
                deleteClubProc.Parameters.Add(new SqlParameter("@club_name", club_name));
                conn.Open();
                deleteClubProc.ExecuteNonQuery();
                ClubNotExist.Text = "Club deleted succesfully";
                conn.Close();
            }
        }

        protected void AddNewStadium(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            String stad_name = StadiumName.Text;
            String stad_location = StadiumLocation.Text;
            String stad_capacity = StadiumCapacity.Text;
            if (stad_name.Length == 0 || stad_location.Length == 0 || stad_capacity.Length == 0)
            {
                DisplayErrorStad.Text = "Please make sure you have entered all fields";
            }
            else
            {
                int realStadCap = Int16.Parse(StadiumCapacity.Text);
                String StadExists = "SELECT * FROM Stadium WHERE name='" + stad_name + "'AND location='" + stad_location + "'";
                SqlDataAdapter sqlData = new SqlDataAdapter(StadExists, conn);
                DataTable data = new DataTable();
                sqlData.Fill(data);
                if (data.Rows.Count > 0)
                {
                    DisplayErrorStad.Text = "This stadium already exists";
                }
                else
                {
                    SqlCommand addStadProc = new SqlCommand("addStadium", conn);
                    addStadProc.CommandType = CommandType.StoredProcedure;
                    addStadProc.Parameters.Add(new SqlParameter("@stadium_name", stad_name));
                    addStadProc.Parameters.Add(new SqlParameter("@stadium_location", stad_location));
                    addStadProc.Parameters.Add(new SqlParameter("@capacity", realStadCap));
                    addStadProc.ExecuteNonQuery();
                    DisplayErrorStad.Text = "Stadium added successfully";
                    conn.Close();
                }
            }
        }

        protected void BlockFan(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            String national_number_string = nID.Text;
            if (national_number_string.Length == 0)
            {
                BlockFanDisplay.Text = "Please make sure you have entered all fields";
            }

            else
            {
                String FanExists = "SELECT * FROM Fans WHERE nID='" + national_number_string + "'";
                SqlDataAdapter sqlData = new SqlDataAdapter(FanExists, conn);
                DataTable data = new DataTable();
                sqlData.Fill(data);
                if (data.Rows.Count == 0)
                {
                    BlockFanDisplay.Text = "This national id doesn't exist";
                }
                else
                {
                    SqlCommand blockTheFan = new SqlCommand("blockFan", conn);
                    blockTheFan.CommandType = CommandType.StoredProcedure;
                    blockTheFan.Parameters.Add(new SqlParameter("@nid", national_number_string));
                    conn.Open();
                    blockTheFan.ExecuteNonQuery();
                    BlockFanDisplay.Text = "Fan blocked succesfully";
                    conn.Close();
                }
            }
        }
    
        protected void DeleteStadium(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["SportsFinalSubmission"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            String Stadium_name = DeleteStadiumName.Text;
            String StadiumExists = "SELECT * FROM Stadium WHERE name='" + Stadium_name + "'";
            SqlDataAdapter sqlData = new SqlDataAdapter(StadiumExists, conn);
            DataTable data = new DataTable();
            sqlData.Fill(data);
            if (Stadium_name.Length == 0)
            {
                StadiumErrorMsg.Text = "Please make sure you have entered all fields";
            }
            else if (data.Rows.Count == 0)
            {
                StadiumErrorMsg.Text = "This stadium already doesn't exist";
            }
            else
            {
                SqlCommand deleteStadProc = new SqlCommand("deleteStadium", conn);
                deleteStadProc.CommandType = CommandType.StoredProcedure;
                deleteStadProc.Parameters.Add(new SqlParameter("@stadium_name", Stadium_name));
                conn.Open();
                deleteStadProc.ExecuteNonQuery();
                StadiumErrorMsg.Text = "Stadium deleted succesfully";
                conn.Close();
            }
        }
    }
}