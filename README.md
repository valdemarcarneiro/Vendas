Execute o projeto em Debug em http://localhost:5100/swagger

O projeto usa Swagger, nesta URL acima você poderá realizar os testes de registro de vendas, buscar vendas e atualizar o status da venda.
  
No banco de dados incluso, já temos produtos, vendedores e status já cadastrados. 

 Produtos
         PK     Nome        Valor
         1	    Notebook	554000
         2	    Mouse	    38000
         3	    Teclado	    100
         4	    Fone	    200
         5	    Carregador	100

Vendedor
         PK Celular     Nome            Email                   Celular
         1	99911122280	Valdemar Felipe	contato@valdemar.com.br	31993851044

Status
            PK  Descrição
            1	Aguardando pagamento
            2	Pagamento Aprovado
            3	Cancelada
            4	Enviado para Transportadora
            5	Entregue         
