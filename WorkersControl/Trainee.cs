using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class Trainee : Worker
    {

        public string name;
        public int age;
        public double rate;        
        public double hours;
        public int days;
        public bool present;


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

        public Trainee(string name,  int age, double rate, double hours, int days) : base(name, age, rate)
        {
            this.name = name;
            this.age = age;
            this.rate = rate;
            this.hours=hours;
            this.days = days;
        }

        public override void CalculateSalary()
        {
            Console.WriteLine("Trainee salary = " + rate* hours * days);
        }

        public override void ShowWorker()
        {
            Console.WriteLine(name + " " + age + '\n');
            CalculateSalary();

        }

    }
}
