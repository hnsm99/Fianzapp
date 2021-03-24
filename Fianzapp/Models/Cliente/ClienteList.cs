using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fianzapp.Models.Cliente
{
    public class ClienteList
    {
        public int id_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string nit_cliente { get; set; }
        public string telefono_cliente { get; set; }
        public string celular_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string correo_cliente { get; set; }
        public string usuario_cliente { get; set; }
        public string contrasena_cliente { get; set; }
        public int numero_fianza { get; set; }
        public int roles_id { get; set; }
        public string Rol { get; set; }
    }
}