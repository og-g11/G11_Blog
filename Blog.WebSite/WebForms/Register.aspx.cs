using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blog.Service.Implementation;
using Blog.WebSite.App_Code;

namespace Blog.WebSite.WebForms
{
    public partial class Register : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            //Master.UserDataVisible = false;
            //Master.SearchVisible = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            using (var provider = new ServiceProvider())
            {   
                bool registered = provider.UserService.Find(x => x.FirstName == firstName && x.Email == email).Count() == 0;

                if (registered)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Write("alert('Failed to register!')");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}