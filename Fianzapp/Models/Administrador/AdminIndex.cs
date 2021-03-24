using Fianzapp.Models.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fianzapp.Models.Administrador
{
    public class AdminIndex
    {
        public int id_admin { get; set; }
        public string nombre_administrador { get; set; }
        public string documento_administrador { get; set; }
        public string correo_administrador { get; set; }
        public string usuario_administrador { get; set; }
        public string contrasena_administrador { get; set; }
        public int id_rol { get; set; }
        public List<RolGet> LstRol { get; set; }
    }
}