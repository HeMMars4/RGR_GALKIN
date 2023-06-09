using ClassLibrary.Data.Article;
using System.ComponentModel.DataAnnotations;
using System;

namespace YungBloger.Models
{
    public class Coment
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateAnswer { get; set; }
        public string NameUser { get; set; }
        public string UserID { get; set; }
        [Required]
        public ArticleUser User { get; set; }

        public Coment() { }
        public Coment(string description, DateTime dateAnswer)
        {
            Description = description;
            DateAnswer = dateAnswer;
        }
    }
}
