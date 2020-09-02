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
       

        public string Description { get; set; }
        public string Item { get; set; }
        public int Category_ID { get; set; }
        public int User_id { get; set; }
        public IEnumerable<Category>Categories {get; set;}


    }
}
