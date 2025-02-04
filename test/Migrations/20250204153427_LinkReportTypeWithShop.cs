using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class LinkReportTypeWithShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("264e73d9-af15-4219-b0e6-f4944380a921"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("52a6ccaf-2d9b-46fa-be70-c2eb2867f002"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("bf8ca247-aae1-4cc0-8872-b7cbbfe2ffca"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("d1ee9afa-def6-495d-bc84-41ce30379401"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("ed5c3a76-da10-4e36-8bf2-2b080e4675e7"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("20a97a2f-d061-4c20-bcf9-6060c5e8d96b"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "RepairTypes",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Cost", "Name", "ShopId" },
                values: new object[,]
                {
                    { new Guid("fb0cde33-67f3-4d60-8ba6-e6e622c2eb10"), 5000f, "Выправление вмятин", null },
                    { new Guid("f4d40fec-ca70-4dfc-b77d-84ddd3c39548"), 8000f, "Замена масла", null },
                    { new Guid("dc0049df-1b21-4db9-8311-f9461bb60cc4"), 500000f, "Замена двигателя", null },
                    { new Guid("82af0c89-2070-48bb-865c-dd72fc871e94"), 2500f, "Замена колес/покрышек", null },
                    { new Guid("23393d8d-a583-4ab1-b4fc-e4184b69c464"), 800f, "Установка радиоприемника", null }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "IdNumber", "Name" },
                values: new object[] { new Guid("d0437a84-be08-4491-ba20-fbb901f13f7c"), "1237873535", "СТО 'Акула'" });

            migrationBuilder.CreateIndex(
                name: "IX_RepairTypes_ShopId",
                table: "RepairTypes",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_Shops_ShopId",
                table: "RepairTypes",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_Shops_ShopId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_RepairTypes_ShopId",
                table: "RepairTypes");

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("23393d8d-a583-4ab1-b4fc-e4184b69c464"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("82af0c89-2070-48bb-865c-dd72fc871e94"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc0049df-1b21-4db9-8311-f9461bb60cc4"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("f4d40fec-ca70-4dfc-b77d-84ddd3c39548"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("fb0cde33-67f3-4d60-8ba6-e6e622c2eb10"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("d0437a84-be08-4491-ba20-fbb901f13f7c"));

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "RepairTypes");

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { new Guid("52a6ccaf-2d9b-46fa-be70-c2eb2867f002"), 5000f, "Выправление вмятин" },
                    { new Guid("bf8ca247-aae1-4cc0-8872-b7cbbfe2ffca"), 8000f, "Замена масла" },
                    { new Guid("d1ee9afa-def6-495d-bc84-41ce30379401"), 500000f, "Замена двигателя" },
                    { new Guid("ed5c3a76-da10-4e36-8bf2-2b080e4675e7"), 2500f, "Замена колес/покрышек" },
                    { new Guid("264e73d9-af15-4219-b0e6-f4944380a921"), 800f, "Установка радиоприемника" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "IdNumber", "Name" },
                values: new object[] { new Guid("20a97a2f-d061-4c20-bcf9-6060c5e8d96b"), "1237873535", "СТО 'Акула'" });
        }
    }
}
