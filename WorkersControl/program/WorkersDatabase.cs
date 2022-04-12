using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class WorkersDatabase
    {

        DataAccessObject dao=new DataAccessObject();
        UInterface menu = new UInterface();

        //List<Worker> workers = new List<Worker>();
        //List<Department> departments = new List<Department>();
        //int indx=0;
        //int depIndx = 0;
        

        public void SetWorker(Worker workerToSet)
        {
            try
            {
                dao.AddWorkerToDB(workerToSet);
                Console.WriteLine("Worker "+workerToSet.Name+ " added to database");
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Worker could not be set");
            }


        } //+

        public void Fire(int fIndx)
        {
            //workers[fIndx].Present = false;
            //Console.WriteLine(workers[fIndx].Name +" fired.");
        }

        public void Update(int index, Worker upWorker)
        {
           // workers [index] = upWorker;

        }



        public void Delete(int worker)
        {
            try
            {
                dao.DeleteWorker(worker);
                Console.WriteLine("Worker with Id: " + worker+ " deleted");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("An error occured: "+ ex);
            }

        }//+


        public void GetWorker(int workerIDToGet)
        {

            
            try
            {
                dao.GetWorker(workerIDToGet);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

        } //+

        public void GetAllWorkers()
        {
            try
            {
                dao.GetAllWorkers();

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
                digit = menu.MainMenu();

                switch (digit)
                {
                    case 1:

                        Worker worker = menu.SetNewWorkerMenu();
                        SetWorker( worker);

                        break;

                    case 2:
                        Console.WriteLine(@"Type worker ID to get info:" + '\n');
                        int inprofile = Convert.ToInt32(Console.ReadLine());
                        GetWorker(inprofile);


                        break;

                    case 3:

                        Console.WriteLine("List of all workers below:" + '\n');
                        GetAllWorkers();
                        Console.WriteLine("");

                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Type worker ID to modify:" + '\n');
                            int modIndx = Int32.Parse(Console.ReadLine());
                            if(dao.WorkerExist(modIndx)){

                                dao.UpdateWorker(modIndx, menu.UpdateWorkerMenu(dao.GetWorker(modIndx)));   
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Invalid worker profile");
                        }
                        break;


                    case 5:

                        int infoChoise=menu.WorkerInfoMenu();
                        switch(infoChoise)
                        {
                            case 1:
                                dao.GetWorkersTotalCartPrice();
                                break;
                            case 2:
                                dao.GetTrainees();
                                break;
                            case 3:
                                dao.GetCatCountByDep();
                                break;
                            default:
                                break;
                        }



                        break;

                    case 6:
                        try {

                            Console.WriteLine("Type worker ID you would like to delete?" + '\n');
                            int workerDel = Int32.Parse(Console.ReadLine());
                            Delete(workerDel);
                            }
                        catch(Exception ex) { Console.WriteLine("An error occured: " + ex); };

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
