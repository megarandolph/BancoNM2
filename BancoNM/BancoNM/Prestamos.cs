//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BancoNM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prestamos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prestamos()
        {
            this.PagoPrestamos = new HashSet<PagoPrestamos>();
        }
    
        public int idPrestamo { get; set; }
        public Nullable<int> idCliente { get; set; }
        public Nullable<decimal> monto { get; set; }
        public Nullable<int> plazo { get; set; }
        public Nullable<decimal> tazaPorcAnual { get; set; }
        public Nullable<decimal> cuotasM { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PagoPrestamos> PagoPrestamos { get; set; }
    }
}
