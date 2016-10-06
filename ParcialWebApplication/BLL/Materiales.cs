using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Materiales : ClaseMaestra
    {
        ConexionDb Conexion = new ConexionDb();
        public int IdMaterial { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }

        public Materiales()
        {
            IdMaterial = 0;
            Descripcion = "";
            Precio = 0.00f;
        }

        public Materiales(int IdMaterial, string Descripcion, float Precio)
        {
            this.IdMaterial = IdMaterial;
            this.Descripcion = Descripcion;
            this.Precio = Precio;

        }

        public override bool Insertar()
        {
            bool retorno = false;

            try
            {
                retorno = Conexion.Ejecutar(string.Format("Insert into Materiales(Descripcion, Precio) values('{0}', {1})", this.Descripcion, this.Precio));
            }
            catch
            {
                retorno = false;
            }
            return retorno;

        }

        public override bool Editar()
        {
            bool retorno = false;

            try
            {
                retorno = Conexion.Ejecutar(string.Format("Update Materiales set Descripcion = '{0}', Precio = {1})", this.Descripcion, this.Precio));
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
                retorno = Conexion.Ejecutar(string.Format("Detele Materiales where IdMaterial = {0}", this.IdMaterial));
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();

            dt = Conexion.ObtenerDatos(string.Format("Select * from Materiales where IdMaterial = " + IdBuscado));
            if(dt.Rows.Count >0)
            {
                this.IdMaterial = IdBuscado;
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.Precio = float.Parse(dt.Rows[0]["Precio"].ToString());
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Orden by  " + Orden;

            return Conexion.ObtenerDatos("Select " + Campos + " From Personas Where " + Condicion + Orden);
        }
    }
}
