using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace djanak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpravaCreateRecept_verze1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Recepts");

            migrationBuilder.AlterColumn<string>(
                name: "SeznamSurovin",
                table: "Recepts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Obtiznost",
                table: "Recepts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CasovaNarocnost",
                table: "Recepts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "SeznamSurovin",
                keyValue: null,
                column: "SeznamSurovin",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SeznamSurovin",
                table: "Recepts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Obtiznost",
                keyValue: null,
                column: "Obtiznost",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Obtiznost",
                table: "Recepts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "CasovaNarocnost",
                keyValue: null,
                column: "CasovaNarocnost",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CasovaNarocnost",
                table: "Recepts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Recepts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageAlt",
                value: "Obrazek1");

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageAlt",
                value: "Obrazek2");

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageAlt",
                value: "Obrazek3");

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageAlt",
                value: "Obrazek4");
        }
    }
}
