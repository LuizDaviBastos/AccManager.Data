
namespace AccManager.Data.Models.ModelSettings
{
    public class EnvioDeContasMongoSettings : IEnvioDeContasMongoSettings
    {
        public string DataBaseName { get; set; }
        public string ConnectionString { get; set; }
        public string SizPag { get; set; }
    }

    public interface IEnvioDeContasMongoSettings
    {
        public string DataBaseName { get; set; }
        public string ConnectionString { get; set; }
        public string SizPag { get; set; }
    }
}
