using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class ShopTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("518c614e-c353-4ebb-b20e-6389295e63cb"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("644593eb-f496-49cd-8cb7-ba58eb80a5d4"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("88ea353e-3635-4fd9-9b01-f95a673b8878"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("cde01ecb-4511-4b15-97ba-0f5b5b691320"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("e4bd2f6a-4712-4970-922b-98e4f3702d68"));

            migrationBuilder.DropColumn(
                name: "CarNumber",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Vehicles",
                newName: "VehicleNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Clients",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { new Guid("f6477a20-35f3-4d20-b953-714b95be254b"), 5000f, "Выправление вмятин" },
                    { new Guid("2cfbba6d-8e79-4379-8fd4-a109fc163355"), 8000f, "Замена масла" },
                    { new Guid("4e03fcfa-1d56-44f6-be60-c96c02b84ca7"), 500000f, "Замена двигателя" },
                    { new Guid("4960a041-9919-45c6-9382-61e95895dd1a"), 2500f, "Замена колес/покрышек" },
                    { new Guid("59570b83-877f-452b-8cbb-536a835ac9b5"), 800f, "Установка радиоприемника" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ShopId",
                table: "Clients",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Shops_ShopId",
                table: "Clients",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Shops_ShopId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ShopId",
                table: "Clients");

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("2cfbba6d-8e79-4379-8fd4-a109fc163355"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("4960a041-9919-45c6-9382-61e95895dd1a"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("4e03fcfa-1d56-44f6-be60-c96c02b84ca7"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("59570b83-877f-452b-8cbb-536a835ac9b5"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("f6477a20-35f3-4d20-b953-714b95be254b"));

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "VehicleNumber",
                table: "Vehicles",
                newName: "Manufacturer");

            migrationBuilder.AddColumn<string>(
                name: "CarNumber",
                table: "Vehicles",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { new Guid("88ea353e-3635-4fd9-9b01-f95a673b8878"), 5000f, "Выправление вмятин" },
                    { new Guid("518c614e-c353-4ebb-b20e-6389295e63cb"), 8000f, "Замена масла" },
                    { new Guid("e4bd2f6a-4712-4970-922b-98e4f3702d68"), 500000f, "Замена двигателя" },
                    { new Guid("cde01ecb-4511-4b15-97ba-0f5b5b691320"), 2500f, "Замена колес/покрышек" },
                    { new Guid("644593eb-f496-49cd-8cb7-ba58eb80a5d4"), 800f, "Установка радиоприемника" }
                });
        }
    }
}
