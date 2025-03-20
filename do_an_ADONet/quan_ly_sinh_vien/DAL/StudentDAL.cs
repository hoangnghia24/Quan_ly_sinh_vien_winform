using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.Policy;

namespace DALLib
{
    public class StudentDAL
    {
        // Lấy danh sách sinh viên
        public List<Students> GetAllStudents()
        {
            List<Students> students = new List<Students>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Student_id, Full_name, Date_of_birth, Gender, Full_address, Email, Phone_number, Class_id FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Students
                    {
                        Student_id = reader.GetString(0),
                        Full_name = reader.GetString(1),
                        Date_of_birth = reader.GetDateTime(2),
                        Gender = reader.GetByte(3),
                        Full_address = reader.GetString(4),
                        Email = reader.GetString(5),
                        Phone_number = reader.GetString(6),
                        Class_id = reader.GetString(7),
                    });
                }
            }

            return students;
        }

        // Thêm sinh viên mới
        public bool InsertStudent(Students students)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Students (Student_id, Full_name, Date_of_birth, Gender, Full_address, Email, Phone_number, Class_id) VALUES (@Student_id, @Full_name, @Date_of_birth, @Gender, @Full_address, @Email, @Phone_number, @Class_id)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Student_id", students.Student_id);
                cmd.Parameters.AddWithValue("@Full_name", students.Full_name);
                cmd.Parameters.AddWithValue("@Date_of_birth", students.Date_of_birth);
                cmd.Parameters.AddWithValue("@Gender", students.Gender);
                cmd.Parameters.AddWithValue("@Full_address", students.Full_address);
                cmd.Parameters.AddWithValue("@Email", students.Email);
                cmd.Parameters.AddWithValue("@Phone_number", students.Phone_number);
                cmd.Parameters.AddWithValue("@Class_id", students.Class_id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật sinh viên
        public bool UpdateStudent(Students students)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Students SET Student_id = @Student_id, Full_name = @Full_name, Date_of_birth = @Date_of_birth, Gender = @Gender, Full_address = @Full_address, Email = @Email, Phone_number = @Phone_number, Class_id = @Class_id WHERE Student_id = @Student_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Student_id", students.Student_id);
                cmd.Parameters.AddWithValue("@Full_name", students.Full_name);
                cmd.Parameters.AddWithValue("@Date_of_birth", students.Date_of_birth);
                cmd.Parameters.AddWithValue("@Gender", students.Gender);
                cmd.Parameters.AddWithValue("@Full_address", students.Full_address);
                cmd.Parameters.AddWithValue("@Email", students.Email);
                cmd.Parameters.AddWithValue("@Phone_number", students.Phone_number);
                cmd.Parameters.AddWithValue("@Class_id", students.Class_id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa sinh viên
        public bool DeleteStudent(String Student_id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Students WHERE Student_id = @Student_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Student_id", Student_id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm sinh viên
        // Tìm kiếm sinh viên theo Student_id hoặc Full_name
        public List<Students> SearchStudent(string student_id, string full_name)
        {
            List<Students> studentsList = new List<Students>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Student_id, Full_name, Date_of_birth, Gender, Full_address, Email, Phone_number, Class_id FROM Students WHERE 1=1";

                if (!string.IsNullOrEmpty(student_id))
                    query += " AND Student_id LIKE @Student_id";
                if (!string.IsNullOrEmpty(full_name))
                    query += " AND Full_name LIKE @Full_name";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(student_id))
                        cmd.Parameters.AddWithValue("@Student_id", "%" + student_id + "%");
                    if (!string.IsNullOrEmpty(full_name))
                        cmd.Parameters.AddWithValue("@Full_name", "%" + full_name + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsList.Add(new Students
                            {
                                Student_id = reader.GetString(0),
                                Full_name = reader.GetString(1),
                                Date_of_birth = reader.GetDateTime(2),
                                Gender = reader.GetByte(3),
                                Full_address = reader.GetString(4),
                                Email = reader.GetString(5),
                                Phone_number = reader.GetString(6),
                                Class_id = reader.GetString(7)
                            });
                        }
                    }
                }
            }

            return studentsList;
        }
    }
}