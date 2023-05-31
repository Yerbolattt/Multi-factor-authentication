namespace MultiFactor.Web.ViewModels.Quizzes
{
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class QuizAssignViewModel : IMapFrom<Quiz>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CreatorId { get; set; }

        public bool IsAssigned { get; set; }
    }
}
