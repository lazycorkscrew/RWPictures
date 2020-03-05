using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.Entities
{
    public class Document
    {
        public string Name { get; set; }
        public string Project { get; set; }
        public string Comment { get; set; }
        public int who_filled { get; set; }


        public int PatternName {get; set; }
        public Dictionary<string, string> Fields { get; set; }
    }
}
