namespace MultiFactor.Web.Infrastructure.Helpers
{
    using System.Collections.Generic;

    using MultiFactor.Web.ViewModels.Questions;
    using MultiFactor.Web.ViewModels.Quizzes;

    public interface IResultHelper
    {
        int CalculateResult(IList<QuestionViewModel> originalQuizQuestions, IList<AttemtedQuizQuestionViewModel> attemptedQuizQuestions);
    }
}
