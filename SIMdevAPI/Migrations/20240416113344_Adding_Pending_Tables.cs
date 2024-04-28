using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMdevAPI.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Pending_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "comp_details",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "login_master",
                columns: table => new
                {
                    LoginId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login_master", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "prod_mast",
                columns: table => new
                {
                    Prod_Mast_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prod_mast", x => x.Prod_Mast_Id);
                });

            migrationBuilder.CreateTable(
                name: "staff_master",
                columns: table => new
                {
                    Staff_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff_master", x => x.Staff_Id);
                });

            migrationBuilder.CreateTable(
                name: "stock_master",
                columns: table => new
                {
                    Stock_Mast_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comp_Details_Id = table.Column<long>(type: "bigint", nullable: false),
                    component_detailsComp_Details_Id = table.Column<long>(type: "bigint", nullable: false),
                    Stock_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Box_Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Buyer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_master", x => x.Stock_Mast_Id);
                    table.ForeignKey(
                        name: "FK_stock_master_comp_details_component_detailsComp_Details_Id",
                        column: x => x.component_detailsComp_Details_Id,
                        principalTable: "comp_details",
                        principalColumn: "Comp_Details_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prod_details",
                columns: table => new
                {
                    Prod_Details_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Mast_Id = table.Column<long>(type: "bigint", nullable: false),
                    prod_masterProd_Mast_Id = table.Column<long>(type: "bigint", nullable: false),
                    Prod_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comp_Details_Id = table.Column<long>(type: "bigint", nullable: false),
                    component_detailsComp_Details_Id = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prod_details", x => x.Prod_Details_Id);
                    table.ForeignKey(
                        name: "FK_prod_details_comp_details_component_detailsComp_Details_Id",
                        column: x => x.component_detailsComp_Details_Id,
                        principalTable: "comp_details",
                        principalColumn: "Comp_Details_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prod_details_prod_mast_prod_masterProd_Mast_Id",
                        column: x => x.prod_masterProd_Mast_Id,
                        principalTable: "prod_mast",
                        principalColumn: "Prod_Mast_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spares_out_for_production",
                columns: table => new
                {
                    Out_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Id = table.Column<long>(type: "bigint", nullable: false),
                    staff_masterStaff_Id = table.Column<long>(type: "bigint", nullable: false),
                    Prod_Mast_Id = table.Column<long>(type: "bigint", nullable: false),
                    product_masterProd_Mast_Id = table.Column<long>(type: "bigint", nullable: false),
                    Comp_Details_Id = table.Column<long>(type: "bigint", nullable: false),
                    component_detailsComp_Details_Id = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spares_out_for_production", x => x.Out_Id);
                    table.ForeignKey(
                        name: "FK_spares_out_for_production_comp_details_component_detailsComp_Details_Id",
                        column: x => x.component_detailsComp_Details_Id,
                        principalTable: "comp_details",
                        principalColumn: "Comp_Details_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spares_out_for_production_prod_mast_product_masterProd_Mast_Id",
                        column: x => x.product_masterProd_Mast_Id,
                        principalTable: "prod_mast",
                        principalColumn: "Prod_Mast_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spares_out_for_production_staff_master_staff_masterStaff_Id",
                        column: x => x.staff_masterStaff_Id,
                        principalTable: "staff_master",
                        principalColumn: "Staff_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staff_prod_in_entry",
                columns: table => new
                {
                    In_Entry_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Mast_Id = table.Column<long>(type: "bigint", nullable: false),
                    product_masterProd_Mast_Id = table.Column<long>(type: "bigint", nullable: false),
                    Staff_Id = table.Column<long>(type: "bigint", nullable: false),
                    staff_masterStaff_Id = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff_prod_in_entry", x => x.In_Entry_Id);
                    table.ForeignKey(
                        name: "FK_staff_prod_in_entry_prod_mast_product_masterProd_Mast_Id",
                        column: x => x.product_masterProd_Mast_Id,
                        principalTable: "prod_mast",
                        principalColumn: "Prod_Mast_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_staff_prod_in_entry_staff_master_staff_masterStaff_Id",
                        column: x => x.staff_masterStaff_Id,
                        principalTable: "staff_master",
                        principalColumn: "Staff_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prod_details_component_detailsComp_Details_Id",
                table: "prod_details",
                column: "component_detailsComp_Details_Id");

            migrationBuilder.CreateIndex(
                name: "IX_prod_details_prod_masterProd_Mast_Id",
                table: "prod_details",
                column: "prod_masterProd_Mast_Id");

            migrationBuilder.CreateIndex(
                name: "IX_spares_out_for_production_component_detailsComp_Details_Id",
                table: "spares_out_for_production",
                column: "component_detailsComp_Details_Id");

            migrationBuilder.CreateIndex(
                name: "IX_spares_out_for_production_product_masterProd_Mast_Id",
                table: "spares_out_for_production",
                column: "product_masterProd_Mast_Id");

            migrationBuilder.CreateIndex(
                name: "IX_spares_out_for_production_staff_masterStaff_Id",
                table: "spares_out_for_production",
                column: "staff_masterStaff_Id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_prod_in_entry_product_masterProd_Mast_Id",
                table: "staff_prod_in_entry",
                column: "product_masterProd_Mast_Id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_prod_in_entry_staff_masterStaff_Id",
                table: "staff_prod_in_entry",
                column: "staff_masterStaff_Id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_master_component_detailsComp_Details_Id",
                table: "stock_master",
                column: "component_detailsComp_Details_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "login_master");

            migrationBuilder.DropTable(
                name: "prod_details");

            migrationBuilder.DropTable(
                name: "spares_out_for_production");

            migrationBuilder.DropTable(
                name: "staff_prod_in_entry");

            migrationBuilder.DropTable(
                name: "stock_master");

            migrationBuilder.DropTable(
                name: "prod_mast");

            migrationBuilder.DropTable(
                name: "staff_master");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "comp_details");
        }
    }
}
