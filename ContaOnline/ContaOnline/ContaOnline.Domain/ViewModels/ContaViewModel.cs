using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.Models
{
    public class ContaViewModel
    {
        public ContaViewModel()
        {
            this.ContaCorrenteList = new List<ContaCorrente>();
            this.ContaCategoriaList = new List<ContaCategoria>();
            this.ContatoList = new List<Contato>();
            this.ContaInstancia = new Conta();
            
            this.ContaInstancia.Tipo = PagarReceber.Pagar;
        }

        public Conta ContaInstancia { get; set; }
        public List<ContaCorrente> ContaCorrenteList { get; set; }
        public List<ContaCategoria> ContaCategoriaList { get; set; }
        public List<Contato> ContatoList { get; set; }
    }
}
