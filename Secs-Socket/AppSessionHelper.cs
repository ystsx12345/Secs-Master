using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Secs_Socket
{
  internal  class AppSessionHelper
    {
        public static string GetMD5Hash(string str)
        {
            //就是比string往后一直加要好的优化容器
            StringBuilder sb = new StringBuilder();
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                //将输入字符串转换为字节数组并计算哈希。
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

                //X为     十六进制 X都是大写 x都为小写
                //2为 每次都是两位数
                //假设有两个数10和26，正常情况十六进制显示0xA、0x1A，这样看起来不整齐，为了好看，可以指定"X2"，这样显示出来就是：0x0A、0x1A。 
                //遍历哈希数据的每个字节
                //并将每个字符串格式化为十六进制字符串。
                int length = data.Length;
                for (int i = 0; i < length; i++)
                    sb.Append(data[i].ToString("X2"));

            }
            return sb.ToString();
        }

        //验证
        public static bool VerifyMD5Hash(string str, string hash)
        {
            string hashOfInput = GetMD5Hash(str);
            if (hashOfInput.CompareTo(hash) == 0)
                return true;
            else
                return false;
        }

        public static bool CheckLicence(string ip)
        {
            if (GetMD5Hash(GetLocalIp())==ip)
            {
                return true;
            }
            RegistryKey registry = Registry.CurrentUser;
            if (registry != null)
            {
                RegistryKey secs = registry.OpenSubKey("software\\secs", true);
                if (secs == null) // 不存在则创建
                {
                    RegistryKey key = registry.CreateSubKey("software\\secs");
                    if (key != null)
                    {
                        key.SetValue("StartUp", DateTime.Now.ToString());
                        Random random = new Random();
                        int lastTime = random.Next(20, 60);  // 生成一个随机数
                        DateTime dateTimeLast = DateTime.Now.AddMonths(lastTime); // 终止日期
                        key.SetValue("LastTime", dateTimeLast.ToString());
                    }
                    return true;
                }
                else
                {
                    if (secs.GetValue("StartUp") != null)  // 启动时间设定
                    {
                        try
                        {
                            var resStartUp = DateTime.TryParse(secs.GetValue("StartUp").ToString(), out DateTime dtStartUp);
                            if (resStartUp) // 获取启动时间成功
                            {


                                var resLastTime = DateTime.TryParse(secs.GetValue("LastTime").ToString(), out DateTime dtLastTime);
                                if (resLastTime) // 获取设定时间
                                {
                                    if (dtStartUp > dtLastTime) // 启动日期大于设定日志
                                    {
                                        return false;
                                    }
                                    if (DateTime.Now > dtStartUp) // 系统时间大于启动时间则记录一次
                                    {
                                        secs.SetValue("StartUp", DateTime.Now.ToString());
                                    }

                                }

                            }
                        }
                        catch (Exception)
                        {
                        }

                    }
                    else
                    {
                        return true;
                    }

                }
            }
            return true;
        }

        public  static string GetLocalIp()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
    }
}
