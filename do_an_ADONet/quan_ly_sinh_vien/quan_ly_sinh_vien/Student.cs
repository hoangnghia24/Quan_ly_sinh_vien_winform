using BLLLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLLib;
using DAL;
using System.Xml.Linq;

namespace quan_ly_sinh_vien
{
    public partial class Student : Form
    {
        StudentBLL studentBLL = new StudentBLL();
        public Student()
        {
            InitializeComponent();
            dgvStudent.DataSource = studentBLL.GetAllStudents();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex]; // Lấy dòng được chọn

                // Gán dữ liệu từ dòng được chọn vào các TextBox
                txtStudentId.Text = row.Cells["Student_id"].Value.ToString();
                txtFullName.Text = row.Cells["Full_name"].Value.ToString();

                string gen = "";
                if (row.Cells["Gender"].Value.ToString() == "1")
                {
                    gen = "Male";
                }
                else
                {
                    gen = "Female";
                }
                txtGender.Text = gen;
                txtClassId.Text = row.Cells["Class_id"].Value.ToString();
                txtAddress.Text = row.Cells["Full_address"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["Phone_number"].Value.ToString();
                if (row.Cells["Date_of_birth"].Value != DBNull.Value)
                {
                    dtpDateofBirth.Value = Convert.ToDateTime(row.Cells["Date_of_birth"].Value);
                }
                else
                {
                    dtpDateofBirth.Value = DateTime.Today; // Nếu NULL thì set về ngày hiện tại
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Students students = new Students();
            students.Student_id = txtStudentId.Text;
            students.Full_name = txtFullName.Text;
            students.Date_of_birth = dtpDateofBirth.Value;
            byte gen;
            if (txtGender.Text == "Male"){
                gen = 1;
        }
            else
            {
                gen = 0;
            }
            students.Gender = gen;
            students.Full_address = txtAddress.Text;
            students.Email = txtEmail.Text;
            students.Phone_number = txtPhoneNumber.Text;
            students.Class_id = txtClassId.Text;

            try
            {
                if (studentBLL.InsertStudent(students))
                {
                    MessageBox.Show("Insert student successfully");
                    dgvStudent.DataSource = studentBLL.GetAllStudents();
                }
                else
                {
                    MessageBox.Show("Insert student failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String student_id = txtStudentId.Text;
            if (studentBLL.DeleteStudent(student_id))
            {
                MessageBox.Show("Delete student successfully");
                dgvStudent.DataSource = studentBLL.GetAllStudents();
            }
            else
            {
                MessageBox.Show("Delete student failed");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Students student = new Students();
            student.Student_id = txtStudentId.Text;
            student.Full_name = txtFullName.Text;
            student.Date_of_birth = dtpDateofBirth.Value;
            byte gen;
            if (txtGender.Text == "Male")
            {
                gen = 1;
            }
            else
            {
                gen = 0;
            }
            student.Gender = gen;
            student.Full_address = txtAddress.Text;
            student.Email = txtEmail.Text;
            student.Phone_number = txtPhoneNumber.Text;
            student.Class_id = txtClassId.Text;
            try
            {
                if (studentBLL.UpdateStudent(student))
                {
                    MessageBox.Show("Update student successfully");
                    dgvStudent.DataSource = studentBLL.GetAllStudents();
                }
                else
                {
                    MessageBox.Show("Update student failed");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!");
                return;
            }

            //if (studentBLL.UpdateStudent(student))
            //{
            //    MessageBox.Show("Update student successfully");
            //    dgvStudent.DataSource = studentBLL.GetAllStudents();
            //}
            //else
            //{
            //    MessageBox.Show("Update student failed");
            //}
        }
    }
}
