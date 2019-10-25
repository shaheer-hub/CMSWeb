using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DAL.Models
{
    public class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public decimal? ProdPrice { get; set; }
        public byte[] Photo { get; set; }
        public BitmapImage Image { get; set; }
        public string PhotoName { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductTypeId { get; set; }
        public string Category { get; set; }
        public string ProductType { get; set; }
    }
}
