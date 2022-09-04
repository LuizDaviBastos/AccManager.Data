using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AccManagerData.Models

{
    public class Contas : Entity
    {
        [BsonElement("nome")]
        [BsonRequired]
        [Required]
        public string nome { set; get; }

        [BsonElement("email")]
        [BsonRequired]
        [Required]
        public string email { set; get; }

        [BsonElement("senha")]
        [BsonRequired]
        [Required]
        public string senha { set; get; }

        [BsonElement("descricao")]
        [BsonRequired()]
        public string descricao { set; get; }


        [BsonElement("codigo_recuperacao")]
        public string codigo_recuperacao { set; get; }


        [BsonElement("Plataforma")]
        public string Plataforma { set; get; }
    }
}
