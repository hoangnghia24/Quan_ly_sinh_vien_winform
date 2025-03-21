using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DALLLib;
using System.Text.RegularExpressions;

namespace BLLLib
{
    public class LecturerBLL
    {
        private LecturerDAL LecturerDAL = new DALLLib.LecturerDAL();
        public List<Lecturers> GetAllLecturers()
        {
            return LecturerDAL.GetAllLecturers();
        }

        public bool InsertLecturer(Lecturers Lecturer)
        {
            if (string.IsNullOrEmpty(Lecturer.Lecturer_name) || string.IsNullOrEmpty(Lecturer.Lecturer_id))
                return false;

            return LecturerDAL.InsertLecturer(Lecturer);
        }

        public bool UpdateLecturer(Lecturers Lecturer)
        {
            if (Lecturer == null || string.IsNullOrWhiteSpace(Lecturer.Lecturer_id))
                return false;

            return LecturerDAL.UpdateLecturer(Lecturer);
        }

        public bool DeleteLecturer(string Lecturer_id)
        {
            if (string.IsNullOrEmpty(Lecturer_id))
                return false;

            return LecturerDAL.DeleteLecturer(Lecturer_id);
        }

        public List<Lecturers> SearchLecturer(string Lecturer_id, string Lecturer_name)
        {
            return LecturerDAL.SearchLecturer(Lecturer_id, Lecturer_name);
        }
    }
}
