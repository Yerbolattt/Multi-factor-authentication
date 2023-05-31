namespace MultiFactor.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MultiFactor.Common;
    using MultiFactor.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorAndTeacherAuthorizationString)]
    [Area(GlobalConstants.Administration)]
    public class AdministrationController : BaseController
    {
    }
}
