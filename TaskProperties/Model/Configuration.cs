using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProperties.Model
{
    public class Configuration
    {
        public static List<string> Type = new List<string>() { "Continuous", "Periodic", "Event" };
        public static List<string> Trigger = new List<string>() { "Axis Watch", "Axis Registration 1", "Axis Registration 2","Motion Group Execution","Event Instruction Only","Module Input Data State Change","Consumed Tag" };

        public static List<string> GetTypeList()
        {
            return Type;
        }

        public static List<string> GetTriggerList()
        {
            return Trigger;
        }
    }
}
