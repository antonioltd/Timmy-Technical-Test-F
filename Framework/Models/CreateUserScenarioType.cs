using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class CreateUserScenarioType
    {
        public int  id { get; set; }
        public string name {get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string addressStreet { get; set; }
        public string addressSuite { get; set; }
        public string addressCity { get; set; }
        public string addressZipcode { get; set; }
        public string addressGeoLat { get; set; }
        public string addressGeoLng { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string companyName { get; set; }
        public string companyCatchPhrase { get; set; }
        public string companyBs { get; set; }

    }
}
