using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;
using Vendas.Logic.Models;

namespace Vendas.Data
{
    public class VendasRepository : IVendasRepository
    {
        private readonly IDbConnection _db;
 
        public VendasRepository(IDbConnection db)
        {
            _db = db;
        }

        public void Registrar(VendaRequest aVendas)
        {

            var lItensVendidos = aVendas.ItensVendidos;

            Venda lVenda = new Venda()
            {
                DataDaVenda = System.DateTime.Now,
                idVendedor = aVendas.Vendedor.id,
                idStatus = 1,                

            };


          var lID =  _db.Insert(lVenda);

            foreach (var item in lItensVendidos)
            {
                item.idVenda = Convert.ToInt32(lID);
            }

            ItensVendidos(lItensVendidos);
        }

        public void ItensVendidos(IList<ItensVendidos> aitens)
        {
            var lID = _db.Insert(aitens);
        }


        public Venda Obter(int idVenda)
        {
            Venda ltransacao;

            ltransacao = _db.Query<Venda>("select * from Venda where TransacaoId = @Id", new { Id = idVenda }).Single();

            return ltransacao;
        }

        public ObterVendasResponse ObterVendas(int aIdVenda)
        {
            var lconsulta = " select " +
            " a.Id as IDVenda, " +
            " a.DataDaVenda, " +
            " a.IdStatus as IdStatus, " +
            " e.Nome as Status, " +
            " d.Id as IDVendedor, " +
            " d.Nome as Vendedor, " +
            " d.CPF as VendedorCPF, " +
            " d.Email as VendedorEmail, " +
            " d.Telefone as VendedorTelefone " +
            " from " +
            " Venda a " +
            " inner " +
            " join Vendedor d on a.idVendedor = d.Id " +
            " inner join Status e on e.Id = a.IdStatus " +
            " where a.Id = @IdVenda";

            ObterVendasResponse lProtocolos = _db.QuerySingle<ObterVendasResponse>(lconsulta, new { IdVenda = aIdVenda });
            lProtocolos.Itens = ItensdaVenda(aIdVenda);
            return lProtocolos;

        }

        private List<Itens> ItensdaVenda(int aIdVenda)
        {
            var lconsulta = " select  " +
            " c.Id as IDProduto, " +
            " c.Nome as Produto, " +
            " b.qtd, " +
            " b.ValorUnitario, " +
            " b.qtd* b.ValorUnitario as TotalProduto " +
            " from " +
            " ItensVendidos b inner join Produto c on b.idProduto = c.Id " +
            " where b.idVenda = @IdVenda";

            var lItens = _db.Query<Itens>(lconsulta, new { IdVenda = aIdVenda }).AsList();         
            return lItens;
        }

        public int StatusdaVenda(int aIdVenda)
        {
            var lconsulta = " select idStatus " +          
            " from " +
            " Venda " +
            " where Id = @IdVenda";

          return _db.QuerySingle<int>(lconsulta, new { IdVenda = aIdVenda });
        }

        public bool AtualizaStatus(int aidVenda, int aStatus)
        {
            var lStatusAtual = StatusdaVenda(aidVenda);

            //De Aguardando Pagamento Para Pagamento Aprovado ou Cancelado
            if (lStatusAtual == 1 && (aStatus == 2 || aStatus == 3))
            {
                AtualizarStatus(aidVenda, aStatus);
                return true;
            }

            //De Pagamento Aprovado Para Cancelada ou Enviado para transportadora
            if (lStatusAtual == 2 && (aStatus == 3 || aStatus == 4))
            {
                AtualizarStatus(aidVenda, aStatus);
                return true;
            }

            //De Enviado para Transportadora para Entregue
            if (lStatusAtual == 4 && (aStatus == 5))
            {
                AtualizarStatus(aidVenda, aStatus);
                return true;
            }

            return false;


        }

        private void AtualizarStatus(int aidVenda, int aStatus)
        {
            var lupdate =
                "Update Venda " +
                " set " +
                " idStatus = @idStatus " +
                " where " +
                " Id = @idVenda ";

            _db.Execute(lupdate, new{idVenda = aidVenda, idStatus = aStatus });
        }


    }
}
