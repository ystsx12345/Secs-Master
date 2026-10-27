using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{
    [Serializable]
   public class SecsBody
    {

        /// <summary>
        /// 没有参数 方便接受的反转换到Body
        /// </summary>
        public SecsBody()
        {

        }

        /// <summary>
        /// 初始化 传入数据类型 与具体数据  Boolean 使用True  False
        /// 支持并只限于传入Byte 数组
        /// </summary>
        /// <param name="type">数据类型</param>
        /// <param name="msg">具体数据  数据类型没有验证 需要自己提前判断  并输入有效内容</param>
        public SecsBody(SecsDataType type,object msg)
        {
            Type = type;
            Messge = msg;
        }





        /// <summary>
        /// 仅限于List调用的初始化函数
        /// </summary>
        /// <param name="type"></param>
        public SecsBody(SecsDataType type)
        {
            Type = type;
            // Messge = msg;
            subScesBody = new List<SecsBody>();
        }

        /// <summary>
        /// 是否为根节点
        /// </summary>
        public bool IsRoot { get; set; } = true;


        /// <summary>
        ///数据类型
        /// </summary>
        public SecsDataType Type { get; set; }

        /// <summary>
        /// 消息长度占用字节数
        /// </summary>
        public byte NumLengthBytes { get; set; }
     

        /// <summary>
        /// 消息长度字节形式
        /// </summary>
        public byte[] BodyLenghtBytes { get; set; }


        /// <summary>
        /// 消息长度字节
        /// </summary>
        public int BodyLength { get; set; }

        
        /// <summary>
        /// 消息转实际类型后数量
        /// </summary>
        public int BodyCount { get; set; }

        /// <summary>
        /// 消息字符串形式
        /// </summary>
        public object  Messge { get; set; }

        /// <summary>
        /// 消息字节形式 已转换16进制
        /// </summary>
        public byte[] BodyBytes { get; set; }

        /// <summary>
        /// 仅作为注释无其他意义
        /// </summary>
        public string Comment { get; set; }


        public List<SecsBody> subScesBody = null;

        /// <summary>
        /// 仅限于List可以添加
        /// </summary>
        /// <param name="body"></param>
        public void Add(SecsBody body)
        {
            if (subScesBody == null) subScesBody = new List<SecsBody>();
            body.IsRoot = false;
            subScesBody.Add(body);
            
        }

        /// <summary>
        /// 实体类生成字节数组
        /// </summary>
        /// <returns></returns>
        public byte[] GetBody()
        {
            byte header = byte.Parse(((int)Type).ToString());
            BodyCount = 1;
            switch (Type)
            {
                case SecsDataType.L:
                    List<byte> msgByte = new List<byte>();
                    if (subScesBody!=null)
                    {
                        foreach (var item in subScesBody)
                        {
                            msgByte.AddRange(item.GetBody());
                        }
                        BodyLenghtBytes = Common.GetByteRemoveZero(subScesBody.Count);
                        NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                        BodyBytes = msgByte.ToArray();
                        BodyCount = subScesBody.Count;
                    }
                    else
                    {
                        BodyLenghtBytes = new byte[1] { 1 };
                        NumLengthBytes = 1;                      
                        BodyCount = 0;
                    }                   
                    break;
                case SecsDataType.B:  // 转个后占了2 位  待解决
              
                    if (Messge is Array)
                    {
                        BodyBytes = Messge as byte[];
                        BodyLenghtBytes= BitConverter.GetBytes(BodyBytes.Length); // 长度字节
                        BodyCount = BodyBytes.Length;
                        //BodyBytes[0] = Convert.ToByte(BodyBytes);
                        //Array.Reverse(BodyBytes);
                        BodyLength = BodyBytes.Length;
                        BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                        NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    }
                    else
                    {
                        BodyBytes = new byte[1];
                        BodyBytes[0] = Convert.ToByte(Messge);
                        Array.Reverse(BodyBytes);
                        BodyLength = BodyBytes.Length;
                        BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                        NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    }                 
                    break;                   
                case SecsDataType.BOOlEAN:
                    BodyBytes = new byte[1];
                    BodyBytes[0] = Convert.ToByte(Messge);
                    Array.Reverse(BodyBytes);
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    break;
                case SecsDataType.I1:
                    BodyBytes = new byte[1];
                    BodyBytes[0] = Convert.ToByte(Messge);
                    Array.Reverse(BodyBytes);
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    break;
                case SecsDataType.U1:
                    BodyBytes = new byte[1];
                    BodyBytes[0] = Convert.ToByte(Messge);
                    Array.Reverse(BodyBytes);
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    break;


                case SecsDataType.ASCII:
                    // 多个字节长度 高位在前
                    BodyBytes = Encoding.ASCII.GetBytes(Messge.ToString());
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes= Common.GetByteRemoveZero(BodyLength);
                    Array.Reverse(BodyLenghtBytes);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    BodyCount = BodyLength;
                    break;
                case SecsDataType.U2:
                    BodyBytes = BitConverter.GetBytes(ushort.Parse(Messge.ToString()));
                    Array.Reverse(BodyBytes);
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    break;
                case SecsDataType.I2:
                    BodyBytes = BitConverter.GetBytes(short.Parse(Messge.ToString()));
                    Array.Reverse(BodyBytes);
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    break;
                case SecsDataType.U4:
                    if (Messge is Array)
                    {                     
                        uint[] values = Messge as uint[];
                        BodyBytes = new byte[values.Length * 4];
                        BodyCount = values.Length;
                        for (int i = 0; i < values.Length; i++)
                        {
                            byte[] temp = BitConverter.GetBytes(values[i]);
                            Array.Reverse(temp);
                            Array.Copy(temp, 0, BodyBytes, i * 4, 4);
                        }
                        BodyLength = BodyBytes.Length;
                        BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                        NumLengthBytes = Convert.ToByte(values.Length / 255+1);
                    }
                    else if (Messge ==null)  // 空数组
                    {
                        BodyCount = 0;
                        BodyBytes = new byte[0];
                    }
                    else
                    {
                        BodyCount = 1;
                        BodyBytes = BitConverter.GetBytes(uint.Parse(Messge.ToString())); ;
                        Array.Reverse(BodyBytes);
                        BodyLength = BodyBytes.Length;
                        BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                        NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    }                                   
                    break;
                case SecsDataType.I4:
                    BodyBytes = BitConverter.GetBytes(int.Parse(Messge.ToString()));
                    Array.Reverse(BodyBytes);
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    break;
                case SecsDataType.F4:
                    BodyBytes = BitConverter.GetBytes(float.Parse(Messge.ToString()));
                    Array.Reverse(BodyBytes);
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    break;

                case SecsDataType.F8:
                    BodyBytes = BitConverter.GetBytes(double.Parse(Messge.ToString()));
                    Array.Reverse(BodyBytes);
                    BodyLength = BodyBytes.Length;
                    BodyLenghtBytes = Common.GetByteRemoveZero(BodyLength);
                    NumLengthBytes = Convert.ToByte(BodyLenghtBytes.Length);
                    break;
                default:
                    break;
            }
            if (BodyBytes!=null)
            {
                byte[] res = new byte[1 + BodyLenghtBytes.Length + BodyBytes.Length];
                res[0] = (byte)(header + NumLengthBytes);
                Array.Copy(BodyLenghtBytes, 0, res, 1, BodyLenghtBytes.Length);
                Array.Copy(BodyBytes, 0, res, BodyLenghtBytes.Length + 1, BodyBytes.Length);
                return res;
            }
            else
            {
                byte[] res = new byte[1 + BodyLenghtBytes.Length];
                res[0] = (byte)(header + NumLengthBytes);
                Array.Copy(BodyLenghtBytes, 0, res, 1, BodyLenghtBytes.Length);
              
                return res;

            }
           

        }

        /// <summary>
        /// 将字节数组生成实体
        /// </summary>
        /// <param name="bytes"></param>
        public void SetBody(byte[] ReciveBytes)
        {

            if (ReciveBytes.Count() == 0) { BodyBytes = null; return; }
            string bin = Format.ByteToBin(ReciveBytes[0]);  // 转2进制
            int header = Convert.ToInt32(bin.Substring(0,6).PadRight(8,'0'), 2);  // 数据类型
            string cnt = bin.Substring(6,2);  // 数据长度 占用字节数 字符串
            NumLengthBytes = Convert.ToByte(cnt,2);  // 数据长度 占用字节数
            BodyLenghtBytes = new byte[NumLengthBytes];                
            Array.Copy(ReciveBytes, 1, BodyLenghtBytes, 0, NumLengthBytes);  // 获取数据长度 字节数组
            BodyLength = (int)Common.bytesToValue(BodyLenghtBytes);  // 具体消息字节长度
            BodyCount = 1;
            Type = (SecsDataType)header;
            switch (Type)
            {
                case SecsDataType.L:
                    BodyCount = BodyLength;
                    if (BodyCount>=0)
                    {
                        BodyBytes = new byte[ReciveBytes.Length - NumLengthBytes - 1]; // 实际数字
                        Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyBytes.Length);
                        int index = 0;
                        for (int i = 0; i < BodyLength; i++)
                        {
                            SecsBody body = new SecsBody();
                            byte[] temp = new byte[BodyBytes.Length - index];
                            Array.Copy(BodyBytes, index, temp, 0, temp.Length);
                            body.SetBody(temp);
                            Add(body);
                            index += body.GetBody().Length;
                        }
                    }                  
                    break;
                case SecsDataType.B:


                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    if (BodyBytes.Length>1)
                    {
                        Messge = new byte[BodyBytes.Length];
                        Array.Copy(BodyBytes, (byte[])Messge,BodyBytes.Length);
                    }
                    else
                    {
                        Messge = Common.bytesToValue(BodyBytes).ToString();
                    }                 
                    break;
                case SecsDataType.BOOlEAN:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Messge = Common.bytesToValue(BodyBytes).ToString();
                    break;
                case SecsDataType.U1:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Messge = Common.bytesToValue(BodyBytes).ToString();
                    break;
                case SecsDataType.I1:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Messge = Common.bytesToValue(BodyBytes).ToString();
                    break;

                case SecsDataType.ASCII:
                    BodyBytes = new byte[BodyLength];
                    BodyCount = BodyLength;
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Messge = Encoding.ASCII.GetString(BodyBytes);
                    break;
                case SecsDataType.U2:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Array.Reverse(BodyBytes);
                    Messge = BitConverter.ToUInt16(BodyBytes,0).ToString();
                    break;
                case SecsDataType.I2:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Array.Reverse(BodyBytes);
                    Messge = BitConverter.ToInt16(BodyBytes,0).ToString();
                    break;
                case SecsDataType.U4:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    if (BodyBytes.Length>4)  // 大于4是数组
                    {
                        int dataLength = BodyBytes.Length / 4;
                        uint[] values  = new uint[dataLength];
                        BodyCount = dataLength;
                        for (int i = 0; i < dataLength; i++)
                        {
                            byte[] dataByte = new byte[4];
                            Array.Copy(BodyBytes, i * 4, dataByte, 0, 4);
                            Array.Reverse(dataByte);
                            values[i] = BitConverter.ToUInt32(dataByte, 0);
                        }
                        Messge = values;
                    }
                    else if(BodyBytes.Length==0)
                    {
                        BodyCount = 0;
                        Messge =null;
                    }
                    else
                    {
                        BodyCount = 1;
                        Array.Reverse(BodyBytes);
                        Messge = BitConverter.ToUInt32(BodyBytes, 0).ToString();
                    }
                    break;
                case SecsDataType.I4:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Array.Reverse(BodyBytes);
                    Messge = BitConverter.ToInt32(BodyBytes,0).ToString();
                    break;
                case SecsDataType.F4:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Array.Reverse(BodyBytes);
                    Messge = BitConverter.ToSingle(BodyBytes, 0).ToString();
                             
                    break;
                case SecsDataType.F8:
                    BodyBytes = new byte[BodyLength];
                    Array.Copy(ReciveBytes, BodyLenghtBytes.Length + 1, BodyBytes, 0, BodyLength);
                    Array.Reverse(BodyBytes);
                    Messge = BitConverter.ToDouble(BodyBytes, 0).ToString();
                    break;
                default:
                    break;
            }
        }

        public  string ToSML(int padLeftCount)
        {
            //if (BodyBytes==null || BodyBytes.Count()==0)
            //{
            //    return string.Empty;
            //}
            StringBuilder builder = new StringBuilder();
            string padleftEnd = string.Empty.PadLeft(padLeftCount, ' ');
            if (this.IsRoot)
            {
                builder.Append(padleftEnd + "<");
            }
            else
            {
                builder.Append("<");
            }

            builder.Append(Enum.GetName(this.Type.GetType(), this.Type));
            builder.Append(",");
            builder.Append(this.BodyCount);

            if (this.Type== SecsDataType.L)
            {
                int Startindex = 3+padLeftCount;
                string padLeft = string.Empty.PadLeft(Startindex, ' ');                              
                if (subScesBody!=null)
                {
                    builder.AppendLine();
                    foreach (var item in this.subScesBody)
                    {
                        builder.AppendLine(padLeft + item.ToSML(Startindex));
                    }
                }
                builder.Append(padleftEnd + ">");               
            }
            else
            {
                builder.Append(",");
                if (Messge is Array)
                {
                    //byte[] data = Messge as byte[];
                    //Array[] data = Messge as Array[];
                    string dataValue = string.Empty;
                    if (Messge.GetType().Name =="UInt32[]")
                    {
                        uint[] data = Messge as UInt32[];
                        foreach (var item in data)
                        {
                            dataValue += $"{item} ";
                        }
                    }
                    if (Messge.GetType().Name =="Byte[]")
                    {
                        byte[] data = Messge as byte[];
                        foreach (var item in data)
                        {
                            dataValue += $"{item} ";
                        }
                    }                                     
                    if(dataValue.Length>2)
                    {
                      dataValue=  dataValue.Remove(dataValue.Length - 1, 1);
                    }                   
                    builder.Append($"'{dataValue}'");
                }else if(Messge==null)  // 数组空
                {
                   builder= builder.Remove(builder.Length - 1, 1);
                }
                else
                {
                    builder.Append($"'{this.Messge}'");
                }
               
                builder.Append(">");
            }
                      
            return builder.ToString();
        }




    }
}
