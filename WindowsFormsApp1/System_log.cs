﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//using System.Generics.Collections;
//at the top and use the template class LinkedList<LogEntry>'


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
       
    }


    public class Log
    {
        LinkedList<LogEntry> m_log;
        LogEntry head = new LogEntry();

        //default contructor
        public Log(){
            m_log = new LinkedList<LogEntry>();

        }
       
        //this iwll add Log entry to the linked list
        public void AddEntry(LogEntry entry) {
            try
            {
                LogEntry newNode = new LogEntry(entry);
                m_log.AddLast(entry);
            }
            catch(Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message);
            }
        }

        //
        //Severity's number represents info/warning/error/fatal error/reactor meltdown
        //1  = info
        // 2 =  warning
        // 3 = error
        // 4 = fatal error
        // 5 reactor meltdown
        //error description
        public void AddEntry(int severity, string logText) {
            try
            {
                LogEntry newNode = new LogEntry(severity, logText);
                m_log.AddLast(newNode);
            }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message);
            }

        }

        //writes the file and save it
        public void SaveFile(string fileName) {
            //FileStream logFile = new FileStream.Create();
            try
            {
                //check if the file already exists
                if (System.IO.File.Exists(fileName))
                {
                    throw new Exception();
                }


                //create the log file
                using (FileStream LogFile = new FileStream(fileName, FileMode.CreateNew)) {

                   //iterate through the created linked list
                    foreach (LogEntry logline in m_log)
                    {
                        //write the text into UTF8 format
                        byte[] buffer = System.Text.UnicodeEncoding.UTF8.GetBytes(logline.ToString());
                        LogFile.Write(buffer, 0, buffer.Length);
                            
                   }

                    //dispose to avoid memory leak
                    LogFile.Dispose();
                } 

            }
            catch(Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message);
            }
        }
    }
}