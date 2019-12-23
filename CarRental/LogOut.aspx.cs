using System;
using System.Web;
using System.Web.UI;

namespace CarRental
{

    public partial class LogOut : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
         
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.AppendHeader("Refresh", "1;url=Default.aspx");

        }
    }
}
