using System;
using System.IO;
using System.Text;
using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using CuttingMachines.Models;


namespace CuttingMachines
{
    public class Program
    {

        public static void Main(string[] args)
        {
            ConsoleKeyInfo key;

            Console.WriteLine("Listing cutting machines:");
            Console.WriteLine("* Press number 2 for filtering by 2D technology");
            Console.WriteLine("* Press number 3 for filtering by 3D technology");
            Console.WriteLine("* Press any other key for no filtering\r\n");

            key = Console.ReadKey(true);

            GetCuttingMachines(key.KeyChar);

            Console.WriteLine("\r\nPress (ENTER) to quit");
            Console.ReadLine();
        }

        public static void GetCuttingMachines(char IdTech)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            var url = $"https://app-academy-neu-codechallenge.azurewebsites.net/api/cut/";

            if (IdTech.Equals('2') || IdTech.Equals('3') )
                url += IdTech;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";

            string username = "lantekacademy";
            string password = ":cPIi<kyF(=5OXc";

            string authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            List<CuttingMachine> machines;
                            string responseBody = objReader.ReadToEnd();
                            machines = JsonConvert.DeserializeObject<List<CuttingMachine>>(responseBody);

                            foreach (CuttingMachine machine in machines)
                            {
                                Console.WriteLine($"Name: {machine.Name}\tManufacturer: {machine.Manufacturer}\tCutting Technology: {machine.CuttingTechnology}D");
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            catch (Exception ex)
            {
                // Handle error
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}