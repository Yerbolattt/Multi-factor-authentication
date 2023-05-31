namespace MultiFactor.Web.ViewModels.Quizzes
{
    using System.Collections.Generic;

    using Ganss.XSS;
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Answers;

    public class AttemtedQuizQuestionViewModel : IMapFrom<Question>
    {
        public AttemtedQuizQuestionViewModel()
        {
            this.Answers = new List<AttemtedQuizAnswerViewModel>();
        }

        public string Id { get; set; }

        public string Text { get; set; }

        public string SanitizedText => new HtmlSanitizer().Sanitize(this.Text);

        public int Number { get; set; }

        public IList<AttemtedQuizAnswerViewModel> Answers { get; set; }
    }
}
