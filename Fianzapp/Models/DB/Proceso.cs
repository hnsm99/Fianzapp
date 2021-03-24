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
    
    public partial class Proceso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proceso()
        {
            this.Seguimiento_Proceso = new HashSet<Seguimiento_Proceso>();
        }
    
        public int id_proceso { get; set; }
        public int numero_proceso { get; set; }
        public int id_estado { get; set; }
        public int id_demandado { get; set; }
        public int id_cliente { get; set; }
        public string descripcion { get; set; }
        public string archivo_proceso { get; set; }
        public int id_administrador { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
    
        public virtual Administrador Administrador { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Demandado Demandado { get; set; }
        public virtual Estado_Proceso Estado_Proceso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seguimiento_Proceso> Seguimiento_Proceso { get; set; }
    }
}
