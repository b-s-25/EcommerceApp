using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class initial1001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "specification_id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "product_type");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "Products",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "product_model");

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "deleted_by",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "discription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "modified_by",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_on",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "product_price",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "discription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "modified_on",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "product_price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "specification_id",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "product_type",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Products",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "product_model",
                table: "Products",
                newName: "description");
        }
    }
}
