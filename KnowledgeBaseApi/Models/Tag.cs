﻿using System;
namespace KnowledgeBaseApi.Models
{
    public class Tag
    {
        public Tag()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; } = false;
        public bool IsInitSelected { get; set; } = false;
    }
}
