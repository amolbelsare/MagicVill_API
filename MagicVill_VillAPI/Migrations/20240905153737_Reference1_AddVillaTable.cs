using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVill_VillAPI.Migrations
{
    /// <inheritdoc />
    public partial class Reference1_AddVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 5, 21, 7, 35, 714, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 5, 21, 7, 35, 714, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 5, 21, 7, 35, 714, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 5, 21, 7, 35, 714, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 5, 21, 7, 35, 714, DateTimeKind.Local).AddTicks(1213));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 4, 11, 5, 48, 526, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 4, 11, 5, 48, 526, DateTimeKind.Local).AddTicks(6826));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 4, 11, 5, 48, 526, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 4, 11, 5, 48, 526, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 4, 11, 5, 48, 526, DateTimeKind.Local).AddTicks(6832));
        }
    }
}
