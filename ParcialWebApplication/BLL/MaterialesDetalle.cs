using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MaterialesDetalle
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public MaterialesDetalle()
        {
            Id = 0;
            Descripcion = "";
        }
      
    }
}
