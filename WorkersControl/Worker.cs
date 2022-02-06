using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class Worker
    {
        private string name;
        private int  birthYear;
        private string position;
        private double salary;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int BirthYear
        {
            get { return birthYear; }
            set { birthYear = value; }

        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }



        public Worker(string name, int birthYear, string position, double salary)
        {
            this.name = name;
            this.birthYear = birthYear; 
            this.position = position;   
            this.salary = salary;


        }


        
        public void ShowWorker()
        {
            Console.WriteLine( name + " " + birthYear + " " + position + " "+ salary);
        }      

    }
}
