using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class RenameToShops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Services_ShopId",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("6008ed75-fda2-4268-b9cf-06a29b71d879"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("80ede21c-0607-466c-adc4-998bfb2fc0ce"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("83a83423-f1b4-424d-b047-5eb0ab2a272b"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("84c3967b-4420-4d17-b23c-6fac77b06b4a"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("dfac210a-e576-4c1c-9e08-45a48d003d1d"));

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Shops");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shops",
                table: "Shops",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Shops_ShopId",
                table: "Repairs",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Shops_ShopId",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shops",
                table: "Shops");

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

            migrationBuilder.RenameTable(
                name: "Shops",
                newName: "Services");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { new Guid("6008ed75-fda2-4268-b9cf-06a29b71d879"), 5000f, "Выправление вмятин" },
                    { new Guid("dfac210a-e576-4c1c-9e08-45a48d003d1d"), 8000f, "Замена масла" },
                    { new Guid("84c3967b-4420-4d17-b23c-6fac77b06b4a"), 500000f, "Замена двигателя" },
                    { new Guid("80ede21c-0607-466c-adc4-998bfb2fc0ce"), 2500f, "Замена колес/покрышек" },
                    { new Guid("83a83423-f1b4-424d-b047-5eb0ab2a272b"), 800f, "Установка радиоприемника" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Services_ShopId",
                table: "Repairs",
                column: "ShopId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
