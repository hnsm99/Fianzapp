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
    
    public partial class Demandado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Demandado()
        {
            this.Proceso = new HashSet<Proceso>();
        }
    
        public int id_usuario_demandado { get; set; }
        public string nombre_usuario_demandado { get; set; }
        public string cedula_usuario_demandado { get; set; }
        public string telefono_usuario_demandado { get; set; }
        public string celular_usuario_demandado { get; set; }
        public string correo_usuario_demandado { get; set; }
        public string direccion_usuario_demandado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proceso> Proceso { get; set; }
    }
}
