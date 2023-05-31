namespace MultiFactor.Web.ViewModels.Groups
{
    using System.ComponentModel.DataAnnotations;

    using MultiFactor.Web.ViewModels.Shared;

    public class CreateGroupInputViewModel
    {
        [Required]
        [StringLength(
            ModelValidations.Groups.NameMaxLength,
            ErrorMessage = ModelValidations.Error.RangeMessage,
            MinimumLength = ModelValidations.Groups.NameMinLength)]
        public string Name { get; set; }
    }
}
