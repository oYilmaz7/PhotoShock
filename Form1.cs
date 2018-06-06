using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
namespace PhotoShock
{
    public partial class Form1 : Form
    {
        string dosyayolu = null;
        int[] redlist = new int [256];
        int[] greenlist = new int[256];
        int[] bluelist = new int[256];

        



        
        public Form1()
        {
            InitializeComponent();
            this.panel1.AutoScroll = true;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.panel3.AutoScroll = true;
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim dosyası |*.jpg;*.png;*.bmp;*.gif";
            ofd.Title = "Bir resim dosyası seçiniz";
            ofd.ShowDialog();
            dosyayolu = ofd.FileName;
            pictureBox1.ImageLocation = dosyayolu;

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {   

            if (dosyayolu!=null) {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG|*.jpg|BMP|*.bmp|GIF Image|*.gif|PNG|*.png";
            sfd.ShowDialog();
           
            string ext = System.IO.Path.GetExtension(sfd.FileName);
            pictureBox1.Image.Save(sfd.FileName);
        }
        }

        private void buttonGrey_Click(object sender, EventArgs e)
        {

            if (dosyayolu != null)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap gri = greyScale(image);
                pictureBox1.Image = gri;

            }
        }

        private Bitmap greyScale(Bitmap bmp) { 
        
        
        for(int i=0; i<bmp.Height-1; i++){
        
        for(int j=0; j<bmp.Width-1; j++){

            int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;

            Color renk;

            renk = Color.FromArgb(deger,deger,deger);

            bmp.SetPixel(j, i, renk);
        }
        }



        return bmp;
        }



        private Bitmap redScale(Bitmap bmp) {

            for (int i = 0; i < bmp.Height - 1; i++)
            {

                for (int j = 0; j < bmp.Width - 1; j++)
                {

                    

                    Color renk;

                    renk = Color.FromArgb(bmp.GetPixel(j, i).R, 0, 0);

                    bmp.SetPixel(j, i, renk);
                }
            }


            return bmp;
        }


        private Bitmap greenScale(Bitmap bmp)
        {

            for (int i = 0; i < bmp.Height - 1; i++)
            {

                for (int j = 0; j < bmp.Width - 1; j++)
                {



                    Color renk;

                    renk = Color.FromArgb(0, bmp.GetPixel(j, i).G, 0);

                    bmp.SetPixel(j, i, renk);
                }
            }


            return bmp;
        }



        private Bitmap blueScale(Bitmap bmp)
        {

            for (int i = 0; i < bmp.Height - 1; i++)
            {

                for (int j = 0; j < bmp.Width - 1; j++)
                {



                    Color renk;

                    renk = Color.FromArgb(0, 0, bmp.GetPixel(j, i).B);

                    bmp.SetPixel(j, i, renk);
                }
            }


            return bmp;
        }


        private Bitmap invertImage (Bitmap bmp)
        {

            for (int i = 0; i < bmp.Height ; i++)
            {

                for (int j = 0; j < bmp.Width ; j++)
                {



                    Color renk;

                    renk = Color.FromArgb(255-bmp.GetPixel(j, i).R, 255-bmp.GetPixel(j, i).G, 255-bmp.GetPixel(j, i).B);

                    bmp.SetPixel(j, i, renk);
                }
            }


            return bmp;
        }


        private Bitmap rotateRight(Bitmap bmp)
        {

            bmp.RotateFlip(RotateFlipType.Rotate270FlipXY);

            return bmp;
        }



        private Bitmap rotateLeft(Bitmap bmp)
        {

            bmp.RotateFlip(RotateFlipType.Rotate90FlipXY);

            return bmp;
        }




        private void buttonRed_Click(object sender, EventArgs e)
        {

            if (dosyayolu != null)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap red = redScale(image);
                pictureBox1.Image = red;

            }
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {

            if (dosyayolu != null)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap green = greenScale(image);
                pictureBox1.Image = green;

            }
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {

            if (dosyayolu != null)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap blue = blueScale(image);
                pictureBox1.Image = blue;

            }
        }

