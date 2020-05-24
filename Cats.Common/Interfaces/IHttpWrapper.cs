using System.Threading.Tasks;

namespace Cats.Common.Interfaces
{
    public interface IHttpWrapper
    {
        Task<string> GetStringAsync(string url);
    }
}
