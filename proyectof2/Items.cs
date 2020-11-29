using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectof2
{
    class Items
    {
        private int id;
        private string nombreProducto;
        private int codigoBarra;
        private double precioC;
        private double precioV;
        private int cantidad;


        public Items()
        {

        }

        public Items(int id,string nombreProducto,int codigoBarra, double precioC, double precioV,  int cantidad)
        {
            this.id = id;
            this.nombreProducto = nombreProducto;
            this.codigoBarra = codigoBarra;
            this.precioC = precioC;
            this.precioV = precioV;
            this.cantidad = cantidad;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }

        public int CodigoBarra
        {
            get { return codigoBarra; }
            set { codigoBarra = value; }
        }

        public double PrecioC
        {
            get { return precioC; }
            set { precioC = value; }
        }

        public double PrecioV
        {
            get { return precioV; }
            set { precioV = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

    }

}
