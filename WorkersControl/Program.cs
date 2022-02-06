using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            WorkersDatabase workersDatabase = new WorkersDatabase();
            workersDatabase.Start();    
        }
    }
}
