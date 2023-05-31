namespace MultiFactor.Web.ViewModels.Quizzes
{
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class QuizResultViewModel : IMapFrom<Result>
    {
        public string QuizName { get; set; }

        public int Points { get; set; }

        public int MaxPoints { get; set; }
    }
}
