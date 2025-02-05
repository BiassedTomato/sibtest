using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class RemoveCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Cost",
                table: "Repairs");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "Repairs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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
        }
    }
}
