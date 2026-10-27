using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{
    [Serializable]
   public class SecsHeader
    {

        /// <summary>
        /// 整个消息的总字节
        /// </summary>
        public int  ByteLength { get; set; }

        public byte UpSessionID { get; set; } = 0x00;
        public byte LowerSessionID { get; set; } = 0x00;

        public byte Stream { get; set; } = 0x81;

        public byte Function { get; set; } = 0x0D;

        public byte PType { get; set; } = 0x00;

        public byte SType { get; set; } = 0x00;


        byte[] systemBytes = new byte[4];
        public byte[] SystemBytes
        {
            get { return systemBytes; }
            set { systemBytes = value; }
        }

        public byte[] GetBytes()
        {
            byte[] data = new byte[10];
            data[0] = UpSessionID;
            data[1] = LowerSessionID;
            data[2] = Stream;
            data[3] = Function;
            data[4] = PType;
            data[5] = SType;
            data[6] = SystemBytes[0];
            data[7] = SystemBytes[1];
            data[8] = SystemBytes[2];
            data[9] = SystemBytes[3];
            return data;
        }


        public SecsType GetScesType()
        {
            return (SecsType)this.SType;
        }

        public override string ToString()
        {
            byte Stream = this.Function % 2 == 0 ? this.Stream : (byte)(this.Stream - 0x80);
            return $"S{Stream}F{Function}";
        }
    }
}
