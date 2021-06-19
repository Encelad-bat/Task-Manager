using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Model
{
    class _Task
    {
        private Process process;

        public Process Process
        {
            get { return process; }
            set { process = value; }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public _Task(Process process)
        {
            this.Process = process;
            if(process.Id.ToString().Length == 4)
            {
                this.Id = process.Id.ToString();
            }
            else
            {
                this.Id = process.Id.ToString();
                for (int i = 0; i <= 4-process.Id.ToString().Length; i++)
                {
                    this.Id += " ";
                }
            }
            this.Name = process.ProcessName;
        }
    }
}
