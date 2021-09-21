namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabletimes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asistencias", "BreIni", c => c.DateTime());
            AlterColumn("dbo.Asistencias", "BreFin", c => c.DateTime());
            AlterColumn("dbo.Asistencias", "HorSal", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asistencias", "HorSal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Asistencias", "BreFin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Asistencias", "BreIni", c => c.DateTime(nullable: false));
        }
    }
}
