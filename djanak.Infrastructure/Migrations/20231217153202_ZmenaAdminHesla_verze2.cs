using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace djanak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ZmenaAdminHesla_verze2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2y$10$qj0FbCiXAYtndzYHvzoree35uSXPsHkeK3H6v982yB4puS7FBtGsq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2y$10$q7J8XG.sfd2n2A11k7oHUelKOI3578LW15s2QDBnBUFWlzi5xA8Ba");
        }
    }
}
