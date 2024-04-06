using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMdevAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comp_mast",
                columns: table => new
                {
                    Comp_Mast_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comp_Mast_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Min_Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_mast", x => x.Comp_Mast_Id);
                });

            migrationBuilder.CreateTable(
                name: "comp_details",
                columns: table => new
                {
                    Comp_Details_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comp_Mast_Id = table.Column<long>(type: "bigint", nullable: false),
                    component_masterComp_Mast_Id = table.Column<long>(type: "bigint", nullable: false),
                    Comp_Details_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_details", x => x.Comp_Details_Id);
                    table.ForeignKey(
                        name: "FK_comp_details_comp_mast_component_masterComp_Mast_Id",
                        column: x => x.component_masterComp_Mast_Id,
                        principalTable: "comp_mast",
                        principalColumn: "Comp_Mast_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comp_details_component_masterComp_Mast_Id",
                table: "comp_details",
                column: "component_masterComp_Mast_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comp_details");

            migrationBuilder.DropTable(
                name: "comp_mast");
        }
    }
}
