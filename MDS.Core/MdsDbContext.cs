namespace MDS.Core
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MdsDbContext : DbContext
    {
        public MdsDbContext()
            : base("name=MdsDbContext")
        {
        }

        public virtual DbSet<AreaCover> AreaCovers { get; set; }
        public virtual DbSet<BankDetail> BankDetails { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorCompany> VendorCompanies { get; set; }
        public virtual DbSet<VendorCourse> VendorCourses { get; set; }
        public virtual DbSet<VendorImage> VendorImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaCover>()
                .Property(e => e.AreaName)
                .IsUnicode(false);

            modelBuilder.Entity<AreaCover>()
                .Property(e => e.PopularName)
                .IsUnicode(false);

            modelBuilder.Entity<AreaCover>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<AreaCover>()
                .Property(e => e.YourUrl)
                .IsUnicode(false);

            modelBuilder.Entity<BankDetail>()
                .Property(e => e.AccountHolderName)
                .IsUnicode(false);

            modelBuilder.Entity<BankDetail>()
                .Property(e => e.AccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<BankDetail>()
                .Property(e => e.ConfirmAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<BankDetail>()
                .Property(e => e.IFSC)
                .IsUnicode(false);

            modelBuilder.Entity<BankDetail>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<BankDetail>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<BankDetail>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ConfirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.DOB)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.AddressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.AddressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<SubscriptionType>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<SubscriptionType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.VehicleCompany)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.VehicleModel)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.VehicleTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.VehicleUrl)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .Property(e => e.WhealsType)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .Property(e => e.VehicleTypeTitle)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .Property(e => e.VehicleTypeUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.ConfirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Designation)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.DateofBirth)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.SubscriptionTypes)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.VendorCompanies)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.AddressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.AddressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.ShortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.LongDescription)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .Property(e => e.YourUrl)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCompany>()
                .HasMany(e => e.AreaCovers)
                .WithRequired(e => e.VendorCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorCompany>()
                .HasMany(e => e.BankDetails)
                .WithRequired(e => e.VendorCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorCompany>()
                .HasMany(e => e.VendorCourses)
                .WithRequired(e => e.VendorCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorCourse>()
                .Property(e => e.CourseTitle)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCourse>()
                .Property(e => e.ShortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCourse>()
                .Property(e => e.LongDescription)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCourse>()
                .Property(e => e.Duration)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCourse>()
                .Property(e => e.VendorPrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<VendorCourse>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCourse>()
                .Property(e => e.YourUrl)
                .IsUnicode(false);

            modelBuilder.Entity<VendorCourse>()
                .HasMany(e => e.VehicleTypes)
                .WithRequired(e => e.VendorCourse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorImage>()
                .Property(e => e.ImageName)
                .IsUnicode(false);
        }
    }
}
