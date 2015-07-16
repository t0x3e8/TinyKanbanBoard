using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KanbanBoardApplication.Model
{
    public class Author
    {
        private Guid id;
        private string name;
        private Image picture;
        private DateTime created;

        public Guid Id
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                }
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                }
            }
        }

        public Image Picture
        {
            get { return this.picture; }
            set
            {
                if (this.picture != value)
                {
                    this.picture = value;
                }
            }
        }

        public DateTime Created
        {
            get { return this.created; }
            set
            {
                if (this.created != value)
                {
                    this.created = value;
                }
            }
        }
    }
}
