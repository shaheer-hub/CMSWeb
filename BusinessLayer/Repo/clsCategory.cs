using DAL.DBACCESS;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class clsCategory
    {
        CategoryDBAccess categoryDb = null;
        public clsCategory()
        {
            categoryDb = new CategoryDBAccess();
        }
        public List<Category> GetCategories()
        {
            return categoryDb.GetCategories();
        }
        //public DataTable Get_Categories()
        //{
        //    return categoryDb.Get_Categories();
        //}
    }
}
