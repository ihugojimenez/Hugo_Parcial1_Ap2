using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialWebApplication.Registros
{
    public partial class rSolicitudesWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Materiales m = new Materiales();
            DataTable dt = new DataTable();
            if(!IsPostBack)
            {
                MaterialDropDownList.DataSource = m.Listado("*", "1=1", "");
                MaterialDropDownList.DataTextField = "Descripcion";
                MaterialDropDownList.DataValueField = "IdMaterial";
                MaterialDropDownList.DataBind();

                dt.Columns.AddRange(new DataColumn[2] {new DataColumn("Material"), new DataColumn("Cantidad") });
            }

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

        }
    }
}