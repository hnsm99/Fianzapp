using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fianzapp.Models.Demandado
{
    public class DemandadoIndex
    {
        public int id_usuario_demandado { get; set; }
        public string nombre_usuario_demandado { get; set; }
        public string cedula_usuario_demandado { get; set; }
        public string telefono_usuario_demandado { get; set; }
        public string celular_usuario_demandado { get; set; }
        public string correo_usuario_demandado { get; set; }
        public string direccion_usuario_demandado { get; set; }
    }
}