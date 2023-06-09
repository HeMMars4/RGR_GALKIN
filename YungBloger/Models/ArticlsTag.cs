using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data.Article
{
    public class ArticlsTag
    {
        public int articlsID { get; set;}
        public Articls articls { get; set;}

        public int tagID { get; set;}
        public Tag tag { get; set;}
        

        public ArticlsTag() { }
        public ArticlsTag(int articlid, int tagid)
        {
            articlsID = articlid;
            tagID = tagid;
        }


    }
}
