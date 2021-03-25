using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace todos.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DueBy = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Content", "CreatedOn", "DueBy", "IsDone", "Name", "Username" },
                values: new object[] { 1, "Sample todo item 1", new DateTime(2021, 3, 23, 14, 4, 55, 991, DateTimeKind.Local).AddTicks(1873), new DateTime(2021, 3, 28, 14, 4, 55, 997, DateTimeKind.Local).AddTicks(8558), false, "Test Todo 1", "SYSTEM" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Content", "CreatedOn", "DueBy", "IsDone", "Name", "Username" },
                values: new object[] { 2, "Sample todo item 2", new DateTime(2021, 3, 23, 14, 4, 55, 999, DateTimeKind.Local).AddTicks(139), new DateTime(2021, 3, 28, 14, 4, 55, 999, DateTimeKind.Local).AddTicks(277), false, "Test Todo 2", "SYSTEM" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Content", "CreatedOn", "DueBy", "IsDone", "Name", "Username" },
                values: new object[] { 3, "Sample todo item 3", new DateTime(2021, 3, 23, 14, 4, 55, 999, DateTimeKind.Local).AddTicks(307), new DateTime(2021, 3, 28, 14, 4, 55, 999, DateTimeKind.Local).AddTicks(313), false, "Test Todo 3", "SYSTEM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
