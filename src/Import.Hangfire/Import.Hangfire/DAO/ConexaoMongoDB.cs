using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Import.Hangfire.DAO
{
    public class ConexaoMongoDB
    {
        public static IMongoDatabase GetConnection()
        {
            string connectionString = "mongodb://helix:H3l1xNG@54.233.152.132:27000";
            string databaseName = "sth_helixiot";

            var client = new MongoClient(connectionString);

            return client.GetDatabase(databaseName);
        }
        
        public static List<string> GetCollections(IMongoDatabase db)
        {
            List<string> collections = new List<string>();

            foreach (var item in db.ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
            {
                string name = item["name"].AsString;
                if (name.Contains("aggr") || name == "helix_startup")
                    continue;

                collections.Add(name);
            }

            return collections;
        }
    }
}
