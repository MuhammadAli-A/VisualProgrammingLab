using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workitemdll
{
    public class Workitem
    {
        private static int currentID;

        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan JobLength { get; set; }

        public Workitem()
        {
            ID = 0;
            Title = "Default title";
            Description = "Default description.";
            JobLength = new TimeSpan();
        }

        public Workitem(string title, string desc, TimeSpan jobLen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.JobLength = jobLen;
        }

        static Workitem()
        {
            currentID = 0;
        }

        protected int GetNextID()
        {
            return ++currentID;
        }

        public void Update(string title, TimeSpan jobLen)
        {
            this.Title = title;
            this.JobLength = jobLen;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", this.ID, this.Title);
        }
    }

}
