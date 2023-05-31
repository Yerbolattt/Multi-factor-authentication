namespace MultiFactor.Web.ViewModels.Groups
{
    using System.Collections.Generic;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Events;
    using MultiFactor.Web.ViewModels.Students;

    public class GroupDetailsViewModel : IMapFrom<Group>
    {
        public GroupDetailsViewModel()
        {
            this.Events = new HashSet<EventsAssignViewModel>();
            this.Students = new HashSet<StudentViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<EventsAssignViewModel> Events { get; set; }

        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
