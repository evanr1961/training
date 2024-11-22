using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHiveMgmt
{
    public abstract class Bee: IWorker
    {
        public const string HONEYMANUFACTURER = "Honey Manufacturer";
        public const string EGGCARE = "Egg Care";
        public const string NECTORCOLLECTOR = "Nector Collector";
        public const string HIVEDEFENDER = "Hive Defender";

        public abstract float CostPerShift { get; }

        public Bee(string Job)
        {
            job = Job;
        }
        

        private string job;
        public string Job { get { return job; }  }


        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift) == true) 
            {
                DoJob(job);
            }
        }

        protected abstract void DoJob(string job);

    }
}
