using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Repository
{
    public class ContaCategoriaRepository : IContaCategoriaRepository
    {
        public void Alterar(ContaCategoria contaCategoria)
        {
            Db.Execute("ContaCategoriaAlterar", contaCategoria);
        }

        public void Excluir(string Id)
        {
            Db.Execute("ContaCategoriaExcluir", new { Id=Id });
        }

        public void Incluir(ContaCategoria contaCategoria)
        {
            Db.Execute("ContaCategoriaIncluir", contaCategoria);
        }

        public ContaCategoria ObterPorId(string Id)
        {
            return Db.QueryEntidade<ContaCategoria>("ContaCategoriaObterPorId", new {Id=Id });
        }

        public IEnumerable<ContaCategoria> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<ContaCategoria>("ContaCategoriaObterTodos", new { UsuarioId=usuarioId});
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
