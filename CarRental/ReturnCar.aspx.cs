using System;
using System.Web;
using System.Web.UI;

namespace CarRental
{

    public partial class ReturnCar : System.Web.UI.Page
    {
        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Review.aspx");
        }

    }
}
