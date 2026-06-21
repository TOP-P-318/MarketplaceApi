using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddProductDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "preview_url",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "characteristics",
                table: "products",
                type: "jsonb",
                nullable: false,
                defaultValue: new Dictionary<string, string>());

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "products",
                type: "character varying(2047)",
                maxLength: 2047,
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "image_urls",
                table: "products",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<BigInteger>(
                name: "price",
                table: "products",
                type: "numeric",
                nullable: false,
                defaultValue: BigInteger.Parse("0", NumberFormatInfo.InvariantInfo));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "products");

            migrationBuilder.DropColumn(
                name: "characteristics",
                table: "products");

            migrationBuilder.DropColumn(
                name: "description",
                table: "products");

            migrationBuilder.DropColumn(
                name: "image_urls",
                table: "products");

            migrationBuilder.DropColumn(
                name: "price",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "preview_url",
                table: "products",
                type: "text",
                nullable: true);
        }
    }
}
