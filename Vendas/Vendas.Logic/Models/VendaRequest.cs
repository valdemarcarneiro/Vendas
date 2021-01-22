using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Vendas.Logic.Models
{
    public class VendaRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informações do Vendedor")]
        [DataMember]
        public Vendedor Vendedor  { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Informações do Vendedor")]
        [DataMember]
        public List<ItensVendidos> ItensVendidos { get; set; }



    }
}
