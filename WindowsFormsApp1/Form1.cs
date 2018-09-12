using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class FIle_path : Form
    {
        Log _log = new Log();
        string filename = ""; //chang the filename path here
 
        public FIle_path()
        {
            InitializeComponent();
            _log.AddEntry(0, "File shredder initialized");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //this function doesnt do anythin
       // private void Destination_Click(object sender, EventArgs e) { }
      
        //click this buttom to active file shredder
        private void Runbottom_Click(object sender, EventArgs e)
        {

            try
            {
                /////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////
                long buffer_Length = 2048;
                //getting the filename from the textBox
                string fileName = FileNameBox.Text.Trim();

                //open the file
                FileStream fileObject = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite);
                //get the file length
                long fileLength = fileObject.Length;

                //message box for filelength
                //MessageBox.Show("The file Length of this file is " + fileLength);
                Random randomBits = new Random();

                //the buffer can be increased or decreaed by bitSize
                byte[] buffer = new byte[buffer_Length];
            

                //enter a loop to overwrite the each bits in the file
                for (long fileIndex = 0; fileIndex < fileLength;)
                {
                    randomBits.NextBytes(buffer);

                    int chunkSize = buffer.Length;
                    if ((fileLength - fileIndex) < buffer.Length)
                    {
                        chunkSize = (int)(fileLength - fileIndex);
                    }

                    fileObject.Write(buffer, 0, chunkSize);
                    fileIndex += chunkSize;

                }

                MessageBox.Show("The Shredding operation successed");
                fileObject.Dispose();
                /////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////

            }
            catch
            {
                MessageBox.Show("The path is invalid or the file does not exist");
                FileNameBox.Text = "";
            }
        }
        //this shows the text
        //work as an input
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Here browse click returns the file address
        private void Browse_Click(object sender, EventArgs e)
        {
            //open the dialog with windows
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FileNameBox.Text = fileDialog.FileName;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _log.SaveFile(filename);
            Log_window log_Window = new Log_window();
            log_Window.ShowDialog();

        }      
    }

}
