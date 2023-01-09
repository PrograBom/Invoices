using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoices.Migrations
{
    public partial class ClientModelImproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Client_ClientId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ClientId",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Client",
                newName: "Street");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "IssueDate",
                table: "Invoice",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId1",
                table: "Invoice",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BankNumber",
                table: "Client",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Client",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Client",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Client",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ClientId1",
                table: "Invoice",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Client_ClientId1",
                table: "Invoice",
                column: "ClientId1",
                principalTable: "Client",
                principalColumn: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Client_ClientId1",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ClientId1",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Client",
                newName: "Address");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "IssueDate",
                table: "Invoice",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "DATE");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Invoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BankNumber",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ClientId",
                table: "Invoice",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Client_ClientId",
                table: "Invoice",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
