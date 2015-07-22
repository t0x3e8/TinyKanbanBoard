using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.Model.Messenger
{
    public class EditCardMessage
    {
        public Card SelectedCard { get; set; }
        public Column ParentColumn { get; set; }
    }
}
