using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilgeDayiBlog.Models
{
    [Table("Posts")]
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Author")]
        [Display(Name = "Yazar")]
        public string AuthorId { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name ="Başlık")]
        public string Title { get; set; }

        [Display(Name = "İçerik")]
        public string  Content { get; set; }
        public virtual ApplicationUser Author { get; set; }

        [Required]
        public DateTime? CreationTime { get; set; }

        public virtual Category category { get; set; }
    }
}