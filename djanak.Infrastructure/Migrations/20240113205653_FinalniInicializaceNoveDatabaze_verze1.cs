using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace djanak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalniInicializaceNoveDatabaze_verze1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CasovaNarocnost", "ImageSrc", "NazevReceptu", "Obtiznost", "PopisReceptu", "PostupPripravy", "SeznamSurovin" },
                values: new object[] { "15 - 45 min.", "/img/products/Recept1.jpg", "Kuřecí karbanátky", "Jednoduchý", "", "[\"Maso usmažit\",\"Maso upéct\"]", "[{\"Nazev\":\"Kuřecí prsa\",\"Mnozstvi\":\"400g\"},{\"Nazev\":\"Blaťácké zlato\",\"Mnozstvi\":\"100g\"}]" });

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CasovaNarocnost", "Kategorie", "NazevReceptu", "Obtiznost" },
                values: new object[] { "15 - 45 min.", "Snack", "Jednoduchý pamlsek pro děti i dospělé", "Jednoduchý" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CasovaNarocnost", "ImageSrc", "NazevReceptu", "Obtiznost", "PopisReceptu", "PostupPripravy", "SeznamSurovin" },
                values: new object[] { "30 minut", "/img/products/recept_01.jpg", "Pražská polévka", "Snadné", "Recept je velmi chutný a jednoduchý na přípravu", "Nakrájenou cibuli necháme 12 minut odležet. Poté ji na sádle zpěníme, přidáme nakrájenou klobásu a opečeme.Přidáme mrkev, orestujeme a poté zasypeme červenou paprikou. Vše zalijeme vývarem, přidáme oloupané, nakrájené brambory, osolíme a polévku vaříme 15 minut.", "1ks cibule, 1ks mrkev, 2ks brambory, 1ks klobása, 1l vývar, sůl, 2 lžičky sladké papriky, 1 lžíce sádla" });

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CasovaNarocnost", "Kategorie", "NazevReceptu", "Obtiznost" },
                values: new object[] { "40 minut", "Přílohy", "Vařené brambory", "Snadné" });
        }
    }
}
