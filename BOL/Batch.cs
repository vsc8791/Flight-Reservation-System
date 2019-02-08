using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BOL
{
   public class Batch
    {
        public int BatchId{ get; set; }
        public String BatchName { get; set; }
        public int BatchNOS { get; set; }
        public String BatchStart { get; set; }
        public String BatchEnd { get; set; }
        public String BatchDuration { get; set; }
        public String BatchProgress { get; set; }
        public String CourseOffered { get; set; }
    }
}
