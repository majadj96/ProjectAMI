using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMIAgregator
{
    public class ModelDBContex : DbContext
    {
        public ModelDBContex() : base("ModelContext")
        {

        }
        public DbSet<Model> Modeli { get; set; }
    }
}
