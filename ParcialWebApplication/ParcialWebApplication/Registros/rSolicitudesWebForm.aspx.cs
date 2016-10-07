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
            dt.Rows.Add(MaterialDropDownList.SelectedValue/*m.Descripcion*/, CantTextBox.Text, m.Precio);
            ViewState["Detalle"] = dt;
            this.BindGrind();
            aux  += m.Precio * Convert.ToInt32(CantTextBox.Text);
            ViewState["Total"] = aux;
            TotalTextBox.Text = ViewState["Total"].ToString();
            CantTextBox.Text = "";
            
        }

        protected void LlenarClase(Solicitudes s)
        {
            
            //s.Fecha = DateTime.Now;
            s.Razon = RazonTextBox.Text;
            s.Total = Convert.ToSingle(ViewState["Total"]);

            foreach(GridViewRow gv in DataGridView.Rows)
            {
                s.AgregarMateriales(s.IdSolicitud, Convert.ToInt32(gv.Cells[0].Text), Convert.ToInt32(gv.Cells[1].Text));
            }

        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Solicitudes S = new Solicitudes();
            LlenarClase(S);
            S.Insertar();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Solicitudes so = new Solicitudes();
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);
            so.IdSolicitud = id;

            so.Eliminar();
        }

        protected void LlenarCampos(Solicitudes s)
        {
            Materiales m = new Materiales();//declare esta varaiable para que cada vez que entre al foreach, osea mninetras halla detalle(ver linea 101)..
            IdTextBox.Text = s.IdSolicitud.ToString();
            RazonTextBox.Text = s.Razon;
            TotalTextBox.Text = s.Total.ToString();
            DataTable det = new DataTable();

            foreach(var aux in s.Detalle)
            {
                DataTable dt = (DataTable)ViewState["Detalle"];
                m.Buscar(aux.idMaterial); //buscar por el idmaterial que tenga el aux, y darle una salida mas optima para el usuario, jeje, en el examen no hubiera tenido tiempo para eso >.<
                dt.Rows.Add(m.Descripcion, aux.Cantidad, m.Precio);
                ViewState["Detalle"] = dt;
                DataGridView.DataSource = dt; 
                this.BindGrind();
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Solicitudes so = new Solicitudes();

            so.Buscar(Convert.ToInt32(IdTextBox.Text));
            LlenarCampos(so);
        }
    }
}