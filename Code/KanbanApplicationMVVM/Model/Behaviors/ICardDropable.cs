using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.Model.Behaviors
{
    public interface ICardDropable
    {
        Type Type { get; }
        void Drop(Card data);
    }
}
