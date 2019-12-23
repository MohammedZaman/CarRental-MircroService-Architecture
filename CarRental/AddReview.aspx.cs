using System;
using System.Web;
using System.Web.UI;
using CarRental.Objects;

namespace CarRental
{

    public partial class AddReview : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Session["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }
        private AccessAPI api = new AccessAPI("https://carrentalgateway.azure-api.net/");
        protected void rate_Click(object sender, EventArgs e)
        {
            Review review = new Review();
            review.customerId = (long)Session["id"];
            review.reviewText = reviewTxtBox.Text;
            review.rating = Convert.ToInt64(rateDropDown.SelectedItem.Value);
            api.addReview(review);
            DisplayAlert("Review Added");
           
        }

        protected void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
        }

    }
}
