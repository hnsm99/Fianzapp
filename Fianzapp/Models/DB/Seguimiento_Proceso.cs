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
    
    public partial class Seguimiento_Proceso
    {
        public int id_seg_proceso { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_modificado { get; set; }
        public string observaciones { get; set; }
        public string archivo_seg_proceso { get; set; }
        public int id_estado { get; set; }
        public int id_proceso { get; set; }
    
        public virtual Estado_Seguimiento Estado_Seguimiento { get; set; }
        public virtual Proceso Proceso { get; set; }
    }
}
