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
    public class ClassBLL
    {
        private ClassDAL classDAL = new DALLLib.ClassDAL();

        public List<Classes> GetAllClasses()
        {
            return classDAL.GetAllClasses();
        }

        public bool InsertClass(Classes Class)
        {
            if (string.IsNullOrEmpty(Class.Class_id) || string.IsNullOrEmpty(Class.Day_of_week))
                return false;

            return classDAL.InsertClass(Class);
        }

        public bool UpdateClass(Classes Class)
        {
            if (Class == null || string.IsNullOrWhiteSpace(Class.Class_id))
                return false;

            return classDAL.UpdateClass(Class);
        }

        public bool DeleteClass(string Class_id)
        {
            if (string.IsNullOrEmpty(Class_id))
                return false;

            return classDAL.DeleteClass(Class_id);
        }

        public List<Classes> SearchClass(string Class_id, string Day_of_week)
        {
            return classDAL.SearchClass(Class_id, Day_of_week);
        }
    }
}
