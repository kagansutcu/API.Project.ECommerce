using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Options
{
    public class BaseMap<T>: EntityTypeConfiguration<T> where T:BaseEntity
    {
    }
}
