using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BeeHiveMgmt
{
    public static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = 0.19f;
        public const float LOW_LEVAL_WARNING = 10f;
        
        private static float honey = 25f;
        private static float nectar = 100f;

        public static string StatusReport()
        {
                 string report =
                    $"Honey: {honey:0.0}\n" +
                    $"Nectar: {nectar:0.0}\n";

                if (honey < LOW_LEVAL_WARNING)
                {
                    report += "LOW HONEY - ADD A HONEY MANUFACTURER\n";
                }

                if (nectar < LOW_LEVAL_WARNING)
                {
                    report += "LOW NECTOR - ADD A NECTOR COLLECTOR\n";
                }
                return report;

        }
        public static void CollectNectar( float amount)
        {
            nectar += (amount > 0) ? amount : 0f;
        }

        public static void ConvertNectarToHoney( float amount)
        {
            amount = (amount < nectar) ? amount : nectar;

            nectar -= amount;
            honey += amount * NECTAR_CONVERSION_RATIO;

        }

        public static bool ConsumeHoney( float amount)
        {
            if (amount < honey)
            {
                honey -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
