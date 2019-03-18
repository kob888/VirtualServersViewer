using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VirtualServersViewer.Migrations
{
    public partial class SetTimerStartValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Timer",
                columns: new[] { "Id", "Timer", "StartTime" },
                values: new object[] { 1, new DateTime(0001, 01, 01, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(0001, 01, 01, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
