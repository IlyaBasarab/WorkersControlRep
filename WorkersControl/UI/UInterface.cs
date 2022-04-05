using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    internal class UInterface
    {
        public int UserMenu()
        {
            Console.WriteLine(" Choose your function:" +
                  '\n' + "Variants:" + '\n' +
                  "[1] Enter worker  data to set" + '\n' +
                  "[2] Choose worker to get info" + '\n' +
                  "[3] View all workers" + '\n' +
                  "[4] Modify worker" + '\n' +
                  "[5] Fire worker" + '\n' +
                  "[6] Delete worker" + '\n' +
                  "[7] Exit program" + '\n'
                  );
            return Int16.Parse(Console.ReadLine());
        }


    }
}
