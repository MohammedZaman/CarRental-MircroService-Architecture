using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using CarRental.Objects;
using Newtonsoft.Json;

namespace CarRental
{

    public partial class ReturnCar : System.Web.UI.Page
    {
        private AccessAPI api = new AccessAPI("https://carrentalgateway.azure-api.net/");

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Session["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        
        protected void return_Click(object sender, EventArgs e)
        {
            Rental rental = getRentalWithRef(referenceTxtBox.Text);
            if (rental != null)
            {
                rental.isReturned = true;
                api.updateRental(rental);

                Vehicle vehicle = getCarWithId(rental.vehicleId);
                vehicle.isAvailable = true;
                api.updateVehicle(vehicle);
                DisplayAlert("Vehicle Returned");
            }
            else {
                DisplayAlert("Reference Number Incorrect");
            }
        }

        public Vehicle getCarWithId(long id)
        {

            List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(api.getAvailableVehicles());
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].vehicleId == id)
                {
                    return vehicles[i];
                }

            }
            return null;
        }

        public Rental getRentalWithRef(String refNum)
        {
            List<Rental> rentals = JsonConvert.DeserializeObject<List<Rental>>(api.getRentals());
            for (int i = 0; i < rentals.Count; i++)
            {
                if (rentals[i].refNum == refNum)
                {
                    return rentals[i];
                }
                

            }
            return null;
        }

        protected void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
        }
    }
 }
    
