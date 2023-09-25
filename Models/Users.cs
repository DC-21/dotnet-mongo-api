using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudApi.Models;
public class User{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
     public string? Id { get; set; }

     [BsonElement("Name")]
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}