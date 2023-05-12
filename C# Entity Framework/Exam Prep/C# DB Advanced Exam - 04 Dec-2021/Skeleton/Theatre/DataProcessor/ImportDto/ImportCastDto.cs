﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Data.Models;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [XmlElement("FullName")]
        public string FullName { get; set; } = null!;

        [Required]
        [XmlElement("IsMainCharacter")]
        public string IsMainCharacter { get; set; }

        [Required]
        [XmlElement("PhoneNumber")]
        [RegularExpression(@"\+44-\d{2}-\d{3}-\d{4}")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Play))]
        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}
