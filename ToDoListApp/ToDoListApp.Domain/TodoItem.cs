﻿using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Domain
{
    public class ToDoItem
    {
        public Guid Id { get; private set; } // private set for EF (EF can set properties with a private setter)
        [MinLength(4)]
        public string Description { get; private set; } // private set for EF (EF can set properties with a private setter)

        public bool IsDone { get; set; }

        private ToDoItem() // private constructor for EF
        {
            Id = Guid.Empty;
            Description = string.Empty;
            IsDone = false;
        }

        public static ToDoItem CreateNew(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }
            return new ToDoItem { 
                Id = Guid.NewGuid(),
                Description = description
            };
        }
    }
}
