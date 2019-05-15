using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationWeb.Model
{
    public class CustomerInfoViewModel
    {
        public string Company { get; set; }
        public AddressViewModel Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ContactName { get; set; }
        public string ContactPosition { get; set; }
    }
}
