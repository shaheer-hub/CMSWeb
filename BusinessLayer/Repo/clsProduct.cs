using DAL.Common;
using DAL.DBACCESS;
using DAL.Helpers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class clsProduct
    {
        ProductDBAccess productDb = null;
        public clsProduct()
        {
            productDb = new ProductDBAccess();
        }
        public List<Product> GetProducts()
        {
            return productDb.GetProducts();
        }
        public Product GetProductById(int id)
        {
            return productDb.GetProductById(id);
        }
        public bool AddProduct(Product product)
        {
            return productDb.AddProduct(product);
        }
        public bool RemoveProduct(int id)
        {
            return productDb.DeleteProduct(id);
        }
        public bool UpdateProduct(Product product)
        {
            return productDb.UpdateProduct(product);
        }
    }
}
