using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product:BaseEntity
    {
        public string ProduuctName { get; set; }
        public string UnitPrice { get; set; }
        public int UnitStock { get; set; }
        public int? CategoryID { get; set; }
        //Relational properties begin
       public virtual Category Category { get; set; }

    }
}
