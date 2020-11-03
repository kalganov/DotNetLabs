﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Labs.Entities
{
    [Table("User")]
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}