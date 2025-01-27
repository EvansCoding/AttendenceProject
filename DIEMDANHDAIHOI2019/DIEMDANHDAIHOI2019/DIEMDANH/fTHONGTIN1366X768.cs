﻿namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using DTODLL;
    using System.Globalization;

    public partial class fTHONGTIN1366X768 : DevExpress.XtraEditors.XtraForm
    {
        public static Guid _maDH;
        List<string> ds = new List<string>();
        List<DOANVIEN> dvl;

        public fTHONGTIN1366X768(Guid guid)
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

        private void fTHONGTIN1366X768_Load(object sender, EventArgs e)
        {
            lbTEN.Parent = pictureBox1;
            lbTEN.BackColor = System.Drawing.Color.Transparent;
            panel1.Parent = pictureBox1;
            panel1.BackColor = System.Drawing.Color.Transparent;
            flpAllUser.Parent = pictureBox1;
            flpAllUser.BackColor = System.Drawing.Color.Transparent;

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
        private void showMain(DOANVIEN dv)
        {
            lbTEN.Text = dv.HOLOT.ToUpper() + " " + dv.TEN.ToUpper();
            ptMain.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + dv.CMND + ".jpg");
            lbGIOITINH.Text = dv.NAM == true ? "Nam" : "Nữ";
            lbNGUYENQUAN.Text = dv.NGUYENQUAN == "" ? "Không" : toTitleCase(dv.NGUYENQUAN);
            lbDANTOC.Text = dv.DANTOC == "" ? "Không" : toTitleCase(dv.DANTOC);
            lbTONGIAO.Text = dv.TONGIAO == "" ? "Không" : toTitleCase(dv.TONGIAO);
            lbCHUYENMON.Text = dv.CMNV == "" ? "Không" : toTitleCase(dv.CMNV);
            lbDONVI.Text = dv.DONVI == "" ? "Không" : toTitleCase(dv.DONVI);
        }

        public string toTitleCase(string _str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_str.ToLower());
        }

        public void showClient(DOANVIEN _clientName)
        {

            US_ShortInfor1366x768 uS_ShortInfo = new US_ShortInfor1366x768(Image.FromFile(Application.StartupPath + "\\Images\\" + _clientName.CMND + ".jpg"), _clientName.HOLOT.ToUpper() + " " + _clientName.TEN.ToUpper());
            flpAllUser.BeginInvoke((Action)(() =>
            {
                flpAllUser.Controls.Add(uS_ShortInfo);
            }));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fCAMERA.mothodHasing(SetValue);

            if (!ds.Contains(resultHashing) && resultHashing != null)
            {
                ds.Add(resultHashing);
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

        private void fTHONGTIN1366X768_KeyDown(object sender, KeyEventArgs e)
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

        private void lbTEN_Click(object sender, EventArgs e)
        {

        }
    }
}