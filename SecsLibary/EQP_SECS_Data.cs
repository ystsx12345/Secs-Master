using ConvertFormt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary
{
    /// <summary>
    /// 此类用于UI界面与SecsLibray的交互作用
    /// 1. secs 数据可以给此类供设备使用
    /// 2. 设备数据可以给此类供Secs使用
    /// </summary>
   public class EQP_SECS_Data
    {

        /// <summary>
        /// 设备厂商
        /// </summary>
        public static string Company { get; set; } = "simtech";

        /// <summary>
        /// 软件版本号
        /// </summary>
        public static string Version { get; set; } = "V1.0";

        /// <summary>
        /// Secs 接口用于接受与发送
        /// </summary>
        public static Secs Secs { get; set; }

        /// <summary>
        /// 设备空闲状态
        /// </summary>
        public static bool Idle { get; set; }

        private static CtrolMode ctrolMode = CtrolMode.None;

        public static event Action<CtrolMode> ControlModeChangedEvent;

        public static CtrolMode ControlMode 
        {
            get { return ctrolMode; }
            set
            {
                if(ctrolMode!=value)
                {
                    ctrolMode = value;
                    ControlModeChangedEvent?.BeginInvoke(value,null,null);
                }              
            }
        }  

        public static bool SecsEnable { get; set; }   

    }

    public enum CtrolMode
    {
        None = 0,
        OfflineLine = 1,
        OnLineLocal = 4,
        OnLineRemote =5,
    }

}
