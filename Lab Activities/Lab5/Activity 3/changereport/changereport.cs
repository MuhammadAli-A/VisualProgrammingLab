using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workitemdll;

namespace changereportdll
{
    public class ChangeRequest : Workitem
    {
        protected int originalItemID { get; set; }

        public ChangeRequest() { }

        public ChangeRequest(string title, string desc, TimeSpan jobLen, int originalID)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.JobLength = jobLen;
            this.originalItemID = originalID;
        }

        public ChangeRequest(int originalItemID)
        {
            this.originalItemID = originalItemID;
        }
    }

}
