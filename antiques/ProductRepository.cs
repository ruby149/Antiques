using antiques.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace antiques
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }
        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
        }

        public IEnumerable<Category>GetAllCategories()
        {
            return _conn.Query<Category>("SELECT* FROM Categories");
        }

        public Product AssignCategory()
        {
            var categoryList = GetAllCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Item = @item, Price = @price WHERE ProductID = @id",
                new { item = product.Item, price = product.Price, id = product.ProductID });
        }
        

        public void CreateProduct(Product product) 
        {
            _conn.Execute("INSERT INTO products ( Price, Description, Item, Category_ID, User_id) VALUES ( @price,@description,@item, @category_ID,@user_ID)",
                new { price = product.Price,  description = product.Description, item = product.Item, category_ID = product.Category_ID, user_id = product.User_id });

        }

     
        public void EditProduct(Product productToEdit) 
        {
            _conn.Execute("UPDATE Into products SET Item = @item, Price =@price, Size =@size, CategoryID=@categoryID WHERE ProductID =@productID ",
                new { item = productToEdit.Item, price = productToEdit.Price, categoryID = productToEdit.Category_ID, productID
                =productToEdit.ProductID});
            
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM products WHERE ProductID =@id;",
                new {id=product.ProductID});
        }

       
    }

}
