﻿using System.ComponentModel.DataAnnotations;
using Domain;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,16}$",ErrorMessage ="Password must be complex")]

        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string OdeljenjeId { get; set; }
        public string Specijalizacija { get; set; }
    }
}
