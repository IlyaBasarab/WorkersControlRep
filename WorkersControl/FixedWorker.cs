using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class FixedWorker : Worker
    {
        private string name;
        private int age;
        private double rate;
        private bool present;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return Age; }
            set { Age = value; }

        }
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }



        public FixedWorker(string name, int age,double rate) : base(name, age, rate)
        {
            this.name = name;
            this.age = age;
            this.rate = rate;  }


        public override void CalculateSalary()
        {
            Console.WriteLine( "Worker salary = "+rate*22);
            
        }
        public override void ShowWorker()
        {
            Console.WriteLine(name + " " + age + '\n' + "Salary : ");
            CalculateSalary();

        }


    }

}
