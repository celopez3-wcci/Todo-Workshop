using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace todos.Migrations
{
    public partial class SwitchedUsernametoOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Todos");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Todos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 1, "carlos@wecancodeit.org", "Carlos" });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 2, "davis@wecancodeit.org", "Davis" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DueBy", "OwnerId" },
                values: new object[] { new DateTime(2021, 3, 26, 10, 16, 39, 808, DateTimeKind.Local).AddTicks(3832), new DateTime(2021, 3, 31, 10, 16, 39, 814, DateTimeKind.Local).AddTicks(5993), 1 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueBy", "OwnerId" },
                values: new object[] { new DateTime(2021, 3, 26, 10, 16, 39, 814, DateTimeKind.Local).AddTicks(8134), new DateTime(2021, 3, 31, 10, 16, 39, 814, DateTimeKind.Local).AddTicks(8201), 2 });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueBy", "OwnerId" },
                values: new object[] { new DateTime(2021, 3, 26, 10, 16, 39, 814, DateTimeKind.Local).AddTicks(8233), new DateTime(2021, 3, 31, 10, 16, 39, 814, DateTimeKind.Local).AddTicks(8240), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_OwnerId",
                table: "Todos",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Owner_OwnerId",
                table: "Todos",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Owner_OwnerId",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Todos_OwnerId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Todos");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DueBy", "Username" },
                values: new object[] { new DateTime(2021, 3, 23, 14, 4, 55, 991, DateTimeKind.Local).AddTicks(1873), new DateTime(2021, 3, 28, 14, 4, 55, 997, DateTimeKind.Local).AddTicks(8558), "SYSTEM" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueBy", "Username" },
                values: new object[] { new DateTime(2021, 3, 23, 14, 4, 55, 999, DateTimeKind.Local).AddTicks(139), new DateTime(2021, 3, 28, 14, 4, 55, 999, DateTimeKind.Local).AddTicks(277), "SYSTEM" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueBy", "Username" },
                values: new object[] { new DateTime(2021, 3, 23, 14, 4, 55, 999, DateTimeKind.Local).AddTicks(307), new DateTime(2021, 3, 28, 14, 4, 55, 999, DateTimeKind.Local).AddTicks(313), "SYSTEM" });
        }
    }
}
