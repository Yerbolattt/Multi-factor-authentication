namespace MultiFactor.Web.ViewModels.Groups
{
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class GroupAssignViewModel : IMapFrom<Group>
    {
        public string Id { get; set; }

        public string CreatorId { get; set; }

        public string Name { get; set; }

        public bool IsAssigned { get; set; }
    }
}
