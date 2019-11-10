namespace BUS.Classes
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class saveImages
    {
        private static saveImages instance;

        public static saveImages Instance
        {
            get
            {
                if (instance == null) return instance = new saveImages();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public bool saveImageToFolderImages(string _pathImages)
        {
            try
            {
                string[] files;
                files = Directory.GetFiles(_pathImages);
                if (saveImage(files))
                    return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private bool saveImage(string[] files)
        {
            try
            {
                foreach (var item in files)
                {
                    string[] name = item.Split('\\');
                    string[] namShort = name[name.Length - 1].Split('.');
                    Image image = Image.FromFile(item);
                    image = resizeImage(image, new Size(300, 400));
                    image.Save(Application.StartupPath + "\\Images\\" + namShort[0] +".jpg");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return false;
        }

    }
}
