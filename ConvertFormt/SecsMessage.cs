using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{
    [Serializable]
   public class SecsMessage
    {
        /// <summary>
        /// 字节长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 请求主机回复需要true
        /// </summary>
        public bool IsRquest { get; set; }

        /// <summary>
        /// 消息头信息
        /// </summary>
        public SecsHeader Header { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public SecsBody Body { get; set; }


        private Time.T3 t3;
        public Time.T3 Tim3
        {
            get
            {
                if(t3==null)
                {
                    t3 = new Time.T3();
                }
                return t3;
            }

            set { t3 = value; }
        }

       


      


    }


}
