using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using System.Collections.Generic;

namespace ContaOnline.Testes
{
    [TestClass]
    public class UsuarioTeste
    {
        [TestMethod]
        public void UsuarioValidarNomeTeste()
        {
            var usuario = new Usuario()
            {
                Email = "teste@usuario.com",
                Id = "1",
                Senha = "12345"
            };

            var erros = usuario.Validar();
            Assert.AreEqual(1, erros.Count, "Deveria retornar 1 erro");
        }
        [TestMethod]
        public void UsuarioValidarSenhaTeste()
        {
            var usuario = new Usuario()
            {
                Nome = "Maria",
                Email = "teste@usuario.com",
                Id = "1",
                Senha = "123"
            };

            var erros = usuario.Validar();
            Assert.AreEqual(1, erros.Count, "Deveria retornar 1 erro");
            Assert.AreEqual(erros[0], "A senha deve ter 5 caracteres no minimo", "Mensagem Errada");
        }
        [TestMethod]
        public void UsuarioObterTodosTeste()
        {
            var rep = new UsuarioRepository();
            var lista = rep.ObterTodos(null);
            foreach (var usuario in lista)
            {
                Console.WriteLine(usuario.Nome);
                Console.WriteLine(usuario.Email);
            }
        }

        [TestMethod]
        public void UsuarioIncluirTeste()
        {
            var usuario = new Usuario()
            {
                Id = "4",
                Nome = "Teste Rep 4",
                Email = "Teste123@gmail.com",
                Senha = "123456"
            };
            var repositorio = new UsuarioRepository();
            repositorio.Incluir(usuario);
        }

        [TestMethod]
        public void UsuarioObterPorIdTeste()
        {
            var repositorio = new UsuarioRepository();
            var usuario = repositorio.ObterPorId("3");

            if (usuario != null)
            {
                Console.WriteLine(usuario.Id);
                Console.WriteLine(usuario.Nome);
                Console.WriteLine(usuario.Email);
                Console.WriteLine(usuario.Senha);
            }
        }

        [TestMethod]
        public void UsuarioAlterarTeste()
        {
            var usuario = new Usuario()
            {
                Id = "3",
                Nome = "Teste Alterado Rep",
                Email = "Teste123Alterado@gmail.com",
                Senha = "1234567"
            };
            var repositorio = new UsuarioRepository();
            repositorio.Alterar(usuario);
        }

        [TestMethod]
        public void UsuarioExcluirTeste()
        {          
            var repositorio = new UsuarioRepository();
            repositorio.Excluir("3");
        }

        [TestMethod]
        public void UsuarioObterPorEmailSenhaTeste()
        {
            var repositorio = new UsuarioRepository();
            var usuario = repositorio.ObterPorEmailSenha("Teste123@gmail.com", "123456");

            if (usuario != null)
            {
                Console.WriteLine(usuario.Id);
                Console.WriteLine(usuario.Nome);
                Console.WriteLine(usuario.Email);
                Console.WriteLine(usuario.Senha);
            }
        }
    }
}
