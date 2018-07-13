using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsefulSites.DataAccess.Migrations.ApplicationDb
{
    public partial class DescriptionForResourceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Resource",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2018, 7, 1, 11, 59, 43, 711, DateTimeKind.Local), new DateTime(2018, 7, 1, 11, 59, 43, 715, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Resource");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2018, 7, 1, 10, 34, 16, 155, DateTimeKind.Local), new DateTime(2018, 7, 1, 10, 34, 16, 158, DateTimeKind.Local) });
        }
    }
}
