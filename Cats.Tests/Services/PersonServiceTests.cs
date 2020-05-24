using Cats.Common.Interfaces;
using Cats.Configurations.Interfaces;
using Cats.Domain;
using Cats.Services;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cats.Tests.Services
{
    public class PersonServiceTests
    {
        private readonly string _personServiceUrl = "http://localhost";
        private IConfiguration _configuration = null;
        private IHttpWrapper _http = null;

        private string testData =>
            "[{'name':'Bob','gender':'Male','age':23,'pets':[{'name':'Garfield','type':'Cat'},{'name':'Fido','type':'Dog'}]},{'name':'Jennifer','gender':'Female','age':18,'pets':[{'name':'Garfield','type':'Cat'}]},{'name':'Steve','gender':'Male','age':45,'pets':null},{'name':'Fred','gender':'Male','age':40,'pets':[{'name':'Tom','type':'Cat'},{'name':'Max','type':'Cat'},{'name':'Sam','type':'Dog'},{'name':'Jim','type':'Cat'}]}]";

        [SetUp]
        public void Setup()
        {
            var moqConfig = new Mock<IConfiguration>();
            moqConfig.Setup(config => config.Get(It.Is<string>(val => val == "peopleService")))
                .Returns(_personServiceUrl);
            _configuration = moqConfig.Object;

            var moqHttp = new Mock<IHttpWrapper>();
            moqHttp.Setup(http => http.GetStringAsync(It.Is<string>(val => val == _personServiceUrl)))
                .Returns(Task.FromResult(testData));
            _http = moqHttp.Object;
        }

        [Test]
        public async Task PersonService_ShouldReturn_People()
        {
            var testPeople = JsonConvert.DeserializeObject<IEnumerable<Person>>(testData);
            var personService = new PersonService(_configuration, _http);
            var result = await personService.GetPeopleAsync();            

            Assert.True(result.IsSuccess);
            Assert.AreEqual(testPeople.Count(), result.Value.Count());
            //Add more assertions as needed.
        }
    }
}