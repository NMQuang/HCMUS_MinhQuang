using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEL;
using BAL;

namespace ThreeTierStructure
{
    public partial class ViewEmployees : Form
    {
        public Operations opr = new Operations();
        public Informations info = new Informations();

        public ViewEmployees()
        {
            InitializeComponent();
        }

        private void ViewEmployees_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = opr.viewemployees(info);
            dgvEmployee.DataSource = dt;
            dgvEmployee.Columns[0].Visible = false;
            dgvEmployee.Columns[7].Visible = false;
            dgvEmployee.Columns[8].Visible = false;

        }
    }
}
