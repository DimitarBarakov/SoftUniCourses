﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class ExportPlayDto
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }

        [Required]
        [XmlAttribute("Duration")]
        public string Duration { get; set; }

        [Required]
        [XmlAttribute("Rating")]
        public string Rating { get; set; }

        [Required]
        [XmlAttribute("Genre")]
        public string Genre { get; set; }

        [XmlArray("Actors")]
        public ExportActorDto[] Actors { get; set; } 
    }
}
