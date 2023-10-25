using Microsoft.VisualStudio.TestTools.UnitTesting;
using CuttingMachines;
using System;
using System.IO;
using System.Text;
using System.Net;
using CuttingMachines.Models;

namespace CuttingMachines.Tests
{
    [TestClass()]
    public class CuttingMachinesTest
    {
        private HttpWebRequest request;
        private HttpWebResponse response;

        [TestInitialize]
        public void SetUp()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            var url = $"https://app-academy-neu-codechallenge.azurewebsites.net/api/cut/";

            request = (HttpWebRequest)WebRequest.Create(url);

            string username = "lantekacademy";
            string password = ":cPIi<kyF(=5OXc";

            string authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
            request.Method = "GET";
            request.Accept = "application/json";
        }

        [TestCleanup]
        public void Dispose()
        {
            response.Dispose();
        }

        [TestMethod()]
        public void GetResponseTest()
        {
            response = (HttpWebResponse)request.GetResponse();

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [TestMethod()]
        public void RetrievingDataTest()
        {
           string responseBody;

            using (response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        responseBody = objReader.ReadToEnd();
                    }
                }
            }

            Assert.IsTrue(responseBody.Length > 0);
        }
    }
}
