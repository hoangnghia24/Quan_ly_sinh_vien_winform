using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using DAL;

namespace DALLLib
{
    public class ClassDAL
    {
        public List<Classes> GetAllClasses()
        {
            List<Classes> Class = new List<Classes>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Class_id, Start_time, End_time, Day_of_week FROM Classes";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Class.Add(new Classes
                    {
                        Class_id = reader.GetString(0),
                        Start_time = reader.GetTimeSpan(1),
                        End_time = reader.GetTimeSpan(2),
                        Day_of_week = reader.GetString(3),
                    });
                }
            }

            return Class;
        }

        // Thêm giảng viên mới
        public bool InsertClass(Classes Class)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Classes (Class_id, Start_time, End_time, Day_of_week) VALUES (@Class_id, @Start_time, @End_time, @Day_of_week)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Class_id", Class.Class_id);
                cmd.Parameters.AddWithValue("@Start_time", Class.Start_time);
                cmd.Parameters.AddWithValue("@End_time", Class.End_time);
                cmd.Parameters.AddWithValue("@Day_of_week", Class.Day_of_week);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật giảng viên
        public bool UpdateClass(Classes Class)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Classes SET Start_time = @Start_time, End_time = @End_time, Day_of_week = @Day_of_week WHERE Class_id = @Class_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Class_id", Class.Class_id);
                cmd.Parameters.AddWithValue("@Start_time", Class.Start_time);
                cmd.Parameters.AddWithValue("@End_time", Class.End_time);
                cmd.Parameters.AddWithValue("@Day_of_week", Class.Day_of_week);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa giảng viên
        public bool DeleteClass(String Class_id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Classes WHERE Class_id = @Class_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Class_id", Class_id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm giảng viên theo Student_id hoặc Full_name
        public List<Classes> SearchClass(string Class_id, string Day_of_week)
        {
            List<Classes> ClassList = new List<Classes>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Class_id, Start_time, End_time, Day_of_week FROM Classes WHERE 1=1";

                if (!string.IsNullOrEmpty(Class_id))
                    query += " AND Class_id LIKE @Class_id";
                if (!string.IsNullOrEmpty(Day_of_week))
                    query += " AND Day_of_week LIKE @Day_of_week";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(Class_id))
                        cmd.Parameters.AddWithValue("@Class_id", "%" + Class_id + "%");
                    if (!string.IsNullOrEmpty(Day_of_week))
                        cmd.Parameters.AddWithValue("@Day_of_week", "%" + Day_of_week + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClassList.Add(new Classes
                            {
                                Class_id = reader.GetString(0),
                                Start_time = reader.GetTimeSpan(1),
                                End_time = reader.GetTimeSpan(2),
                                Day_of_week = reader.GetString(3),
                            });
                        }
                    }
                }
            }

            return ClassList;
        }
    }
}
