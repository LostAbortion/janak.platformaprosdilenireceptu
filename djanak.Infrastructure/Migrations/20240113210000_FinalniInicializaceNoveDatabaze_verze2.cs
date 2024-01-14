using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace djanak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalniInicializaceNoveDatabaze_verze2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopisReceptu",
                value: "Suprové karbanátky");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recepts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopisReceptu",
                value: "");

            migrationBuilder.InsertData(
                table: "Recepts",
                columns: new[] { "Id", "CasovaNarocnost", "DatumVytvoreni", "ImageSrc", "Kategorie", "NazevReceptu", "Obtiznost", "PopisReceptu", "PostupPripravy", "SeznamSurovin" },
                values: new object[,]
                {
                    { 2, "15 - 45 min.", new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/products/recept_02.jpg", "Snack", "Jednoduchý pamlsek pro děti i dospělé", "Jednoduchý", "Brambory se hodí ke všemu", "Brambory oloupeme a dáme do hrnce s vodou.Nakrájíme je na kostky, propláchneme a zalijeme čerstvou vodou. Osolíme, přidáme kmín a dáme vařit.Vaříme 15 minut do změknutí. Zda jsou brambory hotové, poznáme tak, že se po píchnutí vidličkou rozpadnou.", "6ks brambory, 1 špetka soli, 1 špetka kmínu" },
                    { 3, "20 minut", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/products/recept_03.jpg", "Oběd", "Tuňákové těstoviny", "Snadné", "Tuňák je zdravý pro kosti (určitě jo)", "Těstoviny uvaříme dle návodu.Na troše olivového oleje necháme zesklovatět nadrobno nakrájenou cibuli. Přidáme na plátky nakrájený česnek, chvilku míchejte.Přidejte rajčata a nakrájené lístky bazalky. Chvíli povařte. Nakonec vmíchejte rozdrobené maso tuňáka,které se snažíme vložit do jídla s minimálním množstvím oleje z konzervy, dochuťte solí/pepřem a nechte maso ve směsi prohřát.Do hotové směsi vmíchejte těstoviny a můžete servírovat. V případě zájmu je možné těstoviny posypat strouhaným parmazánem, není to však třeba.", "1ks cibule, olivový olej, 3 stoužky česneku, 1 plechovka loupaných rajčat, pepř, sůl, 180g tuňáka v plechu, strouhaný parmazám,200g těstovin" },
                    { 4, "40 minut", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/products/recept_04.jpg", "Oběd", "Kuřecí prsa s broskvemi a švestkami", "Střední", "Mňam mňam broskvička s masíkem", "Prvně nasekat, pak povařit, pak promíchat. Tenhle recept je hrozně dlouhej, tak jsem ho sem nevkládal celej.", "4ks kuřecí prsa, 2 lžíce povidla, 8 plátků šunky, 8ks šarlotky, 8ks švestek, 2ks broskve, olivový olej, sůl, pepř" }
                });
        }
    }
}
