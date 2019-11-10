using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    public partial class US_ShortInfo1920x1080 : DevExpress.XtraEditors.XtraUserControl
    {
        public US_ShortInfo1920x1080(Image _picture, string _text)
        {
            InitializeComponent();
            pictureBox1.Image = _picture;
            label1.Text = _text;
        }
    }
}
