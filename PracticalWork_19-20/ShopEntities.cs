using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_19_20
{
    public partial class ShopEntities : DbContext
    {
        private static ShopEntities context;
        public static ShopEntities GetContext()
        {
            if (context == null)
            {
                context = new ShopEntities();
            }
            return context;
        }
    }
}
