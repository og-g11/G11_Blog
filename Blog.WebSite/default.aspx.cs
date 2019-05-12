using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blog.Repository;
using Blog.Service;

namespace Blog.WebSite
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            //AddCategory category = new AddCategory(1, "SciFi", "bla bla bla", false);
            AddCategory read = new AddCategory();
            read.ReadCategory();
        }
    }
}