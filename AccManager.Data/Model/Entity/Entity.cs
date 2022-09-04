using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace AccManagerData.Models
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { set; get; }
    }
}
