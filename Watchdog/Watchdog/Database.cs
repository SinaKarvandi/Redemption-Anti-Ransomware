
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Database : DbContext
    {
        // Your context has been configured to use a 'Database' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Anti_Ransomware.Database' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Database' 
        // connection string in the application configuration file.
        public Database()
            : base("name=Database")
        {
         //   System.Data.Entity.Database.SetInitializer<Database>(new MigrateDatabaseToLatestVersion<Database, Migrations.Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Extensions> Extension { get; set; }
        public virtual DbSet<Honeypot> Honeypots { get; set; }
        public virtual DbSet<AuditingZone> AuditingZones { get; set; }
        public virtual DbSet<Dump> Dumps { get; set; }
    }

    public class Extensions
    {
        [Key]
        public int ExtID { get; set; }
        public string Ext { get; set; }
    }
    public class Honeypot
    {
        [Key]
        public int HoneypotID { get; set; }
        public string HoneypotPath { get; set; }
    }
    public class AuditingZone
    {
        [Key]
        public int ZoneID { get; set; }
        public string ZonePath { get; set; }
    }
    public class Dump
    {
        [Key]
        public int DumpID { get; set; }
        public string DumpPath { get; set; }
    }
