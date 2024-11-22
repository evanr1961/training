using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordDamage
{
    class SwordDamageCalculator
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        
        private Decimal MagicMultiplier = 1M;
        private int FlamingDamage = 0;
        public int Damage;
        private int roll = 0;
        private bool magic;
        private bool flaming;

        public int Roll {  
            get { return roll; } 
            set
            {
                if (value > 0)
                {
                    roll = value;
                    CalculateDamage();
                }
            } 
        }


        private void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
        }

        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                if (magic)
                {
                    MagicMultiplier = 1.75M;
                }
                else
                {
                    MagicMultiplier = 1M;
                }
                CalculateDamage();
            }
        }

        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;

                if (flaming)
                {
                    FlamingDamage = FLAME_DAMAGE;
                }
                else
                {
                    FlamingDamage = 0;
                }
                CalculateDamage();
            }
        }
    }
}
