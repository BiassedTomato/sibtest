using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class AdequateInn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("0071a805-30a3-4766-a1a8-1a587f0c1ade"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("7a320b57-a15f-4681-88ce-f88f950495fb"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("7e1d35a0-b292-45aa-bcfc-3d2ede1200b7"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("ad223441-7957-4919-bea5-685cce636387"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("f58d0478-507c-4e36-9f05-bbfdcc16cf77"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("c44f3c7d-0d76-4abf-a03f-555a1cdee7da"));

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Cost", "Name", "ShopId" },
                values: new object[,]
                {
                    { new Guid("43ff72a4-a37f-459a-a7cc-77f6ae345cab"), 5000f, "Выправление вмятин", null },
                    { new Guid("7a1b5213-8781-4ff2-81b8-12962553f6c0"), 8000f, "Замена масла", null },
                    { new Guid("012e7144-a42f-4db7-9b35-21a0f85c5082"), 500000f, "Замена двигателя", null },
                    { new Guid("b2231e87-09a8-4505-90f5-5880f9f05914"), 2500f, "Замена колес/покрышек", null },
                    { new Guid("34195d1e-b325-4f56-aa64-d8d11067597d"), 800f, "Установка радиоприемника", null }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "IdNumber", "Name" },
                values: new object[] { new Guid("7bc39ced-d354-434b-a51e-fc81f4726165"), "1234567890", "СТО 'Акула'" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("012e7144-a42f-4db7-9b35-21a0f85c5082"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("34195d1e-b325-4f56-aa64-d8d11067597d"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("43ff72a4-a37f-459a-a7cc-77f6ae345cab"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("7a1b5213-8781-4ff2-81b8-12962553f6c0"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("b2231e87-09a8-4505-90f5-5880f9f05914"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("7bc39ced-d354-434b-a51e-fc81f4726165"));

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Cost", "Name", "ShopId" },
                values: new object[,]
                {
                    { new Guid("0071a805-30a3-4766-a1a8-1a587f0c1ade"), 5000f, "Выправление вмятин", null },
                    { new Guid("7e1d35a0-b292-45aa-bcfc-3d2ede1200b7"), 8000f, "Замена масла", null },
                    { new Guid("f58d0478-507c-4e36-9f05-bbfdcc16cf77"), 500000f, "Замена двигателя", null },
                    { new Guid("7a320b57-a15f-4681-88ce-f88f950495fb"), 2500f, "Замена колес/покрышек", null },
                    { new Guid("ad223441-7957-4919-bea5-685cce636387"), 800f, "Установка радиоприемника", null }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "IdNumber", "Name" },
                values: new object[] { new Guid("c44f3c7d-0d76-4abf-a03f-555a1cdee7da"), "1237873535", "СТО 'Акула'" });
        }
    }
}
