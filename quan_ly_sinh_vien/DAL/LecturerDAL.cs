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
    public class LecturerDAL
    {
        // Lấy danh sách giảng viên
        public List<Lecturers> GetAllLecturers()
        {
            List<Lecturers> Lecturer = new List<Lecturers>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Lecturer_id, Lecturer_name, Email, Phone_number, gender FROM Lecturers";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lecturer.Add(new Lecturers
                    {
                        Lecturer_id = reader.GetString(0),
                        Lecturer_name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Phone_number = reader.GetString(3),
                        gender = reader.GetString(4),
                    });
                }
            }

            return Lecturer;
        }

        // Thêm giảng viên mới
        public bool InsertLecturer(Lecturers Lecturer)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Lecturers (Lecturer_id, Lecturer_name, Email, Phone_number, gender) VALUES (@Lecturer_id, @Lecturer_name, @Email, @Phone_number, @gender)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Lecturer_id", Lecturer.Lecturer_id);
                cmd.Parameters.AddWithValue("@Lecturer_name", Lecturer.Lecturer_name);
                cmd.Parameters.AddWithValue("@Email", Lecturer.Email);
                cmd.Parameters.AddWithValue("@Phone_number", Lecturer.Phone_number);
                cmd.Parameters.AddWithValue("@gender", Lecturer.gender);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật giảng viên
        public bool UpdateLecturer(Lecturers Lecturer)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Lecturers SET Lecturer_id = @Lecturer_id, Lecturer_name = @Lecturer_name, Email = @Email, Phone_number = @Phone_number, gender = @gender WHERE Lecturer_id = @Lecturer_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Lecturer_id", Lecturer.Lecturer_id);
                cmd.Parameters.AddWithValue("@Lecturer_name", Lecturer.Lecturer_name);
                cmd.Parameters.AddWithValue("@Email", Lecturer.Email);
                cmd.Parameters.AddWithValue("@Phone_number", Lecturer.Phone_number);
                cmd.Parameters.AddWithValue("@gender", Lecturer.gender);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa giảng viên
        public bool DeleteLecturer(String Lecturer_id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Lecturers WHERE Lecturer_id = @Lecturer_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Lecturer_id", Lecturer_id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm giảng viên theo Student_id hoặc Full_name
        public List<Lecturers> SearchLecturer(string Lecturer_id, string Lecturer_name)
        {
            List<Lecturers> LecturersList = new List<Lecturers>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Lecturer_id, Lecturer_name, Email, Phone_number, gender FROM Lecturers WHERE 1=1";

                if (!string.IsNullOrEmpty(Lecturer_id))
                    query += " AND Lecturer_id LIKE @Lecturer_id";
                if (!string.IsNullOrEmpty(Lecturer_name))
                    query += " AND Lecturer_name LIKE @Lecturer_name";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(Lecturer_id))
                        cmd.Parameters.AddWithValue("@Lecturer_id", "%" + Lecturer_id + "%");
                    if (!string.IsNullOrEmpty(Lecturer_name))
                        cmd.Parameters.AddWithValue("@Lecturer_name", "%" + Lecturer_name + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LecturersList.Add(new Lecturers
                            {
                                Lecturer_id = reader.GetString(0),
                                Lecturer_name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Phone_number = reader.GetString(3),
                                gender = reader.GetString(4),
                            });
                        }
                    }
                }
            }

            return LecturersList;
        }
    }
}
