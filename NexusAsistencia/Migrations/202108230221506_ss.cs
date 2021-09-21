namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Dni", c => c.String(maxLength: 8));
            AlterColumn("dbo.AspNetUsers", "NomApe", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "NomApe", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "Dni", c => c.String(nullable: false, maxLength: 8));
        }
    }
}
