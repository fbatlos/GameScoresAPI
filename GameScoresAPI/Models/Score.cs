using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameScoreAPI.Models
{
    public class Score
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  // Permite manejar el Id como string en C#
        public string Id { get; set; } = string.Empty;

        [BsonElement("playerName")] // Nombre del campo en la colección MongoDB
        public string PlayerName { get; set; } = string.Empty;

        [BsonElement("points")]
        public int Points { get; set; }
    }
}