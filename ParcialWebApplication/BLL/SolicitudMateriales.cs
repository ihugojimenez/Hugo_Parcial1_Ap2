using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SolicitudMateriales : ClaseMaestra
    {
        ConexionDb con = new ConexionDb();
        public int Id { get; set; }
        public string Razon { get; set; }
        public List<MaterialesDetalle> Detalle { get; set; }

        public override bool Buscar(int IdBuscado)
        {
            int encontro = 0;

            try
            {
                encontro = Convert.ToInt32(con.ObtenerDatos(string.Format("select * from SolicitudMateriales where Id = " + IdBuscado)));
                if(encontro > 0)
                {
                    this.Id = IdBuscado;
                    this.Razon = Razon;
                }
            }catch
            {
                encontro = 0;
            }
            return encontro > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;

            try
            {
                retorno = con.Ejecutar(string.Format("Update SolicitudMateriales set Razon = '{0}'", this.Razon));
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;

            try
            {
                retorno = con.Ejecutar(string.Format("Delete from SolicitudMateriales where Id = {0}", this.Id));
            }catch
            {
                retorno = false;
            }
            return retorno;

        }

        public override bool Insertar()
        {
            int retorno = 0;

            try
            {
                retorno = Convert.ToInt32(con.Ejecutar(string.Format("Insert into SolicitudMateriales(Razon) values('{0}')", this.Razon)));
                if(retorno >0)
                {
                    foreach(MaterialesDetalle d in Detalle)
                    {
                        con.Ejecutar(string.Format("insert into MaterialesDetalle(Id,SolicitudId, Descripcion) values({0}, '{1}', {2})", d.Id,this.Id, d.Descripcion));
                    }
                }
            }
            catch
            {
                retorno = 0;
            }

            return retorno >0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }
    }
}
