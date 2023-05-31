namespace MultiFactor.Web.ViewModels.Categories
{
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class CategorySimpleViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
