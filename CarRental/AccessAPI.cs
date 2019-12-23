using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using CarRental.Objects;
using Newtonsoft.Json;

namespace CarRental
{
    public class AccessAPI
    {
        private String URL;
        public AccessAPI(String Url) {
            URL = Url;

        }


        public String logIn(string userName ,String password) {
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = cli.UploadString(URL+ "CustomerManagement/Authorisation", "{\"userName\":\""+userName+"\",\"password\":\""+password+"\"}");
            return response;
        }

        public String getAvailableVehicles()
        {
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = cli.DownloadString(URL+"VehicleManagement/Vehicle");
            return response;
        }

        public String addRental(Rental rental)
        {
            String uploadString  = Newtonsoft.Json.JsonConvert.SerializeObject(rental);
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = cli.UploadString(URL + "RentalManagement/Rental", uploadString);
            return response;
        }



        public String updateVehicle(Vehicle vehicle)
        {
            String uploadString = Newtonsoft.Json.JsonConvert.SerializeObject(vehicle);
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = cli.UploadString(URL + "VehicleManagement/Vehicle/"+vehicle.vehicleId,"PUT", uploadString);
            return response;
        }


        public String getRentals()
        {
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = cli.DownloadString(URL + "RentalManagement/Rental");
            return response;
        }

        public String updateRental(Rental rental)
        {
            String uploadString = Newtonsoft.Json.JsonConvert.SerializeObject(rental);
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = cli.UploadString(URL + "RentalManagement/Rental/" + rental.rentalId, "PUT", uploadString);
            return response;
        }

        public String addReview(Review review)
        {
            String uploadString = Newtonsoft.Json.JsonConvert.SerializeObject(review);
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = cli.UploadString(URL + "ReviewManagement/Review", uploadString);
            return response;
        }






    }
}
