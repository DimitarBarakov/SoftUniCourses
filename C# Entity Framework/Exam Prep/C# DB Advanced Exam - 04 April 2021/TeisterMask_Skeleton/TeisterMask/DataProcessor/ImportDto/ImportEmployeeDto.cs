﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        [RegularExpression(@"[A-z0-9]+")]
        [JsonProperty("Username")]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        [JsonProperty("Email")]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(@"[\d]{3}-[\d]{3}-[\d]{4}")]
        [JsonProperty("Phone")]
        public string Phone { get; set; } = null!;

        [JsonProperty("Tasks")]
        public int[] Tasks { get; set; } = null!;
    }
}
