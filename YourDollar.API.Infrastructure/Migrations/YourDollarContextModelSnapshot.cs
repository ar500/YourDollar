﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourDollar.API.Infrastructure.Context;

namespace YourDollar.API.Migrations
{
    [DbContext(typeof(YourDollarContext))]
    partial class YourDollarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YourDollar.API.Infrastructure.Entities.BudgetCategoryEntity", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.ToTable("BudgetCategories");
                });

            modelBuilder.Entity("YourDollar.API.Infrastructure.Entities.ExpenseEntity", b =>
                {
                    b.Property<Guid>("ExpenseId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<Guid>("BudgetCategoryCategoryId");

                    b.Property<string>("CompanyAccountNumber");

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("IsRecurring");

                    b.Property<DateTime>("PayoutDate");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ExpenseId");

                    b.HasIndex("BudgetCategoryCategoryId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("YourDollar.API.Infrastructure.Entities.PersonEntity", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("YourDollar.API.Infrastructure.Entities.ExpenseEntity", b =>
                {
                    b.HasOne("YourDollar.API.Infrastructure.Entities.BudgetCategoryEntity", "BudgetCategory")
                        .WithMany()
                        .HasForeignKey("BudgetCategoryCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
