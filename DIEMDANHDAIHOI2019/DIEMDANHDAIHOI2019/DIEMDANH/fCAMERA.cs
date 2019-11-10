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
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;
using BUS;
using static DIEMDANHDAIHOI2019.DIEMDANH.fTHONGTINDIEMDANH;
using System.Globalization;

namespace DIEMDANHDAIHOI2019.DIEMDANH
{
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
        private FilterInfoCollection capturedev;
        private VideoCaptureDevice finalframe;

        private void load()
        {
            capturedev = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            finalframe = new VideoCaptureDevice(capturedev[1].MonikerString);
            finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            finalframe.Start();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                ptCamera.Image = (Bitmap)eventArgs.Frame.Clone();

            }
            catch (Exception)
            {
            }
        }
        private void NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            ptCamera.Image = video;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
            if (ptCamera.Image != null)
            {
                try
                {
                    result = reader.Decode((Bitmap)ptCamera.Image);
                    string decoded = result.ToString().Trim();
                    if (decoded != null)
                    {
                        string hashing = decoded;
                        MessageBox.Show(hashing);
                        object[] oj = doanVienBUS.Instance.getByHash(hashing);
                        if (oj != null)
                        {
                           
                            lbTEN.Text = toTitleCase( oj[1] as string + " "+ oj[2] as string);
                            lbGIOITINH.Text = oj[4] as string;
                            lbNGUYENQUAN.Text = oj[5] as string;
                            lbDANTOC.Text = oj[6] as string;
                            lbTONGIAO.Text = oj[7] as string;
                            lbCHUYENMON.Text = oj[8] as string;
                            lbDONVI.Text = oj[12] as string;

                            ptMain.Image = Image.FromFile(Application.StartupPath + "\\" + "Images\\" + oj[0] + ".jpg");
                            Guid guid = new Guid(oj[13] as string);
                            if(thamDuDaiHoiBUS.Instance.getTime(guid, _maDH)== null)
                                thamDuDaiHoiBUS.Instance.setStatus(guid, _maDH);
                            rHash(hashing);
                            timer1.Stop();
                            timer2.Start();
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
            if (finalframe != null)
            {
                if (finalframe.IsRunning == true)
                {
                    finalframe.Stop();
                }
            }
            fQUANLY.Instance.Show();
            //fTHONGTINDIEMDANH.Close();
        }
        fTHONGTIN1920x1080 fTHONGTINDIEMDANH1920;
        fTHONGTINDIEMDANH fTHONGTINDIEMDANH;
        private void fCAMERA_Load(object sender, EventArgs e)
        {
            load();
            fTHONGTINDIEMDANH1920 = new fTHONGTIN1920x1080(_maDH);
            fTHONGTINDIEMDANH1920.Show();

            //fTHONGTINDIEMDANH = new fTHONGTINDIEMDANH(_maDH);
            //fTHONGTINDIEMDANH.Show();
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
    }
}