using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRental.Objects;
using Newtonsoft.Json;

namespace CarRental
{
    public partial class RentCar : System.Web.UI.Page
    {
        private AccessAPI api = new AccessAPI("https://carrentalgateway.azure-api.net/");
        protected override void OnLoad(EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            base.OnLoad(e);
            if (!Page.IsPostBack)
            {
              
                List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(api.getAvailableVehicles());
                for (int i = 0; i < vehicles.Count; i++)
                {
                    if (vehicles[i].isAvailable == true)
                    {
                        carsDropDown.Items.Add(new ListItem(vehicles[i].make + " " + vehicles[i].model, vehicles[i].vehicleId.ToString()));
                    }
                }

            }

            
        }

        protected void rent_Click(object sender, EventArgs e)
        {
            // Rental
            int refnum = GenerateRandomNo();
            Rental rental = new Rental();
            rental.customerId = (long)Session["id"];
            rental.rentalDate = System.DateTime.Now;
            rental.vehicleId = Convert.ToInt64(carsDropDown.SelectedItem.Value);
            rental.refNum = refnum.ToString();
            String request = api.addRental(rental);
            Rental rentalObj = JsonConvert.DeserializeObject<Rental>(request);


            Vehicle vehicle = getCarWithId(Convert.ToInt64(carsDropDown.SelectedItem.Value));
            vehicle.isAvailable = false;
            api.updateVehicle(vehicle);

            DisplayAlert("Here Is Your Reference Number, REMEMBER!" +rentalObj.refNum);

        }

        public Vehicle getCarWithId(long id) {

            List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(api.getAvailableVehicles());
            for (int i = 0; i < vehicles.Count; i++) {
                if (vehicles[i].vehicleId == id){
                    return vehicles[i];
                }

            }
            return null;
        }
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        protected void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
        }
    }
}
