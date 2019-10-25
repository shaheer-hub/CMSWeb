using BusinessLayer.Repo;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSWebForm.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        clsProduct _product = new clsProduct();
        clsCategory _category = new clsCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            imgBtnFirst.Enabled = false;
            imgBtnPrevious.Enabled = false;
            if (!IsPostBack)
            {
                BindCategories();
                BindProductTypes();
                FillGridView();
            }

        }
        public void FillGridView()
        {

            this.GVProducts.DataSource = _product.GetProducts();
            this.GVProducts.DataBind();
        }
        public void BindCategories()
        {

            try
            {
                List<Category> catlist = _category.GetCategories();
                this.ddlCategory.DataSource = catlist;
                this.ddlCategory.DataValueField = "CatId";
                this.ddlCategory.DataTextField = "CatName";
                this.ddlCategory.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void BindProductTypes()
        {
            try
            {
                clsProductType _prodType = new clsProductType();
                List<ProductType> prodTypeList = _prodType.GetAllProdTypes();
                this.ddlProdType.DataSource = prodTypeList;
                this.ddlProdType.DataValueField = "Id";
                this.ddlProdType.DataTextField = "ProductTypeName";
                this.ddlProdType.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProdName = txtName.Text.ToString();
                product.ProdPrice = Convert.ToDecimal(txtPrice.Text);
                product.ProdDescription = txtPDescription.Text.ToString();
                product.CategoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                product.ProductTypeId = Convert.ToInt32(ddlProdType.SelectedItem.Value);
                if (imgUploader.HasFile)
                {
                    int length = imgUploader.PostedFile.ContentLength;
                    byte[] imgbyte = new byte[length];
                    HttpPostedFile img = imgUploader.PostedFile;
                    //set the binary data  
                    img.InputStream.Read(imgbyte, 0, length);
                    string filename = Path.GetFileName(imgUploader.PostedFile.FileName);

                    //be.Eimage=txtimage.  
                    product.PhotoName = filename;
                    product.Photo = imgbyte;



                }
                clsProduct _product = new clsProduct();
                _product.AddProduct(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region pagging controls

        private void SetPaggingData()
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlPageSize_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                GVProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                FillGridView();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgBtnFirst_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void imgBtnNext_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {
                int i = GVProducts.PageIndex + 1;
                if (i <= GVProducts.PageCount)
                {
                    GVProducts.PageIndex = i;
                    FillGridView();
                    imgBtnLast.Enabled = true;
                    imgBtnPrevious.Enabled = true;
                    imgBtnFirst.Enabled = true;
                }

                if (GVProducts.PageCount - 1 == GVProducts.PageIndex)
                {
                    imgBtnNext.Enabled = false;
                    imgBtnLast.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void imgBtnPrevious_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {
                int i = GVProducts.PageCount;
                if (GVProducts.PageIndex > 0)
                {

                    GVProducts.PageIndex = GVProducts.PageIndex - 1;
                    FillGridView();
                    imgBtnLast.Enabled = true;
                    imgBtnPrevious.Enabled = true;
                }

                if (GVProducts.PageIndex == 0)
                {
                    imgBtnFirst.Enabled = false;
                }
                if (GVProducts.PageCount - 1 == GVProducts.PageIndex + 1)
                {
                    imgBtnNext.Enabled = true;
                }
                if (GVProducts.PageIndex == 0)
                {
                    imgBtnPrevious.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void imgBtnLast_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void cmbNumberOfPages_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindPageData(int pageSize, int pageIndex)
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MakePageSizeQuery()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EnableDisableButtons(int index)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion pagging controls
        protected void GVProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVProducts.PageIndex = e.NewPageIndex;
            FillGridView();
        }


    }
}