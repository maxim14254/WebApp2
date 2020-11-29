using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SuccessEdit : System.Web.UI.Page
    {
        string email;
        string name;
        string familia;
        string telephone;
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["name"];
            email = Request.QueryString["email"];
            familia = Request.QueryString["familia"];
            telephone = Request.QueryString["telephone"];
            id = Request.QueryString["id"];

            if (email != null && name != null && familia != null && telephone != null && id != null) 
            {
                DataBase db = new DataBase(email, name, familia, telephone, id);
                Task t1 = Task.Run(() => db.EditUser());
            }
            else
            {
                Response.StatusCode = 404;
            }
        }
    }
}