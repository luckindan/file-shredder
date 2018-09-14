using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    public class LogEntry
    {
        public DateTime m_TimeStamp;
        public int m_Severity;
        public string m_LogText;

        //default constructor
        public LogEntry()
        {
            m_TimeStamp = DateTime.Now;
            m_Severity = 0;
            m_LogText = "";
        }

        //constructor takes severity and LogText
        public LogEntry(int severity, string LogText)
        {
            m_TimeStamp = DateTime.Now;
            m_Severity = severity;
            m_LogText = LogText;
        }
        //copy constructor
        public LogEntry(LogEntry new_logEntry)
        {
            m_TimeStamp = new_logEntry.m_TimeStamp;
            m_Severity = new_logEntry.m_Severity;
            m_LogText = new_logEntry.m_LogText;
        }

        //overloaded ToString function
        public new string ToString()
        {
            return m_TimeStamp.ToString() + ", " + Enum.GetName(typeof(InfotypeEnum),m_Severity)+ ", " + m_LogText.ToString() + "\r\n"; 
        }
        enum InfotypeEnum
        {
            Info = 0,
            Warning = 1,
            Error = 2,
            Fatal_Error = 3,
            reator_Melt_Down = 4
        }
    }


    public class Log
    {
        LinkedList<LogEntry> m_log;
        LogEntry head = new LogEntry();

        //default contructor
        public Log(){
            m_log = new LinkedList<LogEntry>(); //craete the new linked list
        }
       
        //this will add Log entry to the linked list
        public bool AddEntry(LogEntry entry) {
            bool m_operation = false;
            try
            {
                LogEntry newNode = new LogEntry(entry);
                m_log.AddLast(entry);
                m_operation = true; //add entry successed
            }
            catch(Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message);
            }
            return m_operation;
        }
  
        //Severity's number represents info/warning/error/fatal error/reactor meltdown
        //0 = info
        //1 =  warning
        //2 = error
        //3 = fatal error
        //4 reactor meltdown
        //error description
        public bool AddEntry(int severity, string logText) {
            bool m_operation = false;
            try
            {
                LogEntry newNode = new LogEntry(severity, logText);
                m_log.AddLast(newNode);
                m_operation = true; //operation successed
            }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message);
            }
            return m_operation; //return the operation status
        }
        //writes the file and save it
        public bool SaveFile(string fileName) {
            bool m_operation = false;
            try
            {
                //check if the file already exists
                //if it exists, append to the existed file
                if (System.IO.File.Exists(fileName))
                {
                    using (FileStream LogFile = new FileStream(fileName, FileMode.Append))
                    {
                        //iterate through the created linked list
                        foreach (LogEntry logline in m_log)
                        {
                            //write the text into UTF8 format
                            byte[] buffer = System.Text.UnicodeEncoding.UTF8.GetBytes(logline.ToString());
                            LogFile.Write(buffer, 0, buffer.Length);

                        }
                        //dispose to avoid memory leak
                        LogFile.Dispose();
                        m_operation = true; //operation successed
                    }                
                }
                //if it does not exist, write a new file
                else
                {
                    //create the log file
                    using (FileStream LogFile = new FileStream(fileName, FileMode.CreateNew))
                    {
                        //iterate through the created linked list
                        foreach (LogEntry logline in m_log)
                        {
                            //write the text into UTF8 format
                            byte[] buffer = System.Text.UnicodeEncoding.UTF8.GetBytes(logline.ToString());
                            LogFile.Write(buffer, 0, buffer.Length);
                        }
                        //dispose to avoid memory leak
                        LogFile.Dispose();
                        m_operation = true; //operation successed
                    }                    
                }
            }
            catch(Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message);
            }
            return m_operation; //return the operation statues
        }

        //reads the file and return a string
        public string ReadFile(string fileName)
        {
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[file.Length]; //create the buffer
                    int byteread = file.Read(buffer, 0, buffer.Length); //loads the data into byteRead
                    string textReadIn = System.Text.UnicodeEncoding.UTF8.GetString(buffer); //send the info from byteread to textReadIn
                    file.Dispose();
                    return textReadIn; //return the read text string
                }
            }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message); //show the error message if read failed
                return ""; //return nothing
            }
        }
    }
}
