using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    internal class UInterface
    {
        public int MainMenu()
        {
            Console.WriteLine(" Choose your function:" +
                  '\n' + "Variants:" + '\n' +
                  "[1] Enter worker  data to set" + '\n' +
                  "[2] Type worker to get info" + '\n' +
                  "[3] View all workers" + '\n' +
                  "[4] Modify worker" + '\n' +
                  "[5] Worker/Mentor/Cart information" + '\n' +
                  "[6] Delete worker" + '\n' +
                  "[7] Exit program" + '\n'
                  );
            return Int16.Parse(Console.ReadLine());
        }

        public Worker SetNewWorkerMenu()
        {
            Console.WriteLine("Enter worker name:  ");
            string enteredName = Console.ReadLine();
            Console.WriteLine("Enter worker age: ");
            int enteredAge = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter worker rate: ");
            double enteredRate = Double.Parse(Console.ReadLine());
            
            Worker worker = new FixedWorker(enteredName, enteredAge, enteredRate);
            return worker;
        }

        public Worker UpdateWorkerMenu(Worker baseWorker)
        {
            Console.WriteLine("What would you like to modify?" + '\n' +
                                        "[1]Name" + '\n' +
                                        "[2]Age" + '\n' +
                                        "[3]Rate");
            int value = Int32.Parse(Console.ReadLine());

            if (value == 1)
            {
                Console.WriteLine("Enter worker's new name:  " + '\n');
                string newName = Console.ReadLine();
                baseWorker.Name = newName;
            }
            else if (value == 2)
            {
                Console.WriteLine("Enter worker's new age: " + '\n');
                int newAge = Int32.Parse(Console.ReadLine());
                baseWorker.Age = newAge;
            }
            else if (value == 3)
            {
                Console.WriteLine("Enter new worker's rate:");
                double newRate = Int32.Parse(Console.ReadLine());
                baseWorker.Rate= newRate;
            } 
            return baseWorker;
        }

        public int WorkerInfoMenu()
        {
            Console.WriteLine("Variants:" + '\n' +
                  "[1] Get average cart price by worker ID " + '\n' +
                  "[2] Show employees who has mentor(with mentor's info)" + '\n' +
                  "[3]  " + '\n' 
                  );
            int infoChoise = Convert.ToInt32(Console.ReadLine());
            return infoChoise;
        }


    }
}
