using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damage
{
    class ArrowDamageCalculator
    {
        public const decimal BASE_MULTIPLIER = 0.35M;
        public const decimal MAGIC_MULTIPLIER = 2.5M;
        public const decimal FLAME_DAMAGE = 1.25M;


        private decimal MagicMultiplier = 1M;
        private decimal FlamingDamage = 0M;
        public int Damage;
        private int roll = 0;
        private bool magic;
        private bool flaming;

        public int Roll
        {
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
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) { baseDamage *= MAGIC_MULTIPLIER; }
            if (Flaming) { Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE); }
            else { Damage = (int)Math.Ceiling(baseDamage); }

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
                    FlamingDamage = 0M;
                }
                CalculateDamage();
            }
        }
        public ArrowDamageCalculator()
        {
            CalculateDamage();
        }
    }

}
