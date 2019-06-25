using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blog.Service;

namespace Blog.WebSite.WebForms {
	public partial class Login : Page {
		protected void Page_Load(object sender, EventArgs e) {
			Master.ShowFilter = false;
		}
		
		protected void btnLogin_Click(object sender, EventArgs e) {
			string email = txtEmail.Text;
			string password = txtPassword.Text;

			if(email == "admin" && password == "admin") {
				FormsAuthentication.RedirectFromLoginPage(email, chckRememberPassword.Checked);
			} else {
				lblError.Text = "Login Failed!";
			}
		}

		protected void btnRegister_Click(object sender, EventArgs e) {
			Response.Redirect("Register.aspx");
		}
	}
}