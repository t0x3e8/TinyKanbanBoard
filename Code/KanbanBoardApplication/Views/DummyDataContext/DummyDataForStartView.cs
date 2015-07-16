using KanbanBoardApplication.Model.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardApplication.Views.DummyDataContext
{
    class DummyDataForStartView
    {
        public ObservableCollection<BoardEntity> BoardsSet { get; set; }

        public DummyDataForStartView()
        {
            this.BoardsSet = new ObservableCollection<BoardEntity>();
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked=true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 1, Name = "board 1", Created = DateTime.Now, IsChecked = true });
            this.BoardsSet.Add(new BoardEntity() { Id = 4, Name = "board 2", Created = DateTime.Now });
            this.BoardsSet.Add(new BoardEntity() { Id = 2, Name = "board 3", Created = DateTime.Now, IsChecked = true }); 
        }
    }
}
