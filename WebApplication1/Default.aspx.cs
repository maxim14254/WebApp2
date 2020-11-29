using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            data.Rows.Add(new TableRow());
            data.Rows[0].CssClass = "t2";
            
            data.Rows[0].Cells.Add(new TableCell());
            data.Rows[0].Cells[0].Text = "Id";
            
            data.Rows[0].Cells.Add(new TableCell());
            data.Rows[0].Cells[1].Text = "Имя";
            
            data.Rows[0].Cells.Add(new TableCell());
            data.Rows[0].Cells[2].Text = "Фамилия";
            
            data.Rows[0].Cells.Add(new TableCell());
            data.Rows[0].Cells[3].Text = "Email";
            
            data.Rows[0].Cells.Add(new TableCell());
            data.Rows[0].Cells[4].Text = "Телефон";
           
            data.Rows[0].Cells.Add(new TableCell());
            data.Rows[0].Cells[5].Style.Add(HtmlTextWriterStyle.BorderStyle, "none");

            data.Rows[0].Cells.Add(new TableCell());
            data.Rows[0].Cells[6].Style.Add(HtmlTextWriterStyle.BorderStyle, "none");

            ViewTable();
        }
        private void ViewTable()
        {
            DataBase db = new DataBase();
            List<ModelUser> users =db.GetUsers();
            for (int i = 0; i < users.Count; i++)
            {
                data.Rows.Add(new TableRow());
                data.Rows[i + 1].CssClass = "t3";

                data.Rows[i + 1].Cells.Add(new TableCell());
                data.Rows[i + 1].Cells[0].Text = (i+1).ToString();

                data.Rows[i + 1].Cells.Add(new TableCell());
                data.Rows[i + 1].Cells[1].Text = users[i].Name.ToString();

                data.Rows[i + 1].Cells.Add(new TableCell());
                data.Rows[i + 1].Cells[2].Text = users[i].Familia.ToString();

                data.Rows[i + 1].Cells.Add(new TableCell());
                data.Rows[i + 1].Cells[3].Text = users[i].Email.ToString();

                data.Rows[i + 1].Cells.Add(new TableCell());
                data.Rows[i + 1].Cells[4].Text = users[i].Telephone.ToString();

                data.Rows[i + 1].Cells.Add(new TableCell());
                data.Rows[i + 1].Cells[5].Style.Add(HtmlTextWriterStyle.BorderStyle, "none");
                data.Rows[i + 1].Cells[5].Text = $"<a href=\"/EditUser?email={users[i].Email.ToString()}&name={users[i].Name.ToString()}&familia={users[i].Familia.ToString()}&telephone={users[i].Telephone.ToString()}&id={users[i].Id.ToString()}\">Изменить</a>";

                data.Rows[i + 1].Cells.Add(new TableCell());
                data.Rows[i + 1].Cells[6].Style.Add(HtmlTextWriterStyle.BorderStyle, "none");
                data.Rows[i + 1].Cells[6].Text = $"<a href=\"/SuccessDelete?email={users[i].Email.ToString()}\">Удалить</a>";
            }
        }
    }
}