using DAL.Common;
using DAL.Helpers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBACCESS
{
    public class CategoryDBAccess : ICategory
    {
        public List<Category> GetCategories()
        {
            List<Category> lstcategory = null;
            using (DataTable dt = SqlDbHelper.ExecuteSelectCommand(CommandType.StoredProcedure, "GetAllCategories"))
            {
                if (dt.Rows.Count > 0)
                {
                    lstcategory = new List<Category>();
                    foreach (DataRow row in dt.Rows)
                    {

                        Category category = new Category();
                        category.CatId = Convert.ToInt32(row["CatId"]);
                        category.CatName = row["CatName"].ToString();
                        lstcategory.Add(category);
                    }
                }
            }
            return lstcategory;

        }

        //public DataTable Get_Categories()
        //{
        //    DataTable dTResult = new DataTable();
        //    try
        //    {
        //        DataSet dSet = ((DataSet)SqlDbHelper.ExecuteDataSet(CommandType.StoredProcedure, "GetAllCategories", null)); ;
        //        dTResult = dSet.Tables[0];
        //    }
        //    catch (Exception Exp)
        //    {
        //        throw Exp;
        //    }
        //    return dTResult;
        //}
    }
}
