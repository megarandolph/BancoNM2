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

    public partial class DebitoCA
    {
        [DisplayName("Número de Transacción")]
        public int numTrans { get; set; }
        [DisplayName("Número de Cuenta")]
        public Nullable<int> numCuenta { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [DisplayName("Fecha")]
        public Nullable<System.DateTime> fecha { get; set; }
        [DisplayName("Monto")]
        public Nullable<decimal> monto { get; set; }
    
        public virtual CuentaA CuentaA { get; set; }
    }
}
