﻿// <auto-generated />
using System;
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
    [Migration("20240416113344_Adding_Pending_Tables")]
    partial class Adding_Pending_Tables
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

                    b.Property<string>("Value")
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

            modelBuilder.Entity("SIMdevAPI.Models.Login_Master", b =>
                {
                    b.Property<long>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("LoginId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("login_master");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Product_Details", b =>
                {
                    b.Property<long>("Prod_Details_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Prod_Details_Id"));

                    b.Property<long>("Comp_Details_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Prod_Mast_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Prod_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<long>("component_detailsComp_Details_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("prod_masterProd_Mast_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Prod_Details_Id");

                    b.HasIndex("component_detailsComp_Details_Id");

                    b.HasIndex("prod_masterProd_Mast_Id");

                    b.ToTable("prod_details");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Product_Master", b =>
                {
                    b.Property<long>("Prod_Mast_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Prod_Mast_Id"));

                    b.Property<string>("Prod_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Prod_Mast_Id");

                    b.ToTable("prod_mast");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Spares_Out_For_Production", b =>
                {
                    b.Property<long>("Out_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Out_Id"));

                    b.Property<long>("Comp_Details_Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("Prod_Mast_Id")
                        .HasColumnType("bigint");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<long>("Staff_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("component_detailsComp_Details_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("product_masterProd_Mast_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("staff_masterStaff_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Out_Id");

                    b.HasIndex("component_detailsComp_Details_Id");

                    b.HasIndex("product_masterProd_Mast_Id");

                    b.HasIndex("staff_masterStaff_Id");

                    b.ToTable("spares_out_for_production");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Staff_Master", b =>
                {
                    b.Property<long>("Staff_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Staff_Id"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Staff_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Staff_Id");

                    b.ToTable("staff_master");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Staff_Production_In_Entry", b =>
                {
                    b.Property<long>("In_Entry_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("In_Entry_Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("Prod_Mast_Id")
                        .HasColumnType("bigint");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<long>("Staff_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("product_masterProd_Mast_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("staff_masterStaff_Id")
                        .HasColumnType("bigint");

                    b.HasKey("In_Entry_Id");

                    b.HasIndex("product_masterProd_Mast_Id");

                    b.HasIndex("staff_masterStaff_Id");

                    b.ToTable("staff_prod_in_entry");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Stock_Master", b =>
                {
                    b.Property<long>("Stock_Mast_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Stock_Mast_Id"));

                    b.Property<string>("Box_Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Buyer_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Comp_Details_Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<string>("Stock_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("component_detailsComp_Details_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Stock_Mast_Id");

                    b.HasIndex("component_detailsComp_Details_Id");

                    b.ToTable("stock_master");
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

            modelBuilder.Entity("SIMdevAPI.Models.Product_Details", b =>
                {
                    b.HasOne("SIMdevAPI.Models.Component_Details", "component_details")
                        .WithMany()
                        .HasForeignKey("component_detailsComp_Details_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMdevAPI.Models.Product_Master", "prod_master")
                        .WithMany("product_details")
                        .HasForeignKey("prod_masterProd_Mast_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("component_details");

                    b.Navigation("prod_master");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Spares_Out_For_Production", b =>
                {
                    b.HasOne("SIMdevAPI.Models.Component_Details", "component_details")
                        .WithMany()
                        .HasForeignKey("component_detailsComp_Details_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMdevAPI.Models.Product_Master", "product_master")
                        .WithMany()
                        .HasForeignKey("product_masterProd_Mast_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMdevAPI.Models.Staff_Master", "staff_master")
                        .WithMany()
                        .HasForeignKey("staff_masterStaff_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("component_details");

                    b.Navigation("product_master");

                    b.Navigation("staff_master");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Staff_Production_In_Entry", b =>
                {
                    b.HasOne("SIMdevAPI.Models.Product_Master", "product_master")
                        .WithMany()
                        .HasForeignKey("product_masterProd_Mast_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIMdevAPI.Models.Staff_Master", "staff_master")
                        .WithMany()
                        .HasForeignKey("staff_masterStaff_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product_master");

                    b.Navigation("staff_master");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Stock_Master", b =>
                {
                    b.HasOne("SIMdevAPI.Models.Component_Details", "component_details")
                        .WithMany()
                        .HasForeignKey("component_detailsComp_Details_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("component_details");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Component_Master", b =>
                {
                    b.Navigation("component_details");
                });

            modelBuilder.Entity("SIMdevAPI.Models.Product_Master", b =>
                {
                    b.Navigation("product_details");
                });
#pragma warning restore 612, 618
        }
    }
}
