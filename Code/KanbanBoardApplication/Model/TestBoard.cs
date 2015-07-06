using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardApplication.Model
{
    class TestBoard
    {
        public static Board GetBoard()
        {
            Author author1 = new Author() { Id = Guid.NewGuid(), Created = DateTime.Today, Name = "Jarek", Picture = null };
            Author author2 = new Author() { Id = Guid.NewGuid(), Created = DateTime.Parse("2012.02.03"), Name = "Filip", Picture = null };

            Comment comment1 = new Comment() { Created = DateTime.Parse("2013.02.04 17:45"), Text = "I wonder if this works", Owner = author1 };
            Comment comment2 = new Comment() { Created = DateTime.Parse("2013.02.04 18:45"), Text = "Sure it will", Owner = author2 };
            Comment comment3 = new Comment() { Created = DateTime.Parse("2013.02.04 19:00"), Text = "Good :)", Owner = author1 };

            Card card1 = new Card() { Index = 0, Owner = author1, Text = "Let's add first card" };
            card1.Comments.Add(comment1);
            card1.Comments.Add(comment2);
            card1.Comments.Add(comment3);
            Card card2 = new Card() { Index = 1, Owner = author1, Text = "Let's add second card" };
            Card card3 = new Card() { Index = 2, Owner = author1, Text = "Enough for now" };
            Card card4 = new Card() { Index = 0, Owner = author2, Text = "Stop running" };
            Card card5 = new Card() { Index = 1, Owner = author2, Text = "Do something else" };
            Card card6 = new Card() { Index = 0, Owner = author1, Text = "Eat dinner" };

            Column column1 = new Column() { Header = "To do", Index = 0 };
            column1.Cards.Add(card1);
            column1.Cards.Add(card2);
            column1.Cards.Add(card3);
            Column column2 = new Column() { Header = "In progress", Index = 1 };
            column2.Cards.Add(card4);
            column2.Cards.Add(card5);
            Column column3 = new Column() { Header = "Done", Index = 2 };
            column3.Cards.Add(card6);

            Board board = new Board() { Name = "New board", Created = DateTime.Today };
            board.Columns.Add(column1);
            board.Columns.Add(column2);
            board.Columns.Add(column3);

            return board;
        }
    }
}
