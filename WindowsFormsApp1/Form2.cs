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
            textBox1.Text = "No log files here";
        }
        public Log_window(string fileName)
        {
            InitializeComponent();
            readLog(fileName);
          
        }

        void readLog(string fileName)
        {
            Log m_log = new Log();
            textBox1.Text = m_log.ReadFile(fileName); //reads the text from the log file
        }
    }
}
