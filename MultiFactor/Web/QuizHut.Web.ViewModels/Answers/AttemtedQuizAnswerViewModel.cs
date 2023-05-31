namespace MultiFactor.Web.ViewModels.Answers
{
    using Ganss.XSS;
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class AttemtedQuizAnswerViewModel : IMapFrom<Answer>
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string SanitizedText => new HtmlSanitizer().Sanitize(this.Text);

        public bool IsRightAnswerAssumption { get; set; }
    }
}
