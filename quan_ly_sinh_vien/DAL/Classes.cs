using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Classes
    {
        public string Class_id { get; set; }  
        public TimeSpan Start_time { get; set; }  
        public TimeSpan End_time { get; set; }   
        public string Day_of_week { get; set; }
    }
}
