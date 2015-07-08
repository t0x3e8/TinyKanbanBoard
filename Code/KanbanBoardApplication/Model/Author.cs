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
        private bool isDirty;

        public Guid Id
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.isDirty = true;
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
                    this.isDirty = true;
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
                    this.isDirty = true;
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
                    this.isDirty = true;
                }
            }
        }

        public bool IsDirty
        {
            get { return this.isDirty; }
            set { this.isDirty = value; }
        }
    }
}
