using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class HourlyWorker : Worker
    {

        public string name;
        public int age;
        public double rate;
        public double hours;
        public int pos_id = 2;
        public int dep_id;
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


        public HourlyWorker(string name,int age, double rate, double hours) : base(name, age,rate)
        {
            this.name = name;
            this.age = age;
            this.rate = rate;
            this.hours = hours;
        }

        public override double CalculateSalary()
        {
            //Console.WriteLine("Hourly worker salary = " + rate *hours* 22);
            return rate * hours * 22;
        }

        public override void ShowWorker()
        {
            Console.WriteLine(name + " " + age + '\n');
            CalculateSalary();

        }

    }
}
