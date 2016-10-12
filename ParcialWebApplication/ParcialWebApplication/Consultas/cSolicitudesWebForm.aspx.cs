using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialWebApplication.Consultas
{
    public partial class cSolicitudesWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Solicitudes s = new Solicitudes();

            SolicitudesGridView.DataSource = s.Listado("S.IdSolicitud as Id, S.Razon, S.Fecha, M.Descripcion, SD.Cantidad, M.Precio, S.Total ", "S.IdSolicitud = " + BuscarTextBox.Text, "");
            SolicitudesGridView.DataBind();

           
            
        }
    }
}