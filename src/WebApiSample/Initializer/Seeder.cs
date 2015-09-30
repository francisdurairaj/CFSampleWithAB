using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSample.Models;

namespace WebApiSample.Initializer
{
    public class Seeder
    {
        public static List<Product> lstProducts { get; set; }
        public static List<CreateAdd> lstAdds { get; set; }
        public static List<AddsHistory> lstAddsHistory { get; set; }

        public static void intialize()
        {
            lstProducts = DataFeeder.getProducts();
            lstAdds = DataFeeder.getActiveAdds();
            lstAddsHistory = DataFeeder.getAddsHistory();
        }
    }
}
