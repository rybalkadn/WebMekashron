﻿using System.ComponentModel.DataAnnotations;

namespace WebMekashron.ViewModels
{
    public class LoginModel
    {

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

    }
}