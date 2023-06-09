using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YungBloger.Models;

namespace ClassLibrary.Data.Article
{
    public class Articls
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string UserID { get; set; }
        [Required]
        public ArticleUser User { get; set; }
        
        public Articls() { }
        public Articls(string h, string d, DateTime D)
        {
            Heading= h;
            Description= d;
            DateOfPublication= D;
        }
    }
}
