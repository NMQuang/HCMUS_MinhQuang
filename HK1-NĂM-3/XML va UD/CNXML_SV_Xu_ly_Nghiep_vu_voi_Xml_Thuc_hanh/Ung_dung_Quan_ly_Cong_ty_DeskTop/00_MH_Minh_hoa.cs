using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using PET_Dong_ho_Ho_tro_thuc_hanh;
 
    public partial class MH_Minh_hoa : Form
    {
        public MH_Minh_hoa()
        {
            InitializeComponent();
        }

        #region "Biến/Đối tượng toàn cục"
      
        protected XL_NGHIEP_VU Nghiep_vu = new XL_NGHIEP_VU();
        protected XL_THE_HIEN The_hien = new XL_THE_HIEN();

        protected XmlElement Goc;
        #endregion
        #region "Xử lý giao diện"
        public void Xu_ly(XmlElement Goc)
        {
            this.Goc = Goc;
            XL_Bien_co_Khoi_dong();
        //==== Xử lý PET : Chỉ phục vụ giảng dạy 
        string Thong_bao_PET = "Thông báo  PET : Đưa chuột đến Tiêu đề để xem chi tiết thông báo";
        Th_Thong_bao_PET.Text = Thong_bao_PET;
        Thong_bao_PET = "Ứng dụng này minh họa  xử lý nghiệp vụ với Xml " + "\n";
        Thong_bao_PET += "== > Giao diện mức tối thiểu    " + "\n";
        Thong_bao_PET += "== > Sinh viên cần tập trung vào XL_NGHIEP_VU   " + "\n";
        Thong_bao_PET += "Lưu ý PET : Xem thêm Source Code của dịch vụ  " + "\n";
        Thong_bao_PET += "1 Thành phần nghiệp vụ là thành phần quan trọng nhất của mô hình 3 lớp  " + "\n";
        Thong_bao_PET += "2  Công  nghệ Xml là công nghệ tốt nhất để thực hiện thành phần nghiệp vụ   " + "\n";
        Thong_bao_PET += "3 Xem thêm Source Code của dịch vụ  " + "\n";
        ToolTip Th_Ghi_chu = new ToolTip();
        Th_Ghi_chu.IsBalloon = true;
        Th_Ghi_chu.SetToolTip(Th_Nguoi_dung, Thong_bao_PET);
        //======
            this.ShowDialog();
        }

        #endregion
        #region "Xử lý Biến cố : Khởi động"
        protected void XL_Bien_co_Khoi_dong()
        {

            Xuat_Danh_sach_Chuc_nang();
            Xuat_Danh_sach_Don_vi_Thong_ke();
           The_hien.Xuat_Yeu_cau_Nhap_Chuoi(Th_Chuoi_Ho_ten, XL_Bien_co_Yeu_cau_Tra_cuu_Nhan_vien_theo_Ho_ten);
           The_hien.Xuat_Yeu_cau_Nhap_Chuoi(Th_Chuoi_Muc_luong, XL_Bien_co_Yeu_cau_Tra_cuu_Nhan_vien_theo_Muc_luong);

    }
        //**** Lưu ý PET : Nên chuyển các hàm xử này vào class XL_THE_HIEN            
        //**** Câu hỏi PET : Tại sao ? 
     
        protected void Xuat_Danh_sach_Chuc_nang()
    {     //=== Chuẩn bị thực đơn ( Danh sách chức năng )
        string[] Danh_sach_Ten_Chuc_nang = new string[] {
                        "Cập nhật hồ sơ Công ty", "Thành lập Chi nhánh mới", "Cập nhật hay Giải thể Chi nhánh ", "Thành lập Đơn vị mới",
                                 "Thuyên chuyển Nhân viên"};
            string[] Danh_sach_Ma_so_Chuc_nang = new string[] {
                "CAP_NHAT_HO_SO_CONG_TY", "THANH_LAP_CHI_NHANH", "CAP_NHAT_HO_SO_GIAI_THE_CHI_NHANH", "THANH_LAP_DON_VI",
                                 "THUYEN_CHUYEN_NHAN_VIEN"};
            //==== Kết xuất danh sách chức năng 
        for( int i=0; i<Danh_sach_Ten_Chuc_nang.Length-1; i++)
            {
                string Ten = Danh_sach_Ten_Chuc_nang[i];
                string Ma_so = Danh_sach_Ma_so_Chuc_nang[i];
                //=== Tạo thể hiện 
               Button  Th_Chuc_nang =new Button();
                Th_Danh_sach_Chuc_nang.Controls.Add(Th_Chuc_nang);
               //=== Xuất thông tin 
               Th_Chuc_nang.Text = Ten;
                //== Định dạng 
                Th_Chuc_nang.Size = new Size(180, 80);
                Th_Chuc_nang.BackColor = Color.White;
                Th_Chuc_nang.ForeColor = Color.Red;
                //=== Chuẩn bị xử lý biến cố 
                Th_Chuc_nang.Tag = Ma_so;
                Th_Chuc_nang.Click += XL_Bien_co_Chon_Chuc_nang;
            }

           
        
        }

        protected void Xuat_Danh_sach_Don_vi_Thong_ke()
        {
        XmlElement[] Bang_Don_vi_Thong_ke = Nghiep_vu.Thong_ke_So_luong_Nhan_vien_theo_Don_vi(Goc);
        foreach ( XmlElement Don_vi in Bang_Don_vi_Thong_ke)
        {  //=== Tạo thể hiện : 
            Button Th_Don_vi = new Button();
            Th_Danh_sach_Don_vi_Thong_ke.Controls.Add(Th_Don_vi);
            //=== Xuất thông tin 
            string Chuoi_Thong_ke = Don_vi.GetAttribute("Ten") + "\n";
            Chuoi_Thong_ke += Don_vi.GetAttribute("So_Nhan_vien") + " NV - " + Don_vi.GetAttribute("Ty_le");
            Th_Don_vi.Text = Chuoi_Thong_ke;
            //=== Định dạng thể hiện 
            Th_Don_vi.Size = new Size(180, 60);
            Th_Don_vi.BackColor = Color.White;
            Th_Don_vi.ForeColor = Color.Brown;
            //=== Chuẩn bị hàm xử lý Biến cố 
            Th_Don_vi.Tag = Don_vi;
            Th_Don_vi.Click += XL_Bien_co_Yeu_cau_Tra_cuu_Nhan_vien_theo_Don_vi;

        }
          
      
        }



    #endregion

    #region "Xử lý Biến cố : Chọn Chức năng == > Kích họa màn hình khác "
    private void XL_Bien_co_Chon_Chuc_nang(object sender, EventArgs e)
    {
        // Nhập 
        Control Th_Chuc_nang = (Control)sender;
        string Ma_so = (string)Th_Chuc_nang.Tag;
        // Xử lý 
        if (Ma_so == "CAP_NHAT_HO_SO_CONG_TY")
        {
            XmlElement Cong_ty = (XmlElement)Goc.SelectSingleNode(XL_NGHIEP_VU.Ma_so_Loai_Doi_tuong_Cong_ty);
            MH_Cap_nhat_Ho_so_Cong_ty Mh = new MH_Cap_nhat_Ho_so_Cong_ty();
            Mh.Xu_ly(Cong_ty);
           }
        else
            Th_Thong_bao_PET.Text = "sẽ thực hiện  chức năng " + Th_Chuc_nang.Text + " với mã số " + Ma_so;
    }
    #endregion

    #region "Xử lý Biến cố :  Yêu cầu thực hiện nghiệp vụ  "

    // Tra cứu 
    private void XL_Bien_co_Yeu_cau_Tra_cuu_Nhan_vien_theo_Ho_ten(object sender, KeyEventArgs Bc)
        {
            if (Bc.KeyCode == Keys.Enter)
            {  // Chuẩn bị đo thời gian thực hiện 
                 XL_DONG_HO   Dong_ho = new  XL_DONG_HO();
                // Nhập 
                string Chuoi_Ho_ten = The_hien.Nhap_Chuoi(Th_Chuoi_Ho_ten);
                // Xử lý 
                List<XmlElement> Danh_sach_Nhan_vien = Nghiep_vu.Tra_cuu_Nhan_vien_theo_Ho_ten
                                        (Goc, Chuoi_Ho_ten);
                // Kết xuất
                The_hien.Xuat_Danh_sach_Nhan_vien(Danh_sach_Nhan_vien, Th_Danh_sach_Nhan_vien);

            //==== Xử lý PET : Chỉ phục vụ giảng dạy =======
            string Thong_bao_PET = "Thông báo  PET : ";
            Thong_bao_PET += "Đọc thật kỹ Source Code của đoạn xử lý này   " + "\n" ;
            this.Text = Dong_ho.Tao_Chuoi_Thoi_gian_do("Thời gian xử lý");
            Th_Thong_bao_PET.Text = Thong_bao_PET;
            //======

        }

        }

    private void XL_Bien_co_Yeu_cau_Tra_cuu_Nhan_vien_theo_Muc_luong(object sender, KeyEventArgs Bc)
    {
        if (Bc.KeyCode == Keys.Enter)
        {  // Chuẩn bị đo thời gian thực hiện 
            XL_DONG_HO Dong_ho = new XL_DONG_HO();
            // Nhập 
            string Chuoi_Muc_luong = The_hien.Nhap_Chuoi(Th_Chuoi_Muc_luong);
            // Xử lý 

            // Kết xuất


            //==== Xử lý PET : Chỉ phục vụ giảng dạy =======
            string Thong_bao_PET = "Thông báo  PET : ";
            Thong_bao_PET += "Sinh viên sẽ tự thực hiện Tra cứu nhân viên theo mức lương với tiêu chí tra cứu   " +  Chuoi_Muc_luong;
        
            Th_Thong_bao_PET.Text = Thong_bao_PET;
            //======

        }

    }
    private void XL_Bien_co_Yeu_cau_Tra_cuu_Nhan_vien_theo_Don_vi(object sender, EventArgs e)
        {
        // Chuẩn bị đo thời gian thực hiện 
        XL_DONG_HO Dong_ho = new XL_DONG_HO();
        // Nhập 
        Control Th_Don_vi = (Control)sender;
        XmlElement Don_vi = (XmlElement)Th_Don_vi.Tag;
        // Xử lý 
        List<XmlElement> Danh_sach_Nhan_vien = Nghiep_vu.Tra_cuu_Nhan_vien_theo_Don_vi(Goc, Don_vi);
        // Kết xuất
        The_hien.Xuat_Danh_sach_Nhan_vien(Danh_sach_Nhan_vien, Th_Danh_sach_Nhan_vien);


        //==== Xử lý PET : Chỉ phục vụ giảng dạy =======
        string Thong_bao_PET = "Thông báo  PET : ";
        Thong_bao_PET += "Đọc thật kỹ Source Code của đoạn xử lý này   " + "\n";
        this.Text = Dong_ho.Tao_Chuoi_Thoi_gian_do("Thời gian xử lý");
        Th_Thong_bao_PET.Text = Thong_bao_PET;
        //======
    }
    #endregion
}

