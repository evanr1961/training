using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHiveMgmt
{
    internal class HiveDefender:Bee, IDefend
    {
        public HiveDefender() : base(HIVEDEFENDER) { }
        public override float CostPerShift { get { return 1.35f; } }

        protected override void DoJob(string job)
        {
            return;
        }
        public void DefendHive() 
        {
            return;
        }
    }
}
