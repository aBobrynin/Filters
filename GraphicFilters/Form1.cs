using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace GraphicsFilters
{
    public partial class Form1 : Form
    {
        public Bitmap image = null;
        List<Bitmap> listB = new List<Bitmap>();
        int listSize = -1;
        int ls = 0;
        bool check = false;

        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            progressBar1.Visible = false;
        }

        public void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filter = "All Files (*.*) | *.*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openDialog.FileName);
                listB.Add(image);
                listSize++;
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }

            label1.Visible = false;
            Console.WriteLine(listSize);
            //Console.WriteLine(ImIndex);
        }

        private void TextToLabel(String str)
        {
            label1.Visible = true;
            label1.Text = str;

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();

                saveDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveDialog.Title = "Сохранить изображение";
            
                saveDialog.DefaultExt = "jpg";
                saveDialog.FileName = "default.jpg";
                saveDialog.ShowDialog();
            
                image.Save(saveDialog.FileName);
            }
            else
            {
                TextToLabel("Нечего сохранять");
            }

            
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                invertFilter filter = new invertFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
                
            }
            else
            {
                TextToLabel("Выберите изображение");
            }

        }

        private void grayscalePALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                grayPalFilter filter = new grayPalFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        private void grayscaleHDTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                grayHdtvFilter filter = new grayHdtvFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                sepiaFilter filter = new sepiaFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                brightFilter filter = new brightFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        private void grayWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                grayWFilter filter = new grayWFilter(image);
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        // Matrix filters-----------------------------------------------------------------------------------------------
        private void lowContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                lowContrastFilter filter = new lowContrastFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                gaussianFilter filter = new gaussianFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        private void boxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                boxFilter filter = new boxFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                sobelFilter filter = new sobelFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        private void embossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                embossFilter filter = new embossFilter();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                TextToLabel("Выберите изображение");
            }
        }

        //Threads

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            image = ((Filter)e.Argument).processImage(image, backgroundWorker1);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;

            if (check) //check Undo/Redo
            {
                listB.RemoveRange(ls + 1, listSize - ls);
                listSize = ls;
                button2.Enabled = false;
                check = false;
            }

            listB.Add(image); 
            listSize++;
            ls = listSize;

            pictureBox1.Image = image;
            pictureBox1.Refresh();
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            label1.Visible = false;

        }

        //other elements

        private void label1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem1_Click(sender, e);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            check = true;
            
            if (ls > 0)
            {
                ls--;
                pictureBox1.Image = listB.ElementAt(ls);
                button2.Enabled = true;
                image = listB.ElementAt(ls);
            }

            if (ls == 0)
            {
                 button1.Enabled = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;

            if (ls < listSize)
            {
                ls++;
                pictureBox1.Image = listB.ElementAt(ls);
            }

            if (ls == listSize) button2.Enabled = false;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem1_Click(sender, e);
        }
        

       
        
        
    }
}
