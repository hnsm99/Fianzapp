//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fianzapp.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Proceso = new HashSet<Proceso>();
        }
    
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
    
        public virtual Rol Rol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proceso> Proceso { get; set; }
    }
}
