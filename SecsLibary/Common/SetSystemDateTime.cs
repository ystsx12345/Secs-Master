using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary.Common
{

    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMiliseconds;
    }


    public class SetSystemDateTime
    {
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime sysTime);


        public static bool SetLocalTimeByStr(ushort YYYY,ushort MM,ushort DD,ushort hh,ushort mm,ushort ss,ushort cc)
        {
              bool flag = false;
            SystemTime sysTime = new SystemTime();
          // DateTime dt = Convert.ToDateTime(timestr);
            sysTime.wYear = Convert.ToUInt16(YYYY);
            sysTime.wMonth = Convert.ToUInt16(MM);
            sysTime.wDay = Convert.ToUInt16(DD);
            sysTime.wHour = Convert.ToUInt16(hh);
            sysTime.wMinute = Convert.ToUInt16(mm);
            sysTime.wSecond = Convert.ToUInt16(ss);
            sysTime.wMiliseconds = Convert.ToUInt16(cc);
            try
            {
                flag = SetSystemDateTime.SetLocalTime(ref sysTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("SetSystemDateTime函数执行异常" + e.Message);
            }
            return flag;
        }



        public static bool SetLocalTimeByStr(string timestr)
        {
            bool flag = false;
            SystemTime sysTime = new SystemTime();
            DateTime dt = Convert.ToDateTime(timestr);
            sysTime.wYear = Convert.ToUInt16(dt.Year);
            sysTime.wMonth = Convert.ToUInt16(dt.Month);
            sysTime.wDay = Convert.ToUInt16(dt.Day);
            sysTime.wHour = Convert.ToUInt16(dt.Hour);
            sysTime.wMinute = Convert.ToUInt16(dt.Minute);
            sysTime.wSecond = Convert.ToUInt16(dt.Second);
            sysTime.wMiliseconds = Convert.ToUInt16(dt.Millisecond);
            try
            {
                flag = SetSystemDateTime.SetLocalTime(ref sysTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("SetSystemDateTime函数执行异常" + e.Message);
            }
            return flag;
        }

        public static void ProSetSystemDateTime(string createDateTime)
        {
            ProcessStartInfo PstartInfoCmd = new ProcessStartInfo();
            PstartInfoCmd.FileName = "cmd.exe";
            PstartInfoCmd.Arguments = "/C date " + createDateTime;
            PstartInfoCmd.WindowStyle = ProcessWindowStyle.Hidden;
            Process proStep1 = new Process();
            proStep1.StartInfo = PstartInfoCmd;
            proStep1.Start();
        }
    }

}
