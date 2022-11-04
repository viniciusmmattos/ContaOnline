using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaController : Controller
    {
        private IContaRepository repositorio;
        private Usuario usuario;

        public ContaController()
        {
            repositorio = AppHelper.ObterContaRepository();
            usuario = AppHelper.ObterUsuarioLogado();
        }


        public ActionResult Excluir(string id)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var conta = repositorio.ObterExibirPorId(id);
            return View(conta);
        }

        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            repositorio.Excluir(id);
            return RedirectToAction("Inicio");
        }

        public ActionResult Alterar(string id)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();
            viewModel.ContaInstancia = repositorio.ObterPorId(id);
            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Alterar(ContaViewModel viewModel)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            try
            {
                viewModel.ContaInstancia.UsuarioId = usuario.Id;
                repositorio.Alterar(viewModel.ContaInstancia);
                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        public ActionResult Incluir()
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();
            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Incluir(ContaViewModel viewModel)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            try
            {
                viewModel.ContaInstancia.UsuarioId = usuario.Id;
                viewModel.ContaInstancia.Id = Guid.NewGuid().ToString();
                repositorio.Incluir(viewModel.ContaInstancia);
                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        private void PreencherViewModel(ContaViewModel viewModel)
        {
            var contaCorrenteRep = AppHelper.ObterContaCorrenteRepository();
            viewModel.ContaCorrenteList = contaCorrenteRep.ObterTodos(usuario.Id).ToList();

            var contaCategoriaRep = AppHelper.ObterContaCategoriaRepository();
            viewModel.ContaCategoriaList = contaCategoriaRep.ObterTodos(usuario.Id).ToList();

            var contatoRep = AppHelper.ObterContatoRepository();
            viewModel.ContatoList = contatoRep.ObterTodos(usuario.Id).ToList();

        }

        [HttpPost]
        public ActionResult Inicio(ContaListViewModel viewModel)
        {
            if (usuario == null) return RedirectToAction("Login", "App");

            viewModel.Filtro.UsuarioId = usuario.Id;
            viewModel.ContaList = repositorio.ObterPorFiltro(viewModel.Filtro).ToList();
            PreencherContaListViewModel(viewModel);
            return View(viewModel);

        }

        public ActionResult Inicio()
        {
            if (usuario == null) return RedirectToAction("Login", "App");

            var viewModel = new ContaListViewModel();
            viewModel.Filtro.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            viewModel.Filtro.DataFinal = DateTime.Now;
            viewModel.Filtro.UsuarioId = usuario.Id;
            viewModel.ContaList = repositorio.ObterPorFiltro(viewModel.Filtro).ToList();

            PreencherContaListViewModel(viewModel);

            return View(viewModel);

        }

        private void PreencherContaListViewModel(ContaListViewModel viewModel)
        {
            var catRep = AppHelper.ObterContaCategoriaRepository();
            viewModel.CategoriaList = catRep.ObterTodos(usuario.Id).ToList();

            var contaCorrenteRep = AppHelper.ObterContaCorrenteRepository();
            viewModel.ContaCorrenteList = contaCorrenteRep.ObterTodos(usuario.Id).ToList();

            viewModel.CategoriaList.Insert(0, new ContaCategoria() { Id = string.Empty, Nome = string.Empty });
            viewModel.ContaCorrenteList.Insert(0, new ContaCorrente() { Id = string.Empty, Descricao = string.Empty });
        }
    }
}