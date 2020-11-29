using System;
using System.Threading.Tasks;


namespace WebApplication1
{
    public partial class Success : System.Web.UI.Page
    {
        string email;
        string name;
        string familia;
        string telephone;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["name"];
            email = Request.QueryString["email"];
            familia = Request.QueryString["familia"];
            telephone = Request.QueryString["telephone"];

            if (email != null && name != null && familia != null && telephone != null)
            {
                DataBase db = new DataBase(email, name, familia, telephone);
                Task<string> t1 = Task.Run(() => db.CreateBase());
                Label1.Text=t1.Result;
            }
            else
            {
                Response.StatusCode = 404;
            }
        }
        
    }
}