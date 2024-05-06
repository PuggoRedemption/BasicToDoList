using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicToDoList
{
    internal class Task
    {
        //public Guid TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskComplete { get; set; }
    }
}
