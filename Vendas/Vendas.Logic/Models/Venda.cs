using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vendas.Logic.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Key]
        public int id { get; set; }

        //public int idProduto { get; set; }

        public int idVendedor { get; set; }

        //public int Quantidade { get; set; }

        public DateTime DataDaVenda { get; set; }

        public int idStatus { get; set; }

    }
}
