﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BancoNMEntities : DbContext
    {
        public BancoNMEntities()
            : base("name=BancoNMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<CreditoCA> CreditoCA { get; set; }
        public virtual DbSet<CuentaA> CuentaA { get; set; }
        public virtual DbSet<DebitoCA> DebitoCA { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Monedas> Monedas { get; set; }
        public virtual DbSet<Nacionalidad> Nacionalidad { get; set; }
        public virtual DbSet<PagoPrestamos> PagoPrestamos { get; set; }
        public virtual DbSet<SolicitudCA> SolicitudCA { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Prestamos> Prestamos { get; set; }
    }
}
