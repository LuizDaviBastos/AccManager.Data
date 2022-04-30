using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace AccManager.Data.Models
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { set; get; }
    }
}
