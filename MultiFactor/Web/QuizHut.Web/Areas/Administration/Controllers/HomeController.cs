namespace MultiFactor.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MultiFactor.Web.Infrastructure.Filters;
    using MultiFactor.Web.ViewModels.Quizzes;

    public class HomeController : AdministrationController
    {
        [ClearDashboardRequestInSessionActionFilterAttribute]
        public IActionResult Index(string password, string errorText)
        {
            var model = new PasswordInputViewModel();
            if (errorText != null)
            {
                model.Password = password;
                model.Error = errorText;
            }

            return this.View(model);
        }
    }
}
