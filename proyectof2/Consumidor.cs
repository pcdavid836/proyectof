using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectof2
{
    class Consumidor
    {
        private int idf;
        private int nit;
        private string nombreOR;
        private string fechas;
        private double total;

        string pathName2 = @"d:\registroVentas.txt";
        public Consumidor()
    {

    }


        public Consumidor(int idf, int nit,string nombreOR, string fechas,double total)
    {
        this.idf = idf;
        this.nit = nit;
        this.nombreOR = nombreOR;
        this.fechas = fechas;
        this.total = total;
    }

    public int Id
    {
        get { return idf; }
        set { idf = value; }
    }

        public int Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        public string Nombre
        {
            get { return nombreOR; }
            set { nombreOR = value; }
        }

        public string Fecha
        {
            get { return fechas; }
            set { fechas = value; }
        }

        public double TotalBs
        {
            get { return total; }
            set { total = value; }
        }

        internal void EscribirArchivoB3(string mensaje2)
        {
            StreamWriter tuberiaEscritura2 = File.AppendText(pathName2);
            tuberiaEscritura2.WriteLine(mensaje2);
            tuberiaEscritura2.Close();
        }
    }
}
