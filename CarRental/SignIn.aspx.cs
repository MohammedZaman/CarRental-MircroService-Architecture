using System;
using System.Web;
using CarRental.Objects;
using Newtonsoft.Json;

namespace CarRental
{
    public partial class SignIn : System.Web.UI.Page
    {
        private AccessAPI api = new AccessAPI("https://carrentalgateway.azure-api.net/");
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Session["id"] != null) {
                Response.Redirect("Default.aspx");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
           Authorisation auth = JsonConvert.DeserializeObject<Authorisation>(api.logIn(uTxtBox.Text, passwordTxtBox.Text));
            if (auth.isAuthorized == true)
            {
                Session["id"] = auth.customerId ;
                DisplayAlert("Success");
                Response.Redirect("Default.aspx");

            }
            else {
                DisplayAlert("incorrect username and password");
            }
        }
        
        protected void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
        }
    }
}
