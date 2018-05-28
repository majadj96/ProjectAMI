using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AgregatorBaseDBContex : DbContext
    {
       public AgregatorBaseDBContex() : base("AgregatorBaseContex")
         {

        }
        public DbSet<AgregatorBase> AgregatorBaseData { get; set; }

        
    }
}
