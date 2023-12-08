﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using djanak.Infrastructure.Database;

#nullable disable

namespace djanak.Infrastructure.Migrations
{
    [DbContext(typeof(EshopDbContext))]
    [Migration("20231208182308_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("djanak.Domain.Entities.Carousel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageAlt")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Carousels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageAlt = "First slide",
                            ImageSrc = "/img/carousel/carousel_01.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ImageAlt = "Second slide",
                            ImageSrc = "/img/carousel/carousel_02.jpg"
                        },
                        new
                        {
                            Id = 3,
                            ImageAlt = "Third slide",
                            ImageSrc = "/img/carousel/carousel_03.jpg"
                        });
                });

            modelBuilder.Entity("djanak.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataTimeCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("djanak.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("djanak.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CasovaNarocnost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DatumVytvoreni")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Kategorie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NazevProductu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Obtiznost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PopisReceptu")
                        .HasColumnType("longtext");

                    b.Property<string>("PostupPripravy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SeznamSurovin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CasovaNarocnost = "30 minut",
                            DatumVytvoreni = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageAlt = "Obrazek1",
                            ImageSrc = "/img/products/recept_01.jpg",
                            Kategorie = "Oběd",
                            NazevProductu = "Pražská polévka",
                            Obtiznost = "Snadné",
                            PopisReceptu = "Recept je velmi chutný a jednoduchý na přípravu",
                            PostupPripravy = "Nakrájenou cibuli necháme 12 minut odležet. Poté ji na sádle zpěníme, přidáme nakrájenou klobásu a opečeme.Přidáme mrkev, orestujeme a poté zasypeme červenou paprikou. Vše zalijeme vývarem, přidáme oloupané, nakrájené brambory, osolíme a polévku vaříme 15 minut.",
                            SeznamSurovin = "1ks cibule, 1ks mrkev, 2ks brambory, 1ks klobása, 1l vývar, sůl, 2 lžičky sladké papriky, 1 lžíce sádla"
                        },
                        new
                        {
                            Id = 2,
                            CasovaNarocnost = "40 minut",
                            DatumVytvoreni = new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageAlt = "Obrazek2",
                            ImageSrc = "/img/products/recept_02.jpg",
                            Kategorie = "Přílohy",
                            NazevProductu = "Vařené brambory",
                            Obtiznost = "Snadné",
                            PopisReceptu = "Brambory se hodí ke všemu",
                            PostupPripravy = "Brambory oloupeme a dáme do hrnce s vodou.Nakrájíme je na kostky, propláchneme a zalijeme čerstvou vodou. Osolíme, přidáme kmín a dáme vařit.Vaříme 15 minut do změknutí. Zda jsou brambory hotové, poznáme tak, že se po píchnutí vidličkou rozpadnou.",
                            SeznamSurovin = "6ks brambory, 1 špetka soli, 1 špetka kmínu"
                        },
                        new
                        {
                            Id = 3,
                            CasovaNarocnost = "20 minut",
                            DatumVytvoreni = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageAlt = "Obrazek3",
                            ImageSrc = "/img/products/recept_03.jpg",
                            Kategorie = "Oběd",
                            NazevProductu = "Tuňákové těstoviny",
                            Obtiznost = "Snadné",
                            PopisReceptu = "Tuňák je zdravý pro kosti (určitě jo)",
                            PostupPripravy = "Těstoviny uvaříme dle návodu.Na troše olivového oleje necháme zesklovatět nadrobno nakrájenou cibuli. Přidáme na plátky nakrájený česnek, chvilku míchejte.Přidejte rajčata a nakrájené lístky bazalky. Chvíli povařte. Nakonec vmíchejte rozdrobené maso tuňáka,které se snažíme vložit do jídla s minimálním množstvím oleje z konzervy, dochuťte solí/pepřem a nechte maso ve směsi prohřát.Do hotové směsi vmíchejte těstoviny a můžete servírovat. V případě zájmu je možné těstoviny posypat strouhaným parmazánem, není to však třeba.",
                            SeznamSurovin = "1ks cibule, olivový olej, 3 stoužky česneku, 1 plechovka loupaných rajčat, pepř, sůl, 180g tuňáka v plechu, strouhaný parmazám,200g těstovin"
                        },
                        new
                        {
                            Id = 4,
                            CasovaNarocnost = "40 minut",
                            DatumVytvoreni = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageAlt = "Obrazek4",
                            ImageSrc = "/img/products/recept_04.jpg",
                            Kategorie = "Oběd",
                            NazevProductu = "Kuřecí prsa s broskvemi a švestkami",
                            Obtiznost = "Střední",
                            PopisReceptu = "Mňam mňam broskvička s masíkem",
                            PostupPripravy = "Prvně nasekat, pak povařit, pak promíchat. Tenhle recept je hrozně dlouhej, tak jsem ho sem nevkládal celej.",
                            SeznamSurovin = "4ks kuřecí prsa, 2 lžíce povidla, 8 plátků šunky, 8ks šarlotky, 8ks švestek, 2ks broskve, olivový olej, sůl, pepř"
                        });
                });

            modelBuilder.Entity("djanak.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("djanak.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("djanak.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("djanak.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
