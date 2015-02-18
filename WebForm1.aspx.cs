using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        PService PS = new PService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGRid();
            }
        }

        private void FillGRid()
        {
            GridView1.DataSource = PS.GetALlUSer();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {

                PS.FirstName = ((TextBox)GridView1.HeaderRow.FindControl("TextBox2")).Text;
                PS.LastName = ((TextBox)GridView1.HeaderRow.FindControl("TextBox4")).Text;
                PS.InsertNewUser(PS);
                FillGRid();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PS.UserID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            PS.DeleteUser(PS.UserID);
            FillGRid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            PS.FirstName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            PS.LastName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            PS.UserID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            PS.UpdateUser(PS);
            GridView1.EditIndex = -1;
            FillGRid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillGRid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillGRid();
        }
    }
}