        private void buttonInvert_Click(object sender, EventArgs e)
        {

            if (dosyayolu != null)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap inverted = invertImage(image);
                pictureBox1.Image = inverted;

            }
        }

        private void buttonRotateRight_Click(object sender, EventArgs e)
        {
            if (dosyayolu != null)
            {

            Bitmap simg = (Bitmap)pictureBox1.Image;
            int genislik = simg.Width;
            int yukseklik = simg.Height;

            Bitmap mimg = new Bitmap(yukseklik, genislik);
            int temp = yukseklik;
            for (int y = 0; y < yukseklik; y++)
            {
                temp--;
                for (int x = 0; x < genislik; x++)
                {
                    Color p = simg.GetPixel(x, temp);
                    mimg.SetPixel(y, x, p);
                }
            }

            pictureBox1.Image = mimg;

        }
            
        }

        private void buttonRotateLeft_Click(object sender, EventArgs e)
        {
            if (dosyayolu != null)
            {
            
                Bitmap simg = (Bitmap)pictureBox1.Image;
                int genislik = simg.Width;
                int yukseklik = simg.Height;

                Bitmap mimg = new Bitmap(yukseklik, genislik);
                int temp = genislik;
                for (int x = 0; x < genislik; x++)
                {
                    temp--;
                    for (int y = 0; y < yukseklik; y++)
                    {
                        Color p = simg.GetPixel(temp, y);
                        mimg.SetPixel(y, x, p);
                    }
                }
                pictureBox1.Image = mimg;
                
        }
        }

        private void pictureBox1_Click_3(object sender, EventArgs e)
        {
            
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void buttonSag_Click(object sender, EventArgs e)
        {


                Bitmap simg = (Bitmap)pictureBox1.Image;
                int genislik = simg.Width;
                int yukseklik = simg.Height;

                Bitmap mimg = new Bitmap(yukseklik, genislik);
                int temp = yukseklik;
                for (int y = 0; y < yukseklik; y++)
                {
                    temp--;
                    for (int x = 0; x < genislik; x++)
                    {
                        Color p = simg.GetPixel(x, temp);
                        mimg.SetPixel(y, x, p);
                    }
                }

                pictureBox1.Image = mimg;
                
            










            
        }

        private void buttonHistogram_Click(object sender, EventArgs e)
        {
            if (dosyayolu != null)
            {
            
            
            
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            /*
            for (int i = 0; i < 256; i++)
            {
                redlist[i] = 0;
                greenlist[i] = 0;
                bluelist[i] = 0;
            }

            int indexr;
            int indexg;
            int indexb;

            for (int i = 0; i < bmp.Height - 1; i++)
            {

                for (int j = 0; j < bmp.Width - 1; j++)
                {



                    indexr = bmp.GetPixel(j, i).R;
                    redlist[indexr]++;
                    indexg = bmp.GetPixel(j, i).G;
                    greenlist[indexg]++;
                    indexb = bmp.GetPixel(j, i).B;
                    bluelist[indexb]++;



                    Console.WriteLine(indexr);

                }
            }

            */
            histogramciz(histogram(bmp));
        }
        }

       


        public int[,] histogram(Bitmap resim)
        {
            int[,] hist = new int[3, 256];

            int a = 0;

            if (resim.PixelFormat == PixelFormat.Format32bppArgb)
            {
                a = 4;
            }
            else if (resim.PixelFormat == PixelFormat.Format24bppRgb)
            {
                a = 3;
            }

            progressBar1.Visible = true;
            progressBar1.Maximum = resim.Width * resim.Height;

            unsafe
            {

                BitmapData data = resim.LockBits(new Rectangle(0, 0, resim.Width, resim.Height), ImageLockMode.ReadWrite, resim.PixelFormat);
                byte* z = (byte*)data.Scan0;

                for (int i = 0; i < data.Width; i++)
                {
                    for (int j = 0; j < data.Height; j++)
                    {
                        hist[0, z[0]]++;
                        hist[1, z[1]]++;
                        hist[2, z[2]]++;
                        z += a;

                        if ((i % 5) == 0)//her on satÄ±rda bir gÃ¶stergeyi gÃ¼ncelle
                        {
                            progressBar1.Value = i * resim.Height + j;
                            Application.DoEvents();
                        }
                    }
                }
                resim.UnlockBits(data);
            }
            progressBar1.Visible = false;
            return hist;
        }

        public void histogramciz(int[,] hist)
        {
            pictureBox2.Refresh();
            pictureBox3.Refresh();
            pictureBox4.Refresh();
            Graphics g = pictureBox2.CreateGraphics();
            Pen pp = new Pen(Color.Red,1);
            for (int i = 0; i < 256; i++)
            {

                g.DrawLine(pp, new Point(i, pictureBox2.Height), new Point(i, pictureBox2.Height - hist[2, i] / 10));

            }
            
            
            g = pictureBox3.CreateGraphics();
            pp = new Pen(Color.Green, 1);
            for (int i = 0; i < 256; i++)
            {

                g.DrawLine(pp, new Point(i, pictureBox3.Height), new Point(i, pictureBox3.Height - hist[1, i] / 10));

            }
            
            
            g = pictureBox4.CreateGraphics();
            pp = new Pen(Color.Blue, 1);
            for (int i = 0; i < 256; i++)
            {

                g.DrawLine(pp, new Point(i, pictureBox4.Height), new Point(i, pictureBox4.Height - hist[0, i] / 10));

            }

            g.Dispose();

        }

        private void buttonBoyut_Click(object sender, EventArgs e)
        {

            if (dosyayolu != null)
            {
                Bitmap simg = (Bitmap)pictureBox1.Image;

                //get source image dimension
                int width = simg.Width;
                int height = simg.Height;

                //load source image in picturebox1
                // pictureBox2.Image = simg;

                //mirror image
                Bitmap mimg = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int lx = 0, rx = width - 1; lx < width; lx++, rx--)
                    {
                        //get source pixel value
                        Color p = simg.GetPixel(lx, y);

                        //set mirror pixel value
                        //  mimg.SetPixel(lx, y, p);
                        mimg.SetPixel(rx, y, p);
                    }
                }

                //load mirror image in picturebox2
                pictureBox1.Image = mimg;

                //save (write) mirror image
                // mimg.Save("D:\\Image\\MirrorImage.png");
        }
        }

        private void buttonReOpen_Click(object sender, EventArgs e)
        {

            if (dosyayolu != null)
            {
                pictureBox1.ImageLocation = dosyayolu;
            }
        }

        private void buttonOlcek_Click(object sender, EventArgs e)
        {


            if (dosyayolu != null)
            {
                    
                    float width = float.Parse(textBox1.Text);
                    float height = float.Parse(textBox2.Text);


                    Color brush = Color.FromArgb(0, 0, 0);
                    
                    Bitmap image = (Bitmap)pictureBox1.Image;

                    float scale = Math.Min(width / image.Width, height / image.Height);

                    Bitmap bmp = new Bitmap((int)width, (int)height);
                    var graph = Graphics.FromImage(bmp);

                    // uncomment for higher quality output
                 //  graph.InterpolationMode = InterpolationMode.High;
                 //  graph.CompositingQuality = CompositingQuality.HighQuality;
                  //  graph.SmoothingMode = SmoothingMode.AntiAlias;

                    var scaleWidth = (int)(image.Width * scale);
                    var scaleHeight = (int)(image.Height * scale);

                    //graph.FillRectangle(brush, new Rectangle(0, 0, width, height));
                    graph.DrawImage(image, new Rectangle(((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight));
                    pictureBox1.Image = bmp;
                    
        }
                    
            
        }

        

        



    }
}
