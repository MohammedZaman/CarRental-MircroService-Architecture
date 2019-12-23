<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" Inherits="CarRental.AddReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">

<div  style="padding:50px 0px;">       
<div class="row">
  <div class="col s12 l4 offset-l4">
    <div class="card grey lighten-3">
      <div class="card-content">
        <h4 class="card-title center-align">Login</h4>
        
          <div class="row">
            <div class="input-field col s12"> 
                    
             <asp:DropDownList CssClass="dropdown-trigger btn"  ID="rateDropDown" runat="server">
             <asp:ListItem Text="Rate" Value="-1" />
             <asp:ListItem Text="1(Very Bad)" Value="1" />
             <asp:ListItem Text="2(Bad)" Value="2" />
             <asp:ListItem Text="3(Okay)" Value="3" />
             <asp:ListItem Text="4(Good)" Value="4" />
             <asp:ListItem Text="5(Very Good)" Value="5" />
             </asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidatoRate" runat="server" Style= "width: 128px; color:red;" ErrorMessage="RequiredFieldValidator"
                ControlToValidate="rateDropDown">* Fill in required Field </asp:RequiredFieldValidator>
               
            </div>
          </div>
          
          <div class="row">
           <label class="col s12">Comments</label>
            <div class="input-field col s12">
              <asp:TextBox TextMode="multiline" CssClass="validate" ID="reviewTxtBox" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidatorReview" runat="server" Style= "width: 128px; color:red;" ErrorMessage="RequiredFieldValidator"
                ControlToValidate="reviewTxtBox">* Fill in required Field </asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row center-align">
          <asp:Button ID="submit" CssClass="btn waves-effect waves-light"  runat="server" Text="Submit" OnClick="rate_Click"  />
          </div>

      </div>
    </div>
  </div>
</div>
</div>
</asp:Content>