namespace MultiFactor.Web.ViewModels.Events
{
    using MultiFactor.Data.Common.Enumerations;
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class EventSimpleViewModel : IMapFrom<Event>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }
    }
}
