
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Data.Article
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<ArticlsTag> Articles { get; set; }

        public Tag() { }
        public Tag(string name) 
        {
            Name = name;
        }
    }
}
