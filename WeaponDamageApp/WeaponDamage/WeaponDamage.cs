using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    internal class WeaponDamage
    {
        private int roll = 0;
        public int Roll
        {
            get { return roll; }
            set { roll = value; CalculateDamage(); }
        }
        
        bool magic = false;
        public bool Magic
        {
            get { return magic; }
            set { magic = value; CalculateDamage(); }
        }

        bool flaming = false;
        public bool Flaming
        {
            get { return flaming; }
            set { flaming = value; CalculateDamage(); }
        }

        public int Damage { get; protected set; }

        public WeaponDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
        protected virtual void CalculateDamage()
        {
            return;
        }
    }
}
