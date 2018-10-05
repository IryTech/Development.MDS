namespace MDS.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatatype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaCover",
                c => new
                    {
                        AreaCoverId = c.Int(nullable: false, identity: true),
                        VendorCompanyId = c.Int(nullable: false),
                        AreaName = c.String(maxLength: 100, unicode: false),
                        PopularName = c.String(maxLength: 100, unicode: false),
                        Title = c.String(maxLength: 100, unicode: false),
                        YourUrl = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.AreaCoverId)
                .ForeignKey("dbo.VendorCompany", t => t.VendorCompanyId)
                .Index(t => t.VendorCompanyId);
            
            CreateTable(
                "dbo.VendorCompany",
                c => new
                    {
                        VendorCompanyId = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Mobile = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        State = c.String(maxLength: 50, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Street = c.String(maxLength: 50, unicode: false),
                        ZIPCode = c.Int(),
                        AddressLine1 = c.String(maxLength: 200, unicode: false),
                        AddressLine2 = c.String(maxLength: 200, unicode: false),
                        ShortDescription = c.String(maxLength: 500, unicode: false),
                        LongDescription = c.String(unicode: false),
                        Title = c.String(maxLength: 100, unicode: false),
                        YourUrl = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.VendorCompanyId)
                .ForeignKey("dbo.Vendor", t => t.VendorId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.BankDetails",
                c => new
                    {
                        BankDetailsId = c.Int(nullable: false, identity: true),
                        VendorCompanyId = c.Int(nullable: false),
                        AccountHolderName = c.String(maxLength: 30, unicode: false),
                        AccountNumber = c.String(maxLength: 20, unicode: false),
                        ConfirmAccountNumber = c.String(maxLength: 20, unicode: false),
                        IFSC = c.String(maxLength: 20, unicode: false),
                        BankName = c.String(maxLength: 30, unicode: false),
                        State = c.String(maxLength: 30, unicode: false),
                        City = c.String(maxLength: 30, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.BankDetailsId)
                .ForeignKey("dbo.VendorCompany", t => t.VendorCompanyId)
                .Index(t => t.VendorCompanyId);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20, unicode: false),
                        LastName = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Mobile = c.String(maxLength: 20, unicode: false),
                        Password = c.String(maxLength: 100, unicode: false),
                        ConfirmPassword = c.String(maxLength: 100, unicode: false),
                        Designation = c.String(maxLength: 100, unicode: false),
                        DateofBirth = c.String(maxLength: 30, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.VendorId);
            
            CreateTable(
                "dbo.SubscriptionType",
                c => new
                    {
                        SubscriptionTypeId = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        Title = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 50, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.SubscriptionTypeId)
                .ForeignKey("dbo.Vendor", t => t.VendorId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.VendorImage",
                c => new
                    {
                        VendorImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(unicode: false),
                        ImageLocation = c.String(unicode: false),
                        VendorCompanyId = c.Int(),
                        VendorCourseId = c.Int(),
                        VendorId = c.Int(),
                        CustomerId = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.VendorImageId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Vendor", t => t.VendorId)
                .ForeignKey("dbo.VendorCompany", t => t.VendorCompanyId)
                .ForeignKey("dbo.VendorCourse", t => t.VendorCourseId)
                .Index(t => t.VendorCompanyId)
                .Index(t => t.VendorCourseId)
                .Index(t => t.VendorId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20, unicode: false),
                        LastName = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Mobile = c.String(maxLength: 20, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        ConfirmPassword = c.String(maxLength: 50, unicode: false),
                        DOB = c.String(maxLength: 20, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        State = c.String(maxLength: 50, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Street = c.String(maxLength: 50, unicode: false),
                        ZIPCode = c.Int(),
                        AddressLine1 = c.String(maxLength: 200, unicode: false),
                        AddressLine2 = c.String(maxLength: 200, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.VendorCourse",
                c => new
                    {
                        VendorCourseId = c.Int(nullable: false, identity: true),
                        VendorCompanyId = c.Int(nullable: false),
                        CourseTitle = c.String(maxLength: 50, unicode: false),
                        ShortDescription = c.String(maxLength: 500, unicode: false),
                        LongDescription = c.String(unicode: false),
                        Duration = c.String(maxLength: 25, unicode: false),
                        VendorPrice = c.Decimal(precision: 12, scale: 2),
                        Title = c.String(maxLength: 100, unicode: false),
                        YourUrl = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.VendorCourseId)
                .ForeignKey("dbo.VendorCompany", t => t.VendorCompanyId)
                .Index(t => t.VendorCompanyId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VendorCourseId = c.Int(),
                        VehicleTypesId = c.Int(),
                        VehicleCompany = c.String(maxLength: 100, unicode: false),
                        VehicleModel = c.String(maxLength: 50, unicode: false),
                        VehicleTitle = c.String(maxLength: 100, unicode: false),
                        VehicleUrl = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.VendorCourse", t => t.VendorCourseId)
                .Index(t => t.VendorCourseId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypesId = c.Int(nullable: false, identity: true),
                        VendorCourseId = c.Int(nullable: false),
                        WhealsType = c.String(maxLength: 50, unicode: false),
                        VehicleTypeTitle = c.String(maxLength: 100, unicode: false),
                        VehicleTypeUrl = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.VehicleTypesId)
                .ForeignKey("dbo.VendorCourse", t => t.VendorCourseId)
                .Index(t => t.VendorCourseId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false),
                        CityName = c.String(maxLength: 40, unicode: false),
                        StateId = c.Int(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false),
                        StateName = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropForeignKey("dbo.VendorCourse", "VendorCompanyId", "dbo.VendorCompany");
            DropForeignKey("dbo.VendorImage", "VendorCourseId", "dbo.VendorCourse");
            DropForeignKey("dbo.VehicleTypes", "VendorCourseId", "dbo.VendorCourse");
            DropForeignKey("dbo.Vehicle", "VendorCourseId", "dbo.VendorCourse");
            DropForeignKey("dbo.VendorImage", "VendorCompanyId", "dbo.VendorCompany");
            DropForeignKey("dbo.VendorImage", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.VendorImage", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.VendorCompany", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.SubscriptionType", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.BankDetails", "VendorCompanyId", "dbo.VendorCompany");
            DropForeignKey("dbo.AreaCover", "VendorCompanyId", "dbo.VendorCompany");
            DropIndex("dbo.City", new[] { "StateId" });
            DropIndex("dbo.VehicleTypes", new[] { "VendorCourseId" });
            DropIndex("dbo.Vehicle", new[] { "VendorCourseId" });
            DropIndex("dbo.VendorCourse", new[] { "VendorCompanyId" });
            DropIndex("dbo.VendorImage", new[] { "CustomerId" });
            DropIndex("dbo.VendorImage", new[] { "VendorId" });
            DropIndex("dbo.VendorImage", new[] { "VendorCourseId" });
            DropIndex("dbo.VendorImage", new[] { "VendorCompanyId" });
            DropIndex("dbo.SubscriptionType", new[] { "VendorId" });
            DropIndex("dbo.BankDetails", new[] { "VendorCompanyId" });
            DropIndex("dbo.VendorCompany", new[] { "VendorId" });
            DropIndex("dbo.AreaCover", new[] { "VendorCompanyId" });
            DropTable("dbo.State");
            DropTable("dbo.City");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicle");
            DropTable("dbo.VendorCourse");
            DropTable("dbo.Customer");
            DropTable("dbo.VendorImage");
            DropTable("dbo.SubscriptionType");
            DropTable("dbo.Vendor");
            DropTable("dbo.BankDetails");
            DropTable("dbo.VendorCompany");
            DropTable("dbo.AreaCover");
        }
    }
}
