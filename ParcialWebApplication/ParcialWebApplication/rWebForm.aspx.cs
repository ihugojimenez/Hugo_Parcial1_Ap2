using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialWebApplication
{
    public partial class rWebForm : System.Web.UI.Page
    {
        SolicitudMateriales SM = new SolicitudMateriales();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LlenarClase(SolicitudMateriales sm)
        {
            sm.Razon = RazonTextBox.Text;
            
        }

        protected void VacearClase(SolicitudMateriales sm)
        {
            RazonTextBox.Text = sm.Razon;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            SolicitudMateriales sm = new SolicitudMateriales();

            
            LlenarClase(sm);
            /*if(sm.Insertar())
            {
                foreach(MaterialesDetalle d in sm.Detalle)
                {
                    sm.Detalle.Add(d.Descripcion)
                }
            }*/

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {

            int id = 0;
            int.TryParse(IdTextBox.Text, out id);
            SM.Id = id;

            SM.Buscar(SM.Id);
            VacearClase(SM);
             
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);
            SM.Id = id;
            SM.Eliminar();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            MaterialesDetalle md = new MaterialesDetalle();
            md.Descripcion = MaterialTextBox.Text;
            md.Id = 0;
            DataTable dt = new DataTable();//(DataTable)ViewState["Descripcion"];
            dt.Rows.Add(MaterialTextBox.Text);
            ViewState["Descripcion"] = dt;
            DataGridView.DataSource = dt.Container;
            DataBind();
            
        }
    }
}