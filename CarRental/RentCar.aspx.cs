using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarRental
{
    public partial class RentCar : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!Page.IsPostBack)
            {
                String[] cars = { "BMW", "Mercedes", "Golf" };

                for (int i = 0; i < cars.Length; i++)
                {
                    carsDropDown.Items.Add(new ListItem(cars[i], i.ToString()));
                }
            }

            
        }

        protected void rent_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReturnCar.aspx");
        }
    }
}
