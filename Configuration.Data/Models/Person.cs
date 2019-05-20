using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Configuration.Data.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public Address Address  { get; set; }
        public Department Department { get; set; }
    }
}
