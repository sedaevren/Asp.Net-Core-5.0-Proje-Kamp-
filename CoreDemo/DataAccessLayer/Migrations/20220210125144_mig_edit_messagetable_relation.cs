using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_edit_messagetable_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_Receiver",
                table: "Message2");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_Sender",
                table: "Message2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message2",
                table: "Message2");

            migrationBuilder.DropIndex(
                name: "IX_Message2_Receiver",
                table: "Message2");

            migrationBuilder.DropIndex(
                name: "IX_Message2_Sender",
                table: "Message2");

            migrationBuilder.DropColumn(
                name: "MessageDate",
                table: "Message2");

            migrationBuilder.DropColumn(
                name: "MessageDetails",
                table: "Message2");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                table: "Message2");

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Message2");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Message2");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Message2");

            migrationBuilder.RenameTable(
                name: "Message2",
                newName: "Messages2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages2",
                table: "Messages2",
                column: "MessageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages2",
                table: "Messages2");

            migrationBuilder.RenameTable(
                name: "Messages2",
                newName: "Message2");

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageDate",
                table: "Message2",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MessageDetails",
                table: "Message2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MessageStatus",
                table: "Message2",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Receiver",
                table: "Message2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sender",
                table: "Message2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Message2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message2",
                table: "Message2",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_Message2_Receiver",
                table: "Message2",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_Message2_Sender",
                table: "Message2",
                column: "Sender");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_Receiver",
                table: "Message2",
                column: "Receiver",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_Sender",
                table: "Message2",
                column: "Sender",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
