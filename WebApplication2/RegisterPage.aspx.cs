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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterSAM(object sender, EventArgs e)
        {
            Response.Redirect("SAMRegisterPage.aspx");
            
        }

    
        protected void ClubRep(object sender, EventArgs e)
        {
            Response.Redirect("ClubRepRegPage.aspx");
        }
        protected void StadiumManagerReg(object sender, EventArgs e)
        {
            Response.Redirect("StadiumManagerRegPage.aspx");
        }
        protected void RegFan(object sender, EventArgs e)
        {
            Response.Redirect("FanRegPage.aspx");
        }







    }
}