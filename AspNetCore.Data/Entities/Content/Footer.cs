using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("Footers")]
    public class Footer : DomainEntity<string>, ISwitchable
    {
        public Footer()
        {
        }

        public Footer(string content, Status status)
        {
            Content = content;
            Status = Status;
        }

        [Required]
        public string Content { set; get; }

        public Status Status { set; get; }
    }
}