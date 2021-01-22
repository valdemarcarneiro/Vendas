using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;


namespace Vendas.Logic.Models
{
    [Table("ItensVendidos")]
    public class ItensVendidos
    {
        //[Key]
        //[DataMember]
        //public int Id { get; set; }
        
        [DataMember]
        public int idProduto { get; set; }
        
        [DataMember]
        public int qtd { get; set; }

        [DataMember]
        public float ValorUnitario { get; set; }

        [DataMember]
        public int idVenda { get; set; }
    }
}
