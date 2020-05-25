namespace Cats.Domain.Configurations
{
    public interface IConfiguration
    {
        string Get(string key);
    }
}
