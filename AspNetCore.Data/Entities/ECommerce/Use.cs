using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    public class Use : DomainEntity<Guid>
    {
        public Use()
        {
            // Use: Home | Office | Hotel | Hospital | Cafe ...
            // Sử dụng: Nhà | Văn phòng | Khách sạn | Bệnh viện | Quán Cafe | Nhà hàng | Sân khấu | Ô tô | Mầm non | Hội trường | Đám cưới | Chung cư | Spa | Y tế...
        }

        //public Use(Guid id, string name, string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]       
        public string Description { get; set; }
    }
}
