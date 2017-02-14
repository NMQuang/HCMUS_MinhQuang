using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM_DO_AN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           //Application.Run(new Thu());
            Trang_chu trangChu = new Trang_chu();
            trangChu.Load();
            trangChu.ShowDialog();
           /* Thu thu = new Thu();
            thu.LoadDuLieu();
            thu.ShowDialog();*/
            /*Thong_ke_thang thongKe = new Thong_ke_thang();
            thongKe.LoadDuLieu();
            thongKe.ShowDialog();*/
            /*Thong_ke_nam thongKe = new Thong_ke_nam();
            thongKe.LoadDuLieu();
            thongKe.ShowDialog();*/
        }
    }
}
