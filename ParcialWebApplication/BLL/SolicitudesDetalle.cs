using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SolicitudesDetalle
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public int idMaterial { get; set; }
        public int Cantidad { get; set; }

        public SolicitudesDetalle(int Idsolicitud, int IdMaterial, int Cantidad)
        {
            this.IdSolicitud = Idsolicitud;
            this.idMaterial = IdMaterial;
            this.Cantidad = Cantidad;
        }
    }
}
