using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardApplication.Model.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<BoardDbSet> Boards { get; set; }

        public DatabaseContext() : base("BoardsDBConnectionString")
        {

        }
    }
}
