using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Moq;

using djanak.Application.Abstraction;
using djanak.Infrastructure.Database;
using djanak.Domain.Entities;
using djanak.Application.Implementation;

namespace djanak.Tests.ApplicationLayer
{
    public class ReceptServiceCreateTests
    {
        [Fact]
        public async Task Create_Success()  //Testuje Create metodu v ReceptAdminService
            //Testuje chování služby, která provádí operaci vytváření receptu a manipuluje s databází
        {
            // Arrange

            //nastaveni falesne sluzby pro produkty
            var pathToImage = "img/product/UploadImageFile.png";
            var fileUpload = new Mock<IFileUploadService>();
            fileUpload.Setup(fu => fu.FileUploadAsync(It.IsAny<IFormFile>(), It.IsAny<string>())).Returns(() => Task.Run<string>(() => pathToImage));


            //nastaveni falesne IFormFile
            Mock<IFormFile> iffMock = new Mock<IFormFile>();
            iffMock.Setup(iff => iff.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                                    .Callback<Stream, CancellationToken>((stream, token) =>
                                    {
                                        return;
                                    })
                                    .Returns(Task.CompletedTask);



            //Nainstalovan Nuget package: Microsoft.EntityFrameworkCore.InMemory
            //databazi vytvori v pameti
            DbContextOptions options = new DbContextOptionsBuilder<PortalDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new PortalDbContext(options);
            databaseContext.Database.EnsureCreated();
            //smazani inicializacnich dat, pokud existuji
            databaseContext.Recepts.RemoveRange(databaseContext.Recepts);
            databaseContext.SaveChanges();



            ReceptAdminService service = new ReceptAdminService(fileUpload.Object, databaseContext);


            Recept testProduct = GetTestProduct(iffMock.Object);


            //Act
            await service.Create(testProduct);



            // Assert
            Assert.Single(databaseContext.Recepts);

            Recept addedProduct = databaseContext.Recepts.First();
            Assert.Equal(testProduct.Id, addedProduct.Id);
            Assert.NotNull(addedProduct.NazevReceptu);
            Assert.Matches(testProduct.NazevReceptu, addedProduct.NazevReceptu);
            Assert.Equal(testProduct.PopisReceptu, addedProduct.PopisReceptu);
            Assert.NotNull(addedProduct.ImageSrc);
            Assert.Matches(pathToImage, addedProduct.ImageSrc);

        }



        Recept GetTestProduct(IFormFile iff)
        {
            return new Recept()
            {
                Id = 1,
                NazevReceptu = "Vepřový guláš",
                PopisReceptu = "Velmi chutný veprový guláš",
                Kategorie = "Oběd",
                PostupPripravy = "Promíchat a uvařit",
                ImageSrc = String.Empty,
                Image = iff
            };
        }

    }
}
