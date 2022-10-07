using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_edit_messagetable_relation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MessageDate",
                table: "Messages2",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MessageDetails",
                table: "Messages2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MessageStatus",
                table: "Messages2",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Receiver",
                table: "Messages2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sender",
                table: "Messages2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Messages2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages2_Receiver",
                table: "Messages2",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_Messages2_Sender",
                table: "Messages2",
                column: "Sender");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_Writers_Receiver",
                table: "Messages2",
                column: "Receiver",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_Writers_Sender",
                table: "Messages2",
                column: "Sender",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_Writers_Receiver",
                table: "Messages2");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_Writers_Sender",
                table: "Messages2");

            migrationBuilder.DropIndex(
                name: "IX_Messages2_Receiver",
                table: "Messages2");

            migrationBuilder.DropIndex(
                name: "IX_Messages2_Sender",
                table: "Messages2");

            migrationBuilder.DropColumn(
                name: "MessageDate",
                table: "Messages2");

            migrationBuilder.DropColumn(
                name: "MessageDetails",
                table: "Messages2");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                table: "Messages2");

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Messages2");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Messages2");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Messages2");
        }
    }
}
