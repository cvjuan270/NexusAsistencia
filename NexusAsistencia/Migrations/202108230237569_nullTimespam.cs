namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullTimespam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "HorJor", c => c.Time(precision: 7));
            AlterColumn("dbo.AspNetUsers", "HorBre", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "HorBre", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.AspNetUsers", "HorJor", c => c.Time(nullable: false, precision: 7));
        }
    }
}
