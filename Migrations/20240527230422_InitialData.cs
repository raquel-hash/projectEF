using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("989c5a75-4667-464b-b0da-9f63e7b0c110"),
                column: "CreateDate",
                value: new DateTime(2024, 5, 27, 23, 4, 22, 27, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("989c5a75-4667-464b-b0da-9f63e7b0c111"),
                column: "CreateDate",
                value: new DateTime(2024, 5, 27, 23, 4, 22, 27, DateTimeKind.Utc).AddTicks(2344));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("989c5a75-4667-464b-b0da-9f63e7b0c110"),
                column: "CreateDate",
                value: new DateTime(2024, 5, 27, 23, 3, 26, 165, DateTimeKind.Utc).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("989c5a75-4667-464b-b0da-9f63e7b0c111"),
                column: "CreateDate",
                value: new DateTime(2024, 5, 27, 23, 3, 26, 165, DateTimeKind.Utc).AddTicks(185));
        }
    }
}
