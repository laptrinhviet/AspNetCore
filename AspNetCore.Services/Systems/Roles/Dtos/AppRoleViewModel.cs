using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Services.Systems.Roles.Dtos
{
    public class AppRoleViewModel
    {
        public Guid Id { set; get; }

        [StringLength(255)]
        [Required(ErrorMessage = "You must enter name")]
        public string Name { set; get; }

        [StringLength(255)]
        public string Description { set; get; }

    }
}