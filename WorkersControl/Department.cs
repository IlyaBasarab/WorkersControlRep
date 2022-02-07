﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class Department
    {
         string departmentName;
        private int depIndx=0;
        
        List <Worker> department = new List<Worker>();
        

        public Department(string departmentName)
        {
            this.departmentName = departmentName;
        }

        public string DepartmentName
            {
            get { return departmentName; }
            set { departmentName = value; }
            }

        

        public void AddToDepartment(Worker worker)
        {
            department[depIndx]=worker;            
            Console.WriteLine("Worker added to department");
            depIndx++;
        }

        public void DeleteFromDep(Worker worker)
        {
            for (int i = 0; i < department.Count - 1; i++)
            {
                if (department[i] == worker)
                    department[i] = department[i + 1];
                
            }
            depIndx--;
            
        }

        public bool InDepartment(Worker worker)
        {
            for(int i = 0; i <=department.Count; i++)
            {
                if (department.Contains(worker))
                    return true;
            }
            
            return false;

        }


    }
}
