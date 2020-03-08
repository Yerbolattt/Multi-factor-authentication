﻿namespace QuizHut.Web.ViewModels.Quizzes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using QuizHut.Data.Models;
    using QuizHut.Services.Mapping;
    using QuizHut.Web.ViewModels.Questions;
    using QuizHut.Web.ViewModels.Shared;

    public class InputQuizViewModel : IMapFrom<Quiz>, IHaveCustomMappings
    {
        public InputQuizViewModel()
        {
            this.Questions = new List<QuestionViewModel>();
        }

        public string Id { get; set; }

        [Required]
        [StringLength(
            ModelValidations.Quizzes.NameMaxLength,
            ErrorMessage = ModelValidations.Error.RangeMessage,
            MinimumLength = ModelValidations.Quizzes.NameMinLength)]
        public string Name { get; set; }

        public string CreatorId { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(
            ModelValidations.Password.PasswordMaxLength,
            ErrorMessage = ModelValidations.Error.RangeMessage,
            MinimumLength = ModelValidations.Password.PasswordMinLength)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int? Timer { get; set; }

        public bool PasswordIsValid { get; set; }

        public IList<QuestionViewModel> Questions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Quiz, InputQuizViewModel>()
             .ForMember(
                   x => x.Password,
                   opt => opt.MapFrom(x => x.Password.Content));
        }
    }
}
