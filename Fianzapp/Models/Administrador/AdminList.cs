using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fianzapp.Models.Administrador
{
    public class AdminList
    {
        public int id_admin { get; set; }
        public string nombre_administrador { get; set; }
        public string documento_administrador { get; set; }
        public string correo_administrador { get; set; }
        public string usuario_administrador { get; set; }
        public int id_rol { get; set; }
        public string rol { get; set; }
    }
}