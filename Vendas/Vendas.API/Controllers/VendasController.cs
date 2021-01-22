using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Vendas.Logic.Models;
using Microsoft.AspNetCore.Http;
using Vendas.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vendas.API.Controllers
{
    [Route("api/vendas")]
    [ApiController]
    public class VendasController : ControllerBase
    {

        /* Produtos
         PK     Nome        Valor
         1	    Notebook	554000
         2	    Mouse	    38000
         3	    Teclado	    100
         4	    Fone	    200
         5	    Carregador	100
        */

        /*
         Vendedor
         PK Celular     Nome            Email                   Celular
         1	99911122280	Valdemar Felipe	contato@valdemar.com.br	31993851044

         */

        /*
         Status
            PK  Descrição
            1	Aguardando pagamento
            2	Pagamento Aprovado
            3	Cancelada
            4	Enviado para Transportadora
            5	Entregue         
         */


        private readonly IVendasRepository _vendasRepository;

        public VendasController(IVendasRepository vendasRepository)
        {
            _vendasRepository = vendasRepository;          
        }


        [HttpPost]
        [Route("registrar/")]
        [Produces("application/json", Type = typeof(VendaResponse) )]
        public IActionResult registrarvenda([FromBody] VendaRequest lTipo)
        {
            var lStatus =  StatusDaVenda.Status.AguardandoPagamento;

            _vendasRepository.Registrar(lTipo);

            return StatusCode(200, lStatus);
        }

        [HttpGet]
        [Route("buscar/idvenda={idvenda}")]
        [Produces("application/json", Type = typeof(ObterVendasResponse))]
        public IActionResult buscarvenda(int idvenda)
        {

            var lretorno = _vendasRepository.ObterVendas(idvenda);
            return StatusCode(200, lretorno);
        }

        [HttpPut]
        [Route("atualizar/idvenda={idvenda}&idStatus={idStatus}")]
        [Produces("application/json", Type = typeof(VendaResponse))]
        public IActionResult atualizarvenda(int idvenda, int idStatus)
        {
           var lAtualiza = _vendasRepository.AtualizaStatus(idvenda, idStatus);

            if (lAtualiza)
            {
                return StatusCode(200, "Status Atualizado.");
            }
            else
            {
                return StatusCode(401, "Atualização não permitida.");
            }
        }

        /**/
    }
}
