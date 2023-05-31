namespace MultiFactor.Web.ViewModels.Questions
{
    using System.Collections.Generic;

    using Ganss.XSS;
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Answers;

    public class QuestionViewModel : IMapFrom<Question>
    {
        public QuestionViewModel()
        {
            this.Answers = new List<AnswerViewModel>();
        }

        public string Id { get; set; }

        public string Text { get; set; }

        public string SanitizedText => new HtmlSanitizer().Sanitize(this.Text);

        public IList<AnswerViewModel> Answers { get; set; }

        public int Number { get; set; }
    }
}
