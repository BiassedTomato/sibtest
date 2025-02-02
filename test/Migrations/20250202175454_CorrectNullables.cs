using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class CorrectNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Shops_ShopId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Clients_ClientId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Shops_ShopId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Clients_OwnerId",
                table: "Vehicles");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Vehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShopId",
                table: "Repairs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Repairs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShopId",
                table: "Clients",
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
                    { new Guid("41e54824-8328-4b20-912f-b0807c6cb5d2"), 5000f, "Выправление вмятин" },
                    { new Guid("37468462-b695-4c53-9cc5-3d79e3b7b739"), 8000f, "Замена масла" },
                    { new Guid("eeaddbee-9944-49e7-bd1c-e2f1b7286156"), 500000f, "Замена двигателя" },
                    { new Guid("6d65de11-ce33-477c-ae6b-f160bb1d711e"), 2500f, "Замена колес/покрышек" },
                    { new Guid("ba50ffe4-7aae-4e22-b91e-644efc809007"), 800f, "Установка радиоприемника" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Shops_ShopId",
                table: "Clients",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Clients_ClientId",
                table: "Repairs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Shops_ShopId",
                table: "Repairs",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Clients_OwnerId",
                table: "Vehicles",
                column: "OwnerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Shops_ShopId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Clients_ClientId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Shops_ShopId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Clients_OwnerId",
                table: "Vehicles");

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
                name: "OwnerId",
                table: "Vehicles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShopId",
                table: "Repairs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Repairs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShopId",
                table: "Clients",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Shops_ShopId",
                table: "Clients",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Clients_ClientId",
                table: "Repairs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Shops_ShopId",
                table: "Repairs",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Clients_OwnerId",
                table: "Vehicles",
                column: "OwnerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
