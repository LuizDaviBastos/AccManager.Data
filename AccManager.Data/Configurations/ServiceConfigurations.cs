using AccManagerData.Models;
using AccManagerData.Models.ModelSettings;
using AccManagerData.MongoServicoGenerico;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace AccManagerData.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddAccManagerServices(this IServiceCollection services)
        {
            string json = "{\r\n                            \"ConfiguracaoSmtp\": {\r\n                            \"SmtpServer\": \"smtp-mail.outlook.com\",\r\n                            \"SmtpPort\": 587,\r\n                            \"Email\": \"davi-sdb@hotmail.com\",\r\n                            \"Senha\": \"80849903Dd\",\r\n                            \"MensagemPosEnvio\": \"nao definido\"\r\n                          },\r\n                          \"EnvioDeContasMongoSettings\": {\r\n                            \"DataBaseName\": \"BancoContas\",\r\n                            \"ConnectionString\": \"mongodb://luiz:80849903D@cluster0-shard-00-00-m1ukj.azure.mongodb.net:27017,cluster0-shard-00-01-m1ukj.azure.mongodb.net:27017,cluster0-shard-00-02-m1ukj.azure.mongodb.net:27017/test?ssl=true;replicaSet=Cluster0-shard-0;authSource=admin;retryWrites=true;w=majority\",\r\n                            \"SizPag\": \"10\"\r\n                          }\r\n                        }";
            JObject jObject = JObject.Parse(json);
            JToken value = jObject.GetValue("EnvioDeContasMongoSettings");
            JToken value2 = jObject.GetValue("ConfiguracaoSmtp");
            EnvioDeContasMongoSettings mongoValues = value.ToObject<EnvioDeContasMongoSettings>();
            services.AddSingleton((Func<IServiceProvider, IEnvioDeContasMongoSettings>)((IServiceProvider x) => mongoValues));
            services.AddScoped<IMongoService<HistoricoEnvio>, MongoService<HistoricoEnvio>>();
            services.AddScoped<IMongoService<Contas>, MongoService<Contas>>();
            services.AddScoped<IMongoService<Plataforma>, MongoService<Plataforma>>();
            services.AddScoped<IMongoService<Arquivo>, MongoService<Arquivo>>();
            services.AddScoped<IMongoService<Layout>, MongoService<Layout>>();
            services.AddScoped((IServiceProvider sp) => new MongoClient(mongoValues.ConnectionString));
            services.AddScoped<IMongoService<Contas>, MongoService<Contas>>();
            return services;
        }
    }
}
