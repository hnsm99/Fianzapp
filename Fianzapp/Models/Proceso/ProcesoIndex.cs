using Fianzapp.Models.Administrador;
using Fianzapp.Models.Cliente;
using Fianzapp.Models.Demandado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fianzapp.Models.Proceso
{
    public class ProcesoIndex
    {
        public int id_proceso { get; set; }
        public int numero_proceso { get; set; }
        public int id_estado { get; set; }
        public int id_demandado { get; set; }
        public int id_cliente { get; set; }
        public string descripcion { get; set; }
        public string archivo_proceso { get; set; }
        public int id_administrador { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public List<Estado_Procesos> LstEstado_Proc { get; set; }
        public List<DemandadoIndex> LstDemandado { get; set; }
        public List<ClienteIndex> LstCliente { get; set; }
        public List<AdminIndex> LstAdmin { get; set; }
    }
}