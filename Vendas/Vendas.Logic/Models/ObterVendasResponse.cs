using System;
using System.Collections.Generic;
using System.Text;

namespace Vendas.Logic.Models
{
  

    public class ObterVendasResponse
    {

        public int IDVenda { get; set; }

        public int IdStatus { get; set; }

        public string Status { get; set; }

        public int IDVendedor { get; set; }
        public string Vendedor { get; set; }

        public string VendedorCPF { get; set; }
        public string VendedorEmail { get; set; }

        public string VendedorTelefone { get; set; }

        public List<Itens> Itens { get; set; }


    }

    public class Itens
    {
        public int idProduto { get; set; }

        public string Produto { get; set; }

        public int qtd { get; set; }

        public double ValorUnitario { get; set; }

        public double TotalProduto { get; set; }

    }
}
