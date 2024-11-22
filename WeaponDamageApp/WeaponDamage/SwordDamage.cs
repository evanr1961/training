using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage
{
    internal class SwordDamage : WeaponDamage
    {

        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public SwordDamage(int startingRoll) : base(startingRoll) 
        { 
            
        }

        protected override void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;

            
        }
    }
}
