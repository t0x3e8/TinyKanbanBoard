using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Project> Projects{ get; set; }

        public DatabaseContext() : base("KanbanDBConnectionString") { }
    }
}
