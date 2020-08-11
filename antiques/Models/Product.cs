using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace antiques.Models
{
    public class Product
    {
        public Product()
        {

        }

        public int ProductID { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }

        public string Description { get; set; }
        public string Item { get; set; }
        public int CategoryID { get; set; }
        public int User_id { get; set; }


    }
}
