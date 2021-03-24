using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fianzapp.Models.Proceso
{
    public class ProcesoList
    {
        public int id_proceso { get; set; }
        public int numero_proceso { get; set; }
        public int id_estado { get; set; }
        public string estado { get; set; }
        public int id_demandado { get; set; }
        public string demandado { get; set; }
        public int id_cliente { get; set; }
        public string cliente { get; set; }
        public string descripcion { get; set; }
        public string archivo_proceso { get; set; }
        public int id_administrador { get; set; }
        public string administrador { get; set; }
        public DateTime? Fecha_creacion { get; set; }
    }
}