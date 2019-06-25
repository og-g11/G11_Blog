using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.WebSite.App_Code {
	public class BasePage : System.Web.UI.Page {
		public bool IsLogged => User.Identity?.Name != null; //?

		protected virtual void Page_Load(object sender, EventArgs e) {
			
		}
	}
}