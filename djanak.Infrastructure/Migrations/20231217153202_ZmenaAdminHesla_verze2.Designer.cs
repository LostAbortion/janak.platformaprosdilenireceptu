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
    [Migration("20231217153202_ZmenaAdminHesla_verze2")]
    partial class ZmenaAdminHesla_verze2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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

            modelBuilder.Entity("djanak.Domain.Entities.Recept", b =>
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

                    b.ToTable("Recepts");

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

            modelBuilder.Entity("djanak.Infrastructure.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("djanak.Infrastructure.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                            Email = "admin@admin.cz",
                            EmailConfirmed = true,
                            FirstName = "Adminek",
                            LastName = "Adminovy",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.CZ",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "$2y$10$qj0FbCiXAYtndzYHvzoree35uSXPsHkeK3H6v982yB4puS7FBtGsq",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                            Email = "manager@manager.cz",
                            EmailConfirmed = true,
                            FirstName = "Managerek",
                            LastName = "Managerovy",
                            LockoutEnabled = true,
                            NormalizedEmail = "MANAGER@MANAGER.CZ",
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                            TwoFactorEnabled = false,
                            UserName = "manager"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("djanak.Infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("djanak.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("djanak.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("djanak.Infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("djanak.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("djanak.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("djanak.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("djanak.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("djanak.Domain.Entities.Recept", "Product")
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
