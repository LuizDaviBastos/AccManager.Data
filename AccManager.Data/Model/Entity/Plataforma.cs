using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace AccManager.Data.Models
{
    public class Plataforma : Entity
    {
        [BsonElement("plataforma")]
        public string plataforma { get; set; }
    }
}
