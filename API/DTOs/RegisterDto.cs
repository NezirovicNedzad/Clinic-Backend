﻿using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$",ErrorMessage ="Password must be complex")]

        public string Password { get; set; }


        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Required]
        public string Username { get; set; }
    }
}