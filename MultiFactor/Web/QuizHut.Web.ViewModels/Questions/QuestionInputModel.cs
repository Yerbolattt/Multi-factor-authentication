namespace MultiFactor.Web.ViewModels.Questions
{
    using System.ComponentModel.DataAnnotations;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Shared;

    public class QuestionInputModel : IMapFrom<Question>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(
           ModelValidations.Question.TextMaxLength,
           ErrorMessage = ModelValidations.Error.RangeMessage,
           MinimumLength = ModelValidations.Question.TextMinLength)]
        public string Text { get; set; }
    }
}
