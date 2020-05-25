using Cats.Domain;
using Cats.Domain.Common;
using Cats.Domain.Configurations;
using Cats.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats.Services
{
    internal class PersonService : IPersonService
    {
        private readonly IConfiguration _config = null;
        private readonly IHttpWrapper _http = null;

        public PersonService(
            IConfiguration configuration, 
            IHttpWrapper http)
        {
            _config = configuration ?? throw new ArgumentNullException("Config is null");
            _http = http ?? throw new ArgumentNullException("Http wrapper is null");
        }

        public async Task<Result<IEnumerable<Person>>> GetPeopleAsync()
        {
            var url = _config.Get("peopleService");
            if (string.IsNullOrWhiteSpace(url))
                return new Result<IEnumerable<Person>>(null);

            var response = await _http.GetStringAsync(url);
            return new Result<IEnumerable<Person>>(JsonConvert.DeserializeObject<IEnumerable<Person>>(response));
        }
    }
}
