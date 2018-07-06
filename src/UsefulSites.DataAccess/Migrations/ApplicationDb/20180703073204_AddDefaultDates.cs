using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsefulSites.DataAccess.Migrations.ApplicationDb
{
    public partial class AddDefaultDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ResourceType",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ResourceType",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ResourceRequest",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ResourceRequest",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Resource",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Resource",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2018, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ResourceType",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ResourceType",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ResourceRequest",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ResourceRequest",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Resource",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Resource",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2018, 7, 1, 11, 59, 43, 711, DateTimeKind.Local), new DateTime(2018, 7, 1, 11, 59, 43, 715, DateTimeKind.Local) });
        }
    }
}
