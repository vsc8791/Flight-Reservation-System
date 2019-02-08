
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace BOL
{
   public class Schedule
    {
        public int ScheduleId { get; set; }
        public String CourseName { get; set; }
        public String BatchName { get; set; }
        public String SubjectName { get; set; }
        public String FacultyName { get; set; }
        public String Timing { get; set; }
        public String Venue { get; set; }
        public String DateOfLec { get; set; }

    }
}
