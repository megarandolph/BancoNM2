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

    public partial class Usuarios
    {
        [DisplayName("ID Usuario")]
        public int idUsuario { get; set; }
        [DisplayName("Usuario")]
        public string usuario { get; set; }
        [DisplayName("Contraseña")]
        public string pass { get; set; }
        [DisplayName("Acceso")]
        public Nullable<int> acceso { get; set; }
    }
}
