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
        private double hours;
        private int days;
        private bool present;
        private int pos_id = 3;
        private int dep_id;


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

        public Trainee(string name,  int age, double rate, double hours, int days) : base(name, age, rate)
        {
            this.name = name;
            this.age = age;
            this.rate = rate;
            this.hours=hours;
            this.days = days;
        }

        public override double CalculateSalary()
        {
            //Console.WriteLine("Trainee salary = " + rate* hours * days);
            return rate* hours * days;
        }

        public override void ShowWorker()
        {
            Console.WriteLine(name + " " + age + '\n');
            CalculateSalary();

        }

    }
}
