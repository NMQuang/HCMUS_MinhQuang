namespace QLHS
{
    partial class HocSinh
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
            this.dgv_HocSinh = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.maHocSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenHocSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_mahocsinh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_tenhocsinh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_dienthoai = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_timkiem = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.pan_gioitinh = new DevComponents.DotNetBar.PanelEx();
            this.rbn_nam = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbn_nu = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btn_them = new DevComponents.DotNetBar.ButtonX();
            this.btn_sua = new DevComponents.DotNetBar.ButtonX();
            this.btn_xoa = new DevComponents.DotNetBar.ButtonX();
            this.btn_timkiem = new DevComponents.DotNetBar.ButtonX();
            this.dtp_ngaysinh = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txt_malop = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HocSinh)).BeginInit();
            this.pan_gioitinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_ngaysinh)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_HocSinh
            // 
            this.dgv_HocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HocSinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHocSinh,
            this.tenHocSinh,
            this.maLop,
            this.ngaySinh,
            this.gioiTinh,
            this.SDT});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_HocSinh.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_HocSinh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_HocSinh.Location = new System.Drawing.Point(0, 172);
            this.dgv_HocSinh.Name = "dgv_HocSinh";
            this.dgv_HocSinh.Size = new System.Drawing.Size(697, 141);
            this.dgv_HocSinh.TabIndex = 0;
            this.dgv_HocSinh.Click += new System.EventHandler(this.dgv_HocSinh_Click);
            // 
            // maHocSinh
            // 
            this.maHocSinh.DataPropertyName = "maHocSinh";
            this.maHocSinh.HeaderText = "Mã Học Sinh";
            this.maHocSinh.Name = "maHocSinh";
            this.maHocSinh.ReadOnly = true;
            // 
            // tenHocSinh
            // 
            this.tenHocSinh.DataPropertyName = "tenHocSinh";
            this.tenHocSinh.HeaderText = "Tên Học Sinh";
            this.tenHocSinh.Name = "tenHocSinh";
            this.tenHocSinh.ReadOnly = true;
            this.tenHocSinh.Width = 150;
            // 
            // maLop
            // 
            this.maLop.DataPropertyName = "maLop";
            this.maLop.HeaderText = "Mã Lớp";
            this.maLop.Name = "maLop";
            this.maLop.ReadOnly = true;
            // 
            // ngaySinh
            // 
            this.ngaySinh.DataPropertyName = "ngaySinh";
            this.ngaySinh.HeaderText = "Ngày Sinh";
            this.ngaySinh.Name = "ngaySinh";
            this.ngaySinh.ReadOnly = true;
            // 
            // gioiTinh
            // 
            this.gioiTinh.DataPropertyName = "gioiTinh";
            this.gioiTinh.HeaderText = "Giới Tính";
            this.gioiTinh.Name = "gioiTinh";
            this.gioiTinh.ReadOnly = true;
            // 
            // SDT
            // 
            this.SDT.DataPropertyName = "SDT";
            this.SDT.HeaderText = "SĐT";
            this.SDT.Name = "SDT";
            this.SDT.ReadOnly = true;
            // 
            // txt_mahocsinh
            // 
            // 
            // 
            // 
            this.txt_mahocsinh.Border.Class = "TextBoxBorder";
            this.txt_mahocsinh.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_mahocsinh.Location = new System.Drawing.Point(120, 2);
            this.txt_mahocsinh.Name = "txt_mahocsinh";
            this.txt_mahocsinh.PreventEnterBeep = true;
            this.txt_mahocsinh.Size = new System.Drawing.Size(138, 20);
            this.txt_mahocsinh.TabIndex = 1;
            this.txt_mahocsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_mahocsinh_KeyDown);
            // 
            // txt_tenhocsinh
            // 
            // 
            // 
            // 
            this.txt_tenhocsinh.Border.Class = "TextBoxBorder";
            this.txt_tenhocsinh.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_tenhocsinh.Location = new System.Drawing.Point(120, 38);
            this.txt_tenhocsinh.Name = "txt_tenhocsinh";
            this.txt_tenhocsinh.PreventEnterBeep = true;
            this.txt_tenhocsinh.Size = new System.Drawing.Size(138, 20);
            this.txt_tenhocsinh.TabIndex = 2;
            // 
            // txt_dienthoai
            // 
            // 
            // 
            // 
            this.txt_dienthoai.Border.Class = "TextBoxBorder";
            this.txt_dienthoai.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_dienthoai.Location = new System.Drawing.Point(394, 38);
            this.txt_dienthoai.Name = "txt_dienthoai";
            this.txt_dienthoai.PreventEnterBeep = true;
            this.txt_dienthoai.Size = new System.Drawing.Size(143, 20);
            this.txt_dienthoai.TabIndex = 4;
            // 
            // txt_timkiem
            // 
            // 
            // 
            // 
            this.txt_timkiem.Border.Class = "TextBoxBorder";
            this.txt_timkiem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_timkiem.Location = new System.Drawing.Point(120, 131);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.PreventEnterBeep = true;
            this.txt_timkiem.Size = new System.Drawing.Size(365, 20);
            this.txt_timkiem.TabIndex = 6;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(39, 2);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "Mã học sinh";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(39, 34);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "Tên học sinh";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(39, 73);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "Mã lớp";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(39, 127);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "Tìm kiếm";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(313, 1);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 11;
            this.labelX5.Text = "Giới tính";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(313, 34);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 12;
            this.labelX6.Text = "Điện thoại";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(313, 72);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 13;
            this.labelX7.Text = "Ngày sinh";
            // 
            // pan_gioitinh
            // 
            this.pan_gioitinh.CanvasColor = System.Drawing.SystemColors.Control;
            this.pan_gioitinh.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pan_gioitinh.Controls.Add(this.rbn_nu);
            this.pan_gioitinh.Controls.Add(this.rbn_nam);
            this.pan_gioitinh.DisabledBackColor = System.Drawing.Color.Empty;
            this.pan_gioitinh.Location = new System.Drawing.Point(394, 2);
            this.pan_gioitinh.Name = "pan_gioitinh";
            this.pan_gioitinh.Size = new System.Drawing.Size(143, 25);
            this.pan_gioitinh.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pan_gioitinh.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pan_gioitinh.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pan_gioitinh.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pan_gioitinh.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pan_gioitinh.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pan_gioitinh.Style.GradientAngle = 90;
            this.pan_gioitinh.TabIndex = 18;
            // 
            // rbn_nam
            // 
            // 
            // 
            // 
            this.rbn_nam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbn_nam.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbn_nam.Checked = true;
            this.rbn_nam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbn_nam.CheckValue = "Y";
            this.rbn_nam.Location = new System.Drawing.Point(3, 0);
            this.rbn_nam.Name = "rbn_nam";
            this.rbn_nam.Size = new System.Drawing.Size(100, 23);
            this.rbn_nam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbn_nam.TabIndex = 0;
            this.rbn_nam.Text = "Nam";
            // 
            // rbn_nu
            // 
            // 
            // 
            // 
            this.rbn_nu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbn_nu.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbn_nu.Location = new System.Drawing.Point(75, 0);
            this.rbn_nu.Name = "rbn_nu";
            this.rbn_nu.Size = new System.Drawing.Size(100, 23);
            this.rbn_nu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbn_nu.TabIndex = 1;
            this.rbn_nu.Text = "Nữ";
            // 
            // btn_them
            // 
            this.btn_them.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_them.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_them.Location = new System.Drawing.Point(602, 4);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_them.TabIndex = 22;
            this.btn_them.Text = "Thêm";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_sua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_sua.Location = new System.Drawing.Point(602, 48);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_sua.TabIndex = 23;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_xoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_xoa.Location = new System.Drawing.Point(602, 87);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_xoa.TabIndex = 24;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_timkiem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_timkiem.Location = new System.Drawing.Point(602, 128);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(75, 23);
            this.btn_timkiem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_timkiem.TabIndex = 25;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // dtp_ngaysinh
            // 
            // 
            // 
            // 
            this.dtp_ngaysinh.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_ngaysinh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_ngaysinh.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtp_ngaysinh.ButtonDropDown.Visible = true;
            this.dtp_ngaysinh.IsPopupCalendarOpen = false;
            this.dtp_ngaysinh.Location = new System.Drawing.Point(397, 76);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtp_ngaysinh.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_ngaysinh.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtp_ngaysinh.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_ngaysinh.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_ngaysinh.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_ngaysinh.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_ngaysinh.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_ngaysinh.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_ngaysinh.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_ngaysinh.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_ngaysinh.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtp_ngaysinh.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_ngaysinh.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_ngaysinh.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_ngaysinh.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_ngaysinh.MonthCalendar.TodayButtonVisible = true;
            this.dtp_ngaysinh.Name = "dtp_ngaysinh";
            this.dtp_ngaysinh.Size = new System.Drawing.Size(140, 20);
            this.dtp_ngaysinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtp_ngaysinh.TabIndex = 26;
            // 
            // txt_malop
            // 
            // 
            // 
            // 
            this.txt_malop.Border.Class = "TextBoxBorder";
            this.txt_malop.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_malop.Location = new System.Drawing.Point(121, 75);
            this.txt_malop.Name = "txt_malop";
            this.txt_malop.PreventEnterBeep = true;
            this.txt_malop.Size = new System.Drawing.Size(137, 20);
            this.txt_malop.TabIndex = 27;
            // 
            // HocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 325);
            this.Controls.Add(this.txt_malop);
            this.Controls.Add(this.dtp_ngaysinh);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.pan_gioitinh);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txt_timkiem);
            this.Controls.Add(this.txt_dienthoai);
            this.Controls.Add(this.txt_tenhocsinh);
            this.Controls.Add(this.txt_mahocsinh);
            this.Controls.Add(this.dgv_HocSinh);
            this.Name = "HocSinh";
            this.Text = "HocSinh";
            this.Load += new System.EventHandler(this.HocSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HocSinh)).EndInit();
            this.pan_gioitinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_ngaysinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_HocSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHocSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenHocSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_mahocsinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_tenhocsinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_dienthoai;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_timkiem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.PanelEx pan_gioitinh;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbn_nu;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbn_nam;
        private DevComponents.DotNetBar.ButtonX btn_them;
        private DevComponents.DotNetBar.ButtonX btn_sua;
        private DevComponents.DotNetBar.ButtonX btn_xoa;
        private DevComponents.DotNetBar.ButtonX btn_timkiem;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_ngaysinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_malop;
    }
}