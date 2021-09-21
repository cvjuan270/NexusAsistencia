namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfechaasistencia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asistencias", "Fecha", c => c.DateTime());
            AlterColumn("dbo.Asistencias", "HorEnt", c => c.Time(precision: 7));
            AlterColumn("dbo.Asistencias", "HorSal", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asistencias", "HorSal", c => c.DateTime());
            AlterColumn("dbo.Asistencias", "HorEnt", c => c.DateTime());
            DropColumn("dbo.Asistencias", "Fecha");
        }
    }
}
