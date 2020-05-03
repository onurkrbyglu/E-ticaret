using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        public ProductListModel()
        {
            Products = new List<ProductModel>();
            Categorys = new List<CategoryModel>();
            Manufacturers = new List<ManufacturerModel>();
        }
        public List<ProductModel> Products { get; set; }
        public List<CategoryModel> Categorys { get; set; }
        public List<ManufacturerModel> Manufacturers { get; set; }
    }
}