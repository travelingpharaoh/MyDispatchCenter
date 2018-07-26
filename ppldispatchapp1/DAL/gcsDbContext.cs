using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DAL.Models.Interfaces;

namespace DAL
{
    public partial class gcsDbContext : DbContext
    {
        public gcsDbContext()
        {
        }

        public gcsDbContext(DbContextOptions<gcsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Calls> Calls { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Filters> Filters { get; set; }
        public DbSet<KnowledgeBase> KnowledgeBase { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Calls>(entity =>
            {
                entity.HasIndex(e => e.Caller)
                    .HasName("Calls$Caller");

                entity.HasIndex(e => e.Case)
                    .HasName("Calls$New_Calls to Case");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CallTime)
                    .HasColumnName("Call Time")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Caller).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.HasOne(d => d.CaseNavigation)
                    .WithMany(p => p.Calls)
                    .HasForeignKey(d => d.Case)
                    .HasConstraintName("Calls$New_Calls to Case");
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.HasIndex(e => e.AssignedTo)
                    .HasName("Cases$New_EmployeesCasesAssignedTo");

                entity.HasIndex(e => e.Customer)
                    .HasName("Cases$New_CustomerOwnedBy");

                entity.HasIndex(e => e.Kb)
                    .HasName("Cases$New_KBForCase");

                entity.HasIndex(e => e.OpenedBy)
                    .HasName("Cases$New_EmployeesCasesOpenedBy");

                entity.HasIndex(e => e.Priority)
                    .HasName("Cases$Priority");

                entity.HasIndex(e => e.Status)
                    .HasName("Cases$Status");

                entity.HasIndex(e => e.Title)
                    .HasName("Cases$Title");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssignedTo).HasColumnName("Assigned To");

                entity.Property(e => e.Attachments)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CasePrice)
                    .HasColumnName("Case Price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDate)
                    .HasColumnName("Due Date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Kb).HasColumnName("KB");

                entity.Property(e => e.OpenedBy).HasColumnName("Opened By");

                entity.Property(e => e.OpenedDate)
                    .HasColumnName("Opened Date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('(2) Normal')");

                entity.Property(e => e.RelatedCases)
                    .HasColumnName("Related Cases")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.ResolvedDate)
                    .HasColumnName("Resolved Date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.CasesAssignedToNavigation)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("Cases$New_EmployeesCasesAssignedTo");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("Cases$New_CustomerOwnedBy");

                entity.HasOne(d => d.OpenedByNavigation)
                    .WithMany(p => p.CasesOpenedByNavigation)
                    .HasForeignKey(d => d.OpenedBy)
                    .HasConstraintName("Cases$New_EmployeesCasesOpenedBy");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BasePrice)
                    .HasColumnName("Base_Price")
                    .HasColumnType("money");

                entity.Property(e => e.CategoryName).HasMaxLength(255);

                entity.Property(e => e.CustomerPrice)
                    .HasColumnName("Customer_Price")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.City)
                    .HasName("Customers$City");

                entity.HasIndex(e => e.Company)
                    .HasName("Customers$Company");

                entity.HasIndex(e => e.FirstName)
                    .HasName("Customers$First Name");

                entity.HasIndex(e => e.LastName)
                    .HasName("Customers$Last Name");

                entity.HasIndex(e => e.StateProvince)
                    .HasName("Customers$State/Province");

                entity.HasIndex(e => e.ZipPostalCode)
                    .HasName("Customers$Postal Code");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Attachments)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessPhone)
                    .HasColumnName("Business Phone")
                    .HasMaxLength(25);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.CountryRegion)
                    .HasColumnName("Country/Region")
                    .HasMaxLength(50);

                entity.Property(e => e.EMailAddress)
                    .HasColumnName("E-mail Address")
                    .HasMaxLength(50);

                entity.Property(e => e.FaxNumber)
                    .HasColumnName("Fax Number")
                    .HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First Name")
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone)
                    .HasColumnName("Home Phone")
                    .HasMaxLength(25);

                entity.Property(e => e.JobTitle)
                    .HasColumnName("Job Title")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last Name")
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("Mobile Phone")
                    .HasMaxLength(25);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.StateProvince)
                    .HasColumnName("State/Province")
                    .HasMaxLength(50);

                entity.Property(e => e.WebPage).HasColumnName("Web Page");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnName("ZIP/Postal Code")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasIndex(e => e.City)
                    .HasName("Employees$City");

                entity.HasIndex(e => e.Company)
                    .HasName("Employees$Company");

                entity.HasIndex(e => e.FirstName)
                    .HasName("Employees$First Name");

                entity.HasIndex(e => e.LastName)
                    .HasName("Employees$Last Name");

                entity.HasIndex(e => e.StateProvince)
                    .HasName("Employees$State/Province");

                entity.HasIndex(e => e.ZipPostalCode)
                    .HasName("Employees$Postal Code");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Attachments)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessPhone)
                    .HasColumnName("Business Phone")
                    .HasMaxLength(25);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.CountryRegion)
                    .HasColumnName("Country/Region")
                    .HasMaxLength(50);

                entity.Property(e => e.EMailAddress)
                    .HasColumnName("E-mail Address")
                    .HasMaxLength(50);

                entity.Property(e => e.FaxNumber)
                    .HasColumnName("Fax Number")
                    .HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First Name")
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone)
                    .HasColumnName("Home Phone")
                    .HasMaxLength(25);

                entity.Property(e => e.JobTitle)
                    .HasColumnName("Job Title")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last Name")
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("Mobile Phone")
                    .HasMaxLength(25);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.StateProvince)
                    .HasColumnName("State/Province")
                    .HasMaxLength(50);

                entity.Property(e => e.WebPage).HasColumnName("Web Page");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnName("ZIP/Postal Code")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Filters>(entity =>
            {
                entity.HasIndex(e => e.FilterName)
                    .HasName("Filters$Filter Name")
                    .IsUnique();

                entity.HasIndex(e => e.ObjectName)
                    .HasName("Filters$ObjectName");

                entity.HasIndex(e => e.ObjectType)
                    .HasName("Filters$ObjectType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FilterName)
                    .IsRequired()
                    .HasColumnName("Filter Name")
                    .HasMaxLength(50);

                entity.Property(e => e.FilterString).HasColumnName("Filter String");

                entity.Property(e => e.ObjectName)
                    .IsRequired()
                    .HasColumnName("Object Name")
                    .HasMaxLength(255);

                entity.Property(e => e.ObjectType).HasColumnName("Object Type");

                entity.Property(e => e.SortString).HasColumnName("Sort String");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();
            });

            modelBuilder.Entity<KnowledgeBase>(entity =>
            {
                entity.ToTable("Knowledge Base");

                entity.HasIndex(e => e.Title)
                    .HasName("Knowledge Base$Title");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.Tags)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Url).HasColumnName("URL");
            });
        }
    }
}
