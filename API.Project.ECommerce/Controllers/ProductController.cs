using API.Project.ECommerce.ViewModels;
using BLL.DesignPatterns.RepositoryPattern.ConcRep;
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
        ProductRep pr;
        public ProductController()
        {
            pr = new ProductRep();
        }

        [HttpGet]
        public List<ProductVM> GetAllProducts()
        {
            return pr.Select(x => new ProductVM
            {
                ID = x.ID,
                ProduuctName = x.ProduuctName,
                UnitPrice = x.UnitPrice,
                Category = x.Category,
                CategoryID = x.CategoryID.Value
            }) as List<ProductVM>;
            
           
            
        }
    }
}
