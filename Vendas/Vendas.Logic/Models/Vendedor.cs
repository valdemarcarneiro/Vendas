using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Vendas.Logic.Models
{
    public class Vendedor
    {
        [DataMember]
        public int id { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o CPF")]
        //[DataMember]
        //public string cpf { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Nome")]
        //[DataMember]
        //public string nome { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o E-mail")]
        //[DataMember]
        //public string email { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Telefone")]
        //[DataMember]
        //public string telefone { get; set; }

    }
}
