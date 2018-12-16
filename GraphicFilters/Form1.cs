using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicFilters // Goncharov_Filters 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap image = null;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "All Files ( . ) | *.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);

                pictureBox1.Image = image;
                pictureBox1.Refresh();

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            
            dialog.Filter = "All Files ( . ) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(dialog.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter invfilter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(invfilter);

        }

          private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            image = ((Filter)e.Argument).processImage(image,backgroundWorker1);
            
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter sep = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(sep);

        }

        private void grayscalePALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter grayscale = new GrayFilterPAL();
            backgroundWorker1.RunWorkerAsync(grayscale);
        }

        private void grayscaleHDTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter grayscale = new GrayFilterHDTV();
            backgroundWorker1.RunWorkerAsync(grayscale);

        }

        private void Matr1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[,] krr = new float[3, 3];

            //////zadaem matricu

            //1 line
            krr[0, 0] = 0;
            krr[0, 1] = -1;
            krr[0, 2] = 0;
            //////2 line
            krr[1, 0] = -1;
            krr[1, 1] = 5;
            krr[1, 2] = 1;
            //////3 line
            krr[2, 0] = 0;
            krr[2, 1] = -1;
            krr[2, 2] = 0;

            int dvf = 4;
            
            //////////////
            
            Filter Matr = new LinearFilter(krr, dvf);

            backgroundWorker1.RunWorkerAsync(Matr);

        }

        private void gaussToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GAUSS

            float[,] krr = new float[3, 3];

            //////zadaem matricu

            //1 sline
            krr[0, 0] = 1;
            krr[0, 1] = 2;
            krr[0, 2] = 1;
            //////2 line
            krr[1, 0] = 2;
            krr[1, 1] = 4;
            krr[1, 2] = 2;
            //////3 line
            krr[2, 0] = 1;
            krr[2, 1] = 2;
            krr[2, 2] = 1;

            //////////////
            int dvf = 16;


            Filter Matr = new LinearFilter(krr, dvf);

            backgroundWorker1.RunWorkerAsync(Matr);

        }

        private void eaglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[,] krr = new float[3, 3];

            //////zadaem matricu  EAGLES

            //1 line
            krr[0, 0] = -1;
            krr[0, 1] = -1;
            krr[0, 2] = -1;
            //////2 line
            krr[1, 0] = -1;
            krr[1, 1] = 8;
            krr[1, 2] = -1;
            //////3 line
            krr[2, 0] = -1;
            krr[2, 1] = -1;
            krr[2, 2] = -1;

            //////////////
            int dvf = 1;


            Filter Matr = new LinearFilter(krr, dvf);

            backgroundWorker1.RunWorkerAsync(Matr);

        }

     
    }
}

