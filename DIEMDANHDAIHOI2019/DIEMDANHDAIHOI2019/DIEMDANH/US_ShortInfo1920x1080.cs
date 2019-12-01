namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class US_ShortInfo1920x1080 : DevExpress.XtraEditors.XtraUserControl
    {
        private static PictureBox background = new PictureBox() { BackgroundImage = Properties.Resources.backgroundfixed};
        
        
        public US_ShortInfo1920x1080(Image _picture, string _text, FlowLayoutPanel _background)
        {
            InitializeComponent();
            Parent = background;
            BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = _picture;
            label1.BackColor = Color.White;
            label1.Text = _text;

        }

        private void US_ShortInfo1920x1080_Load(object sender, System.EventArgs e)
        {

        }
    }
}
