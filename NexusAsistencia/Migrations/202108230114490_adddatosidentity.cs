namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatosidentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Dni", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.AspNetUsers", "NomApe", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "NumCel", c => c.String(maxLength: 9));
            AddColumn("dbo.AspNetUsers", "FecNac", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "HorJor", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.AspNetUsers", "Breake", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "HorBre", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HorBre");
            DropColumn("dbo.AspNetUsers", "Breake");
            DropColumn("dbo.AspNetUsers", "HorJor");
            DropColumn("dbo.AspNetUsers", "FecNac");
            DropColumn("dbo.AspNetUsers", "NumCel");
            DropColumn("dbo.AspNetUsers", "NomApe");
            DropColumn("dbo.AspNetUsers", "Dni");
        }
    }
}
