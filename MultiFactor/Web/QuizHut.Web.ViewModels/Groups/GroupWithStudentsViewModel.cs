namespace MultiFactor.Web.ViewModels.Groups
{
    using System.Collections.Generic;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Students;

    public class GroupWithStudentsViewModel : IMapFrom<Group>
    {
        public GroupWithStudentsViewModel()
        {
            this.Students = new List<StudentViewModel>();
        }

        public string Id { get; set; }

        public bool Error { get; set; }

        public IList<StudentViewModel> Students { get; set; }
    }
}
