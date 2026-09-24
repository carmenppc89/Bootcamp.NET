using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;
using WebApp_MVC_Animales.DAL;
using WebApp_MVC_Animales.Models;
using WebApp_MVC_Animales.Models.ViewModels;

namespace WebApp_MVC_Animales.Controllers
{
    public class AnimalController : Controller
    {
        AnimalDAL _dalAnimal = new AnimalDAL();
        TipoAnimalDAL _dalTipoAnimal = new TipoAnimalDAL();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details()
        {
            if (TempData["Animal"] != null)
            {
                var json = TempData["Animal"] as string;
                var vm = JsonConvert.DeserializeObject<DetailAnimalViewModel>(json);

                return View(vm);
            }
            else
            {
                ViewBag.NoAnimal = "No se ha conseguido encontrar ningún animal";
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, string NombreAnimal, string Raza, int idTipoAnimal, DateOnly FechaNacimiento)
        {
            Animal animalToUpdate = new Animal();

            animalToUpdate.IdAnimal = id;
            animalToUpdate.NombreAnimal = NombreAnimal;
            animalToUpdate.Raza = Raza;
            animalToUpdate.RidTipoAnimal = idTipoAnimal;
            animalToUpdate.FechaNacimiento = FechaNacimiento;

            TempData["AnimalToUpdate"] = JsonConvert.SerializeObject(animalToUpdate);

            return RedirectToAction("AnimalUpdate", "Home", new { id });
        }

    }
}
