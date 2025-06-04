using System.Text.Json.Serialization;
using Mysqlx.Datatypes;
using WaruSmart.API.IAM.Domain.Model.ValueObjects;
using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;

namespace WaruSmart.API.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash)
{
    public User() : this(string.Empty, string.Empty)
    {
    }
    
    public int Id { get; set; }
    
    public string Username { get; private set; } = username;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
    public ICollection<Sowing> Sowings { get; set; }
    
    //TODO: Add feature about user with profile in bounded context IAM
    //public ProfileId Profile { get; set; }

    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }

    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

}