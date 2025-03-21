namespace quan_ly_sinh_vien
{
    partial class Class
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvClass = new System.Windows.Forms.DataGridView();
            this.btnReloadClass = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.lblEndTime = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.TextBox();
            this.txtClassId = new System.Windows.Forms.TextBox();
            this.btnSearchClass = new System.Windows.Forms.Button();
            this.btnDeleteClass = new System.Windows.Forms.Button();
            this.btnUpdateClass = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClass
            // 
            this.dgvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvClass.Location = new System.Drawing.Point(0, 0);
            this.dgvClass.Margin = new System.Windows.Forms.Padding(4);
            this.dgvClass.Name = "dgvClass";
            this.dgvClass.RowHeadersWidth = 72;
            this.dgvClass.RowTemplate.Height = 31;
            this.dgvClass.Size = new System.Drawing.Size(1173, 493);
            this.dgvClass.TabIndex = 28;
            this.dgvClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClass_CellContentClick);
            // 
            // btnReloadClass
            // 
            this.btnReloadClass.Location = new System.Drawing.Point(854, 549);
            this.btnReloadClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnReloadClass.Name = "btnReloadClass";
            this.btnReloadClass.Size = new System.Drawing.Size(138, 59);
            this.btnReloadClass.TabIndex = 43;
            this.btnReloadClass.Text = "Reload";
            this.btnReloadClass.UseVisualStyleBackColor = true;
            this.btnReloadClass.Click += new System.EventHandler(this.btnReloadClass_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 693);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 23);
            this.label7.TabIndex = 41;
            this.label7.Text = "Day : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(388, 632);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 23);
            this.label5.TabIndex = 40;
            this.label5.Text = "End time : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 632);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "Start time : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 575);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "Lecturer ID : ";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(137, 693);
            this.txtDay.Margin = new System.Windows.Forms.Padding(4);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(227, 29);
            this.txtDay.TabIndex = 36;
            // 
            // lblEndTime
            // 
            this.lblEndTime.Location = new System.Drawing.Point(501, 628);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(233, 29);
            this.lblEndTime.TabIndex = 35;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(137, 628);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(230, 29);
            this.lblStartTime.TabIndex = 34;
            // 
            // txtClassId
            // 
            this.txtClassId.Location = new System.Drawing.Point(137, 571);
            this.txtClassId.Margin = new System.Windows.Forms.Padding(4);
            this.txtClassId.Name = "txtClassId";
            this.txtClassId.Size = new System.Drawing.Size(136, 29);
            this.txtClassId.TabIndex = 33;
            // 
            // btnSearchClass
            // 
            this.btnSearchClass.Location = new System.Drawing.Point(1026, 549);
            this.btnSearchClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchClass.Name = "btnSearchClass";
            this.btnSearchClass.Size = new System.Drawing.Size(138, 59);
            this.btnSearchClass.TabIndex = 32;
            this.btnSearchClass.Text = "Search";
            this.btnSearchClass.UseVisualStyleBackColor = true;
            this.btnSearchClass.Click += new System.EventHandler(this.btnSearchClass_Click);
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.Location = new System.Drawing.Point(487, 549);
            this.btnDeleteClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.Size = new System.Drawing.Size(138, 59);
            this.btnDeleteClass.TabIndex = 31;
            this.btnDeleteClass.Text = "Delete";
            this.btnDeleteClass.UseVisualStyleBackColor = true;
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // btnUpdateClass
            // 
            this.btnUpdateClass.Location = new System.Drawing.Point(669, 549);
            this.btnUpdateClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateClass.Name = "btnUpdateClass";
            this.btnUpdateClass.Size = new System.Drawing.Size(138, 59);
            this.btnUpdateClass.TabIndex = 30;
            this.btnUpdateClass.Text = "Update";
            this.btnUpdateClass.UseVisualStyleBackColor = true;
            this.btnUpdateClass.Click += new System.EventHandler(this.btnUpdateClass_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(315, 549);
            this.btnAddClass.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(138, 59);
            this.btnAddClass.TabIndex = 29;
            this.btnAddClass.Text = "Add";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // Class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 735);
            this.Controls.Add(this.btnReloadClass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.txtClassId);
            this.Controls.Add(this.btnSearchClass);
            this.Controls.Add(this.btnDeleteClass);
            this.Controls.Add(this.btnUpdateClass);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.dgvClass);
            this.MinimumSize = new System.Drawing.Size(1197, 799);
            this.Name = "Class";
            this.Text = "Class";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClass;
        private System.Windows.Forms.Button btnReloadClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox lblEndTime;
        private System.Windows.Forms.TextBox lblStartTime;
        private System.Windows.Forms.TextBox txtClassId;
        private System.Windows.Forms.Button btnSearchClass;
        private System.Windows.Forms.Button btnDeleteClass;
        private System.Windows.Forms.Button btnUpdateClass;
        private System.Windows.Forms.Button btnAddClass;
    }
}