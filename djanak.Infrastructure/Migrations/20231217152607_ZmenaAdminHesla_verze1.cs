using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace djanak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ZmenaAdminHesla_verze1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2y$10$q7J8XG.sfd2n2A11k7oHUelKOI3578LW15s2QDBnBUFWlzi5xA8Ba");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==");
        }
    }
}
