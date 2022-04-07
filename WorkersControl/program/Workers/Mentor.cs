using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersControl
{
    internal class Mentor
    {
        public string Name { get; set; }

        public int Mentor_Id { get; set; }
        public Mentor( Worker worker)
        {
            Name = worker.Name;
            Mentor_Id = worker.worker_id;
        }


    }
}
