using AccManager.Data.Model.Validation;
using System.ComponentModel.DataAnnotations;

namespace AccManager.Data.Models
{

    public class Email : ValidaModelo<Email>
    {
        [Required]
        public string Para { get; set; }

        [Required]
        public string Titulo { get; set; }

        [EmailAddress]
        [Required]
        [Display]
        public string EmailAdress { get; set; }

        [Required]
        public string Senha { get; set; }

        public string CaminhoArquivo { get; set; }

        public string Plataforma { get; set; }
    }
}
