using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workitemdll;
using changereportdll;

namespace Activity_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Workitem item = new Workitem("Fix Bugs", "Fix all bugs in my code branch", new TimeSpan(3, 4, 0, 0));
            ChangeRequest change = new ChangeRequest("Change Base Class Design", "Add members to the class", new TimeSpan(4, 0, 0), 1);

            Console.WriteLine(item.ToString());
            change.Update("Change the Design of the Base Class", new TimeSpan(4, 0, 0));
            Console.WriteLine(change.ToString());

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();



        }
    }
}
