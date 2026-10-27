using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConvertFormt.Models
{
    [Serializable]
  public class ScesModel
    {
    
        [XmlAttribute("Stream")]
        public string Key { get; set; }
        public string Mesage { get; set; }

   
          
    }
}
