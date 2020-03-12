﻿namespace QuizHut.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuizHut.Common;
    using QuizHut.Web.ViewModels.Quizzes;

    public class HomeController : AdministrationController
    {
        public IActionResult Index(string password, string errorText)
        {
            var model = new PasswordInputViewModel();
            if (password != null)
            {
                model.Error = GlobalConstants.ErrorMessages.EmptyPasswordField;
            }

            model.Password = password;
            model.Error = errorText;

            return this.View(model);
        }
    }
}
