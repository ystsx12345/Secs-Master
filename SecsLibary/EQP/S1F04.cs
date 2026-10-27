using ConvertFormt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertFormt.Server;

namespace SecsLibary.EQP
{
    public class S1F04 : IResponse
    {
        public S1F04()
        {
            Key = "S1F3";
          
        }
    
        public override SecsMessage GetResponed(SecsMessage reciveSces,Secs status)
        {
            int listcount = reciveSces.Body.subScesBody.Count;
            if (reciveSces.Body.Type != SecsDataType.L)
            {
                return ResultError(reciveSces);            
            }
            SecsBody body = new SecsBody(SecsDataType.L);
            foreach (var item in reciveSces.Body.subScesBody)
            {
               var res=   DataItem.DataList.VIDList.ContainsKey(item.Messge.ToString());
                if (!res)
                {
                    return ResultError(reciveSces);
                }
                SecsBody itemBody = new SecsBody(SecsDataType.ASCII, DataItem.DataList.VIDList[item.Messge.ToString()].VALUES);
                body.Add(itemBody);
            } 
            SecsBodyCommon com = new SecsBodyCommon();         
            return com.CreateScesMessage(1, 4, reciveSces.Header.SystemBytes, body);
        }

        private SecsMessage ResultError(SecsMessage reciveSces)
        {
            SecsBody body = new SecsBody(SecsDataType.L);
            SecsBodyCommon com = new SecsBodyCommon();
            return com.CreateScesMessage(1, 4, reciveSces.Header.SystemBytes, body);
        }
    }
}
