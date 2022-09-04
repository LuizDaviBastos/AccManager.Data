
namespace AccManagerData.Models.ModelSettings
{
    public class ConfiguracaoSmtp : IConfiguracaoSmtp
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string MensagemPosEnvio { get; set; }

    }

    public interface IConfiguracaoSmtp
    {
        string SmtpServer { get; set; }
        int SmtpPort { get; set; }
        string Email { get; set; }
        string Senha { get; set; }

        string MensagemPosEnvio { get; set; }
    }
}
