<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/MainMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Blog.WebSite.WebForms.Register" %>
<%@ MasterType VirtualPath="~/Templates/MainMaster.Master" %>

<asp:Content ContentPlaceHolderID="contentMain" runat="server">

				<div class="login-group col-md-4 col-md-offset-4 col-4 col-offset-4">
					<div class="form-group">
					    <asp:Label for="lg_firstname" class="sr-only" runat="server">firstname</asp:Label>
                        <asp:TextBox ID="txtFirstName" type="text" class="form-control usernamelbl" name="lg_firstname" placeholder="firstname" runat="server" />
                    </div>
					<div class="form-group">
					    <asp:Label for="lg_lastname" class="sr-only" runat="server">lastname</asp:Label>
                        <asp:TextBox ID="txtLastName" type="text" class="form-control usernamelbl" name="lg_lastname" placeholder="lastname" runat="server" />
                    </div>
					<div class="form-group">
						<asp:label for="lg_password" class="sr-only" runat="server">Password</asp:label>
					    <asp:TextBox ID="txtPassword" TextMode="Password" type="password" class="form-control passwordlbl" name="lg_password" placeholder="password" runat="server" />
                    </div>
                    <div class="form-group">
						<asp:label for="lg_email" class="sr-only" runat="server">Password</asp:label>
					    <asp:TextBox ID="txtEmail" TextMode="Password" type="text" class="form-control passwordlbl" name="lg_email" placeholder="email" runat="server" />
                    </div>
                     <asp:Button ID="btnLogin" CssClass=" btn button loginbtn" Width="150" Text="Login" OnClick="btnLogin_Click" runat="server" />
    <asp:Button ID="btnRegister" CssClass="btn button registerbtn" Width="150" Text="Register" OnClick="btnRegister_Click" runat="server" />
				</div>
   

</asp:Content>