using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHiveMgmt
{
    public class HoneyManufacturer : Bee
    {
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
        public HoneyManufacturer() : base(HONEYMANUFACTURER) {  }
        public override float CostPerShift { get { return 1.7f;  } }

        protected override void DoJob(string job)
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}