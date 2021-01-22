using System;
using System.Collections.Generic;
using System.Text;
using Vendas.Logic.Models;

namespace Vendas.Data
{
   public interface IVendasRepository
    {
        void Registrar(VendaRequest TransacaoToSubmit);

        ObterVendasResponse ObterVendas(int aIdVenda);

        bool AtualizaStatus(int aidVenda, int aStatus);

    }
}
