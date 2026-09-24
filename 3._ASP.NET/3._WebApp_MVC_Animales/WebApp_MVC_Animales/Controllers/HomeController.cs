using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp_MVC_Animales.DAL;
using WebApp_MVC_Animales.Models;
using WebApp_MVC_Animales.Models.ViewModels;

namespace WebApp_MVC_Animales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AnimalDAL _dalAnimal;
        private TipoAnimalDAL _dalTipoAnimal;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _dalAnimal = new AnimalDAL();
            _dalTipoAnimal = new TipoAnimalDAL();
        }

        public IActionResult Index()
        {
            AnimalViewModel avm = new AnimalViewModel();
            avm.Animales = _dalAnimal.GetAll();
            avm.TipoAnimales = _dalTipoAnimal.GetAll();

            return View(avm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AnimalDetail(int id)
        {
            //return RedirectToAction("Details", "Animal", new { id });

            _dalAnimal = new AnimalDAL();
            _dalTipoAnimal = new TipoAnimalDAL();

            DetailAnimalViewModel vm = new DetailAnimalViewModel();

            vm.AnimalDetail = _dalAnimal.GetById(id);
            vm.TipoAnimales = _dalTipoAnimal.GetAll();

            TempData["Animal"] = JsonConvert.SerializeObject(vm);

            return RedirectToAction("Details", "Animal");
        }

        [HttpGet]
        public ActionResult AnimalUpdate(int id)
        {
            if (TempData["AnimalToUpdate"] != null)
            {
                var json = TempData["AnimalToUpdate"] as string;
                var animalToUpdate = JsonConvert.DeserializeObject<Animal>(json);

                Animal animalUpdated = _dalAnimal.UpdateByAnimal(animalToUpdate);

                //if (animalUpdated != null)
                //    ViewBag.AnimalUpdated = animalUpdated.IdAnimal;
            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
