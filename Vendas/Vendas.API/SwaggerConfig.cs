using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Vendas.API
{
    public class SwaggerConfig : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IConfiguration _config;

        public SwaggerConfig(IConfiguration config)
        {
            _config = config;
        }

        public void Configure(SwaggerGenOptions options)
        {

         //   var oauthScopeDic = new Dictionary<string, string> { { "api", "Valdemar Sistema de Vendas - BackEnd API" } };

            options.DescribeAllParametersInCamelCase();
            options.CustomSchemaIds(x => x.FullName);
            options.SwaggerDoc("v1", new OpenApiInfo {
                Title = "Valdemar - BackEnd API",
                Version = "v1",
                Description = " Existe o vendedor cadastrado com o ID = 1. " +
                              " Os Produtos com id de 1 a 5"

            });
           // options.EnableAnnotations();
        }
    }
}
