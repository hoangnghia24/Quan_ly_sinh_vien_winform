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
    public partial class Class: Form
    {
        ClassBLL ClassBLL = new ClassBLL();
        public Class()
        {
            InitializeComponent();
            dgvClass.DataSource = ClassBLL.GetAllClasses();
        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClass.Rows[e.RowIndex]; // Lấy dòng được chọn

                // Gán dữ liệu từ dòng được chọn vào các TextBox
                txtClassId.Text = row.Cells["Class_id"].Value.ToString();
                lblStartTime.Text = TimeSpan.Parse(row.Cells["Start_time"].Value.ToString()).ToString(@"hh\:mm\:ss");
                lblEndTime.Text = TimeSpan.Parse(row.Cells["End_time"].Value.ToString()).ToString(@"hh\:mm\:ss");
                txtDay.Text = row.Cells["Day_of_week"].Value.ToString();
            }
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            Classes Class = new Classes();
            Class.Class_id = txtClassId.Text;
            Class.Start_time = TimeSpan.Parse(lblStartTime.Text);
            Class.End_time = TimeSpan.Parse(lblEndTime.Text);
            Class.Day_of_week = txtDay.Text;

            try
            {
                if (ClassBLL.InsertClass(Class))
                {
                    MessageBox.Show("Insert Class successfully");
                    dgvClass.DataSource = ClassBLL.GetAllClasses();
                }
                else
                {
                    MessageBox.Show("Insert Class failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            String Class_id = txtClassId.Text;
            if (ClassBLL.DeleteClass(Class_id))
            {
                MessageBox.Show("Delete Class successfully");
                dgvClass.DataSource = ClassBLL.GetAllClasses();
            }
            else
            {
                MessageBox.Show("Delete Class failed");
            }
        }

        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            Classes Class = new Classes();
            Class.Class_id = txtClassId.Text;
            Class.Start_time = TimeSpan.Parse(lblStartTime.Text);
            Class.End_time = TimeSpan.Parse(lblEndTime.Text);
            Class.Day_of_week = txtDay.Text;

            try
            {
                if (ClassBLL.UpdateClass(Class))
                {
                    MessageBox.Show("Update Class successfully");
                    dgvClass.DataSource = ClassBLL.GetAllClasses();
                }
                else
                {
                    MessageBox.Show("Update Class failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void btnSearchClass_Click(object sender, EventArgs e)
        {
            try
            {
                string Class_id = txtClassId.Text.Trim();
                string Day_of_week = txtDay.Text.Trim();

                List<Classes> result = ClassBLL.SearchClass(Class_id, Day_of_week);

                if (result.Count > 0)
                {
                    MessageBox.Show("Search Class successfully!");
                    dgvClass.DataSource = result; // Hiển thị kết quả lên DataGridView
                }
                else
                {
                    MessageBox.Show("Search Class failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReloadClass_Click(object sender, EventArgs e)
        {
            dgvClass.DataSource = ClassBLL.GetAllClasses();
        }
    }
}
