using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Warehouse : UserControl
    {
        public UC_Warehouse()
        {
            InitializeComponent();
            // ví dụ sau này:
            // btnAdd.Click += BtnAdd_Click;
            // btnEdit.Click += BtnEdit_Click;
            // btnDelete.Click += BtnDelete_Click;

            // dgvWarehouse.AutoGenerateColumns = false; // nếu bạn bind bằng DataSource
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
