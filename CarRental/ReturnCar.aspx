<%@ Page Language="C#"  MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" Inherits="CarRental.ReturnCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">

<div  style="padding:50px 0px;">       
<div class="row">
  <div class="col s12 l4 offset-l4">
    <div class="card grey lighten-3">
      <div class="card-content">
        <h4 class="card-title center-align">Return Vehicle</h4>
          <div class="row">
            <div class="input-field col s12">
              <asp:TextBox CssClass="validate" ID="referenceTxtBox" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidatorReference" runat="server" Style= "width: 128px; color:red;" ErrorMessage="RequiredFieldValidator"
                ControlToValidate="referenceTxtBox">* Fill in required Field </asp:RequiredFieldValidator>
              <label for="referenceTxtBox">Rental Reference</label>
            </div>
          </div>
          <div class="row center-align">
          <asp:Button ID="submit" CssClass="btn waves-effect waves-light"  runat="server" Text="Return" OnClick="return_Click"  />
          </div>

      </div>
    </div>
  </div>
</div>
</div>
</asp:Content>