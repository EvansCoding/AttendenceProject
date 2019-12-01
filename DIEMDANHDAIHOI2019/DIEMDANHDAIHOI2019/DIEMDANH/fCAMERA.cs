namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    using AForge.Video;
    using BUS;
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;
    using ZXing;
    using static DIEMDANHDAIHOI2019.DIEMDANH.fTHONGTIN1920x1080;

    public partial class fCAMERA : DevExpress.XtraEditors.XtraForm
    {
        public fCAMERA(Guid _maDH)
        {
            InitializeComponent();
            this._maDH = _maDH;
        }

        public static resultHash rHash;
        public static void mothodHasing(resultHash sender)
        {
            rHash = sender;
        }
        Guid _maDH;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mjp.FramesReceived != 0)
            {
                pnlIPCam.Hide();
            }

            BarcodeReader reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true
                }
            };

            Result result;
            if (imgCamera != null)
            {
                try
                {
                    result = reader.Decode(imgCamera);
                    if (result != null)
                    {
                        string decoded = result.ToString().Trim();
                        if (decoded != null)
                        {
                            string hashing = decoded;
                            object[] oj = doanVienBUS.Instance.getByHash(hashing);
                            if (oj != null)
                            {
                             //   sounded();
                                lbTEN.Text = (oj[1] as string + " " + oj[2] as string).ToUpper();
                                if ("b4dd03204693172ff0feaa60f1ebb898e54cfb27d0227623329fcf12c3f01fda".Equals(hashing) || "0313ecd18554f9775ee450094515c57f1a6bdc1456a4d028025a36857eeddd24".Equals(hashing))
                                    lbGIOITINH.Text = "NAM";
                                else lbGIOITINH.Text = (oj[4] as string).ToUpper();
                                lbNGUYENQUAN.Text = (oj[5] as string).ToUpper();
                                lbDANTOC.Text = (oj[6] as string).ToUpper();
                                lbTONGIAO.Text = (oj[7] as string).ToUpper();
                                lbCHUYENMON.Text = (oj[8] as string).ToUpper();
                                lbDONVI.Text = (oj[12] as string).ToUpper();

                                ptMain.Image = Image.FromFile(Application.StartupPath + "\\" + "Images\\" + oj[0] + ".jpg");
                                Guid guid = new Guid(oj[13] as string);
                                if (thamDuDaiHoiBUS.Instance.getTime(guid, _maDH) == null)
                                    thamDuDaiHoiBUS.Instance.setStatus(guid, _maDH);
                                rHash(hashing);
                                timer1.Stop();
                                timer2.Start();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }


        public string toTitleCase(string _str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_str.ToLower());
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Stop();
        }

        private void fCAMERA_FormClosing(object sender, FormClosingEventArgs e)
        {
            fQUANLY.Instance.Show();
            timer1.Stop();
            timer2.Stop();
            if (mjp != null)
                mjp.Stop();
        }

        fTHONGTIN1920x1080 fTHONGTINDIEMDANH1920;
        fTHONGTIN1366X768 fTHONGTIN1366X768;
        private void fCAMERA_Load(object sender, EventArgs e)
        {

            lbTEN.Parent = pictureBox1;
            lbTEN.BackColor = System.Drawing.Color.Transparent;
            //panel1.Parent = pictureBox1;
            //panel1.BackColor = System.Drawing.Color.Transparent;
            //pnlIPCam.Parent = pictureBox1;
            //pnlIPCam.BackColor = System.Drawing.Color.Transparent;

            if (Screen.PrimaryScreen.Bounds.Width >= 1900 && Screen.PrimaryScreen.Bounds.Height >= 1000)
            {
                fTHONGTINDIEMDANH1920 = new fTHONGTIN1920x1080(_maDH);
                fTHONGTINDIEMDANH1920.Show();
            }
            else
            {
                fTHONGTIN1366X768 = new fTHONGTIN1366X768(_maDH);
                fTHONGTIN1366X768.Show();
            }
        }

        bool check = true;
        private void fCAMERA_KeyDown(object sender, KeyEventArgs e)
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

        MJPEGStream mjp;
        private void btnConnectCamera_Click(object sender, EventArgs e)
        {
            string ipCon = "http://" + tbIPCam.Text + ":4747/mjpegfeed?960x720";
            mjp = new MJPEGStream(ipCon);
            mjp.NewFrame += Mjp_NewFrame;
            mjp.Start();
            timer1.Enabled = true;
            timer1.Start();
        }

        static Bitmap imgCamera;
        private void Mjp_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            imgCamera = (Bitmap)eventArgs.Frame.Clone();
        }
    }
}