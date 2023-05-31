namespace MultiFactor.Web.ViewModels.Groups
{
    using System.ComponentModel.DataAnnotations;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Shared;

    public class EditGroupNameInputViewModel : IMapFrom<Group>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(
            ModelValidations.Groups.NameMaxLength,
            ErrorMessage = ModelValidations.Error.RangeMessage,
            MinimumLength = ModelValidations.Groups.NameMinLength)]
        public string Name { get; set; }
    }
}
