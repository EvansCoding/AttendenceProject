namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    using DTODLL;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    public partial class fTHONGTIN1920x1080 : DevExpress.XtraEditors.XtraForm
    {
        public fTHONGTIN1920x1080(Guid guid)
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
            if ("b4dd03204693172ff0feaa60f1ebb898e54cfb27d0227623329fcf12c3f01fda".Equals(dv.HASHING) || "0313ecd18554f9775ee450094515c57f1a6bdc1456a4d028025a36857eeddd24".Equals(dv.HASHING))
                lbGIOITINH.Text = "NAM";
            else lbGIOITINH.Text = dv.NAM == true ? "NAM" : "NỮ";

            lbNGUYENQUAN.Text = dv.NGUYENQUAN == "" ? "KHÔNG" : dv.NGUYENQUAN.ToUpper();
            lbDANTOC.Text = dv.DANTOC == "" ? "KHÔNG" : dv.DANTOC.ToUpper();
            lbTONGIAO.Text = dv.TONGIAO == "" ? "KHÔNG" : dv.TONGIAO.ToUpper();
            lbCHUYENMON.Text = dv.CMNV == "" ? "KHÔNG" : dv.CMNV.ToUpper();
            lbDONVI.Text = dv.DONVI == "" ? "KHÔNG" : dv.DONVI.ToUpper();
        }

        public string toTitleCase(string _str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_str.ToLower());
        }

        private void fTHONGTIN1920x1080_Load(object sender, EventArgs e)
        {
            lbTEN.Parent = pictureBox1;
            lbTEN.BackColor = System.Drawing.Color.Transparent;
            //panel1.Parent = pictureBox1;
            //panel1.BackColor = System.Drawing.Color.Transparent;
            //flpAllUser.Parent = pictureBox1;
            //flpAllUser.BackColor = System.Drawing.Color.Transparent;
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

            US_ShortInfo1920x1080 uS_ShortInfo = new US_ShortInfo1920x1080(Image.FromFile(Application.StartupPath + "\\Images\\" + _clientName.CMND + ".jpg"), _clientName.HOLOT.ToUpper() + " " + _clientName.TEN.ToUpper(), flpAllUser);
            flpAllUser.BeginInvoke((Action)(() =>
            {
                flpAllUser.Controls.Add(uS_ShortInfo);
            }));
        }
        private void sounded()
        {
            //   System.Media.MP3Player mplayer = new MP3Player();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Application.StartupPath + @"\sound\bipwav.wav");
            player.Play();
        }

        public static Guid _maDH;
        List<string> ds = new List<string>();
        List<DOANVIEN> dvl;

        private void timer1_Tick(object sender, EventArgs e)
        {
            fCAMERA.mothodHasing(SetValue);

            if (!ds.Contains(resultHashing) && resultHashing != null)
            {
                sounded();
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
    }
}