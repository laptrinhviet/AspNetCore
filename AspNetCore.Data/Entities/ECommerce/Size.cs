using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Data.Enums;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("Sizes")]
    public class Size : DomainEntity<Guid>
    {
        public Size()
        {

        }

        public Size(Guid id, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
        }

        //[StringLength(255)]
        //public string Name { set; get; }

        public int Width { set; get; }
        public int Height { set; get; }

    }
}
