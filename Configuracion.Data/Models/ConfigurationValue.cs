using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Configuration.Data.Models
{
    public class ConfigurationValue
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
