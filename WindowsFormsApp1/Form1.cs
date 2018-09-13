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
        string filename = "C:\\Testing\\text.csv"; //change the filename path here
 
        public FIle_path()
        {
            InitializeComponent();
            _log.AddEntry(0, "File shredder initialized");
        }
     
        //click this buttom to active file shredder
        private void Runbottom_Click(object sender, EventArgs e)
        {
            _log.AddEntry(0, "Initializing shredding operation");
            try
            {
                long buffer_Length = 2048;
                //getting the filename from the textBox
                string fileName = FileNameBox.Text.Trim();

                //open the file
                FileStream fileObject = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite);
                _log.AddEntry(0, "File reads succesfully");
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
                _log.AddEntry(0, "Shredding complete\n");
                MessageBox.Show("The Shredding operation successed");
                fileObject.Dispose();

            }
            catch
            {
                _log.AddEntry(1, "failed to shred");
                MessageBox.Show("The path is invalid or the file does not exist");
                FileNameBox.Text = "";
            }
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

        //opens the form2 the log window
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {  
                if (_log.SaveFile(filename))
                {
                    Log_window log_Window = new Log_window(filename);
                    log_Window.ShowDialog();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }      
    }

}
