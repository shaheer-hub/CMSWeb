using DAL.DBACCESS;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class clsProductType
    {
        ProductTypeDBAccess prodTypeDb = null;
        public clsProductType()
        {
            prodTypeDb = new ProductTypeDBAccess();
        }
        public List<ProductType> GetAllProdTypes()
        {
            return prodTypeDb.GetProductTypes();
        }
    }
}
