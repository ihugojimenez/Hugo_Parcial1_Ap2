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
        public int Idsolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public string Razon { get; set; }
        public float Total { get; set; }
        public List<SolicitudesMateriales> Detalle { get; set; }

        public Solicitudes()
        {
            Idsolicitud = 0;
            Fecha = DateTime.Today;
            Razon = "";
            Total = 0.00f;
            Detalle = new List<SolicitudesMateriales>();
        }

        public override bool Insertar()
        {
            int retorno = 0;
            try
            {
                retorno = Convert.ToInt32(Conexion.ObtenerValor(string.Format("Insert into Solicitudes(Fecha, Razon, Total) values({0}, '{1}', {2})", this.Fecha, this.Razon, this.Total)));
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
            return retorno > 0;
        }

        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Buscar(int IdBuscado)
        {
            throw new NotImplementedException();
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }
    }
}
