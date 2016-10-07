using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Solicitudes : ClaseMaestra
    {
        ConexionDb Conexion = new ConexionDb();
        public int IdSolicitud { get; set; }
       // public DateTime Fecha { get; set; }
        public string Razon { get; set; }
        public float Total { get; set; }
        public List<SolicitudesDetalle> Detalle { get; set; }

        public Solicitudes()
        {
            IdSolicitud = 0;
            //Fecha = DateTime.Today;
            Razon = "";
            Total = 0.00f;
            Detalle = new List<SolicitudesDetalle>();
        }

        public override bool Insertar()
        {

            int retorno = 0;
            object identity;
            try
            {
                //obtengo el identity insertado en la tabla personas
                identity = Conexion.ObtenerValor(
                    string.Format("Insert into Solicitudes(Razon, Total) values('{0}', {1}); select @@Identity"
                    , this.Razon, this.Total));

                //intento convertirlo a entero
                int.TryParse(identity.ToString(), out retorno);

                this.IdSolicitud = retorno;
                foreach (SolicitudesDetalle item in this.Detalle)
                {
                    Conexion.Ejecutar(string.Format("Insert into SolicitudesDetalle(IdSolicitud, IdMaterial, Cantidad) values({0}, {1}, {2})",
                        retorno, item.idMaterial, item.Cantidad));
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno > 0;

            /*int retorno = 0;
            try
            {
                retorno = Convert.ToInt32(Conexion.ObtenerValor(string.Format("Insert into Solicitudes(Fecha, Razon, Total) values({0}, '{1}', {2}); SELECT SCOPE_IDENTITY(); --", this.Fecha, this.Razon, this.Total)));
                if(retorno > 0)
                {
                    foreach(SolicitudesMateriales sm in Detalle)
                    {
                        Conexion.Ejecutar(string.Format("Insert into SolicitudesMateriales(IdSolicitud, IdMaterial, Cantidad) values({0}, {1}, {2})", retorno, sm.idMaterial, sm.Cantidad));
                    }
                }
            }
            catch
            {
                retorno = 0;
            }
            return retorno > 0;*/
        }

        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            bool retorno = false;

            try
            {
                retorno = Conexion.Ejecutar(string.Format("Delete from Solicitudes Where IdSolicitud = {0}", this.IdSolicitud));
                if (retorno)
                    Conexion.Ejecutar(string.Format("Delete from SolicitudesDetalle Where IdSolicitud = {0}", this.IdSolicitud));

            }catch
            {
                retorno = false;
            }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable det = new DataTable();

            try
            {
                dt = Conexion.ObtenerDatos(string.Format("Select * from Solicitudes where IdSolicitud = {0}", IdBuscado));
                if(dt.Rows.Count >0)
                {
                    this.IdSolicitud = IdBuscado;
                    this.Razon = dt.Rows[0]["Razon"].ToString();
                    this.Total = Convert.ToSingle(dt.Rows[0]["Total"]);

                }
                det = Conexion.ObtenerDatos(string.Format("Select * from SolicitudesDetalle where IdSolicitud ={0}", this.IdSolicitud));
                if(det.Rows.Count>0)
                {
                    foreach(DataRow dr in det.Rows)
                    {
                        this.AgregarMateriales(IdBuscado, (int)dr["IdMaterial"], (int)dr["Cantidad"]);
                    }
                }
            }
            catch
            {
                return false;
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }

        public void AgregarMateriales(int IdSolicitud,int IdMaterial, int cant) // A este metodo se referia cuando dijo que se podia agregar desde la misma clase...
        {
            this.Detalle.Add(new SolicitudesDetalle(IdSolicitud, IdMaterial, cant));
        }
    }
}
