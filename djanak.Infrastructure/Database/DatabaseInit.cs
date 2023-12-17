using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using djanak.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using djanak.Infrastructure.Identity;
using System.Data;

// ZDE SE PŘÍMO INICIALIZUJE DATABÁZE
// DO ILIST<PRODUCT> SE PŘIDÁVAJÍ DATA
namespace djanak.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public IList<Recept> GetProducts()
        {
            IList<Recept> products = new List<Recept>();


            products.Add(
                new Recept()
                {
                    Id = 1,
                    NazevProductu = "Pražská polévka",
                    Kategorie = "Oběd",
                    Obtiznost = "Snadné",
                    CasovaNarocnost = "30 minut",
                    PopisReceptu = "Recept je velmi chutný a jednoduchý na přípravu",
                    SeznamSurovin = "1ks cibule, 1ks mrkev, 2ks brambory, 1ks klobása, 1l vývar, sůl, 2 lžičky sladké papriky, 1 lžíce sádla",
                    PostupPripravy = "Nakrájenou cibuli necháme 12 minut odležet. Poté ji na sádle zpěníme, přidáme nakrájenou klobásu a opečeme." +
                    "Přidáme mrkev, orestujeme a poté zasypeme červenou paprikou. Vše zalijeme vývarem, přidáme oloupané, nakrájené brambory, osolíme a polévku vaříme 15 minut.",
                    DatumVytvoreni = new DateTime(2023, 10, 31),
                    ImageSrc = "/img/products/recept_01.jpg",
                    ImageAlt = "Obrazek1"
                });
            
            products.Add(
                new Recept()
                {
                    Id = 2,
                    NazevProductu = "Vařené brambory",
                    Kategorie = "Přílohy",
                    Obtiznost = "Snadné",
                    CasovaNarocnost = "40 minut",
                    PopisReceptu = "Brambory se hodí ke všemu",
                    SeznamSurovin = "6ks brambory, 1 špetka soli, 1 špetka kmínu",
                    PostupPripravy = "Brambory oloupeme a dáme do hrnce s vodou." +
                    "Nakrájíme je na kostky, propláchneme a zalijeme čerstvou vodou. Osolíme, přidáme kmín a dáme vařit." +
                    "Vaříme 15 minut do změknutí. Zda jsou brambory hotové, poznáme tak, že se po píchnutí vidličkou rozpadnou.",
                    DatumVytvoreni = new DateTime(2020, 10, 31),
                    ImageSrc = "/img/products/recept_02.jpg",
                    ImageAlt = "Obrazek2"
                });

            products.Add(
                new Recept()
                {
                    Id = 3,
                    NazevProductu = "Tuňákové těstoviny",
                    Kategorie = "Oběd",
                    Obtiznost = "Snadné",
                    CasovaNarocnost = "20 minut",
                    PopisReceptu = "Tuňák je zdravý pro kosti (určitě jo)",
                    SeznamSurovin = "1ks cibule, olivový olej, 3 stoužky česneku, 1 plechovka loupaných rajčat, pepř, sůl, 180g tuňáka v plechu, strouhaný parmazám," +
                    "200g těstovin",
                    PostupPripravy = "Těstoviny uvaříme dle návodu." +
                    "Na troše olivového oleje necháme zesklovatět nadrobno nakrájenou cibuli. Přidáme na plátky nakrájený česnek, chvilku míchejte." +
                    "Přidejte rajčata a nakrájené lístky bazalky. Chvíli povařte. Nakonec vmíchejte rozdrobené maso tuňáka," +
                    "které se snažíme vložit do jídla s minimálním množstvím oleje z konzervy, dochuťte solí/pepřem a nechte maso ve směsi prohřát." +
                    "Do hotové směsi vmíchejte těstoviny a můžete servírovat. V případě zájmu je možné těstoviny posypat strouhaným parmazánem, není to však třeba.",
                    DatumVytvoreni = new DateTime(2023, 1, 1),
                    ImageSrc = "/img/products/recept_03.jpg",
                    ImageAlt = "Obrazek3"
                });

            products.Add(
                new Recept()
                {
                    Id = 4,
                    NazevProductu = "Kuřecí prsa s broskvemi a švestkami",
                    Kategorie = "Oběd",
                    Obtiznost = "Střední",
                    CasovaNarocnost = "40 minut",
                    PopisReceptu = "Mňam mňam broskvička s masíkem",
                    SeznamSurovin = "4ks kuřecí prsa, 2 lžíce povidla, 8 plátků šunky, 8ks šarlotky, 8ks švestek, 2ks broskve, olivový olej, sůl, pepř",
                    PostupPripravy = "Prvně nasekat, pak povařit, pak promíchat. Tenhle recept je hrozně dlouhej, tak jsem ho sem nevkládal celej.",
                    DatumVytvoreni = new DateTime(2023, 10, 31),
                    ImageSrc = "/img/products/recept_04.jpg",
                    ImageAlt = "Obrazek4"
                });
            
            return products;
        }

        public IList<Carousel> GetCarousels()
        {
            IList<Carousel> carousels = new List<Carousel>();

            carousels.Add(new Carousel()
            {
                Id = 1,
                ImageSrc = "/img/carousel/carousel_01.jpg",
                ImageAlt = "First slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 2,
                ImageSrc = "/img/carousel/carousel_02.jpg",
                ImageAlt = "Second slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 3,
                ImageSrc = "/img/carousel/carousel_03.jpg",
                ImageAlt = "Third slide"
            });

            return carousels;
        }



        //for Identity tables

        public List<Role> CreateRoles()
        {
            List<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleManager = new Role()
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role roleCustomer = new Role()
            {
                Id = 3,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };


            roles.Add(roleAdmin);
            roles.Add(roleManager);
            roles.Add(roleCustomer);

            return roles;
        }


        public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Adminek",
                LastName = "Adminovy",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

            return (admin, adminUserRoles);
        }


        public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
        {
            User manager = new User()
            {
                Id = 2,
                FirstName = "Managerek",
                LastName = "Managerovy",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.cz",
                NormalizedEmail = "MANAGER@MANAGER.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

            return (manager, managerUserRoles);
        }
    }
}
