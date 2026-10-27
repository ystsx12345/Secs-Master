using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary
{
    /// <summary>
    /// 此类时Secs数据的一些配置可序列化文件
    /// </summary>
   public class SecsConfig
    {
        public  string IP { get; set; }

        public  int Port { get; set; }

        public  bool AutoEnable { get; set; }

        public   int ControlState { get; set; }  // 0- local  1- online local 2- online remote

        [Newtonsoft.Json.JsonIgnore]
        public bool Listen { get; set; }// SECS 已开启

        public bool AddIDWhenUpdate { get; set; } //当更新时不存在ID 是否添加

        public int ControlModeEventID { get; set; } = 3100;

    }
}
