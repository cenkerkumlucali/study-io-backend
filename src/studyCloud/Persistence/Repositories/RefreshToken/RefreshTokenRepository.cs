using Application.Repositories.Services.RefreshToken;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Persistence.Repositories.RefreshToken;

public class RefreshTokenRepository:IRefreshTokenRepository
{
     private readonly ILogger<RefreshTokenRepository> _logger;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;
    
        public RefreshTokenRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
        {
            _logger = loggerFactory.CreateLogger<RefreshTokenRepository>();
            _redis = redis;
            _database = redis.GetDatabase();
        }
    
        public async Task<bool> DeleteAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }
    
        public IEnumerable<string> GetUsers()
        {
            var server = GetServer();
    
            var data = server.Keys();
    
            return data?.Select(k => k.ToString());
        }

        public async Task<Domain.Entities.Users.RefreshToken> GetByRefreshToken(string refreshToken)
        {
            RedisValue data = await _database.StringGetAsync(refreshToken);
            if (data.IsNullOrEmpty)
                return null;
            return JsonConvert.DeserializeObject<Domain.Entities.Users.RefreshToken>(data);
        }

        public async Task<Domain.Entities.Users.RefreshToken> GetAsync(string id)
        {
            var data = await _database.StringGetAsync(id);
    
            if (data.IsNullOrEmpty)
            {
                return null;
            }
    
            return JsonConvert.DeserializeObject<Domain.Entities.Users.RefreshToken>(data);
        }
    
        public async Task<Domain.Entities.Users.RefreshToken> UpdateAsync(Domain.Entities.Users.RefreshToken refreshToken)
        {
            var created = await _database.StringSetAsync(refreshToken.Token, JsonConvert.SerializeObject(refreshToken));

            
            if (!created)
            {
                _logger.LogInformation("Problem occur persisting the item.");
                return null;
            }
            
            _logger.LogInformation("Refresh Token persisted successfully.");
            
             return await GetAsync(refreshToken.UserId.ToString());
        }
    
        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }
}