﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Homies.Models
{
    public class EventDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public string Description { get; set; } = null!;

        public string OrganiserId { get; set; } = null!;

        public string Organiser { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TypeId { get; set; }
        public string Type { get; set; } = null!;
    }
}
