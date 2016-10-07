using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialWebApplication.Registros
{
    public partial class rMaterialesWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LlenarClase(Materiales m)
        {
            
            m.Descripcion = DescTextBox.Text;
            m.Precio = Convert.ToSingle(PrcTextBox.Text);
        }

        protected void LlenarCampos(Materiales m)
        {
            IdTextBox.Text = m.IdMaterial.ToString();
            DescTextBox.Text = m.Descripcion;
            PrcTextBox.Text = m.Precio.ToString();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Materiales m = new Materiales();

            LlenarClase(m);

           if( m.Insertar())
            {
                Limpiar();
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Materiales M = new Materiales();
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);
                M.IdMaterial = id;
            M.Buscar(M.IdMaterial);
            LlenarCampos(M);

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Materiales ma = new Materiales();
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);
            ma.IdMaterial = id;

            ma.Buscar(ma.IdMaterial);

            if(ma.Eliminar())
            {
                Limpiar();
            }
        }

        protected void Limpiar()
        {
            IdTextBox.Text = "";
            DescTextBox.Text = "";
            PrcTextBox.Text = "";
        }

        protected void NewButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}