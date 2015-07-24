using KanbanApplicationMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KanbanApplicationMVVM.Service
{
    public interface IColumnRepository
    {
        void AddCard(Card card);
        IEnumerable<Card> GetCards();
        void RemoveCard(Card card);
        Column Column { get; }
    }
}
