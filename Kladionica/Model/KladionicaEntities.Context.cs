﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kladionica.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class KladionicaEntities : DbContext
    {
        public KladionicaEntities()
            : base("name=KladionicaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Listic> Listics { get; set; }
        public virtual DbSet<Oklada> Okladas { get; set; }
        public virtual DbSet<Ponuda> Ponudas { get; set; }
        public virtual DbSet<Susret> Susrets { get; set; }
    
        public virtual ObjectResult<GetOkladas_Result> GetOkladas(Nullable<long> listicId)
        {
            var listicIdParameter = listicId.HasValue ?
                new ObjectParameter("ListicId", listicId) :
                new ObjectParameter("ListicId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOkladas_Result>("GetOkladas", listicIdParameter);
        }
    }
}
