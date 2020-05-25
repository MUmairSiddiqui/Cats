using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats.Domain.Services
{
    public interface IPersonService
    {
        Task<Result<IEnumerable<Person>>> GetPeopleAsync();
    }
}
