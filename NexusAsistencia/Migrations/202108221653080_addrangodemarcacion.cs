namespace NexusAsistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrangodemarcacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anexoes", "RanMet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anexoes", "RanMet");
        }
    }
}
