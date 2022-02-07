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

        public FixedWorker(string name, int age,double rate) : base(name, age, rate)
        {
             
        }


        public override void CalculateSalary()
        {
            Console.WriteLine( "Worker salary = "+rate*22);
            
        }
        public override void ShowWorker()
        {
            Console.WriteLine(name + " " + age + '\n');
            CalculateSalary();

        }


    }

}
