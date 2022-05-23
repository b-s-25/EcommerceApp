using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class initial1004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "specification_id",
                table: "Products",
                newName: "specificationId");

            migrationBuilder.RenameColumn(
                name: "product_type",
                table: "Products",
                newName: "productType");

            migrationBuilder.RenameColumn(
                name: "product_price",
                table: "Products",
                newName: "productPrice");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Products",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "product_model",
                table: "Products",
                newName: "productModel");

            migrationBuilder.RenameColumn(
                name: "modified_on",
                table: "Products",
                newName: "modifiedOn");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "Products",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "discription",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "Products",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "created_on",
                table: "Products",
                newName: "createdOn");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "Products",
                newName: "createdBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "specificationId",
                table: "Products",
                newName: "specification_id");

            migrationBuilder.RenameColumn(
                name: "productType",
                table: "Products",
                newName: "product_type");

            migrationBuilder.RenameColumn(
                name: "productPrice",
                table: "Products",
                newName: "product_price");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Products",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "productModel",
                table: "Products",
                newName: "product_model");

            migrationBuilder.RenameColumn(
                name: "modifiedOn",
                table: "Products",
                newName: "modified_on");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Products",
                newName: "modified_by");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "discription");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "Products",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "createdOn",
                table: "Products",
                newName: "created_on");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Products",
                newName: "created_by");
        }
    }
}
