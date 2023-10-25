using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CuttingMachines.Models
{
    public class CuttingMachine
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; }
        [JsonProperty(PropertyName = "technology")]
        public int CuttingTechnology { get; set; }
    }
}
