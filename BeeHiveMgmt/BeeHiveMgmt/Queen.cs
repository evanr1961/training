using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BeeHiveMgmt
{
    public class Queen : Bee, INotifyPropertyChanged
    {
        const float EGGS_PER_SHIFT = 0.45f;
        const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        
   
        private string statusReport = "Empty";
        public string StatusReport { get { return statusReport; } }

        private float eggs = 0;
        private float unassignedWorkers = 2;
        private IWorker[] workers;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override float CostPerShift { get { return 2.15f; } }

        public Queen() : base("Queen")
        {
            AssignBee(EGGCARE);
            AssignBee(HONEYMANUFACTURER);
            AssignBee(NECTORCOLLECTOR);

        }
 
        public void AssignBee( string JobName )
        {
            switch (JobName )
            {
                case EGGCARE:
                    AddWorker(new EggCare(this));
                    break;

                case HONEYMANUFACTURER:
                    AddWorker(new HoneyManufacturer());
                    break;

                case NECTORCOLLECTOR:
                    AddWorker(new NectarCollector());
                    break;

                default:
                    break;

            }
            this.UpdateStatusReport();
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        private void UpdateStatusReport()
        {
            int nectorCollector = 0;
            int honeyManufacturer = 0;
            int eggCare = 0;
            int defender = 0;

            foreach(IWorker worker in workers)
            {
                switch (worker.Job)
                {
                    case EGGCARE:
                        eggCare++;
                        break;

                    case HONEYMANUFACTURER:
                        honeyManufacturer++;
                        break;

                    case NECTORCOLLECTOR:
                        nectorCollector++;
                        break;

                    case HIVEDEFENDER:
                        defender++;
                        break;

                    default:
                        break;

                }
            }
            statusReport = HoneyVault.StatusReport() +
                "\nEgg count: " + eggs.ToString("F") +
                "\nUnassigned Workers: " + unassignedWorkers.ToString("F") +
                "\n" + nectorCollector + " Nectar Collector bees" +
                "\n" + honeyManufacturer + " Honey Manufacture bees" +
                "\n" + eggCare + " Egg Care bees" +
                "\n" + defender + " Defenders" + 
                "\nTOTAL WORKERS: " + (nectorCollector + honeyManufacturer + eggCare + defender);

            OnPropertyChanged("StatusReport");
        }

        protected override void DoJob(string job)
        {
            eggs += EGGS_PER_SHIFT;

            foreach(Bee bee in  workers)
            {
                bee.WorkTheNextShift();
            }

            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);

            UpdateStatusReport();

        }

        private void AddWorker(Bee worker) 
        { 
            if (unassignedWorkers >= 1)
            {
                if (workers == null)
                {
                    workers = new Bee[1];
                    workers[0]= worker;
                }
                else
                {
                    unassignedWorkers--;
                    Array.Resize(ref workers, workers.Length + 1);
                    workers[workers.Length - 1] = worker;
                }
            }
        }

        
    }
}
