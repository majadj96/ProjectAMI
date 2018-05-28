using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LocalBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AgregatorCode { get; set; }
        public string DeviceCode { get; set; }
        public string TimeStamp { get; set; }
        public double Voltage { get; set; }
        public double Eletricity { get; set; }
        public double ActivePower { get; set; }
        public double ReactivePower { get; set; }

        
    }
}
