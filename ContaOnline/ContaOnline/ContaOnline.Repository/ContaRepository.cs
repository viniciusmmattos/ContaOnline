using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;

namespace ContaOnline.Repository
{
    public class ContaRepository : IContaRepository
    {
        public void Alterar(Conta conta)
        {
            Db.Execute("ContaAlterar", conta);
        }

        public void Excluir(string Id)
        {
            Db.Execute("ContaExcluir", new { Id=Id});
        }

        public void Incluir(Conta conta)
        {
            Db.Execute("ContaIncluir", conta);
        }

        public ContaExibirViewModel ObterExibirPorId(string Id)
        {
            return Db.QueryEntidade<ContaExibirViewModel>("ContaObterExibirPorId", new { ContaId = Id });
        }

        public Conta ObterPorId(string Id)
        {
            return Db.QueryEntidade<Conta>("ContaObterPorId", new {Id=Id});
        }

        public IEnumerable<ContaListItem> ObterPorUsuario(string usuarioId)
        {
            return Db.QueryColecao<ContaListItem>("ContaObterTodos", new { UsuarioId = usuarioId });
        }

        public IEnumerable<Conta> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Conta>("ContaObterTodos", new { UsuarioId = usuarioId });
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContaListItem> ObterPorFiltro(ContaFiltro filtro)
        {
            //if (filtro.DataInicial == DateTime.MinValue) filtro.DataInicial = DateTime.MinValue;
            if (filtro.DataFinal==DateTime.MinValue) filtro.DataFinal = new DateTime(2090,12,31);

            var lista = Db.QueryColecao<ContaListItem>("ContaObterEntreDatas",
                new
                {
                    DataInicial = filtro.DataInicial,
                    DataFinal = filtro.DataFinal,
                    IdUsuario = filtro.UsuarioId
                }).ToList();

            var listaFiltrada = lista.ToList();
            if (filtro.ContaCorrenteId != null)
            {
                listaFiltrada = listaFiltrada.ToList().Where(m => m.ContaCorrenteId == filtro.ContaCorrenteId).ToList();
            }

            if (filtro.CategoriaId != null)
            {
                listaFiltrada = listaFiltrada.ToList().Where(m => m.CategoriaId == filtro.CategoriaId).ToList();
            }
            
            return listaFiltrada;
        }
    }
}
