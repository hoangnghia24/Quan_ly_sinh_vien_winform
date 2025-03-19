﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DAL;
//using System.Windows.Forms;

namespace DALLib
{
    public class StudentDAL
    {
        // Lấy danh sách sản phẩm
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

        // Thêm sản phẩm mới
        public bool InsertStudent(Students students)
        {
            //using (SqlConnection conn = DatabaseHelper.GetConnection())
            //{
            //    conn.Open();
            //    string query = "INSERT INTO Students (Student_id, Full_name, Date_of_birth, Gender, Full_address, Email, Phone_number, Class_id) VALUES (@Student_id, @Full_name, @Date_of_birth, @Gender, @Full_address, @Email, @Phone_number, @Class_id)";
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@Student_id", students.Student_id);
            //    cmd.Parameters.AddWithValue("@Full_name", students.Full_name);
            //    cmd.Parameters.AddWithValue("@Date_of_birth", students.Date_of_birth);
            //    cmd.Parameters.AddWithValue("@Gender", students.Gender);
            //    cmd.Parameters.AddWithValue("@Full_address", students.Full_address);
            //    cmd.Parameters.AddWithValue("@Email", students.Email);
            //    cmd.Parameters.AddWithValue("@Phone_number", students.Phone_number);
            //    cmd.Parameters.AddWithValue("@Class_id", students.Class_id);

            //    return cmd.ExecuteNonQuery() > 0;
            //}
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Students (Student_id, Full_name, Date_of_birth, Gender, Phone_number, Class_id) " +
                                   "VALUES (@StudentId, @FullName, @DateOfBirth, @Gender, @PhoneNumber, @ClassId)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Student_id", students.Student_id);
                    cmd.Parameters.AddWithValue("@Full_name", students.Full_name);
                    cmd.Parameters.AddWithValue("@Date_of_birth", students.Date_of_birth);
                    cmd.Parameters.AddWithValue("@Gender", students.Gender);
                    cmd.Parameters.AddWithValue("@Full_address", students.Full_address);
                    cmd.Parameters.AddWithValue("@Email", students.Email);
                    cmd.Parameters.AddWithValue("@Phone_number", students.Phone_number);
                    cmd.Parameters.AddWithValue("@Class_id", students.Class_id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chèn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật sản phẩm
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

        // Xóa sản phẩm
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
    }
}