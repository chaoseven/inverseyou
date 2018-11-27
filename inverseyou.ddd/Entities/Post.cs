using System;
using System.Collections.Generic;

namespace inverseyou.ddd.Entities
{
    public class Post:Entity
    {
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastEditTime { get; set; }
    }
}
