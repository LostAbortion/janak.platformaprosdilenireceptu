using System;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Moq;
using djanak.Application.Abstraction;
using djanak.Domain.Entities;
using djanak.Infrastructure.Database;
using janak.platformaprosdilenireceptu.Areas.Admin.Controllers;

namespace janak.platformaprosdilenireceptu.Tests.Admin.ProductController
{
    public class ReceptControllerCreateTests
    {

        [Fact]
        public async Task Create_success()  //Testuje metodu Create v ReceptControlleru
            //Testuje chování kontroleru a jeho schopnost vytvořit nový recept
        {
            //Arrange -> Zde se připravují všechny potřebné podmínky pro provedení testu
            DatabaseFake.Recepts.Clear();   // Vyčištění falešné databáze (aby tam nemohli být kolidující hodnoty)
            Mock<IReceptAdminService> receptServiceMock = new Mock<IReceptAdminService>();
            receptServiceMock.Setup(receptService => receptService.Create(It.IsAny<Recept>()))
                                        .Returns<Recept>(recept => Task.Run(() => { DatabaseFake.Recepts.Add(recept); }));

            var recept = GetProduct();  // Vytváření instance receptu

            var receptController = new janak.platformaprosdilenireceptu.Areas.Admin.Controllers.ReceptController(receptServiceMock.Object);


            //Act -> Zde se provádí akce, kterou chceme otestovat
            var actionResult = await receptController.Create(recept);


            //Assert -> Zde se ověřuje zda akce vrátí požadovaný výsledek
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.NotNull(redirectToActionResult.ActionName);  //Zde očekávám že by měl být výsledek RedirectToAction(Index)
            Assert.Equal(nameof(janak.platformaprosdilenireceptu.Areas.Admin.Controllers.ReceptController.Index), redirectToActionResult.ActionName);  //Zde porovnávám zda to vrací i zde i v mém controlleru ten stejný Index

            Assert.NotEmpty(DatabaseFake.Recepts);  //Zde kontroluji zda se produkt přidat úspěšně do databáze
            Assert.Single(DatabaseFake.Recepts);
        }

        Recept GetProduct()  //Tato funkce mi tvoří instanci Receptu 
        {
            return new Recept()  //Zadávám naprosto defaultní hodnoty, ale pro test to stačí
            {
                Id = 1,
                NazevReceptu = "Vepřový guláš",
                Kategorie = "Oběd",
                PostupPripravy = "Promíchat a uvařit",
                ImageSrc = "/superimage.jpeg",
                Image = new Mock<IFormFile>().Object
            };
        }
    }
}

