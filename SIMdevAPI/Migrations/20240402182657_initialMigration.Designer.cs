﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIMdevAPI.Data;

#nullable disable

namespace SIMdevAPI.Migrations
{
    [DbContext(typeof(SimDataContext))]
    [Migration("20240402182657_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SIMdevAPI.Models.Component_Details", b =>
                {
                    b.Property<long>("Comp_Details_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Comp_Details_Id"));

                    b.Property<string>("Comp_Details_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Comp_Mast_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("component_masterComp_Mast_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Comp_Details_Id");

                    b.HasIndex("component_masterComp_Mast_Id");

                    b.ToTable("comp_details");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Component_Master", b =>
                {
                    b.Property<long>("Comp_Mast_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Comp_Mast_Id"));

                    b.Property<string>("Comp_Mast_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Min_Qty")
                        .HasColumnType("float");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Comp_Mast_Id");

                    b.ToTable("comp_mast");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Component_Details", b =>
                {
                    b.HasOne("SIMdevAPI.Models.Component_Master", "component_master")
                        .WithMany("component_details")
                        .HasForeignKey("component_masterComp_Mast_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("component_master");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Component_Master", b =>
                {
                    b.Navigation("component_details");
                });
#pragma warning restore 612, 618
        }
    }
}
