using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AccManager.Data.Models

{
    public class HistoricoEnvio : Entity
    {

        [BsonElement("Destino")]
        [BsonRequired]
        public string Destino { get; set; }

        [BsonElement("Jogo")]
        [BsonRequired]
        public string Jogo { get; set; }

        [BsonElement("DataEnvio")]
        [BsonRequired]
        public DateTime DataEnvio { get; set; }

        [BsonElement("Status")]
        [BsonRequired]
        public bool Status { get; set; }

        [BsonElement("Conta")]
        public Contas Conta { get; set; }

    }
}
