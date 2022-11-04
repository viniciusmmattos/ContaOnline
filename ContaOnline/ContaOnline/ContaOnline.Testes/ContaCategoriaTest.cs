using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.Interfaces;
using ContaOnline.Repository;

namespace ContaOnline.Testes
{
    [TestClass]
    public class ContaCategoriaTeste
    {
        [TestMethod]
        public void IncluirTeste()
        {
            ContaCategoriaRepository repositorio = new ContaCategoriaRepository();
            var conta = new ContaCategoria()
            {
                Id = "10",
                Nome = "TesteCat",
                UsuarioId = "10"
            };
            repositorio.Incluir(conta);
        }

        [TestMethod]
        public void AlterarTeste()
        {
            ContaCategoriaRepository repositorio = new ContaCategoriaRepository();
            var conta = new ContaCategoria()
            {
                Id = "10",
                Nome = "TesteCatAlterado",
                UsuarioId = "10"
            };
            repositorio.Alterar(conta);
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            ContaCategoriaRepository repositorio = new ContaCategoriaRepository();          
            repositorio.Excluir("10");
        }

        [TestMethod]
        public void ObterTodosTeste()
        {
            ContaCategoriaRepository repositorio = new ContaCategoriaRepository();
            var lista = repositorio.ObterTodos("10");
            foreach(var conta in lista)
            {
                Exibir(conta);
            }
        }

        private void Exibir(ContaCategoria conta)
        {
            Console.WriteLine(conta.Id);
            Console.WriteLine(conta.Nome);
            Console.WriteLine(conta.UsuarioId);
            Console.WriteLine();
        }

        [TestMethod]
        public void ObterPorIdTeste()
        {
            ContaCategoriaRepository repositorio = new ContaCategoriaRepository();
            var conta = repositorio.ObterPorId("1");
            if (conta != null)
            {
                Exibir(conta);
            }
        }
    }
}
