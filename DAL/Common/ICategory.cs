using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public interface ICategory
    {
        //bool AddProduct(Product product);
        //Product GetProductById(int id);
        //bool DeleteProduct(int id);
        List<Category> GetCategories();
        //bool UpdateProduct(Product product);
    }
}
