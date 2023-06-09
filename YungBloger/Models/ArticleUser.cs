
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using YungBloger.Models;

namespace ClassLibrary.Data.Article
{
	public class ArticleUser : IdentityUser
    {
        public override string Id { get; set; }
        public override string Email { get; set; }
        public string NicName { get; set; }
		public int Age { get; set; }
		public string Password { get; set; }
		public List<Articls> Articles { get; set; }
        public List<Coment> Coments { get; set; }

        public ArticleUser() { }
		public ArticleUser(string name, int age, string password)
		{
			NicName = name;
			Age = age;
			Password = password;
		}

	}
}
