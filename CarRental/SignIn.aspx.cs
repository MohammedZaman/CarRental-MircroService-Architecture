using System;
using System.Web;
using System.Web.UI;
namespace CarRental
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
        }

        protected void submit_Click(object sender, EventArgs e)
        {
           Response.Redirect("RentCar.aspx");
        }
        
        protected void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
        }
    }
}
