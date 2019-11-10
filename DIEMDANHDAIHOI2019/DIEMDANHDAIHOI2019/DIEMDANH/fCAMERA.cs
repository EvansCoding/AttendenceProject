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
                                lbTEN.Text = (oj[1] as string + " " + oj[2] as string).ToUpper();
                                lbGIOITINH.Text = toTitleCase(oj[4] as string);
                                lbNGUYENQUAN.Text = toTitleCase(oj[5] as string);
                                lbDANTOC.Text = toTitleCase(oj[6] as string);
                                lbTONGIAO.Text = toTitleCase(oj[7] as string);
                                lbCHUYENMON.Text = toTitleCase(oj[8] as string);
                                lbDONVI.Text = toTitleCase(oj[12] as string);

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