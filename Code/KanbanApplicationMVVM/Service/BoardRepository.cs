using KanbanApplicationMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanApplicationMVVM.Service
{
    public class BoardRepository : IBoardRepository
    {
        private Board board;

        public BoardRepository()
        {

        }

        public void Initialize(Board board)
        {
            this.board = board;
        }

        public void Initialize(XElement xml)
        {
            this.board = this.CreateBoard(xml);
        }

        public void Restart()
        {
            this.board = null;
        }

        private Board CreateBoard(XElement xml)
        {
            Board board = new Board();
            board.Id = Guid.Parse(xml.Attribute("id").Value);
            board.Name = xml.Attribute("name").Value;
            board.Created = DateTime.Parse(xml.Attribute("created").Value);
            board.Columns.Clear();

            foreach (XElement columnXml in xml.Descendants("column"))
            {
                Column column = new Column(columnXml);
                board.Columns.Add(column);
            }

            return board;
        }

        public Column FindColumn(Card card)
        {
            if (this.board == null)
                return null;

            var column = this.board.Columns.FirstOrDefault<Column>((c) =>
            {
                return c.Cards.Contains(card);
            });

            return column;
        }

        public IEnumerable<Column> GetColumns()
        {
            if (this.board == null)
                return new List<Column>();

            return this.board.Columns;
        }

        public void AddColumn(Column column)
        {
            if (this.board == null)
                return;

            this.board.Columns.Add(column);
        }

        public void RemoveCard(Card card)
        {
            throw new NotImplementedException();
        }

        public XElement ToXml()
        {
            if (this.board == null)
                return new XElement("board");

            return this.board.ToXml();
        }

        public void Dispose()
        {
            this.board = null;
        }
        
        public void RemoveColumn(Column column)
        {
            throw new NotImplementedException();
        }

        public IColumnRepository CreateColumnRepository(Column column)
        {
            return new ColumnRepository(this, column);
        }
    }
}
