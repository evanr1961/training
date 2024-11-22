using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHiveMgmt
{
    public class EggCare : Bee
    {
        private const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        private Queen queen;

        public EggCare(Queen queen) : base(EGGCARE)
        {
            this.queen = queen;
        }

        public override float CostPerShift { get { return 1.35f; } }

        protected override void DoJob(string job)
        {

            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
