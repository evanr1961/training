using System;
using System.Collections.Generic;
using System.Linq;
using WixToolset.Dtf.WindowsInstaller;

namespace MyCSharpCustomAction1
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult MyCSharpCA1(Session session)
        {
            session.Log("Begin MyCSharpCA1");

            session.Log("End MyCSharpCA1");
            return ActionResult.Success;
        }
    }
}
