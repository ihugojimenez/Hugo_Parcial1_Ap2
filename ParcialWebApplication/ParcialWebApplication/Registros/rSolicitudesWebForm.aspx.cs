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

        ClaseAuxiliarClass1 ca = new ClaseAuxiliarClass1();
        float aux;
        protected void Page_Load(object sender, EventArgs e)
        {
            Materiales m = new Materiales();
            DataTable dt = new DataTable();
            ca.Total += ca.Total;
            if(!IsPostBack)
            {
                MaterialDropDownList.DataSource = m.Listado("*", "1=1", "");
                MaterialDropDownList.DataTextField = "Descripcion";
                MaterialDropDownList.DataValueField = "IdMaterial";
                MaterialDropDownList.DataBind();

                dt.Columns.AddRange(new DataColumn[3] {new DataColumn("Material"), new DataColumn("Cantidad"), new DataColumn("Precio") });
                ViewState["Detalle"] = dt;
                ViewState["Total"] = ca.Total;//Tal vez halla una mejor forma de hacerlo pero cree esta session o viewstate que es lo mismo, para poder ir guardando el total sin que me sufra ningun cambio cuando la pag haga load...
            }//habia borrado absolutamente como se hacia esto, mi confuncion fue mas al nunca haberlo intentado antes con textbox unicamente, siempre lo habia practicado con Dropdawnlist

        }

        protected void BindGrind()//necesito saber cual es la funcion exactamente de esto
        {
            DataGridView.DataSource = (DataTable)ViewState["Detalle"];
            DataGridView.DataBind();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Materiales m = new Materiales();
            m.Buscar(Convert.ToInt32(MaterialDropDownList.SelectedValue));
            DataTable dt = (DataTable)ViewState["Detalle"]; //lo que me cofundia es que pensaba que esto no era una sesion y practicamente es lo mismo
            aux = (float)ViewState["Total"];
            dt.Rows.Add(m.Descripcion, CantTextBox.Text, m.Precio);
            ViewState["Detalle"] = dt;
            this.BindGrind();
            aux  += m.Precio * Convert.ToInt32(CantTextBox.Text);
            ViewState["Total"] = aux;
            TotalTextBox.Text = ViewState["Total"].ToString();
            


        }
    }
}