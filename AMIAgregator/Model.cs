using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMIAgregator
{
    public class Model
    {
        [Key]
        public string Code { get; set; }
    }
}
