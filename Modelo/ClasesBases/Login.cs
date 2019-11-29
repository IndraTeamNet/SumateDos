using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ClasesBases
{
    class Login
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public Login()
        {
            Usuario = string.Empty;
            Contrasena = string.Empty;
        }

        public Login(string Usuario, string Contrasena)
        {
            this.Usuario = Usuario;
            this.Contrasena = Contrasena;
        }


    }
}
