using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KanbanBoardApplication.Model
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Image Picture { get; set; }
        public DateTime Created { get; set; }
    }
}
