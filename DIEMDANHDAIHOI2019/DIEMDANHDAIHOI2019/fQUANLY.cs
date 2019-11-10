using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using BUS;
using DIEMDANHDAIHOI2019.Report;
using DIEMDANHDAIHOI2019.DIEMDANH;
using DTODLL;

namespace DIEMDANHDAIHOI2019
{
    public partial class fQUANLY : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fQUANLY()
        {
            InitializeComponent();
        }

        private static fQUANLY instance;
        public static fQUANLY Instance
        {
            get
            {
                if (instance == null) return instance = new fQUANLY();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        #region EVENTS
        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            fInsertDH fInsertDH = new fInsertDH();
            DialogResult dialog = fInsertDH.ShowDialog();
            if (dialog == DialogResult.Cancel)
                refresh();
        }
        #endregion

        #region METHODS
        List<Guid> guids = new List<Guid>();
        private void refresh()
        {
            guids.Clear();
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;

            object[] data = daiHoiBUS.Instance.displayInfo();
            gridControl1.DataSource = data[0] as DataTable;
            List<string> guidString = data[1] as List<string>;
            foreach (var item in guidString)
            {
                Guid temp = new Guid(item.ToString());
                guids.Add(temp);
            }
        }
        #endregion

        #region EVENTS
        private void fQUANLY_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            refresh();
        }
        static int id;



        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool check = false;
            int[]  a  = gridView1.GetSelectedRows();
            foreach (var item in a)
            {
                int id = Convert.ToInt16(gridView1.GetRowCellValue(item, gridView1.Columns[0]));
                thamDuDaiHoiBUS thamDuDaiHoiBUS = new thamDuDaiHoiBUS();
                if (!thamDuDaiHoiBUS.deleteDanhSachThamDu(guids[id - 1])  )
                {
                    Console.WriteLine(guids[id - 1].ToString() + " xóa không thành công!");
                    check = true;
                    break;
                }
            }


            foreach (var item in a)
            {
                int id = Convert.ToInt16(gridView1.GetRowCellValue(item, gridView1.Columns[0]));
                if (!daiHoiBUS.Instance.deleteDaiHoi(guids[id - 1]))
                {
                    Console.WriteLine(guids[id - 1].ToString() + " xóa không thành công!");
                    check = true;
                    break;
                }
            }

            //    if (!check) BUS.daiHoiBUS.Instance.deleteDaiHoi(guids[id - 1]);
            refresh();
        }

        private void btnCamera_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                fCAMERA fCamera= new fCAMERA(guids[id - 1]);
                fCamera.Show();

                this.Hide();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                fSUB  subreport = new fSUB(guids[id - 1]);
                subreport.ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        private void btnStatistic_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                fTHONGKE tHONGKE = new fTHONGKE(guids[id - 1]);
                tHONGKE.ShowDialog();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            id = Convert.ToInt16(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]));
           // thamDuDaiHoiBUS thamDuDaiHoiBUS = new thamDuDaiHoiBUS();

            gridControl2.DataSource = thamDuDaiHoiBUS.Instance.dsDoanVienThamGia(guids[id - 1]);
        }

        private void btnDeleteAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chứ!", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.OK)
            {
                if (Entities.Instance.deleteAll())
                    MessageBox.Show("XÓA THÀNH CÔNG!", "THÔNG BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refresh();
        }
    }
}