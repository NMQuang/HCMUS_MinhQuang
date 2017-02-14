using System;
using System.Collections.Generic;
 
 
using System.Windows.Forms;

namespace Doc_Du_lieu_co_Cau_truc_Cuc_bo
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
            MH_Dang_nhap Mh = new MH_Dang_nhap();
            Mh.XL_Bien_co_Khoi_dong();
            Mh.ShowDialog();
        }
    }
}
