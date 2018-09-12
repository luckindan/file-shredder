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
    public partial class Log_window : Form
    {
        public Log_window()
        {
            InitializeComponent();
        }
        public Log_window(string fileName)
        {
            InitializeComponent();
            readLog(fileName);
        }
        
        void readLog(string fileName)
        {
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    byte[] buffer = new byte[file.Length];

                    int byteread = file.Read(buffer, 0, buffer.Length);
                    string textReadIn = System.Text.UnicodeEncoding.UTF8.GetString(buffer);

                    textBox1.Text = textReadIn;
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
    }
}
