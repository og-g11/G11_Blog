using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blog.Service;

namespace Blog.WebSite.Templates {
	public partial class MainMaster : MasterPage {
		public bool ShowFilter {
			set { secFilter.Visible = value; }
		}


																			 //public bool UserDataVisible { set { pnlUser.Visible = value; } }
																			 //public bool SearchVisible { set { pnlSearch.Visible = value; } }

		//public bool IsUserLogged => Session["User"] != null;
		//public int LoggedUserID => IsUserLogged ? (int)Session["User"] : 0;

		//protected void Page_Load(object sender, EventArgs e)
		//{
		//    if (IsPostBack)
		//        return;

		//    using (var provider = new ServiceProvider())
		//    {
		//        var categories = provider.CategotyService.GetAll().Select(c => c.Name).ToArray();
		//        drpCategory.DataSource = categories;
		//        drpCategory.DataBind();
		//    }

		//    lnkLogin.Visible = !(pnlUserData.Visible = IsUserLogged);

		//    if (IsUserLogged)
		//    {
		//        int id = LoggedUserID;

		//        using (var provider = new ServiceProvider())
		//        {
		//            var user = provider.UserService.Get(id);
		//            lblUserID.Text = id.ToString();
		//            lblFirstName.Text = user.FirstName;
		//            lblLastName.Text = user.LastName;
		//        }
		//    }
		//}
	}
}