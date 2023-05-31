namespace MultiFactor.Web.ViewModels.Quizzes
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Shared;

    public class EditDetailsViewModel : IMapFrom<Quiz>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [StringLength(
           ModelValidations.Quizzes.NameMaxLength,
           ErrorMessage = ModelValidations.Error.RangeMessage,
           MinimumLength = ModelValidations.Quizzes.NameMinLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(
           ModelValidations.Password.PasswordMaxLength,
           ErrorMessage = ModelValidations.Error.RangeMessage,
           MinimumLength = ModelValidations.Password.PasswordMinLength)]
        public string Password { get; set; }

        public int? Timer { get; set; }

        public bool PasswordIsValid { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Quiz, EditDetailsViewModel>()
                .ForMember(
                    x => x.Password,
                    opt => opt.MapFrom(x => x.Password.Content));
        }
    }
}
