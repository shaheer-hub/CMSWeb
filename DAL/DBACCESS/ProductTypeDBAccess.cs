using DAL.Helpers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace DAL.DBACCESS
{
    public class ProductTypeDBAccess
    {
        public List<ProductType> GetProductTypes()
        {
            List<ProductType> lstprodType = null;
            try
            {
                using (DataTable dt = SqlDbHelper.ExecuteSelectCommand(CommandType.StoredProcedure, "GetAllProductTypes"))
                {
                    if (dt.Rows.Count > 0)
                    {
                        lstprodType = new List<ProductType>();
                        foreach (DataRow row in dt.Rows)
                        {
                            ProductType prodType = new ProductType();
                            prodType.Id = Convert.ToInt32(row["ProdTypeId"]);
                            prodType.ProductTypeName = row["ProdTypeName"].ToString();
                            lstprodType.Add(prodType);
                        }
                    }
                }
            }
           catch(Exception ex){
                throw ex;
            }
            return lstprodType;
        }
        
    }
    
}
