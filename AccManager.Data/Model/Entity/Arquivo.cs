using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AccManagerData.Models

{
    public class Arquivo : Entity
    {
        [BsonElement("Path")]
        [Required]
        public string Path { get; set; }

        [BsonElement("Caminho")]
        [Required]
        public string Caminho { get; set; }
    }
}
