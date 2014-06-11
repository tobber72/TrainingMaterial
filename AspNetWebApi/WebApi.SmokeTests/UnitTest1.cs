using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;

namespace WebApi.SmokeTests
{
    [TestClass]
    public class UnitTest1
    {
        public const string ApiUrlRoot = "http://localhost:54402/api";
        public const string resource = "";


        private WebClient CreateWebClient()
        {
            var webClient = new WebClient();

            //const string creds = "jbob" + ":" + "jbob12345";
            //var bcreds = Encoding.ASCII.GetBytes(creds);
            //var base64Creds = Convert.ToBase64String(bcreds);
            //webClient.Headers.Add("Authorization", "Basic " + base64Creds); // amJvYjpqYm9iMTIzNDU=

            return webClient;
        }

        [TestMethod]
        public void GetAllEntity()
        {
            var client = CreateWebClient();
            var response = client.DownloadString(ApiUrlRoot + "/" + resource);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void AddNewEntity()
        {
            var client = CreateWebClient();

            const string url = ApiUrlRoot + "/" + resource;
            const string method = "POST";
            const string newCategory = "";

            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString(url, method, newCategory);

            Assert.IsNotNull(response);
        }
    }
}
