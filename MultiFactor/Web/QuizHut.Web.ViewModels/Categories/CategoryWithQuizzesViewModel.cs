namespace MultiFactor.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Quizzes;

    public class CategoryWithQuizzesViewModel : IMapFrom<Category>
    {
        public CategoryWithQuizzesViewModel()
        {
            this.Quizzes = new List<QuizAssignViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool Error { get; set; }

        public IList<QuizAssignViewModel> Quizzes { get; set; }
    }
}
