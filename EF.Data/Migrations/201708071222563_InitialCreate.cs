namespace EF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ZQ.DEMAND",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        DName = c.String(nullable: false, maxLength: 25, unicode: false),
                        Description = c.String(nullable: false, maxLength: 25, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IP = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "ZQ.MODULES",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ProjectID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IP = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("ZQ.PROJECT", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "ZQ.PROJECT",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PName = c.String(nullable: false, maxLength: 100, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IP = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "ZQ.MYUSER",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserName = c.String(nullable: false, maxLength: 25, unicode: false),
                        Email = c.String(nullable: false, maxLength: 25, unicode: false),
                        Password = c.String(nullable: false, maxLength: 25, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IP = c.String(maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "ZQ.USERPROFILE",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FirstName = c.String(nullable: false, maxLength: 20, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 20, unicode: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(maxLength: 20, unicode: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IP = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("ZQ.MYUSER", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "ZQ.ModuleDemands",
                c => new
                    {
                        Module_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Demand_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Module_ID, t.Demand_ID })
                .ForeignKey("ZQ.MODULES", t => t.Module_ID, cascadeDelete: true)
                .ForeignKey("ZQ.DEMAND", t => t.Demand_ID, cascadeDelete: true)
                .Index(t => t.Module_ID)
                .Index(t => t.Demand_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ZQ.USERPROFILE", "ID", "ZQ.MYUSER");
            DropForeignKey("ZQ.MODULES", "ProjectID", "ZQ.PROJECT");
            DropForeignKey("ZQ.ModuleDemands", "Demand_ID", "ZQ.DEMAND");
            DropForeignKey("ZQ.ModuleDemands", "Module_ID", "ZQ.MODULES");
            DropIndex("ZQ.USERPROFILE", new[] { "ID" });
            DropIndex("ZQ.MODULES", new[] { "ProjectID" });
            DropIndex("ZQ.ModuleDemands", new[] { "Demand_ID" });
            DropIndex("ZQ.ModuleDemands", new[] { "Module_ID" });
            DropTable("ZQ.ModuleDemands");
            DropTable("ZQ.USERPROFILE");
            DropTable("ZQ.MYUSER");
            DropTable("ZQ.PROJECT");
            DropTable("ZQ.MODULES");
            DropTable("ZQ.DEMAND");
        }
    }
}
