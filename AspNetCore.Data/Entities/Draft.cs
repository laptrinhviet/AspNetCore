//using AspNetCore.Infrastructure.SharedKernel;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text;

//namespace AspNetCore.Data.Entities
//{
//    [Table("Drafts")]
//    public class Draft : DomainEntity<Guid>
//    {

//     public Draft()
//     {
//  
//     }

//public AppRole() : base()
//{

//}
//public AppRole(string name, string description) : base(name)
//{
//    this.Description = description;
//}

//     public Draft(string name)
//     {
//     Name = name;
//     }
//        [DefaultValue(Status.Actived)]
//        public Status Status { set; get; } = Status.Actived;

//        [DefaultValue(0)]
//        [StringLength(255)]
//        [MaxLength(255, ErrorMessage = "Số điện thoại không vượt quá 50 ký tự")]
//        [Required]
//        [EmailAddress]
//        [Required(ErrorMessage = "Tên phải nhập")]
//        [Column(TypeName="varchar")]
//        [Column(Order = 1)]
//        public string Name { set; get; }
//        public Guid CategoryId { set; get; }
//        [ForeignKey("CategoryId")]
//        public virtual ProductCategory ProductCategory { set; get; }
//        public virtual ICollection<Product> Products { set; get; }
//    }
//}
