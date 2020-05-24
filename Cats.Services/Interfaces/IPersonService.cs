using Cats.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Result<IEnumerable<Person>>> GetPeopleAsync();
    }
}
