using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace AccManagerData.Models
{
    public class Plataforma : Entity
    {
        [BsonElement("plataforma")]
        public string plataforma { get; set; }
    }
}
