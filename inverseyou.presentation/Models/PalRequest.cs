using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inverseyou.presentation.Models
{
    public class PalRequest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastEditTime { get; set; }
    }
}
