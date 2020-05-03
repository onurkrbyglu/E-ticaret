using ECommerce.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private GurhanDbEntities db = new GurhanDbEntities();
        public ActionResult List()
        {
            ProductListModel productmodel = new ProductListModel();

            var products = db.Products.Where(x => x.Deleted == false);
            var categorys = db.Categories.Where(x => x.Deleted == false);
            var manufacturers = db.Manufacturers.Where(x => x.Deleted == false);
            foreach (var item in products)
            {
                ProductModel product = new ProductModel();
                product.Id = item.Id;
                product.Name = item.Name;
                product.Description = item.Description;
                product.Barcode = item.Barcode;
                product.Sku = item.Sku;
                product.Price = item.Price;
                product.ManufacturerId = item.ManufacturerId;
                product.CategoryId = item.CategoryId;
                product.Active = item.Active;              
                productmodel.Products.Add(product);
            }
            foreach (var item in categorys)
            {
                CategoryModel category = new CategoryModel();
                category.Id = item.Id;
                category.Name = item.Name;
                productmodel.Categorys.Add(category);
                
            }
            foreach (var item in manufacturers)
            {
                ManufacturerModel manufacturer = new ManufacturerModel();
                manufacturer.Id = item.Id;
                manufacturer.Name = item.Name;
                productmodel.Manufacturers.Add(manufacturer);
            }
            return View(productmodel);

        }

        public ActionResult Edit(int id)
        {          
            var entity = db.Products.Find(id);
            var categorys = db.Categories.Where(x => x.Deleted == false).Where(x=>x.Published==true);
            var manufacturers = db.Manufacturers.Where(x => x.Deleted == false).Where(x => x.Published == true);
            ProductModel model = new ProductModel();
            model.Id = entity.Id;            
            model.Name = entity.Name;
            model.Description = entity.Description;
            model.Barcode = entity.Barcode;
            model.Sku = entity.Sku;
            model.Price = entity.Price;
            model.ManufacturerId = entity.ManufacturerId;
            model.CategoryId = entity.CategoryId;
            model.Active = entity.Active;
            foreach (var item in categorys)
            {
                CategoryModel category = new CategoryModel();
                category.Id = item.Id;
                category.Name = item.Name;
                model.Categorys.Add(category);

            }
            foreach (var item in manufacturers)
            {
                ManufacturerModel manufacturer = new ManufacturerModel();
                manufacturer.Id = item.Id;
                manufacturer.Name = item.Name;
                model.Manufacturers.Add(manufacturer);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            var entity = db.Products.Find(model.Id);
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Barcode = model.Barcode;
            entity.Sku = model.Sku;
            entity.Price = model.Price;
            entity.CategoryId = model.CategoryId;
            entity.ManufacturerId = model.ManufacturerId;
            entity.Active = model.Active;
            entity.UpdateOnUtc = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var entity = db.Products.Find(id);
            entity.Deleted = true;
            db.SaveChanges();
            return RedirectToAction("List");
            
        }

        public ActionResult Add()
        {
            var categorys = db.Categories.Where(x => x.Deleted == false).Where(x => x.Published == true);
            var manufacturers = db.Manufacturers.Where(x => x.Deleted == false).Where(x => x.Published == true);
            ProductModel model = new ProductModel();
            foreach (var item in categorys)
            {
                CategoryModel category = new CategoryModel();
                category.Id = item.Id;
                category.Name = item.Name;
                model.Categorys.Add(category);

            }
            foreach (var item in manufacturers)
            {
                ManufacturerModel manufacturer = new ManufacturerModel();
                manufacturer.Id = item.Id;
                manufacturer.Name = item.Name;
                model.Manufacturers.Add(manufacturer);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ProductModel model)
        {
            
            Product product = new Product();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Barcode = model.Barcode;
            product.Sku = model.Sku;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;
            product.ManufacturerId = model.ManufacturerId;
            product.CreatedOnUtc = DateTime.Now;
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}