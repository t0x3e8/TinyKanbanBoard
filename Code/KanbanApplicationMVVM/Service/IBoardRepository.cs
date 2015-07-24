using KanbanApplicationMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanApplicationMVVM.Service
{
    public interface IBoardRepository : IDisposable
    {
        IEnumerable<Column> GetColumns();
        void AddColumn(Column column);
        void RemoveColumn(Column column);
        Column FindColumn(Card card);
        IColumnRepository CreateColumnRepository(Column column);

        XElement ToXml();
        void Initialize(XElement xElement);
        void Initialize(Board board);
        void Restart();
    }
}
