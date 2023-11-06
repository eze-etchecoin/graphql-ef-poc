using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQL_EF_PoC.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredRestOfEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModel_VehicleBrand_BrandId",
                table: "VehicleModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModel_ModelId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleModel",
                table: "VehicleModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleBrand",
                table: "VehicleBrand");

            migrationBuilder.RenameTable(
                name: "VehicleModel",
                newName: "Models");

            migrationBuilder.RenameTable(
                name: "VehicleBrand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleModel_BrandId",
                table: "Models",
                newName: "IX_Models_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "VehicleModel");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "VehicleBrand");

            migrationBuilder.RenameIndex(
                name: "IX_Models_BrandId",
                table: "VehicleModel",
                newName: "IX_VehicleModel_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleModel",
                table: "VehicleModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleBrand",
                table: "VehicleBrand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModel_VehicleBrand_BrandId",
                table: "VehicleModel",
                column: "BrandId",
                principalTable: "VehicleBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModel_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "VehicleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
