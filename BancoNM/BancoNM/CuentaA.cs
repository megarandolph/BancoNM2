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
    using System.ComponentModel;

    public partial class CuentaA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuentaA()
        {
            this.CreditoCA = new HashSet<CreditoCA>();
            this.DebitoCA = new HashSet<DebitoCA>();
        }
        [DisplayName("Número de Cuenta")]
        public int numCuenta { get; set; }
        [DisplayName("Cliente")]
        public Nullable<int> idCliente { get; set; }
        [DisplayName("Moneda")]
        public Nullable<int> idMoneda { get; set; }
        [DisplayName("Estado")]
        public Nullable<bool> estado { get; set; }
        [DisplayName("Balance Disponible")]
        public Nullable<decimal> balanceDisp { get; set; }
        [DisplayName("Balance Totals")]
        public Nullable<decimal> balanceTotal { get; set; }
        [DisplayName("Último Corte")]
        public Nullable<System.DateTime> ultimoCorte { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditoCA> CreditoCA { get; set; }
        public virtual Monedas Monedas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DebitoCA> DebitoCA { get; set; }
    }
}
