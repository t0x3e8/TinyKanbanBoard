using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KanbanBoardApplication.Model;
using System.Xml.Linq;
using System.Diagnostics;

namespace ProjectUnitTests
{
    [TestClass]
    public class DomainModelTests
    {
        public Board InitializeBoard()
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

        [TestMethod]
        public void CreateBoardFromXML()
        {
            string xml =
                "<board name=\"New board\" created=\"2015-07-04T00:00:00+02:00\" id=\"123\">" +
                    "<column header=\"To do\" index=\"0\">" +
                        "<card text=\"Let's add first card\" index=\"0\" owner=\"06dd043f-1d9c-4953-94b3-ab21a01f9ef8\">" +
                            "<comment created=\"2013-02-04T17:45:00\" text=\"I wonder if this works\" owner=\"06dd043f-1d9c-4953-94b3-ab21a01f9ef8\" /> " +
                            "<comment created=\"2013-02-04T18:45:00\" text=\"Sure it will\" owner=\"478394c2-deb1-4ad5-b9b7-2db3c5557311\" />" +
                            "<comment created=\"2013-02-04T19:00:00\" text=\"Good :)\" owner=\"06dd043f-1d9c-4953-94b3-ab21a01f9ef8\" />" +
                        "</card>" +
                        "<card text=\"Let's add second card\" index=\"1\" owner=\"06dd043f-1d9c-4953-94b3-ab21a01f9ef8\" /> " +
                        "<card text=\"Enough for now\" index=\"2\" owner=\"06dd043f-1d9c-4953-94b3-ab21a01f9ef8\" />" +
                    "</column>" +
                    "<column header=\"In progress\" index=\"1\">" +
                        "<card text=\"Stop running\" index=\"0\" owner=\"478394c2-deb1-4ad5-b9b7-2db3c5557311\" />" +
                        "<card text=\"Do something else\" index=\"1\" owner=\"478394c2-deb1-4ad5-b9b7-2db3c5557311\" />" +
                    "</column>" +
                    "<column header=\"Done\" index=\"2\">" +
                        "<card text=\"Eat dinner\" index=\"0\" owner=\"06dd043f-1d9c-4953-94b3-ab21a01f9ef8\" />" +
                    "</column>" +
                "</board>";


            Board board = new Board();
            board.InitializeFromXML(XElement.Parse(xml));

            Assert.IsNotNull(board);
            Assert.AreEqual(3, board.Columns.Count);
        }

        [TestMethod]
        public void CreateXmlFromBoard()
        {
            Board board = this.InitializeBoard();

            XElement xml = board.ToXml();
            Assert.IsNotNull(xml);
        }
    }
}
