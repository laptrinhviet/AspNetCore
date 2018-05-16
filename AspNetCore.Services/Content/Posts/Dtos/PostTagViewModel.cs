using AspNetCore.Services.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Services.Content.Posts.Dtos
{
    public class PostTagViewModel
    {  
        public Guid PostId { set; get; }

        public string TagId { set; get; }

        public PostViewModel Post { set; get; }

        public TagViewModel Tag { set; get; }
    }
}