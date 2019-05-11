using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Blog.Repository;

namespace Blog.WebSite
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var blogcon = new BlogDBContext();
            using (var unitOfWork = new UnitOfWork(new BlogDBContext()))
            {
                var content = unitOfWork.Contents.GetLastContents(5);
                GridView1.DataSource = content.ToList();
                GridView1.DataBind();
            }
        }
    }
}