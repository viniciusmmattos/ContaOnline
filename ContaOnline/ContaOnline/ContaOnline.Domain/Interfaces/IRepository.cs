using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Incluir(T entidade);
        void Alterar(T entidade);
        void Excluir(string Id);
        T ObterPorId(string Id);
        IEnumerable<T> ObterTodos(string usuarioId);
        
        IEnumerable<string> Validar();
    }
}
