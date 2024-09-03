using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVill_VillAPI.Migrations
{
    /// <inheritdoc />
    public partial class Reference_AddVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 31, 15, 54, 53, 876, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 31, 15, 54, 53, 876, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 31, 15, 54, 53, 876, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 31, 15, 54, 53, 876, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 31, 15, 54, 53, 876, DateTimeKind.Local).AddTicks(1078));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 23, 11, 50, 36, 969, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 23, 11, 50, 36, 969, DateTimeKind.Local).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 23, 11, 50, 36, 969, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 23, 11, 50, 36, 969, DateTimeKind.Local).AddTicks(5271));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 23, 11, 50, 36, 969, DateTimeKind.Local).AddTicks(5273));
        }
    }
}
