namespace MultiFactor.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Shared;

    public class EditCategoryNameInputViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(
            ModelValidations.Categories.NameMaxLength,
            ErrorMessage = ModelValidations.Error.RangeMessage,
            MinimumLength = ModelValidations.Categories.NameMinLength)]
        public string Name { get; set; }
    }
}
