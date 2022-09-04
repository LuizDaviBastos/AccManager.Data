﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace AccManagerData.Models
{
    public class Usuario : Entity
    {
        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Senha")]
        public string Senha { get; set; }

    }
}
