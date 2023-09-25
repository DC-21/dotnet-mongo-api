using MongoDB.Driver;
using CrudApi.Models;
using CrudApi.Configurations;
using Microsoft.Extensions.Options;

namespace CrudApi.Services;
public class UsersService
{
    private readonly IMongoCollection<User> _userCollection;
    public UsersService(IOptions<DatabaseSettings>databaseSettings){
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var MongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _userCollection = MongoDB.GetCollection<User>(databaseSettings.Value.CollectionName);
    }
    public async Task<List<User>>GetUsersAsync()=> await _userCollection.Find(_ => true).ToListAsync();
    public async Task<User> GetUserAsync(string id) => await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(User user)=> await _userCollection.InsertOneAsync(user);
    public async Task UpdateAsync(User user)=> await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
    public async Task RemoveAsync(strind id)
}