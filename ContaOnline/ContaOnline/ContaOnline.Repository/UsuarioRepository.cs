using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.Interfaces;
using MySql.Data.MySqlClient;
using Dapper;

namespace ContaOnline.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Alterar(Usuario usuario)
        {
            Db.Execute("UsuarioAlterar", usuario);
        }

        public void Excluir(string Id)
        {
            Db.Execute("UsuarioExcluir", new { Id = Id });
        }

        public void Incluir(Usuario usuario)
        {
            Db.Execute("UsuarioIncluir", usuario);
        }

        public Usuario ObterPorEmailSenha(string Email, string Senha)
        {
            return Db.QueryEntidade<Usuario>("UsuarioObterPorEmailSenha", new { Email=Email, Senha=Senha});
        }

        public Usuario ObterPorId(string Id)
        {
            return Db.QueryEntidade<Usuario>("UsuarioObterPorId", new { Id = Id});
        }

        public IEnumerable<Usuario> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Usuario>("UsuarioObterTodos", null);
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
