<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/MainMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Blog.WebSite.WebForms.Login" %>
<%@ MasterType VirtualPath="~/Templates/MainMaster.Master" %>

<asp:Content ContentPlaceHolderID="contentMain" runat="server">
    <%--<h3>Email <asp:TextBox ID="txtEmail" runat="server" /></h3>
    <h3>Password <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" /></h3>
    <h3>Remember Password <asp:CheckBox ID="chckRememberPassword" runat="server" /></h3>
    <asp:Panel Width="300" Height="30" runat="server">
        
    </asp:Panel>--%>


   
			<div class="login-form-main-message"></div>
			<div class="main-login-form col-md-4 col-lg-offset-4 text-center">
				<div class="login-group">
					<div class="form-group">
					    <asp:Label for="lg_username" class="sr-only" runat="server">Username</asp:Label>
                        <asp:TextBox ID="txtEmail" type="text" class="form-control usernamelbl" name="lg_username" placeholder="Username" runat="server" />
                    </div>
					<div class="form-group">
						<asp:label for="lg_password" class="sr-only" runat="server">Password</asp:label>
					    <asp:TextBox ID="txtPassword" TextMode="Password" type="password" class="form-control passwordlbl" name="lg_password" placeholder="password" runat="server" />
                    </div>
					<div class="form-group login-group-checkbox">
                        <asp:CheckBox ID="chckRememberPassword" type="checkbox"  name="lg_remember" runat="server" />
						<asp:label for="lg_remember" runat="server">remember</asp:label>
					</div>
				</div>
                <asp:Button ID="btnLogin" CssClass=" btn button loginbtn" Width="150" Text="Login" OnClick="btnLogin_Click" runat="server" />
                <asp:Button ID="btnRegister" CssClass="btn button registerbtn" Width="150" Text="Register" OnClick="btnRegister_Click" runat="server" />
				
             <div class="etc-login-form">
				<p>forgot your password? <a href="#">click here</a></p>
				<p>new user? <a href="#">create new account</a></p>
			</div>
			</div>



	<asp:Label runat="server" ID="lblError"></asp:Label>

</asp:Content>
