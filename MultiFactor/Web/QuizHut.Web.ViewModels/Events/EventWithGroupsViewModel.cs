namespace MultiFactor.Web.ViewModels.Events
{
    using System.Collections.Generic;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Groups;

    public class EventWithGroupsViewModel : IMapFrom<Event>
    {
        public EventWithGroupsViewModel()
        {
            this.Groups = new List<GroupAssignViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool Error { get; set; }

        public IList<GroupAssignViewModel> Groups { get; set; }
    }
}
