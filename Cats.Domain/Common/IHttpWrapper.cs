using System.Threading.Tasks;

namespace Cats.Domain.Common
{
    public interface IHttpWrapper
    {
        Task<string> GetStringAsync(string url);
    }
}
