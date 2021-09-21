namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FecNac", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "FecNac", c => c.DateTime(nullable: false));
        }
    }
}
