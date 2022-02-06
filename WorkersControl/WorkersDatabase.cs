using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class WorkersDatabase
    {


        List <Worker>  workers = new List<Worker>();
        int indx=0;
        

        public void SetWorker(Worker workerToSet)
        {
            try
            {
                workers.Add(workerToSet);
                Console.WriteLine("Worker "+workerToSet.Name+ " added to database");
                indx++;

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Worker could not be set");
            }


        }


        public void Update(int index, Worker upWorker)
        {
            workers [index] = upWorker;

        }



        public void Delete(int delInx)
        {
            if (delInx < 0 || delInx >= indx)
                return;

            for (int i = delInx; i < workers.Count - 1; i++)
            {
                workers[i] = workers[i + 1];

            }
            indx--;

        }


        public void GetWorker(string workerToGet)
        {
            try
            {
                
                foreach (var item in workers)
                {
                    if (item.Name == workerToGet)
                        item.ShowWorker();
                    else
                        Console.WriteLine("No such profile found");
                }  
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public void GetAllWorkers()
        {
            try
            {

                foreach (var item in workers)
                {
                        item.ShowWorker();
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

        }



        public void Menu()
        {

            int digit;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine(" Choose your function:" +
                   '\n' + "Variants:" + '\n' +
                   "[1] Enter name , year of birth, position and salary of worker to set" + '\n' +
                   "[2] Choose worker to get info" + '\n' +
                   "[3] View all workers" + '\n' +
                   "[4] Modify worker" + '\n' +
                   "[5] Delete worker" + '\n'+
                   "[6] Exit rogram" + '\n'
                   );


                digit = Int16.Parse(Console.ReadLine());

                switch (digit)
                {
                    case 1:
                        Console.WriteLine("Enter worker name:  "+ '\n');
                        string enteredName = Console.ReadLine();
                        Console.WriteLine("Enter worker birth year: "+'\n');
                        int enteredYear = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter worker position");
                        string enteredPosition = Console.ReadLine();
                        Console.WriteLine("Enter worker salary:");
                        double enteredSalary = Double.Parse(Console.ReadLine());

                        Worker worker = new Worker(enteredName, enteredYear, enteredPosition, enteredSalary);

                        SetWorker(worker);


                        break;

                    case 2:
                        Console.WriteLine(@"Type worker index to get info:" + '\n');
                        string inprofile = Console.ReadLine();
                        GetWorker(inprofile);


                        break;

                    case 3:

                        Console.WriteLine(@"List of all workers below:" + '\n');
                        GetAllWorkers();

                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Which worker would you like to modify?" + '\n');
                            string modIndx = Console.ReadLine();
                            
                            Console.WriteLine(@"Enter new worker data." + '\n');

                            Console.WriteLine("Enter worker name:  " + '\n');
                            string newEnteredName = Console.ReadLine();
                            Console.WriteLine("Enter worker birth year: " + '\n');
                            int newEnteredYear = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter worker position");
                            string newEnteredPosition = Console.ReadLine();
                            Console.WriteLine("Enter worker salary:");
                            double newEnteredSalary = Double.Parse(Console.ReadLine());
                            Worker workerMod = new Worker(newEnteredName, newEnteredYear, newEnteredPosition, newEnteredSalary);

                            SetWorker(workerMod);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Invalid worker profile");
                        }


                        break;

                    case 5:
                        Console.WriteLine("Which worker index you would like to delete?" + '\n');
                        int delIndx = Int32.Parse(Console.ReadLine());
                        Delete(delIndx);

                        break;

                    case 6:
                        flag = false;
                        break;

                    default:
                        break;
                }
            }
        }
        

        public void Start()
        {
            Menu();

        }

        



    }
}
