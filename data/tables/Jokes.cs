using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace data.tables
{
    public class Jokes
    {
        public Jokes() {
            
        }
        [Key]
        public int id { get; set; }
        public string jcontext { get; set; }
    }
}