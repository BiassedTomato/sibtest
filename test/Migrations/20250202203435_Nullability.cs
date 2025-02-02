using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class Nullability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_RepairTypes_RepairTypeId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs");

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("37468462-b695-4c53-9cc5-3d79e3b7b739"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("41e54824-8328-4b20-912f-b0807c6cb5d2"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("6d65de11-ce33-477c-ae6b-f160bb1d711e"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("ba50ffe4-7aae-4e22-b91e-644efc809007"));

            migrationBuilder.DeleteData(
                table: "RepairTypes",
                keyColumn: "Id",
                keyValue: new Guid("eeaddbee-9944-49e7-bd1c-e2f1b7286156"));

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "Repairs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RepairTypeId",
                table: "Repairs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_RepairTypes_RepairTypeId",
                table: "Repairs",
                column: "RepairTypeId",
                principalTable: "RepairTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_RepairTypes_RepairTypeId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "Repairs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "RepairTypeId",
                table: "Repairs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "RepairTypes",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { new Guid("41e54824-8328-4b20-912f-b0807c6cb5d2"), 5000f, "Выправление вмятин" },
                    { new Guid("37468462-b695-4c53-9cc5-3d79e3b7b739"), 8000f, "Замена масла" },
                    { new Guid("eeaddbee-9944-49e7-bd1c-e2f1b7286156"), 500000f, "Замена двигателя" },
                    { new Guid("6d65de11-ce33-477c-ae6b-f160bb1d711e"), 2500f, "Замена колес/покрышек" },
                    { new Guid("ba50ffe4-7aae-4e22-b91e-644efc809007"), 800f, "Установка радиоприемника" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_RepairTypes_RepairTypeId",
                table: "Repairs",
                column: "RepairTypeId",
                principalTable: "RepairTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
