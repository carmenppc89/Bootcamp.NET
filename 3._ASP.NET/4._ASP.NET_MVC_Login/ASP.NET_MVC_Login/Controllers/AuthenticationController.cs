using ASP.NET_MVC_Login.DAL;
using ASP.NET_MVC_Login.Models;
using ASP.NET_MVC_Login.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC_Login.Controllers
{
    public class AuthenticationController : Controller
    {
        private DALUsuario _dalUsuario = new DALUsuario();

        //public IActionResult Index() { return View(); }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel vm)
        {

            if (ModelState.IsValid)
            {
                _dalUsuario = new DALUsuario();
                Usuario userLogged = _dalUsuario.GetUsuarioByLogin(vm.Username, vm.Password);

                if (userLogged != null)
                {
                    HttpContext.Session.SetString("Username", vm.Username);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _dalUsuario = new DALUsuario();
                Usuario userSigning = new Usuario();

                userSigning.UserName = vm.Username;
                string pwd = vm.Password;

                Usuario usuarioExistente = _dalUsuario.GetUsuarioByLogin(userSigning.UserName, pwd);

                if (usuarioExistente != null)
                {
                    ModelState.AddModelError("", "Este usuario ya existe.");
                    return View(vm);
                }

                _dalUsuario.CreateUsuario(userSigning, pwd);

                Usuario validarCreacion = _dalUsuario.GetUsuarioByLogin(vm.Username, pwd);
                if (validarCreacion != null)
                {
                    HttpContext.Session.SetString("Username", userSigning.UserName);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "No se ha podido crear el usuario.");

            }

            return View(vm);

        }

    }

}
