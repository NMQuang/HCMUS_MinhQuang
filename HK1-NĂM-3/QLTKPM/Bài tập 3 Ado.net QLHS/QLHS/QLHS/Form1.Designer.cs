namespace QLHS
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Lop = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.maLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_maLop = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_tenLop = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_khoaHoc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_GVCN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btn_them = new DevComponents.DotNetBar.ButtonX();
            this.btn_sua = new DevComponents.DotNetBar.ButtonX();
            this.btn_xoa = new DevComponents.DotNetBar.ButtonX();
            this.btn_lammoi = new DevComponents.DotNetBar.ButtonX();
            this.btn_thoat = new DevComponents.DotNetBar.ButtonX();
            this.btn_huybo = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Lop)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Lop
            // 
            this.dgv_Lop.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgv_Lop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Lop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maLop,
            this.tenLop,
            this.khoaHoc,
            this.GVCN});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Lop.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Lop.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Lop.Location = new System.Drawing.Point(12, 109);
            this.dgv_Lop.Name = "dgv_Lop";
            this.dgv_Lop.Size = new System.Drawing.Size(596, 181);
            this.dgv_Lop.TabIndex = 0;
            this.dgv_Lop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
            this.dgv_Lop.Click += new System.EventHandler(this.dgv_Lop_Click);
            // 
            // maLop
            // 
            this.maLop.DataPropertyName = "maLop";
            this.maLop.HeaderText = "Mã Lớp";
            this.maLop.Name = "maLop";
            this.maLop.ReadOnly = true;
            // 
            // tenLop
            // 
            this.tenLop.DataPropertyName = "tenLop";
            this.tenLop.HeaderText = "Tên Lớp";
            this.tenLop.Name = "tenLop";
            this.tenLop.ReadOnly = true;
            this.tenLop.Width = 150;
            // 
            // khoaHoc
            // 
            this.khoaHoc.DataPropertyName = "khoaHoc";
            this.khoaHoc.HeaderText = "Khóa Học";
            this.khoaHoc.Name = "khoaHoc";
            this.khoaHoc.ReadOnly = true;
            this.khoaHoc.Width = 150;
            // 
            // GVCN
            // 
            this.GVCN.DataPropertyName = "GVCN";
            this.GVCN.HeaderText = "Giáo Viên Chủ Nhiệm";
            this.GVCN.Name = "GVCN";
            this.GVCN.ReadOnly = true;
            this.GVCN.Width = 150;
            // 
            // txt_maLop
            // 
            // 
            // 
            // 
            this.txt_maLop.Border.Class = "TextBoxBorder";
            this.txt_maLop.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_maLop.Location = new System.Drawing.Point(99, 13);
            this.txt_maLop.Name = "txt_maLop";
            this.txt_maLop.PreventEnterBeep = true;
            this.txt_maLop.Size = new System.Drawing.Size(152, 20);
            this.txt_maLop.TabIndex = 1;
            this.txt_maLop.TextChanged += new System.EventHandler(this.txt_maLop_TextChanged_1);
            // 
            // txt_tenLop
            // 
            // 
            // 
            // 
            this.txt_tenLop.Border.Class = "TextBoxBorder";
            this.txt_tenLop.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_tenLop.Location = new System.Drawing.Point(99, 52);
            this.txt_tenLop.Name = "txt_tenLop";
            this.txt_tenLop.PreventEnterBeep = true;
            this.txt_tenLop.Size = new System.Drawing.Size(152, 20);
            this.txt_tenLop.TabIndex = 2;
            // 
            // txt_khoaHoc
            // 
            // 
            // 
            // 
            this.txt_khoaHoc.Border.Class = "TextBoxBorder";
            this.txt_khoaHoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_khoaHoc.Location = new System.Drawing.Point(417, 13);
            this.txt_khoaHoc.Name = "txt_khoaHoc";
            this.txt_khoaHoc.PreventEnterBeep = true;
            this.txt_khoaHoc.Size = new System.Drawing.Size(152, 20);
            this.txt_khoaHoc.TabIndex = 3;
            // 
            // txt_GVCN
            // 
            // 
            // 
            // 
            this.txt_GVCN.Border.Class = "TextBoxBorder";
            this.txt_GVCN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_GVCN.Location = new System.Drawing.Point(417, 52);
            this.txt_GVCN.Name = "txt_GVCN";
            this.txt_GVCN.PreventEnterBeep = true;
            this.txt_GVCN.Size = new System.Drawing.Size(152, 20);
            this.txt_GVCN.TabIndex = 4;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "Mã Lớp";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 49);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Tên Lớp";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(315, 10);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "Khóa Học";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(315, 52);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "GVCN";
            // 
            // btn_them
            // 
            this.btn_them.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_them.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_them.Location = new System.Drawing.Point(670, 9);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "Thêm";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_sua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_sua.Location = new System.Drawing.Point(670, 61);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_sua.TabIndex = 10;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_xoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_xoa.Location = new System.Drawing.Point(670, 109);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_xoa.TabIndex = 11;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_lammoi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_lammoi.Location = new System.Drawing.Point(670, 218);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(75, 23);
            this.btn_lammoi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_lammoi.TabIndex = 12;
            this.btn_lammoi.Text = "Làm Mới";
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_thoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_thoat.Location = new System.Drawing.Point(670, 267);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_thoat.TabIndex = 13;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_huybo
            // 
            this.btn_huybo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_huybo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_huybo.Location = new System.Drawing.Point(670, 165);
            this.btn_huybo.Name = "btn_huybo";
            this.btn_huybo.Size = new System.Drawing.Size(75, 23);
            this.btn_huybo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_huybo.TabIndex = 14;
            this.btn_huybo.Text = "Hủy bỏ";
            this.btn_huybo.Click += new System.EventHandler(this.btn_huybo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 306);
            this.Controls.Add(this.btn_huybo);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txt_GVCN);
            this.Controls.Add(this.txt_khoaHoc);
            this.Controls.Add(this.txt_tenLop);
            this.Controls.Add(this.txt_maLop);
            this.Controls.Add(this.dgv_Lop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Lop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn khoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GVCN;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_maLop;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_tenLop;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_khoaHoc;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_GVCN;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btn_them;
        private DevComponents.DotNetBar.ButtonX btn_sua;
        private DevComponents.DotNetBar.ButtonX btn_xoa;
        private DevComponents.DotNetBar.ButtonX btn_lammoi;
        private DevComponents.DotNetBar.ButtonX btn_thoat;
        private DevComponents.DotNetBar.ButtonX btn_huybo;
    }
}

