namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asistencias", "BreIni", c => c.Time(precision: 7));
            AlterColumn("dbo.Asistencias", "BreFin", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asistencias", "BreFin", c => c.DateTime());
            AlterColumn("dbo.Asistencias", "BreIni", c => c.DateTime());
        }
    }
}
