using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K.Properties;
using System.Media;

namespace K
{
    public partial class Kompo : UserControl
    {
        int x = 0;
        private double min, max, roznica, scale;
        private double maxScale, minScale;
        private Label labelmin, labelmax,labeljed;
        private String jednostka;
        String[] images = { "gora","prawogora","prawo","prawodol","dol","lewodol","lewo","lewogora" };
        public Kompo()
        {
            InitializeComponent();
            Label label1 = new Label();
            Label lbl0 = new Label();
            Label lbl1 = new Label();
            Label lbl2 = new Label();
            Label lbl3 = new Label();
            Label lbl4 = new Label();
            Label lbl5 = new Label();
            Label lbl6 = new Label();
            Label lbl7 = new Label();
            labeljed = new Label();
             labelmin = new Label();
             labelmax = new Label();
            label1.Image = (Bitmap)Resources.ResourceManager.GetObject(images[0]);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Kompo_MouseWheel);

           
            label1.Focus();




        }
      
        private void Kompo_Load(object sender, EventArgs e)
        {
           

        }

       

      

        private void Kompo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
            if (e.KeyData == Keys.Up)
            {
                if (x == images.Length-1)
                {

                }
                else
                {
                    x++;
                    
                    label1.Image = (Bitmap)Resources.ResourceManager.GetObject(images[x]);
                    SoundPlayer audio = new SoundPlayer(K.Properties.Resources.klik); 
                    audio.Play();
                }

            }
            else if (e.KeyData == Keys.Down)
            {
                if (x == 0)
                {

                }
                else
                {
                    x--;
                   
                    label1.Image = (Bitmap)Resources.ResourceManager.GetObject(images[x]);
                    SoundPlayer audio = new SoundPlayer(K.Properties.Resources.klik); 
                    audio.Play();
                }

            }
        }
        private void Kompo_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (x == images.Length - 1)
                {

                }
                else
                {
                    x++;

                    label1.Image = (Bitmap)Resources.ResourceManager.GetObject(images[x]);
                    SoundPlayer audio = new SoundPlayer(K.Properties.Resources.klik);
                    audio.Play();
                }
            }
            else
            {
                if (x == 0)
                {

                }
                else
                {
                    x--;

                    label1.Image = (Bitmap)Resources.ResourceManager.GetObject(images[x]);
                    SoundPlayer audio = new SoundPlayer(K.Properties.Resources.klik);
                    audio.Play();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        

        public double MaxScale
        {
            get{ return maxScale; }
            set {
                maxScale = value;
                labelmax.Text = maxScale.ToString();
           }
           
            
        }


        public double MinScale
        {
            get { return minScale; }
            set {
                minScale = value;
                labelmin.Text = minScale.ToString();

                roznica =Double.Parse(labelmax.Text)-Double.Parse(labelmin.Text);
                scale = roznica / 8;

                for (int i = 0; i < 8; i++)
                {
                    Double wynik =  ((i + 1) * scale + Double.Parse(labelmin.Text));
                    this.Controls["lbl" + i.ToString()].Text  = wynik.ToString()+labeljed.Text;
                  
                }
            }
        }
        public string Jednostka
        {
            get { return jednostka; }
            set {
                jednostka = value;
                labeljed.Text=jednostka ; }
        }

        
    }
}
