using APILocacao.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APILocacao.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.MSTest
{
    [TestClass]
    public class TestSimpleClientController
    {

        [TestMethod]
        public async Task GetAllClientsAsync_ShouldReturnAllClients()
        {
            var testClients = GetTestClients();
            var controller = new ClientController(testClients);

            var result = await controller.GetAll() as List<Client>;
            Assert.AreEqual(testClients.Count, result.Count);
        }

        [TestMethod]
        public void GetClient_ShouldReturnCorrectClient()
        {
            var testClients = GetTestClients();
            var controller = new SimpleClientController(testClients);

            var result = controller.GetClient(4) as OkNegotiatedContentResult<Client>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testClients[3].Name, result.Content.Name);
        }

        [TestMethod]
        public async Task GetClientAsync_ShouldReturnCorrectClient()
        {
            var testClients = GetTestClients();
            var controller = new SimpleClientController(testClients);

            var result = await controller.GetClientAsync(4) as OkNegotiatedContentResult<Client>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testClients[3].Name, result.Content.Name);
        }

        [TestMethod]
        public void GetClient_ShouldNotFindClient()
        {
            var controller = new SimpleClientController(GetTestClients());

            var result = controller.GetClient(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Client> GetTestClients()
        {
            var testClients = new List<Client>();
            testClients.Add(new Client { CPF = 50661962695, Name = "Carlos Eduardo", Lastname = "Fernando Juan Vieira", Telephone = "(62) 3712-3632", Address = "Vila São Joaquim", DateOfBirth = DateTime.Now, Status = true});
            testClients.Add(new Client { CPF = 50661962695, Name = "Carlos Eduardo", Lastname = "Fernando Juan Vieira", Telephone = "(62) 3712-3632", Address = "Vila São Joaquim", DateOfBirth = new DateTime(year:2001,month:12,day:12), Status = true});
            return testClients;
        }
    }
}
