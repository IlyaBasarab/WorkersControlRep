using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class WorkersDatabase
    {

        DatabaseOptions options=new DatabaseOptions();
        
        List <Worker> workers = new List<Worker>();
        List <Department> departments = new List<Department>();
        int indx=0;
        int depIndx = 0;
        

        public void SetWorker(Worker workerToSet)
        {
            try
            {
                workers[indx] =workerToSet;
                workerToSet.Present = true;
                options.AddWorkerToDB(workerToSet);
                Console.WriteLine("Worker "+workerToSet.Name+ " added to database");
                
                indx++;

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Worker could not be set");
            }


        }

        public void Fire(int fIndx)
        {
            workers[fIndx].Present = false;
            Console.WriteLine(workers[fIndx].Name +" fired.");
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
                workers[i].Present=false;
                workers[i] = workers[i + 1];


            }
            indx--;

        }


        public void GetWorker(string workerToGet)
        {

            options.GetWorker(workerToGet);
            //try
            //{
            //    for(int i=0;i<workers.Count-1;i++)
            //    {
            //        if(workers[i]!=null)
            //        if (workers[i].Name == workerToGet)
            //                workers[i].ShowWorker();
            //        else
            //            Console.WriteLine("No such profile found");
            //    }  
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex);
            //}
            
        }

        public void GetAllWorkers()
        {
            try
            {
                options.GetAllWorkers();

                //foreach (var item in workers)
                //{
                //    if(item!=null&& item.Present)
                //        item.ShowWorker();
                //}

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
                   "[1] Enter worker  data to set" + '\n' +
                   "[2] Choose worker to get info" + '\n' +
                   "[3] View all workers" + '\n' +
                   "[4] Modify worker" + '\n' +
                   "[5] Fire worker"+'\n'+
                   "[6] Delete worker" + '\n'+
                   "[7] Exit program" + '\n'
                   );


                digit = Int16.Parse(Console.ReadLine());

                switch (digit)
                {
                    case 1:
                        Console.WriteLine("Enter worker name:  ");
                        string enteredName = Console.ReadLine();
                        Console.WriteLine("Enter worker age: ");
                        int enteredAge = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter worker rate: ");
                        double enteredRate = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter worker department: ");
                        string enteredDep = Console.ReadLine();

                        Console.WriteLine("Enter worker position:"+'\n'+
                            "1.Fixed worker"+'\n'+
                            "2.Hourly worker"+'\n'+
                            "3.Trainee");
                        int enteredPosition = Int32.Parse(Console.ReadLine());


                        if (enteredPosition == 1)
                        {
                            FixedWorker fWorker = new FixedWorker(enteredName, enteredAge, enteredRate);
                           
                            SetWorker(fWorker);
                            for(int i=0; i<departments.Count-1;i++)
                            {
                                if (departments[i].DepartmentName == enteredDep)
                                {
                                    departments[i].AddToDepartment(fWorker);
                                }
                                else
                                {
                                    departments[i] = new Department(enteredDep,i);
                                    departments[i].AddToDepartment(fWorker);

                                }
                            }
                        }
                        else if (enteredPosition == 2)
                        {
                            Console.WriteLine("Enter workered hours:");
                            double enteredHours = Double.Parse(Console.ReadLine());
                            Worker hWorker = new HourlyWorker(enteredName, enteredAge, enteredRate, enteredHours);
                            SetWorker(hWorker);

                            for (int i = 0; i < departments.Count - 1; i++)
                            {
                                if (departments[i].DepartmentName == enteredDep)
                                {
                                    departments[i].AddToDepartment(hWorker);
                                }
                                else
                                {
                                    departments[i] = new Department(enteredDep,i);
                                    departments[i].AddToDepartment(hWorker);

                                }
                            }



                        }
                        else if (enteredPosition == 3)
                        {
                            Console.WriteLine("Enter workered hours:");
                            double enteredHours = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter workered days:");
                            int enteredDays = Int32.Parse(Console.ReadLine());
                            Worker trainee = new Trainee(enteredName, enteredAge, enteredRate, enteredHours, enteredDays);
                            SetWorker(trainee);

                            for (int i = 0; i < departments.Count - 1; i++)
                            {
                                if (departments[i].DepartmentName == enteredDep)
                                {
                                    departments[i].AddToDepartment(trainee);
                                }
                                else
                                {
                                    departments[i] = new Department(enteredDep,i);
                                    departments[i].AddToDepartment(trainee);

                                }
                            }


                        }
                

  break;

                    case 2:
                        Console.WriteLine(@"Type worker index to get info:" + '\n');
                        string inprofile = Console.ReadLine();
                        GetWorker(inprofile);


                        break;

                    case 3:

                        Console.WriteLine("List of all workers below:" + '\n');
                        GetAllWorkers();

                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Which worker would you like to modify?" + '\n');
                            int modIndx = Int32.Parse(Console.ReadLine());
                            if(workers[modIndx].Present){
                                Console.WriteLine("What would you like to modify?" + '\n' +
                                    "[1]Name" + '\n' +
                                    "[2]Age" + '\n' +
                                    "[3]Rate" + '\n' +
                                    "[4]Department");
                                int value = Int32.Parse(Console.ReadLine());

                                if (value == 1)
                                {
                                    Console.WriteLine("Enter worker's new name:  " + '\n');
                                    workers[modIndx].Name = Console.ReadLine();
                                }
                                else if (value == 2)
                                {
                                    Console.WriteLine("Enter worker's new age: " + '\n');
                                    workers[modIndx].Age = Int32.Parse(Console.ReadLine());
                                }
                                else if (value == 3)
                                {
                                    Console.WriteLine("Enter new worker's rate:");
                                    workers[modIndx].Rate = Int32.Parse(Console.ReadLine());
                                }
                                else if (value==4)
                                {
                                    Console.WriteLine("Enter worker's new department");
                                    string newDep = Console.ReadLine();
                                    for (int i = 0; i <= depIndx; i++)
                                    { 
                                        if (departments[i].InDepartment(workers[modIndx]))
                                        departments[i].DeleteFromDep(workers[modIndx]);
                                    }

                                    for (int i = 0; i <= departments.Count; i++)
                                    {
                                        if (departments[i].DepartmentName == newDep)
                                            departments[i].AddToDepartment(workers[modIndx]);
                                        else
                                        {
                                            departments[i] =new Department(newDep,i);
                                            departments[i].AddToDepartment(workers[modIndx]);
                                            depIndx++;
                                        }
                                    }


                                }
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Invalid worker profile");
                        }


                        break;


                    case 5:



                        break;

                    case 6:
                        Console.WriteLine("Which worker index you would like to delete?" + '\n');
                        int delIndx = Int32.Parse(Console.ReadLine());
                        Delete(delIndx);

                        break;

                    case 7:
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
