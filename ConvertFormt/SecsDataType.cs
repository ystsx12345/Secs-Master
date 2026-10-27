using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{
    public enum SecsDataType
    {
        /// <summary>
        /// List
        /// </summary>
        L = 0x00,

        /// <summary>
        /// 二进制
        /// </summary>
        B = 0x20,

        /// <summary>
        /// bool量
        /// </summary>
        BOOlEAN= 0x24,

        /// <summary>
        /// 单字节有符号
        /// </summary>
        I1 = 0x64,

        /// <summary>
        /// 单字节无符号
        /// </summary>
        U1 =0xA4,

        /// <summary>
        /// 字符串
        /// </summary>
        ASCII= 0x40,    // 10000

        /// <summary>
        /// 16位无符号
        /// </summary>
        U2= 0xA8,

        /// <summary>
        /// 16位有符号
        /// </summary>
        I2= 0x68,

        /// <summary>
        /// 32位无符号
        /// </summary>
        U4= 0xB0,

        /// <summary>
        /// 32位有符号
        /// </summary>
        I4=0X70,

        /// <summary>
        /// 单精度浮点数
        /// </summary>
        F4=0X90,

        /// <summary>
        /// 双进度浮点数
        /// </summary>
        F8= 0X80,
 


    }
}
