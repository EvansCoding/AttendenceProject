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
using DTODLL;

namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    public partial class fTHONGTINDIEMDANH : DevExpress.XtraEditors.XtraForm
    {
        public fTHONGTINDIEMDANH(Guid guid)
        {
            InitializeComponent();
            timer1.Start();
            _maDH = guid;
        }

        bool check = true;

        public delegate void resultHash(String value);
        private string resultHashing;

        private void SetValue(String value)
        {
            resultHashing = value;
        }
        private void fTHONGTINDIEMDANH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11 && check)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                check = false;
            }
            else
            {
                if (e.KeyCode == Keys.F11 && !check)
                {
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
                    WindowState = FormWindowState.Normal;
                    check = true;
                }
            }

        }
        public void showClient(DOANVIEN _clientName)
        {

            US_ShortInfo uS_ShortInfo = new US_ShortInfo(Image.FromFile(Application.StartupPath + "\\Images\\" + _clientName.CMND + ".jpg"), _clientName.HOLOT.ToUpper() + " " + _clientName.TEN.ToUpper());
            flpAllUser.BeginInvoke((Action)(() =>
            {
                flpAllUser.Controls.Add(uS_ShortInfo);
            }));
        }
        public static Guid _maDH;
        List<string> ds = new List<string>();

        List<DOANVIEN> dvl;
        private void timer1_Tick(object sender, EventArgs e)
        {
            fCAMERA.mothodHasing(SetValue);

            if (!ds.Contains(resultHashing) && resultHashing != null)
            {
                ds.Add(resultHashing);
               // doanVienBUS dvBUS = new doanVienBUS();
                DOANVIEN dv = doanVienDTO.Instance.getByHash(resultHashing);
                showMain(dv);
                resultHashing = null;
                dvl = thamDuDaiHoiDTO.Instance.dvTake5(_maDH);

                while (flpAllUser.Controls.Count > 0) flpAllUser.Controls.RemoveAt(0);

                int i = 0;
                foreach (var item in dvl)
                {
                    if (i == 0)
                    {
                        i++;
                        continue;
                    }

                    if (i > 6)
                    {
                        i = 0;
                        continue;
                    }
                    showClient(item);
                    i++;
                }
                dvl.Clear();
            }
        }

        private void showMain(DOANVIEN dv)
        {
            lbTEN.Text = dv.HOLOT.ToUpper() + " " + dv.TEN.ToUpper();
            ptbMain.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + dv.CMND + ".jpg");
            lbGIOITINH.Text = dv.NAM == true ? "NAM" : "NỮ";
            lbNGUYENQUAN.Text = dv.NGUYENQUAN == "" ? "KHÔNG CÓ" : dv.NGUYENQUAN.ToUpper();
            lbDANTOC.Text = dv.DANTOC == "" ? "KHÔNG CÓ" : dv.DANTOC.ToUpper();
            lbCHUYENMON.Text = dv.CMNV == "" ? "KHÔNG CÓ" : dv.CMNV.ToUpper();
            lbDONVI.Text = dv.DONVI == "" ? "KHÔNG CÓ" : dv.DONVI.ToUpper();
        }

        private void fTHONGTINDIEMDANH_Load(object sender, EventArgs e)
        {
            try
            {
                dvl = thamDuDaiHoiDTO.Instance.dvTake5(_maDH);

                while (flpAllUser.Controls.Count > 0) flpAllUser.Controls.RemoveAt(0);

                int i = 0;
                showMain(dvl[i]);
                foreach (var item in dvl)
                {
                    if (i == 0)
                    {
                        i++;
                        continue;
                    }

                    if (i > 5)
                    {
                        i = 0;
                        continue;
                    }
                    showClient(item);
                    i++;
                }
                dvl.Clear();
            }
            catch (Exception)
            {
            }

        }
    }
}