﻿namespace QuizHut.Web.ViewModels.Quizzes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using QuizHut.Data.Models;
    using QuizHut.Services.Mapping;
    using QuizHut.Web.ViewModels.Questions;
    using QuizHut.Web.ViewModels.Shared;

    public class InputQuizViewModel : IMapFrom<Quiz>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(
            ModelValidations.Quizzes.NameMaxLength,
            ErrorMessage = ModelValidations.Error.RangeMessage,
            MinimumLength = ModelValidations.Quizzes.NameMinLength)]
        public string Name { get; set; }

        public string CreatorId { get; set; }

        public string Description { get; set; }

        [RegularExpression(ModelValidations.RegEx.Date, ErrorMessage = ModelValidations.Error.DateFormatMessage)]
        public string ActivationDate { get; set; }

        [Required]
        [StringLength(
            ModelValidations.Quizzes.PasswordMaxLength,
            ErrorMessage = ModelValidations.Error.RangeMessage,
            MinimumLength = ModelValidations.Quizzes.PasswordMinLength)]
        public string Password { get; set; }

        [RegularExpression(ModelValidations.RegEx.Time, ErrorMessage = ModelValidations.Error.TimeFormatMessage)]
        public string ActiveFrom { get; set; }

        [RegularExpression(ModelValidations.RegEx.Time, ErrorMessage = ModelValidations.Error.TimeFormatMessage)]
        public string ActiveTo { get; set; }

        public int? Timer { get; set; }

        public bool PasswordIsValid { get; set; }

        public IList<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
    }
}
