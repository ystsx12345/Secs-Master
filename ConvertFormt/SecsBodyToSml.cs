using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormt
{
   public class ScesMessageToSml
    {
        public ScesMessageToSml()
        {
   


        }

        public static string ToSml(SecsMessage message,int index)
        {
            StringBuilder builder = new StringBuilder();
            string W = message.Header.Function % 2 == 0 ? "" : "W";      
            byte Stream = message.Header.Function % 2 == 0 ? message.Header.Stream : (byte)(message.Header.Stream-0x80);
            string padLeft = string.Empty.PadLeft(index, ' ');
            Array.Reverse(message.Header.SystemBytes);
            builder.AppendLine($"S{Stream}F{message.Header.Function} {W} SystemBytes={BitConverter.ToInt32(message.Header.SystemBytes,0)}");
            if(message.Body.BodyBytes!=null )
            {
                if (message.Body.BodyLenghtBytes.Length > 0)
                {
                    builder.Append(message.Body.ToSML(index));
                    builder.Append(".");
                }
              
            }
            //if (message.Body.BodyLenghtBytes.Length >  0)
            //{
              
            //}
           
            return builder.ToString();

        }

        public static string[] SpliteString(string strip)
        {
            string[] striparr = strip.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            striparr = striparr.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            return striparr;
          
        }


   

    }
}
