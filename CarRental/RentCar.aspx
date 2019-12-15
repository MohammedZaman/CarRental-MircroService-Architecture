<%@ Page Language="C#" Inherits="CarRental.RentCar" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">

<div  style="padding:50px 0px;">       
<div class="row">
  <div class="col s12 l4 offset-l4">
    <div class="card grey lighten-3">
      <div class="card-content">
        <h4 class="card-title center-align">Select Vehicle to Rent</h4>
        
          <div class="row">
            <div class="input-field col s12"> 
                    
             <asp:DropDownList CssClass="dropdown-trigger btn"  ID="carsDropDown" runat="server">
             <asp:ListItem Text="Select Vehicle" Value="-1" />
             </asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidatorCars" runat="server" Style= "width: 128px; color:red;" ErrorMessage="RequiredFieldValidator"
                ControlToValidate="carsDropDown">* Fill in required Field </asp:RequiredFieldValidator>
               
            </div>
          </div>
       
          <div class="row center-align">
          <asp:Button ID="submit" CssClass="btn waves-effect waves-light"  runat="server" Text="Rent" OnClick="rent_Click"  />
          </div>

      </div>
    </div>
  </div>
</div>
</div>
</asp:Content>