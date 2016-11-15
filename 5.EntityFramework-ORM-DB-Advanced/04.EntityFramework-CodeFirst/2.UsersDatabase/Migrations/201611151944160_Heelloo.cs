namespace _2.UsersDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Heelloo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "BornTown_Id", c => c.Int());
            AddColumn("dbo.Users", "CurrentlyLivingTown_Id", c => c.Int());
            CreateIndex("dbo.Users", "BornTown_Id");
            CreateIndex("dbo.Users", "CurrentlyLivingTown_Id");
            AddForeignKey("dbo.Users", "BornTown_Id", "dbo.Towns", "Id");
            AddForeignKey("dbo.Users", "CurrentlyLivingTown_Id", "dbo.Towns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CurrentlyLivingTown_Id", "dbo.Towns");
            DropForeignKey("dbo.Users", "BornTown_Id", "dbo.Towns");
            DropIndex("dbo.Users", new[] { "CurrentlyLivingTown_Id" });
            DropIndex("dbo.Users", new[] { "BornTown_Id" });
            DropColumn("dbo.Users", "CurrentlyLivingTown_Id");
            DropColumn("dbo.Users", "BornTown_Id");
            DropTable("dbo.Towns");
        }
    }
}
