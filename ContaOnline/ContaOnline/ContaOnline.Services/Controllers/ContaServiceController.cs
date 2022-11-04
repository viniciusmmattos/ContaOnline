using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContaOnline.Services.Controllers
{
    public class ContaServiceController : ApiController
    {

        public List<ContaListItem> Get()
        {
            var repositorio = new ContaRepository();
            ContaListViewModel viewModel = new ContaListViewModel();
            viewModel.Filtro.UsuarioId = "cc21864d-41b2-44a1-917d-5fff5807edb6";
            viewModel.Filtro.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            viewModel.Filtro.DataFinal = DateTime.Now;
            viewModel.ContaList = repositorio.ObterPorFiltro(viewModel.Filtro).ToList();
            return viewModel.ContaList;
        }



        public List<ContaListItem> ObterExemplo()
        {
            var lista = new List<ContaListItem>();
            lista.Add(new ContaListItem()
            {
                Categoria = "Despesa",
                Contato = "Empresa ABC",
                Data = DateTime.Now,
                Descricao = "Despesas Gerais",
                Tipo = PagarReceber.Pagar,
                Valor = 100
            });
            lista.Add(new ContaListItem()
            {
                Categoria = "Receitas Gerais",
                Contato = "Empresa Cliente Etc",
                Data = DateTime.Now,
                Descricao = "Recebimentos de Vendas",
                Tipo = PagarReceber.Receber,
                Valor = 1000
            });
            return lista;
        }





    }
}