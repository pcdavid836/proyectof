using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectof2
{
    class Venderte
    {
        private int idv;
        private string nombrev;
        private int codigoBarrav;
        private double preciocv;
        private double preciovv;
        private int cantidadv;
        public Venderte()
        {

        }

        public Venderte(int idv, string nombrev, int codigoBarrav,double preciocv, double preciovv, int cantidadv )
        {
            this.idv = idv;
            this.nombrev = nombrev;
            this.cantidadv = cantidadv;
            this.preciovv = preciovv;
            this.codigoBarrav = codigoBarrav;
            this.preciocv = preciocv;
        }

        public int Id
        {
            get { return idv; }
            set { idv = value; }
        }
        public string Nombre
        {
            get { return nombrev; }
            set { nombrev = value; }
        }
        public int CodigoProducto
        {
            get { return codigoBarrav; }
            set { codigoBarrav = value; }
        }

        public double PrecioC
        {
            get { return preciocv; }
            set { preciocv = value; }
        }
        public double PrecioV
        {
            get { return preciovv; }
            set { preciovv = value; }
        }

        public int Cantidad
        {
            get { return cantidadv; }
            set { cantidadv = value; }
        }

        
    }
}
