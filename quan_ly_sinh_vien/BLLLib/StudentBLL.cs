using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;
using System.Text.RegularExpressions;
using DALLLib;

namespace BLLLib
{
    public class StudentBLL
    {
        private StudentDAL studentDAL = new StudentDAL();
        public List<Students> GetAllStudents()
        {
            return studentDAL.GetAllStudents();
        }

        public bool InsertStudent(Students students)
        {
            if (string.IsNullOrEmpty(students.Full_name) || string.IsNullOrEmpty(students.Student_id))
                return false;

            return studentDAL.InsertStudent(students);
        }

        public bool UpdateStudent(Students students)
        {
            if (students == null || string.IsNullOrWhiteSpace(students.Student_id))
                return false;

            return studentDAL.UpdateStudent(students);
        }

        public bool DeleteStudent(string Student_id)
        {
            if (string.IsNullOrEmpty(Student_id))
                return false;

            return studentDAL.DeleteStudent(Student_id);
        }

        public List<Students> SearchStudent(string student_id, string full_name)
        {
            return studentDAL.SearchStudent(student_id, full_name);
        }
    }
}
