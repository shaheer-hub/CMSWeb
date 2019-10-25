using DAL.Common;
using DAL.Helpers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DAL.DBACCESS
{
    public class ProductDBAccess:IProduct
    {
        public bool AddProduct(Product product)
        {
            SqlParameter[] parameters = new SqlParameter[7];
            if (product.ProdName != null)
                parameters[0] = new SqlParameter("@ProdName", product.ProdName);
            else
                parameters[0] = new SqlParameter("@ProdName", DBNull.Value);
            if (product.ProdDescription != null)
                parameters[1] = new SqlParameter("@ProdDescription", product.ProdDescription);
            else
                parameters[1] = new SqlParameter("@ProdDescription", DBNull.Value);
            if (product.ProdPrice != null)
                parameters[2] = new SqlParameter("@ProdPrice", product.ProdPrice);
            else
                parameters[2] = new SqlParameter("@ProdPrice", product.ProdPrice);
            if (product.CategoryId != null)
                parameters[3] = new SqlParameter("@CategoryId", product.CategoryId);
            else
                parameters[3] = new SqlParameter("@CategoryId", DBNull.Value);
            if (product.ProductTypeId != null)
                parameters[4] = new SqlParameter("@ProductTypeId", product.ProductTypeId);
            else
                parameters[4] = new SqlParameter("@ProductTypeId", DBNull.Value);
            if (product.Photo != null)
                parameters[5] = new SqlParameter("@BinaryPhoto", product.Photo);
            else
                parameters[5] = new SqlParameter("@BinaryPhoto", SqlBinary.Null);
            if (product.PhotoName != null)
                parameters[6] = new SqlParameter("@PhotoName", product.PhotoName);
            else
                parameters[6] = new SqlParameter("@PhotoName", DBNull.Value);
            return SqlDbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "AddNewProduct", parameters);
        }
        public Product GetProductById(int id)
        {
            Product product = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProdId" , id)
            };
            using (DataTable dt = SqlDbHelper.ExecuteParameterizedSelectCommand(CommandType.StoredProcedure, "GetProductById", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    product = new Product();
                    product.ProdId = Convert.ToInt32(row["ProdId"]);
                    product.ProdName = row["ProdName"].ToString();
                    product.ProdPrice = Convert.ToDecimal(row["ProdPrice"]);
                    product.ProdDescription = row["ProdDescription"].ToString();
                    product.Category = row["Category"].ToString();
                    product.ProductType = row["ProductType"].ToString();
                    product.Photo = (byte[])(row["Photo"]);
                }
            }
            return product;

        }
        public List<Product> GetProducts()
        {
            List<Product> lstproduct = null;
            using (DataTable dt = SqlDbHelper.ExecuteSelectCommand(CommandType.StoredProcedure, "sp_GetAllProducts"))
            {
                if (dt.Rows.Count > 0)
                {
                    lstproduct = new List<Product>();
                    foreach (DataRow row in dt.Rows)
                    {

                        Product product = new Product();
                        
                        product.ProdName = row["ProdName"].ToString();
                        product.ProdPrice = Convert.ToDecimal(row["ProdPrice"]);
                        product.ProdDescription = row["ProdDescription"].ToString();
                        product.Category = row["CatName"].ToString();
                        product.ProductType = row["ProdTypeName"].ToString();
                        if (row["BinaryPhoto"] != DBNull.Value)
                        {
                            product.Photo = (byte[])(row["BinaryPhoto"]);
                            MemoryStream stream = new MemoryStream(product.Photo);
                            BitmapImage image = new BitmapImage();
                            image.BeginInit();
                            image.StreamSource = stream;
                            image.EndInit();
                            product.Image = image;
                            
                        }
                        lstproduct.Add(product);

                    }
                }
            }
            return lstproduct;

        }
        public bool DeleteProduct(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProdId" , id)
            };

            return SqlDbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteProduct", parameters);
        }
        public bool UpdateProduct(Product product)
        {
            SqlParameter[] parameters = new SqlParameter[6];
            if (product.ProdName != null)
                parameters[1] = new SqlParameter("@ProdName", product.ProdName);
            else
                parameters[1] = new SqlParameter("@ProdName", DBNull.Value);
            if (product.ProdDescription != null)
                parameters[2] = new SqlParameter("@ProdDescription", product.ProdDescription);
            else
                parameters[2] = new SqlParameter("@ProdDescription", DBNull.Value);
            if (product.ProdPrice != null)
                parameters[3] = new SqlParameter("@ProdPrice", product.ProdPrice);
            else
                parameters[3] = new SqlParameter("@ProdPrice", product.ProdPrice);
            if (product.CategoryId != null)
                parameters[4] = new SqlParameter("@CategoryId", product.CategoryId);
            else
                parameters[4] = new SqlParameter("@CategoryId", DBNull.Value);
            if (product.ProductTypeId != null)
                parameters[5] = new SqlParameter("@ProductTypeId", product.ProductTypeId);
            else
                parameters[5] = new SqlParameter("@ProductTypeId", DBNull.Value);
            if (product.ProductTypeId != null)
                parameters[6] = new SqlParameter("@BinaryPhoto", product.Photo);
            else
                parameters[6] = new SqlParameter("@BinaryPhoto", DBNull.Value);
            return SqlDbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateProduct", parameters);
        }
    }
}

