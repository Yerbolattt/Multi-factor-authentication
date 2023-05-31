namespace MultiFactor.Web.ViewModels.Groups
{
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class GroupSimpleViewModel : IMapFrom<Group>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
