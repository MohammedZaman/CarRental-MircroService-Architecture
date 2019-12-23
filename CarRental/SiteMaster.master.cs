using System;
using System.Web;
using System.Web.UI;
namespace CarRental
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
   
            base.OnLoad(e);
            if (Session["id"] != null)
            {
                signMenu.Style.Add("display", "none");
                logMenu.Style.Add("display", "block");
                rentalMenu.Style.Add("display", "block");
                returnMenu.Style.Add("display", "block");
                reviewMenu.Style.Add("display", "block");
            }
            else {
                signMenu.Style.Add("display", "block");
                logMenu.Style.Add("display", "none");
                rentalMenu.Style.Add("display", "none");
                returnMenu.Style.Add("display", "none");
                reviewMenu.Style.Add("display", "none");

            }
           

        }




        
    }
}
