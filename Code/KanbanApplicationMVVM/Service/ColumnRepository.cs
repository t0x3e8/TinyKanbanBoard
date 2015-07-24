using KanbanApplicationMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KanbanApplicationMVVM.Service
{
    public class ColumnRepository : IColumnRepository
    {
        private IBoardRepository boardRepository;
        private Column column;

        public Column Column { get { return this.column; } }

        public ColumnRepository(IBoardRepository boardRepository, Column column)
        {
            if (boardRepository == null)
                throw new ArgumentException("IBoardRepository cannot be null.");
            if (column == null)
                throw new ArgumentException("Column cannot be null.");

            this.boardRepository = boardRepository;
            this.column = column;
        }

        public void AddCard(Card card)
        {
            this.column.Cards.Add(card);
        }

        public IEnumerable<Card> GetCards()
        {
            return this.column.Cards;
        }

        public void RemoveCard(Card card)
        {
            this.column.Cards.Remove(card);
        }
    }
}
