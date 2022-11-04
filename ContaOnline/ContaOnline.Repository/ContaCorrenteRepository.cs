using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        public void Alterar(ContaCorrente contaCorrente)
        {
            Db.Execute("ContaCorrenteAlterar", contaCorrente);
        }

        public void Excluir(string Id)
        {
            Db.Execute("ContaCorrenteExcluir", new { Id=Id});
        }

        public void Incluir(ContaCorrente contaCorrente)
        {
            Db.Execute("ContaCorrenteIncluir", contaCorrente);
        }

        public ContaCorrente ObterPorId(string Id)
        {
            return Db.QueryEntidade<ContaCorrente> ("ContaCorrenteObterPorId", new {Id=Id});
        }

        public IEnumerable<ContaCorrente> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<ContaCorrente>("ContaCorrenteObterTodos", new {UsuarioId=usuarioId});
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
