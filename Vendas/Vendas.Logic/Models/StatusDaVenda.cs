using System;
using System.Collections.Generic;
using System.Text;

namespace Vendas.Logic.Models
{
   public class StatusDaVenda
    {
      public  enum Status
        {
            AguardandoPagamento = 1,
            PagamentoAprovado = 2,
            EnviadoTransportadora = 3,
            Entregue = 4,
            Cancelada = 5
        }
    }
}
