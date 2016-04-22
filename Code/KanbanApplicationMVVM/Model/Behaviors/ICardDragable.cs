using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.Model.Behaviors
{
    public interface ICardDragable
    {
        Type Type { get; }
        Card DragObject { get; }
        void RemoveDragCard(Card card);
    }
}
