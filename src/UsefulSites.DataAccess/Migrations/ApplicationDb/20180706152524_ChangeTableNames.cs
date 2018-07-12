using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsefulSites.DataAccess.Migrations.ApplicationDb
{
    public partial class ChangeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resource_ResourceType_ResourceTypeId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRequest_ResourceType_ResourceTypeId",
                table: "ResourceRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceType",
                table: "ResourceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceRequest",
                table: "ResourceRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.RenameTable(
                name: "ResourceType",
                newName: "ResourceTypes");

            migrationBuilder.RenameTable(
                name: "ResourceRequest",
                newName: "ResourceRequests");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Resources");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceRequest_ResourceTypeId",
                table: "ResourceRequests",
                newName: "IX_ResourceRequests_ResourceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_ResourceTypeId",
                table: "Resources",
                newName: "IX_Resources_ResourceTypeId");

            migrationBuilder.AddColumn<int>(
                name: "ResourceCategoryId",
                table: "Resources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceTypes",
                table: "ResourceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceRequests",
                table: "ResourceRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ResourceCategories",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceCategoryId",
                table: "Resources",
                column: "ResourceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRequests_ResourceTypes_ResourceTypeId",
                table: "ResourceRequests",
                column: "ResourceTypeId",
                principalTable: "ResourceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_ResourceCategories_ResourceCategoryId",
                table: "Resources",
                column: "ResourceCategoryId",
                principalTable: "ResourceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_ResourceTypes_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId",
                principalTable: "ResourceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRequests_ResourceTypes_ResourceTypeId",
                table: "ResourceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_ResourceCategories_ResourceCategoryId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_ResourceTypes_ResourceTypeId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "ResourceCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceTypes",
                table: "ResourceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ResourceCategoryId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceRequests",
                table: "ResourceRequests");

            migrationBuilder.DropColumn(
                name: "ResourceCategoryId",
                table: "Resources");

            migrationBuilder.RenameTable(
                name: "ResourceTypes",
                newName: "ResourceType");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Resource");

            migrationBuilder.RenameTable(
                name: "ResourceRequests",
                newName: "ResourceRequest");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_ResourceTypeId",
                table: "Resource",
                newName: "IX_Resource_ResourceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceRequests_ResourceTypeId",
                table: "ResourceRequest",
                newName: "IX_ResourceRequest_ResourceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceType",
                table: "ResourceType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resource",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceRequest",
                table: "ResourceRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_ResourceType_ResourceTypeId",
                table: "Resource",
                column: "ResourceTypeId",
                principalTable: "ResourceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRequest_ResourceType_ResourceTypeId",
                table: "ResourceRequest",
                column: "ResourceTypeId",
                principalTable: "ResourceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
