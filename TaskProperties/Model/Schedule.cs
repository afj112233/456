using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProperties.Model{

    public class Schedule
    {
        public static List<string> ScheduleList = new List<string>(){"MainTask","ZhangSan","LiSi"};
        public static List<string> UnscheduleList = new List<string>() { "Wangwu", "Lee", "UselessTask" };
        public static  List<string> GetScheduled()
        {
            return ScheduleList;
        }
        public static  List<string> GetUnscheduled()
        {
            return UnscheduleList;
        }
    }
}
