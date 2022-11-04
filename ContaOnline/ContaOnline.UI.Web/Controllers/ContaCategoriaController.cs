using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaCategoriaController : Controller
    {
        private IContaCategoriaRepository repositorio;
        private Usuario usuario;

        public ContaCategoriaController()
        {
            repositorio = AppHelper.ObterContaCategoriaRepository();
            usuario = AppHelper.ObterUsuarioLogado();
        }

        public ActionResult Inicio()
        {
            if (usuario == null)
            {
                return RedirectToAction("Login", "App");
            }
            var lista = repositorio.ObterTodos(usuario.Id);
            return View(lista);
        }

        public ActionResult Incluir()
        {
            var contaCategoria = new ContaCategoria();
            return View(contaCategoria);
        }

        [HttpPost]
        public ActionResult Incluir(ContaCategoria contaCategoria)
        {
            if (string.IsNullOrEmpty(contaCategoria.Nome))
            {
                ModelState.AddModelError("Nome", "O nome deve ser informado");
            }
            if (ModelState.IsValid)
            {
                contaCategoria.Id = Guid.NewGuid().ToString();
                contaCategoria.UsuarioId = usuario.Id;
                repositorio.Incluir(contaCategoria);
                return RedirectToAction("Inicio");
            }
            return View(contaCategoria);
        }
        public ActionResult Alterar(string Id)
        {
            var contaCategoria = repositorio.ObterPorId(Id);
            return View(contaCategoria);
        }

        [HttpPost]
        public ActionResult Alterar(ContaCategoria contaCategoria)
        {
            if (string.IsNullOrEmpty(contaCategoria.Nome))
            {
                ModelState.AddModelError("Nome", "O nome deve ser informado");
            }
            if (ModelState.IsValid)
            {
                repositorio.Alterar(contaCategoria);
                return RedirectToAction("Inicio");
            }

            return View(contaCategoria);
        }

        public ActionResult Excluir(string Id)
        {
            var contaCategoria = repositorio.ObterPorId(Id);
            return View(contaCategoria);
        }

        [HttpPost]
        public ActionResult Excluir(string Id, FormCollection form)
        {
            repositorio.Excluir(Id);
            return RedirectToAction("Inicio");
        }
    }
}