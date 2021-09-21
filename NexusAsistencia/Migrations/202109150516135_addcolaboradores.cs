namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolaboradores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colaboradors",
                c => new
                    {
                        Dni = c.String(nullable: false, maxLength: 8),
                        Pasword = c.String(),
                        NomApe = c.String(maxLength: 50),
                        NumCel = c.String(maxLength: 9),
                        FecNac = c.DateTime(),
                        HorJor = c.Time(precision: 7),
                        Breake = c.Boolean(nullable: false),
                        HorBre = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.Dni);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Colaboradors");
        }
    }
}
