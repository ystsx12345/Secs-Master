using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{

    /// <summary>
    /// 组合Sces的数据
    /// </summary>
   public class SecsBodyCommon
    {

        /// <summary>
        /// 创建一条消息内容
        /// </summary>
        /// <param name="sn">Stream</param>
        /// <param name="fm">Function</param>
        /// <param name="body">实体类</param>
        /// <returns></returns>
        public  byte[] CreateSnFm(byte sn,byte fm,SecsBody body,out string Sml)
        {
            byte[] data = null;

            SecsHeader header = new SecsHeader();
            if (fm % 2 == 0)
            {
                header.Stream = Convert.ToByte((sn).ToString());
            }
            else
            {
                header.Stream = Convert.ToByte((0x80 + sn).ToString());
            }
            header.Function = Convert.ToByte(fm.ToString());
            header.SType = byte.Parse(((int)SecsType.Message).ToString());
            byte[] ID = BitConverter.GetBytes(MessageID.GetID());
            Array.Reverse(ID);
            Array.Copy(ID, header.SystemBytes, ID.Length);
            byte[] headerbytes =   header.GetBytes();
            byte[] bodybytes =   body.GetBody();
            data = new byte[headerbytes.Length + bodybytes.Length + 4];
            byte[] countbytes = BitConverter.GetBytes(data.Length - 4);
            Array.Reverse(countbytes);
            Array.Copy(countbytes, 0, data, 0, countbytes.Length);
            Array.Copy(headerbytes, 0, data, 4, headerbytes.Length);
            Array.Copy(bodybytes, 0, data,headerbytes.Length + 4, bodybytes.Length);
            SecsMessage message = new SecsMessage() { Header = header, Body = body };
            Sml = ScesMessageToSml.ToSml(message,22);
            return data;

        }

        public byte[] CreateSnFm(SecsHeader header, SecsBody body, out string Sml)
        {
            byte[] data = null;
            

            if (header.Function % 2 == 0)
            {
                header.Stream = Convert.ToByte((header.Stream).ToString());
            }
            else
            {
                header.Stream = Convert.ToByte((0x80 + header.Stream).ToString());
            }
            header.Function = Convert.ToByte(header.Function.ToString());
            header.SType = byte.Parse(((int)SecsType.Message).ToString());
            if (BitConverter.ToInt32(header.SystemBytes,0)==0)
            {
                byte[] ID = BitConverter.GetBytes(MessageID.GetID());
                Array.Reverse(ID);
                Array.Copy(ID, header.SystemBytes, ID.Length);
            }
            byte[] headerbytes = header.GetBytes();
            byte[] bodybytes = body.GetBody();
            data = new byte[headerbytes.Length + bodybytes.Length + 4];
            byte[] countbytes = BitConverter.GetBytes(data.Length - 4);
            Array.Reverse(countbytes);
            Array.Copy(countbytes, 0, data, 0, countbytes.Length);
            Array.Copy(headerbytes, 0, data, 4, headerbytes.Length);
            Array.Copy(bodybytes, 0, data, headerbytes.Length + 4, bodybytes.Length);
            SecsMessage message = new SecsMessage() { Header = header, Body = body };
            Sml = ScesMessageToSml.ToSml(message, 22);
            return data;

        }





        public SecsMessage CreateScesMessage(byte sn, byte fm, SecsBody body)
        {
            byte[] data = null;
          
            SecsHeader header = new SecsHeader();
            //  header.Stream =  Convert.ToByte((0x80 + sn).ToString("X"));
            // header.Function = Convert.ToByte(fm.ToString("X"));
            //if (fm%2==0)
            //{
            //    header.Stream = Convert.ToByte((sn).ToString());
            //}
            //else
            //{
            //    header.Stream = Convert.ToByte((0x80 + sn).ToString());
            //}
            //byte[] ID = BitConverter.GetBytes(MessageID.GetID());
            //Array.Reverse(ID);
            //Array.Copy(ID, header.SystemBytes, ID.Length);
            header.Stream = Convert.ToByte((sn).ToString());
            header.Function = Convert.ToByte(fm.ToString());
            header.SType = byte.Parse(((int)SecsType.Message).ToString());
            byte[] headerbytes = header.GetBytes();
            byte[] bodybytes = body.GetBody();
            data = new byte[headerbytes.Length + bodybytes.Length + 4];
            byte[] countbytes = BitConverter.GetBytes(data.Length - 4);
            Array.Reverse(countbytes);
            Array.Copy(countbytes, 0, data, 0, countbytes.Length);
            Array.Copy(headerbytes, 0, data, 4, headerbytes.Length);
            Array.Copy(bodybytes, 0, data, headerbytes.Length + 4, bodybytes.Length);
            bool isRequest = (header.Function%2) == 1 ? true : false;
            SecsMessage message = new SecsMessage() { Header = header, Body = body ,IsRquest=isRequest};
            return message;
        }

        public SecsMessage CreateScesMessage(byte sn, byte fm,byte[] systemBytes, SecsBody body)
        {
            byte[] data = null;

            SecsHeader header = new SecsHeader();
            //  header.Stream =  Convert.ToByte((0x80 + sn).ToString("X"));
            // header.Function = Convert.ToByte(fm.ToString("X"));
            //if (fm%2==0)
            //{
            //    header.Stream = Convert.ToByte((sn).ToString());
            //}
            //else
            //{
            //    header.Stream = Convert.ToByte((0x80 + sn).ToString());
            //}
            //byte[] ID = BitConverter.GetBytes(MessageID.GetID());
            //Array.Reverse(ID);
            //Array.Copy(ID, header.SystemBytes, ID.Length);
           
            header.Stream = Convert.ToByte((sn).ToString());
            header.Function = Convert.ToByte(fm.ToString());
            header.SType = byte.Parse(((int)SecsType.Message).ToString());
            Array.Reverse(systemBytes);
            Array.Copy(systemBytes, header.SystemBytes, 4);
            byte[] headerbytes = header.GetBytes();
            byte[] bodybytes = body.GetBody();
            data = new byte[headerbytes.Length + bodybytes.Length + 4];
            byte[] countbytes = BitConverter.GetBytes(data.Length - 4);
            Array.Reverse(countbytes);
            Array.Copy(countbytes, 0, data, 0, countbytes.Length);
            Array.Copy(headerbytes, 0, data, 4, headerbytes.Length);
            Array.Copy(bodybytes, 0, data, headerbytes.Length + 4, bodybytes.Length);
            bool isRequest = (header.Function >> 7 & 1) == 1 ? true : false;
            SecsMessage message = new SecsMessage() { Header = header, Body = body,IsRquest=isRequest };
            return message;
        }

        public SecsMessage CreateScesOperator(SecsType type)
        {
            byte[] data = null;

            SecsHeader header = new SecsHeader();
            //  header.Stream =  Convert.ToByte((0x80 + sn).ToString("X"));
            // header.Function = Convert.ToByte(fm.ToString("X"));
            header.UpSessionID = 0xFF;
            header.LowerSessionID = 0xFF;
            header.Stream = 0x00;
            header.Function = 0x00;
            header.SType = byte.Parse(((int)type).ToString());
            byte[] headerbytes = header.GetBytes();
            data = new byte[headerbytes.Length + 4];
            byte[] countbytes = BitConverter.GetBytes(data.Length - 4);
            Array.Reverse(countbytes);
            Array.Copy(countbytes, 0, data, 0, countbytes.Length);
            Array.Copy(headerbytes, 0, data, 4, headerbytes.Length);            
            SecsMessage message = new SecsMessage() { Header = header, Body = null };
            return message;
        }



        /// <summary>
        /// 创建一条操作相关  select.req select.rsp  linktest.req linktest.rsp 等
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public byte[] CreateOperator(SecsType type)
        {
            byte[] data = null;

            SecsHeader header = new SecsHeader();
            //  header.Stream =  Convert.ToByte((0x80 + sn).ToString("X"));
            // header.Function = Convert.ToByte(fm.ToString("X"));
            header.UpSessionID = 0xFF;
            header.LowerSessionID = 0xFF;
            header.Stream = 0x00;
            header.Function = 0x00;
            header.SType = byte.Parse(((int)type).ToString());
            byte[] headerbytes = header.GetBytes();        
            data = new byte[headerbytes.Length  + 4];
            byte[] countbytes = BitConverter.GetBytes(data.Length - 4);
            Array.Reverse(countbytes);
            Array.Copy(countbytes, 0, data, 0, countbytes.Length);
            Array.Copy(headerbytes, 0, data, 4, headerbytes.Length);
          
            return data;

        }

        public byte[] CreateOperator(SecsType type,byte[] systemBytes)
        {
            byte[] data = null;

            SecsHeader header = new SecsHeader();
            //  header.Stream =  Convert.ToByte((0x80 + sn).ToString("X"));
            // header.Function = Convert.ToByte(fm.ToString("X"));
            header.UpSessionID = 0xFF;
            header.LowerSessionID = 0xFF;
            header.Stream = 0x00;
            header.Function = 0x00;
            header.SType = byte.Parse(((int)type).ToString());
            Array.Copy(systemBytes, header.SystemBytes, 4);
            byte[] headerbytes = header.GetBytes();
            data = new byte[headerbytes.Length + 4];
            byte[] countbytes = BitConverter.GetBytes(data.Length - 4);
            Array.Reverse(countbytes);
            Array.Copy(countbytes, 0, data, 0, countbytes.Length);
            Array.Copy(headerbytes, 0, data, 4, headerbytes.Length);

            return data;

        }

        public byte[] CreateSces(SecsMessage message,out string sml)
        {
            SecsType type =  message.Header.GetScesType();
            byte[] data = null;
            if (type== SecsType.Message)
            {
                data = CreateSnFm(message.Header, message.Body, out string smlstring);
                sml = smlstring;
            }
            else
            {
              data=  CreateOperator(type);
              sml = "Operator";
            }

            return data;

        }

    }
}
