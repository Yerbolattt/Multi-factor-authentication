﻿namespace QuizHut.Data.Models
{
    using System;

    using QuizHut.Data.Common.Models;

    public class QuizResult : BaseDeletableModel<string>
    {
        public string QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }

        public string ResultId { get; set; }

        public Result Result { get; set; }
    }
}
