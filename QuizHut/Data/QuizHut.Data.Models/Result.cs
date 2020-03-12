﻿namespace QuizHut.Data.Models
{
    using System;
    using System.Collections.Generic;

    using QuizHut.Data.Common.Models;

    public class Result : BaseDeletableModel<string>
    {
        public Result()
        {
            this.Id = Guid.NewGuid().ToString();
            this.EventsResults = new HashSet<EventResult>();
        }

        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public string StudentId { get; set; }

        public virtual ApplicationUser Student { get; set; }

        public virtual ICollection<EventResult> EventsResults { get; set; }
    }
}
