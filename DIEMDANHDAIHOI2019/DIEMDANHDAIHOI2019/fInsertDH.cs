using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;

namespace DIEMDANHDAIHOI2019
{
    public partial class fInsertDH : DevExpress.XtraEditors.XtraForm
    {
        public fInsertDH()
        {
            InitializeComponent();
        }

        private void bntExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Bạn muốn lưu thông tin!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                bool check = GeneralClass.Instance.INSERTALL(teChuDe.Text, deNgayDaiHoi.Value, tePathExcel.Text, tePathAnh.Text);
                if (check)
                {
                    XtraMessageBox.Show("LƯU THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else XtraMessageBox.Show("LƯU THẤT BẠI! Hãy Kiểm tra lại!...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            string pathExcel = "";
            pathExcel = f.ShowDialog() == DialogResult.OK ? f.FileName : "";
            tePathExcel.Text = pathExcel;
        }

        private void btnOpenFolderAnh_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tePathAnh.Text = fbd.SelectedPath;
                }
            }
        }
    }
}