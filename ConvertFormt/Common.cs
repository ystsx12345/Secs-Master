using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{
    public class Common
    {

        /// <summary>
        /// 数值转字节并移除字节中前面为零的字节
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] GetByteRemoveZero(int value)
        {
            byte[] data = BitConverter.GetBytes(value);
            int lenght = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x00)
                {
                    lenght++;
                }
            }
            byte[] result = new byte[data.Length - lenght];
            Array.Copy(data, 0, result, 0, data.Length - lenght);
            return result;

        }
        /// <summary>
        /// 数值转换16位   删除前面无效0
        /// </summary>
        /// <param name="data">长度必须为2</param>
        /// <returns></returns>
        public static int  GetUInt16RemoveZero(byte[] data)
        {

            int index = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i]==0x00)
                {
                    index++;
                }
                else
                {
                    break;
                }
            }
          

            return  BitConverter.ToUInt16(data, index);
           
        }

        public static int bytesToInt2(byte[] src, int offset)
        {
            int value;
            value = (int)(((src[offset] & 0xFF) << 24)
                    | ((src[offset + 1] & 0xFF) << 16)
                    | ((src[offset + 2] & 0xFF) << 8)
                    | (src[offset + 3] & 0xFF));
            return value;
        }


        /// <summary>
        /// 输入字节数组  返回整数  忽略前面0的情况 字节数组不能超过4
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public static uint bytesToValue(byte[] sr)
        {
            uint temp = 0;
 
            string strTemp = bytesToBin(sr);
            for (int i = 0; i < strTemp.Length; i++)
            {
                double d = Math.Pow(2, (strTemp.Length -i-1));
                temp += Convert.ToUInt32(d) * uint.Parse(strTemp.Substring(i, 1));
            }

            return temp;
        }

        public static string bytesToBin(byte[] bytesTest)
        {
            string strResult = "";
            for (int i = 0; i < bytesTest.Length; i++)
            {
                string strTemp = System.Convert.ToString(bytesTest[i], 2);
                strTemp = strTemp.Insert(0, new string('0', 8 - strTemp.Length));

                strResult += strTemp;
            }
            return strResult;
        }

        

     
    }

}
