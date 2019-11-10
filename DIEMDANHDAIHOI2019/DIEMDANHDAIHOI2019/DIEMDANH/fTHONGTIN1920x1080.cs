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
using System.Globalization;
namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    public partial class fTHONGTIN1920x1080 : DevExpress.XtraEditors.XtraForm
    {
        public fTHONGTIN1920x1080(Guid guid)
        {
            InitializeComponent();
            timer1.Start();
            _maDH = guid;
        }
        bool check = true;

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }
        public delegate void resultHash(String value);
        private string resultHashing;

        private void SetValue(String value)
        {
            resultHashing = value;
        }
        private void fTHONGTIN1920x1080_KeyDown(object sender, KeyEventArgs e)
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
        private void showMain(DOANVIEN dv)
        {
           lbTEN.Text = dv.HOLOT.ToUpper() + " " + dv.TEN.ToUpper();
            ptMain.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + dv.CMND + ".jpg");
            lbGIOITINH.Text = dv.NAM == true ? "Nam" : "Nữ";
            lbNGUYENQUAN.Text = dv.NGUYENQUAN == "" ? "Không Có" : toTitleCase(dv.NGUYENQUAN);
            lbDANTOC.Text = dv.DANTOC == "" ? "Không Có" : toTitleCase(dv.DANTOC);
           lbTONGIAO.Text = dv.TONGIAO == "" ? "Không Có" : toTitleCase(dv.TONGIAO);
           lbCHUYENMON.Text = dv.CMNV == "" ? "Không Có" : toTitleCase(dv.CMNV);
           lbDONVI.Text = dv.DONVI == "" ? "Không Có" : toTitleCase(dv.DONVI);
        }

        public string toTitleCase(string _str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_str.ToLower());
        }

        private void fTHONGTIN1920x1080_Load(object sender, EventArgs e)
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
        public void showClient(DOANVIEN _clientName)
        {

            US_ShortInfo1920x1080 uS_ShortInfo = new US_ShortInfo1920x1080(Image.FromFile(Application.StartupPath + "\\Images\\" + _clientName.CMND + ".jpg"), _clientName.HOLOT.ToUpper() + " " + _clientName.TEN.ToUpper());
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
    }
}