using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace BeeHiveMgmt
{
    public class NectarCollector : Bee
    {
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public NectarCollector() : base(NECTORCOLLECTOR) {  }
        public override float CostPerShift { get { return 1.95f; } }

        protected override void DoJob(string job)
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT); 
        }
    }
}
