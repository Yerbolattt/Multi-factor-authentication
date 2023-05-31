namespace MultiFactor.Web.ViewModels.Quizzes
{
    using System.Collections.Generic;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Questions;

    public class QuizPDFViewModel : IMapFrom<Quiz>
    {
        public QuizPDFViewModel()
        {
            this.Questions = new List<QuestionViewModel>();
        }

        public string Name { get; set; }

        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
