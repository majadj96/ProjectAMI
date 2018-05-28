using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LocalBaseDBContex : DbContext
    {
        public LocalBaseDBContex() :base("LocalBaseContex")
        {

        }
        public DbSet<LocalBase> LocalBaseData { get; set; }

    }
}
