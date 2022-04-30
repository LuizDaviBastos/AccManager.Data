using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace AccManager.Data.Models
{
    public class Layout : Entity
    {

        [BsonElement("Path")]
        [Required]
        public string Path { get; set; }

        [BsonElement("Caminho")]
        [Required]
        public string Caminho { get; set; }

        [BsonElement("Plataforma")]
        public string Plataforma { get; set; }
    }
}
