using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Students
    {
        public string Student_id { get; set; }
        public string Full_name { get; set; }
        public DateTime Date_of_birth { get; set; }
        public byte Gender { get; set; }
        public string Full_address { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }

        public string Class_id { get; set; }
    }
}
