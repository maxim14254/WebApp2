using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SuccessDelete : System.Web.UI.Page
    {
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = Request.QueryString["email"];

            if (email != null)
            {
                DataBase db = new DataBase(email);
                Task t1 = Task.Run(() => db.DeleteUser());
            }
            else
            {
                Response.StatusCode = 404;
            }
        }
    }
}