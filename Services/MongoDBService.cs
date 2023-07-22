using EliteBackend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace EliteBackend.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<User> _User;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _User = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<User>> GetAllsers() => await _User.Find(_ => true).ToListAsync();

        public async Task<User> GetUser(string id) => await _User.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<User> GetUserByUsername(string name) => await _User.Find(x => x.Email == name).FirstOrDefaultAsync();

        public async Task AddUser(User user) => await _User.InsertOneAsync(user);

        public async Task Updateuser(string id, User user) => await _User.ReplaceOneAsync(x => x.Email == id, user);

        public async Task RemoveUser(string id) => await _User.DeleteOneAsync(x => x.Id == id);

    }
}
