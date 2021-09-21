namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAsistencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistencias",
                c => new
                    {
                        IdAsistencia = c.Int(nullable: false, identity: true),
                        Ruc = c.String(maxLength: 11),
                        IdAnexo = c.Int(nullable: false),
                        UserName = c.String(),
                        HorEnt = c.DateTime(),
                        Breake = c.Boolean(nullable: false),
                        BreTie = c.Time(precision: 7),
                        BreIni = c.DateTime(nullable: false),
                        BreFin = c.DateTime(nullable: false),
                        HorSal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdAsistencia)
                .ForeignKey("dbo.Anexoes", t => t.IdAnexo, cascadeDelete: true)
                .ForeignKey("dbo.Empresas", t => t.Ruc)
                .Index(t => t.Ruc)
                .Index(t => t.IdAnexo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asistencias", "Ruc", "dbo.Empresas");
            DropForeignKey("dbo.Asistencias", "IdAnexo", "dbo.Anexoes");
            DropIndex("dbo.Asistencias", new[] { "IdAnexo" });
            DropIndex("dbo.Asistencias", new[] { "Ruc" });
            DropTable("dbo.Asistencias");
        }
    }
}
