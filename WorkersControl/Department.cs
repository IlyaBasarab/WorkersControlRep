using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    class Department
    {
         string departmentName;
        int departmentId;
        public int depIndx=0;
        
        List <Worker> department = new List<Worker>();
        

        public Department(string departmentName, int departmentId)
        {
            this.departmentName = departmentName;
            this.departmentId = departmentId;
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
            worker.dep_id= departmentId;
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
