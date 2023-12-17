using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace djanak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class zmenaProductsNaRecepts_verze1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Recepts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NazevProductu = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kategorie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Obtiznost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CasovaNarocnost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PopisReceptu = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeznamSurovin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostupPripravy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DatumVytvoreni = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImageSrc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageAlt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Recepts",
                columns: new[] { "Id", "CasovaNarocnost", "DatumVytvoreni", "ImageAlt", "ImageSrc", "Kategorie", "NazevProductu", "Obtiznost", "PopisReceptu", "PostupPripravy", "SeznamSurovin" },
                values: new object[,]
                {
                    { 1, "30 minut", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obrazek1", "/img/products/recept_01.jpg", "Oběd", "Pražská polévka", "Snadné", "Recept je velmi chutný a jednoduchý na přípravu", "Nakrájenou cibuli necháme 12 minut odležet. Poté ji na sádle zpěníme, přidáme nakrájenou klobásu a opečeme.Přidáme mrkev, orestujeme a poté zasypeme červenou paprikou. Vše zalijeme vývarem, přidáme oloupané, nakrájené brambory, osolíme a polévku vaříme 15 minut.", "1ks cibule, 1ks mrkev, 2ks brambory, 1ks klobása, 1l vývar, sůl, 2 lžičky sladké papriky, 1 lžíce sádla" },
                    { 2, "40 minut", new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obrazek2", "/img/products/recept_02.jpg", "Přílohy", "Vařené brambory", "Snadné", "Brambory se hodí ke všemu", "Brambory oloupeme a dáme do hrnce s vodou.Nakrájíme je na kostky, propláchneme a zalijeme čerstvou vodou. Osolíme, přidáme kmín a dáme vařit.Vaříme 15 minut do změknutí. Zda jsou brambory hotové, poznáme tak, že se po píchnutí vidličkou rozpadnou.", "6ks brambory, 1 špetka soli, 1 špetka kmínu" },
                    { 3, "20 minut", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obrazek3", "/img/products/recept_03.jpg", "Oběd", "Tuňákové těstoviny", "Snadné", "Tuňák je zdravý pro kosti (určitě jo)", "Těstoviny uvaříme dle návodu.Na troše olivového oleje necháme zesklovatět nadrobno nakrájenou cibuli. Přidáme na plátky nakrájený česnek, chvilku míchejte.Přidejte rajčata a nakrájené lístky bazalky. Chvíli povařte. Nakonec vmíchejte rozdrobené maso tuňáka,které se snažíme vložit do jídla s minimálním množstvím oleje z konzervy, dochuťte solí/pepřem a nechte maso ve směsi prohřát.Do hotové směsi vmíchejte těstoviny a můžete servírovat. V případě zájmu je možné těstoviny posypat strouhaným parmazánem, není to však třeba.", "1ks cibule, olivový olej, 3 stoužky česneku, 1 plechovka loupaných rajčat, pepř, sůl, 180g tuňáka v plechu, strouhaný parmazám,200g těstovin" },
                    { 4, "40 minut", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obrazek4", "/img/products/recept_04.jpg", "Oběd", "Kuřecí prsa s broskvemi a švestkami", "Střední", "Mňam mňam broskvička s masíkem", "Prvně nasekat, pak povařit, pak promíchat. Tenhle recept je hrozně dlouhej, tak jsem ho sem nevkládal celej.", "4ks kuřecí prsa, 2 lžíce povidla, 8 plátků šunky, 8ks šarlotky, 8ks švestek, 2ks broskve, olivový olej, sůl, pepř" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Recepts_ProductID",
                table: "OrderItems",
                column: "ProductID",
                principalTable: "Recepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Recepts_ProductID",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "Recepts");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CasovaNarocnost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DatumVytvoreni = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImageAlt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageSrc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kategorie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NazevProductu = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Obtiznost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PopisReceptu = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostupPripravy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeznamSurovin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CasovaNarocnost", "DatumVytvoreni", "ImageAlt", "ImageSrc", "Kategorie", "NazevProductu", "Obtiznost", "PopisReceptu", "PostupPripravy", "SeznamSurovin" },
                values: new object[,]
                {
                    { 1, "30 minut", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obrazek1", "/img/products/recept_01.jpg", "Oběd", "Pražská polévka", "Snadné", "Recept je velmi chutný a jednoduchý na přípravu", "Nakrájenou cibuli necháme 12 minut odležet. Poté ji na sádle zpěníme, přidáme nakrájenou klobásu a opečeme.Přidáme mrkev, orestujeme a poté zasypeme červenou paprikou. Vše zalijeme vývarem, přidáme oloupané, nakrájené brambory, osolíme a polévku vaříme 15 minut.", "1ks cibule, 1ks mrkev, 2ks brambory, 1ks klobása, 1l vývar, sůl, 2 lžičky sladké papriky, 1 lžíce sádla" },
                    { 2, "40 minut", new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obrazek2", "/img/products/recept_02.jpg", "Přílohy", "Vařené brambory", "Snadné", "Brambory se hodí ke všemu", "Brambory oloupeme a dáme do hrnce s vodou.Nakrájíme je na kostky, propláchneme a zalijeme čerstvou vodou. Osolíme, přidáme kmín a dáme vařit.Vaříme 15 minut do změknutí. Zda jsou brambory hotové, poznáme tak, že se po píchnutí vidličkou rozpadnou.", "6ks brambory, 1 špetka soli, 1 špetka kmínu" },
                    { 3, "20 minut", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obrazek3", "/img/products/recept_03.jpg", "Oběd", "Tuňákové těstoviny", "Snadné", "Tuňák je zdravý pro kosti (určitě jo)", "Těstoviny uvaříme dle návodu.Na troše olivového oleje necháme zesklovatět nadrobno nakrájenou cibuli. Přidáme na plátky nakrájený česnek, chvilku míchejte.Přidejte rajčata a nakrájené lístky bazalky. Chvíli povařte. Nakonec vmíchejte rozdrobené maso tuňáka,které se snažíme vložit do jídla s minimálním množstvím oleje z konzervy, dochuťte solí/pepřem a nechte maso ve směsi prohřát.Do hotové směsi vmíchejte těstoviny a můžete servírovat. V případě zájmu je možné těstoviny posypat strouhaným parmazánem, není to však třeba.", "1ks cibule, olivový olej, 3 stoužky česneku, 1 plechovka loupaných rajčat, pepř, sůl, 180g tuňáka v plechu, strouhaný parmazám,200g těstovin" },
                    { 4, "40 minut", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obrazek4", "/img/products/recept_04.jpg", "Oběd", "Kuřecí prsa s broskvemi a švestkami", "Střední", "Mňam mňam broskvička s masíkem", "Prvně nasekat, pak povařit, pak promíchat. Tenhle recept je hrozně dlouhej, tak jsem ho sem nevkládal celej.", "4ks kuřecí prsa, 2 lžíce povidla, 8 plátků šunky, 8ks šarlotky, 8ks švestek, 2ks broskve, olivový olej, sůl, pepř" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                table: "OrderItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
