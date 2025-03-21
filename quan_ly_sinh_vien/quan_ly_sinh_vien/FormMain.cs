using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace quan_ly_sinh_vien
{
    public partial class FormMain: Form
    {
        
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }
        private void btnStudent_Click(object sender, EventArgs e)
        {
            Student form = new Student();
            form.ShowDialog();
        }
        private void btnLecturer_Click(object sender, EventArgs e)
        {
            Lecturer form = new Lecturer();
            form.ShowDialog();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            Class form = new Class();
            form.ShowDialog();
        }
    }
}
