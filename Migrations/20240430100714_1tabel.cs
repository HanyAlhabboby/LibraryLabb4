using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryLabb4.Migrations
{
    /// <inheritdoc />
    public partial class _1tabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "BookCustomers");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BookCustomers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BookCustomers");

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "BookCustomers",
                type: "bit",
                nullable: true);
        }
    }
}
