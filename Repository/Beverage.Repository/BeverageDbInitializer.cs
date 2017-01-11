using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beverage.Repository
{
    public class BeverageDbInitializer : DropCreateDatabaseIfModelChanges<BeverageDbContext>
    {
        protected override void Seed(BeverageDbContext context)
        {
            base.Seed(context);
        }
    }
}
