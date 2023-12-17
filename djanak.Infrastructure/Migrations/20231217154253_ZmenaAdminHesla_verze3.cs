using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace djanak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ZmenaAdminHesla_verze3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2y$10$qj0FbCiXAYtndzYHvzoree35uSXPsHkeK3H6v982yB4puS7FBtGsq");
        }
    }
}
