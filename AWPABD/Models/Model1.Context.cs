//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AWPABD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AWPABDEntities : DbContext
    {
        public AWPABDEntities()
            : base("name=AWPABDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BlokadyHistory> BlokadyHistory { get; set; }
        public virtual DbSet<DatabaseGroup> DatabaseGroup { get; set; }
        public virtual DbSet<Databases> Databases { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<HostHistory> HostHistory { get; set; }
        public virtual DbSet<Latency> Latency { get; set; }
        public virtual DbSet<LatencyHistory> LatencyHistory { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<LoginServers> LoginServers { get; set; }
        public virtual DbSet<Procedury> Procedury { get; set; }
        public virtual DbSet<ProceduryHistory> ProceduryHistory { get; set; }
        public virtual DbSet<ProcesyHistory> ProcesyHistory { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Servers> Servers { get; set; }
        public virtual DbSet<ServersGroup> ServersGroup { get; set; }
    }
}
