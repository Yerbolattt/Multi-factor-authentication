namespace MultiFactor.Web.ViewModels.Events
{
    using System.Collections.Generic;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Quizzes;

    public class EventWithQuizzesViewModel : IMapFrom<Event>
    {
        public EventWithQuizzesViewModel()
        {
            this.Quizzes = new List<QuizAssignViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool Error { get; set; }

        public string TimeZone { get; set; }

        public IList<QuizAssignViewModel> Quizzes { get; set; }
    }
}
