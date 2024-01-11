using Microsoft.AspNetCore.Mvc;
using djanak.Application.Abstraction;
using djanak.Domain.Entities;
using djanak.Infrastructure.Database;
using djanak.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using djanak.Application.ViewModels;


// TENHLE PRODUCTCONTROLLER BUDE ASI SLOUŽIT PRO AREU ADMIN PRO PRODUKTY
// ASI TO BUDE FUNGOVAT TAK ŽE KDYŽ SERVER GETNE OD UŽIVATELE ŽE UŽIVATEL KLIKL NA INDEX (COŽ JE VLASTNĚ DEFAULT PRODUCTS PAGE)
// NEBO KDYŽ KLIKNE NA DELETE NEBO CREATE NEBO EDIT TAK POTOM TO BUDE REFEROVAT NA PRODUCTADMINDFAKESERVICE.CS
// A V PRODUCTADMINDFAKESERVICE.CS JSOU DEFINOVANÉ PŘÍMO AKCE CO SE S TÍM MÁ DĚLAT
namespace janak.platformaprosdilenireceptu.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]  //tento řádek jsem zakomentoval. Blokoval mě od rozkliknutí Recepts
    public class ReceptController : Controller
    {
        IReceptAdminService _receptService;
        public ReceptController(IReceptAdminService receptService)
        {
            _receptService = receptService;
        }
        public IActionResult Index()
        {
            IList<Recept> recepts = _receptService.Select();
            return View(recepts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recept recept)
        {
            if (ModelState.IsValid)
            {
                recept.DatumVytvoreni = DateTime.Now; // Nastavení aktuálního času

                await _receptService.Create(recept);

                return RedirectToAction(nameof(ReceptController.Index));
            }
            else
            {
                return View(recept);
            }
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _receptService.Delete(Id);

            if (deleted)  //ZDE BY BYLO ASI JAKO NĚCO IF DELETED EXISTS TAK....
            {
                return RedirectToAction(nameof(ReceptController.Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Recept recept = _receptService.GetReceptById(id);

            if (recept == null) 
            {
                return NotFound();
            }

            ReceptViewModel receptViewModel = _receptService.MapReceptToViewModel(recept); // Převést entitu na ViewModel

            return View(receptViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReceptViewModel receptViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(receptViewModel); // Vrátit původní View s chybami, pokud není validní
            }


            await _receptService.Edit(receptViewModel);

            Recept receptToUpdate = _receptService.MapViewModelToRecept(receptViewModel); // Převést ViewModel na entitu

            return RedirectToAction(nameof(Index));
        }
    }
}
