using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsLibary
{
   public class SecsRemember
   {

        private static List<string> define_RPTID;

        public static List<string> Define_RPTIDs
        {
            get
            {
                if (define_RPTID == null) define_RPTID = new List<string>();
                return define_RPTID;
            
            }
            set { define_RPTID = value; }
        }


        private List<string> ceidRptids;

        public List<string> CeidRptids
        {
            get {
                if (ceidRptids == null) ceidRptids = new List<string>();
                return ceidRptids; 
            
               }
            set { ceidRptids = value; }
        }


        private static Dictionary<string, List<string>> define_CEID;

        public static Dictionary<string,List<string>> Define_CEIDs
        {
            get {
                if (define_CEID == null)
                {
                    define_CEID = new Dictionary<string, List<string>>();
                }
                return define_CEID;
                  
               }
            set { define_CEID = value; }
        }


    }
}
