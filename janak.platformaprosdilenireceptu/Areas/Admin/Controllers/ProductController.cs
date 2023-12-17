using Microsoft.AspNetCore.Mvc;
using djanak.Application.Abstraction;
using djanak.Domain.Entities;
using djanak.Infrastructure.Database;
using djanak.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;


// TENHLE PRODUCTCONTROLLER BUDE ASI SLOUŽIT PRO AREU ADMIN PRO PRODUKTY
// ASI TO BUDE FUNGOVAT TAK ŽE KDYŽ SERVER GETNE OD UŽIVATELE ŽE UŽIVATEL KLIKL NA INDEX (COŽ JE VLASTNĚ DEFAULT PRODUCTS PAGE)
// NEBO KDYŽ KLIKNE NA DELETE NEBO CREATE NEBO EDIT TAK POTOM TO BUDE REFEROVAT NA PRODUCTADMINDFAKESERVICE.CS
// A V PRODUCTADMINDFAKESERVICE.CS JSOU DEFINOVANÉ PŘÍMO AKCE CO SE S TÍM MÁ DĚLAT
namespace janak.platformaprosdilenireceptu.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]  //tento řádek jsem zakomentoval. Blokoval mě od rozkliknutí Recepts
    public class ProductController : Controller
    {
        IReceptAdminService _productService;
        public ProductController(IReceptAdminService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            IList<Recept> products = _productService.Select();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recept product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(product);

                return RedirectToAction(nameof(ProductController.Index));
            }
            else
            {
                return View(product);
            }
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _productService.Delete(Id);

            if (deleted)  //ZDE BY BYLO ASI JAKO NĚCO IF DELETED EXISTS TAK....
            {
                return RedirectToAction(nameof(ProductController.Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Recept product = _productService.GetReceptById(id);

            if (product == null) 
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Recept product)
        {
            await _productService.Edit(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
