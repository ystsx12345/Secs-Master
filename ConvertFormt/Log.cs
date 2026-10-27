using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using NLog;
using ConvertFormt.Server;

namespace ConvertFormt
{
    public class Log
    {
        public delegate void LogAppendDelegate(Color color, string text);
        public static RichTextBox richTextBoxRemote;
        public static RichTextBox richTextBoxRemoteSML;
        /// <summary>
        /// 构造函数传入RichTextBox控件的实例。
        /// </summary>
        /// <param name="richTextBoxRemote"></param>
        public  Log(RichTextBox richText)
        {
            richTextBoxRemote = richText;
        }

        public static void SetLogBytes(RichTextBox richText)
        {
            richTextBoxRemote = richText;
        }

        public static void SetLogSML(RichTextBox richText)
        {
            richTextBoxRemoteSML = richText;
        }
        /// <summary>
        /// LogAppendDelegate委托指向的方法
        /// </summary>
        /// <param name="color"></param>
        /// <param name="text"></param>
        private static void LogAppend(Color color, string text)
        {
            if (richTextBoxRemote.Lines.Length > 200)
            {
                richTextBoxRemote.Clear();
            }
            if (EnableLogFile)
            {
                logger.Debug(text);
            }
            richTextBoxRemote.SelectionColor = color;
            richTextBoxRemote.Update();
            richTextBoxRemote.AppendText(text);
            richTextBoxRemote.AppendText(System.Environment.NewLine);
           
        }

        private static void LogAppendSML(Color color, string text)
        {
            if (richTextBoxRemoteSML.Lines.Length > 200)
            {
                richTextBoxRemoteSML.Clear();
            }
            if (EnableLogFile)
            {
                logger.Info(text);
            }
            richTextBoxRemoteSML.SelectionColor = color;
            richTextBoxRemoteSML.Update();
            richTextBoxRemoteSML.AppendText(text);
            richTextBoxRemoteSML.AppendText(System.Environment.NewLine);
          
        }
        /// <summary>   
        /// 追加显示文本   
        /// </summary>   
        /// <param name="text"></param>   
        public static void LogAppendMsg(string text,Color color)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBoxRemote.Invoke(la, color, DateTime.Now.ToString("[yyyy.MM.dd HH:mm:ss:ff] ") + text);
        }

        public static void LogSendBytes(string text)
        {
            if (EnableByteLog)
            {
                LogAppendDelegate la = new LogAppendDelegate(LogAppend);
                richTextBoxRemote.Invoke(la, Color.Blue, DateTime.Now.ToString("[yyyy.MM.dd HH:mm:ss:ff] SEND ") + text);
            }
           
        }


        public static void LogReciveBytes(string text)
        {
            if (EnableByteLog)
            {
                LogAppendDelegate la = new LogAppendDelegate(LogAppend);
                richTextBoxRemote.Invoke(la, Color.HotPink, DateTime.Now.ToString("[yyyy.MM.dd HH:mm:ss:ff] RECV ") + text);
            }
         
        }

        /// <summary>
        /// 必须先调用 SetLogSML
        /// </summary>
        /// <param name="text"></param>
        public static void LogSendSML(string text)
        {
            if (EnableSMLLog)
            {
                LogAppendDelegate la = new LogAppendDelegate(LogAppendSML);
                richTextBoxRemote.Invoke(la, Color.Blue, DateTime.Now.ToString("[yyyy.MM.dd HH:mm:ss:ff] SEND ") + text);
            }
 
        }

        /// <summary>
        /// 必须先调用 SetLogSML
        /// </summary>
        /// <param name="text"></param>
        public static void LogReciveSML(string text)
        {
            if (EnableLogFile)
            {
                LogAppendDelegate la = new LogAppendDelegate(LogAppendSML);
                richTextBoxRemote.Invoke(la, Color.HotPink, DateTime.Now.ToString("[yyyy.MM.dd HH:mm:ss:ff] RECV ") + text);
            }
     
        }

        public static void LogInfo(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBoxRemote.Invoke(la, Color.Green, DateTime.Now.ToString("[yyyy.MM.dd HH:mm:ss:ff] ") + text);
        }

        public static void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBoxRemote.Invoke(la, Color.Red, DateTime.Now.ToString("[yyyy.MM.dd HH:mm:ss:ff] ") + text);
        }

        /// <summary>
        /// 日志系统
        /// </summary>
        public static readonly ILogger logger = LogManager.GetLogger("Logger");

        public static bool EnableLogFile { get; set; } = true;

        public static bool EnableByteLog { get; set; } = true;



        public static bool EnableSMLLog { get; set; } = true;

    }
}