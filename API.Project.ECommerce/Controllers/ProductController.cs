using API.Project.ECommerce.ViewModels;
using BLL.DesignPatterns.SingeltonPattern;
using DAL.Context;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Project.ECommerce.Controllers
{
    public class ProductController : ApiController
    {
        MyContext db;
      
        public ProductController()
        {
            db = DBTool.DBInstance;
        }
     

        [HttpGet]
        public List<ProductVM> GetAllProducts()
        {

           return db.Products.Select(x => new ProductVM()
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryName=x.Category.CategoryName,
                
            }).ToList();
            


        }
    }
}
