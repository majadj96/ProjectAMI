using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GlobalBaseDBContex : DbContext
    {
        public GlobalBaseDBContex() : base("GlobalBaseContex")
        {

        }
        public DbSet<GlobalBase> GlobalBaseData { get; set; }

    }
}
