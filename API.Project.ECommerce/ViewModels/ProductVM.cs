using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




namespace API.Project.ECommerce.ViewModels
{
    public class ProductVM
    {
        public int ID { get; set; }
        public string ProduuctName { get; set; }
        public string UnitPrice { get; set; }
        
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}