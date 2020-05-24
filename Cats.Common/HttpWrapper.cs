using Cats.Common.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cats.Common
{
    internal class HttpWrapper : IHttpWrapper
    {
        public async Task<string> GetStringAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException("Url is null");

            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}
