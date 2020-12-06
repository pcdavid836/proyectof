using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectof2
{
    class User
    {
        private string nombreP;
        private string clase;
        private string nombreUsuario;
        private string password;
        private string id;

        public User()
        {

        }

  

        public User(string id, string nombreP,string clase,string nombreUsuario, string password)
        {
            this.id = id;
            this.nombreP = nombreP;
            this.clase = clase;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Username
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Personaje
        {
            get { return nombreP; }
            set { nombreP = value; }
        }
    
        public string Clase
        {
            get { return clase; }
            set { clase = value; }
        }


    }
}
