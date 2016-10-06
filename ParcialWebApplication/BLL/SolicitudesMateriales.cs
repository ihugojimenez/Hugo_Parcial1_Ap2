using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SolicitudesMateriales
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public int idMaterial { get; set; }
        public int Cantidad { get; set; }

        public SolicitudesMateriales(int Idsolicitud, int IdMaterial, int Cantidad)
        {
            this.IdSolicitud = Idsolicitud;
            this.idMaterial = IdMaterial;
            this.Cantidad = Cantidad;
        }
    }
}
