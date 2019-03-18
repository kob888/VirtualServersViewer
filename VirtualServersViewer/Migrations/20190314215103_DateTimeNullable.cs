using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualServersViewer.Migrations
{
    public partial class DateTimeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RemoveDateTime",
                table: "VirtualServers",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RemoveDateTime",
                table: "VirtualServers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
