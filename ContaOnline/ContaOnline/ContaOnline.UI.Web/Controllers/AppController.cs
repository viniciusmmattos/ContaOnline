using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ContaOnline.UI.Web.Controllers
{
    public class AppController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            IUsuarioRepository repositorio = AppHelper.ObterUsuarioRepository();
            Usuario usuario = repositorio.ObterPorEmailSenha(loginViewModel.Email, loginViewModel.Senha);
            if (usuario==null)
            {
                loginViewModel.Mensagem = "Usuario ou Senha Inexistente";
            }
            else
            {             
                AppHelper.RegistrarUsuario(usuario);
                return RedirectToAction("Inicio");
            }
            
            return View(loginViewModel);
        }

        public ActionResult LogOff()
        {
            AppHelper.LogOff();
            return View();
        }

        public ActionResult Registro()
        {
            var registro = new RegistroViewModel();
            
            return View(registro);
        }
        
        [HttpPost]
        public ActionResult Registro(RegistroViewModel registro)
        {
            if(string.IsNullOrEmpty(registro.Email))
            {
                ModelState.AddModelError("Email", "O Email deve ser informado!");
            }
            if (string.IsNullOrEmpty(registro.Senha))
            {
                ModelState.AddModelError("Senha", "A senha deve ser informada!");
            }
            else
            {
                if (registro.Senha != registro.ConfirmarSenha)
                {
                    ModelState.AddModelError("ConfirmarSenha", "As senhas devem ser iguais!");
                }
            }
            if(ModelState.IsValid)
            {
                //Criando usuario
                var usuario = new Usuario();
                usuario.Nome = registro.Nome;
                usuario.Email = registro.Email;
                usuario.Senha = registro.Senha;
                usuario.Id = Guid.NewGuid().ToString();

                //Gravando no banco
                var usuarioRepo = AppHelper.ObterUsuarioRepository();
                usuarioRepo.Incluir(usuario);

                //Registrando na sessão
                AppHelper.RegistrarUsuario(usuario);

                //Redirecionando
                return RedirectToAction("Inicio");
            }
            return View(registro);
        }

        //Tela Inicial
        // GET: App
        [Authorize]
        public ActionResult Inicio()
        {
            // var usuario = AppHelper.ObterUsuarioLogado();
            //if (usuario == null)
            //{
              //  return RedirectToAction("Login");
            //}

            return View();
        }     
        //Sobre
        public ActionResult Sobre()
        {
            return View();
        }

    }
}