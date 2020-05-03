using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            Categorys = new List<CategoryModel>();
            Manufacturers = new List<ManufacturerModel>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public string Sku { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
        public bool Active { get; set; }
        public List<CategoryModel> Categorys { get; set; }
        public List<ManufacturerModel> Manufacturers { get; set; }

    }
    



}