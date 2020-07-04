using Api.model.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DbContext.DatabaseContext
{
   public class ProjectDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
