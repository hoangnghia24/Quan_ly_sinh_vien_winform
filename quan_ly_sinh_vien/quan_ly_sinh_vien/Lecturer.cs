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

namespace quan_ly_sinh_vien
{
    public partial class Lecturer: Form
    {
        LecturerBLL LecturerBLL = new LecturerBLL();
        public Lecturer()
        {
            InitializeComponent();
            dgvLecturer.Dock = DockStyle.Fill;
            dgvLecturer.DataSource = LecturerBLL.GetAllLecturers();
        }
        private void dgvLecturer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLecturer.Rows[e.RowIndex]; // Lấy dòng được chọn

                // Gán dữ liệu từ dòng được chọn vào các TextBox
                txtLecturerId.Text = row.Cells["Lecturer_id"].Value.ToString();
                txtFullName.Text = row.Cells["Lecturer_name"].Value.ToString();
                txtGender.Text = row.Cells["gender"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["Phone_number"].Value.ToString();
            }
        }

        private void btnAddLect_Click(object sender, EventArgs e)
        {
            Lecturers Lecturer = new Lecturers();
            Lecturer.Lecturer_id = txtLecturerId.Text;
            Lecturer.Lecturer_name = txtFullName.Text;
            Lecturer.gender = txtGender.Text;
            Lecturer.Email = txtEmail.Text;
            Lecturer.Phone_number = txtPhoneNumber.Text;

            try
            {
                if (LecturerBLL.InsertLecturer(Lecturer))
                {
                    MessageBox.Show("Insert Lecturer successfully");
                    dgvLecturer.DataSource = LecturerBLL.GetAllLecturers();
                }
                else
                {
                    MessageBox.Show("Insert Lecturer failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        private void btnDeleteLect_Click(object sender, EventArgs e)
        {
            String Lecturer_id = txtLecturerId.Text;
            if (LecturerBLL.DeleteLecturer(Lecturer_id))
            {
                MessageBox.Show("Delete Lecturer successfully");
                dgvLecturer.DataSource = LecturerBLL.GetAllLecturers();
            }
            else
            {
                MessageBox.Show("Delete Lecturer failed");
            }
        }

        private void btnUpdateLect_Click(object sender, EventArgs e)
        {
            Lecturers Lecturer = new Lecturers();
            Lecturer.Lecturer_id = txtLecturerId.Text;
            Lecturer.Lecturer_name = txtFullName.Text;
            Lecturer.gender = txtGender.Text;
            Lecturer.Email = txtEmail.Text;
            Lecturer.Phone_number = txtPhoneNumber.Text;
            try
            {
                if (LecturerBLL.UpdateLecturer(Lecturer))
                {
                    MessageBox.Show("Update Lecturer successfully");
                    dgvLecturer.DataSource = LecturerBLL.GetAllLecturers();
                }
                else
                {
                    MessageBox.Show("Update Lecturer failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex.Message);
                return;
            }
        }

        private void btnSearchLect_Click(object sender, EventArgs e)
        {
            try
            {
                string Lecturer_id = txtLecturerId.Text.Trim();
                string Lecturer_name = txtFullName.Text.Trim();

                List<Lecturers> result = LecturerBLL.SearchLecturer(Lecturer_id, Lecturer_name);

                if (result.Count > 0)
                {
                    MessageBox.Show("Search Lecturer successfully!");
                    dgvLecturer.DataSource = result; // Hiển thị kết quả lên DataGridView
                }
                else
                {
                    MessageBox.Show("Search Lecturer failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReloadLect_Click(object sender, EventArgs e)
        {
            dgvLecturer.DataSource = LecturerBLL.GetAllLecturers();
        }
    }
}
