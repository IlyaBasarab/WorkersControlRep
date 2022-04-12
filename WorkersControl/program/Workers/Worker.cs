using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    public abstract class Worker
    {
        private string name;
        private int  age;
        private bool present;
        private double rate;
        public int worker_id;
        public int pos_id;
        public int dep_id;

        public Worker(string name, int age, double rate)
        {
            this.name = name;
            this.age = age;
            this.rate = rate;
        }

        public abstract double CalculateSalary();
        public abstract void ShowWorker();


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }

        }
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        public bool Present
        {
            get { return present; }
            set { present = value; }
        }
    }

}
