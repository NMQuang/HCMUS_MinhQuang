using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace FORM_DO_AN
{
    class THE_HIEN
    {
        public void inNoiDung(Control control, string noiDung)
        {
            control.Text = noiDung;
        }

        private void dinhDangKetQuaThuChi(List<string> thoiGian, List<string> tien)
        {
            if (thoiGian.Count == 0)
                return;
            if(thoiGian[0].Contains("/"))
            {
                int giaTri = 1;
               // int viTri = 0;
                //int thang = 0;
                while (thoiGian.Count < 12)
                {
                    thoiGian.Add(thoiGian[0]);
                    tien.Add("0");
                }
                int n = thoiGian.Count - 1;
                for (int i = n; i >= 0; i--)
                {
                    string[] tu = thoiGian[i].Split('/');
                    Int32.TryParse(tu[0], out giaTri);
                    if (giaTri - 1 > i)
                    {
                        thoiGian[giaTri - 1] = thoiGian[i];
                        tien[giaTri - 1] = tien[i];
                        tien[i] = "0";
                    }
                    else
                    {
                        thoiGian[i] = (i + 1).ToString() + "/" + tu[1];
                    }
                }
            }
        }

        public void capNhatLaiPanel(Panel panel, XmlElement chuoiThu, XmlElement chuoiChi, int namHienTai)
        {
            int so = chuoiThu.ChildNodes.Count > chuoiChi.ChildNodes.Count ? chuoiThu.ChildNodes.Count : chuoiChi.ChildNodes.Count;
            List<string> tongThu = new List<string>();
            List<string> tongChi = new List<string>();
            List<string> namThu = new List<string>();
            List<string> namChi = new List<string>();
            int i = 0;

            foreach (XmlElement e in chuoiThu.ChildNodes)
            {
                tongThu.Add(e.GetAttribute("Tong_thu"));
                namThu.Add(e.GetAttribute("Thoi_gian"));
            }
            foreach (XmlElement e in chuoiChi.ChildNodes)
            {
                tongChi.Add(e.GetAttribute("Tong_chi"));
                namChi.Add(e.GetAttribute("Thoi_gian"));
            }

            dinhDangKetQuaThuChi(namThu, tongThu);
            dinhDangKetQuaThuChi(namChi, tongChi);
            
            
                i = 0;
                foreach (Control control in panel.Controls)
                {
                    control.Enabled = true;
                    int thu = 0;
                    int chi = 0;
                    int ketqua= 0;
                    string ketQua = "";
                    

                    
                    Int32.TryParse(tongThu[i], out thu);
                    Int32.TryParse(tongChi[i], out chi);
                    ketqua = thu - chi;
                    ketQua = (thu - chi).ToString();
                    control.Text = namThu[i] + "\n";
                    if (thu != 0 || chi != 0)
                    {
                        tongThu[i] = String.Format("{0:#,0.#} VNĐ", thu);
                        tongChi[i] = String.Format("{0:#,0.#} VNĐ", chi);
                        ketQua = String.Format("{0:#,0.#} VNĐ", ketqua);
                        control.Text += "+" + tongThu[i] + "\n";
                        control.Text += "-" + tongChi[i] +"\n";
                        control.Text += "=>" + ketQua + "\n";
                    }
                    else
                    {
                        control.Enabled = false;
                    }
                    i++;
                }
            }


        internal void inNoiDung(DataGridViewCell dataGridViewCell, string noiDung)
        {
            dataGridViewCell.Value = noiDung;

        }
    }

        
    
}
