using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Import.Hangfire.Models
{
    public class DadosHelixModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime recvTime { get; set; }
        public string attrName { get; set; }
        public string attrType { get; set; }
        public string attrValue { get; set; }
    }
}
