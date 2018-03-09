using Abp.AspNetCore.Mvc.Controllers;
using Abp.Auditing;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using XyAuto.It.EntityFrameworkCore;
using XyAuto.It.Install;
using XyAuto.It.Migrations.Seed.Host;
using XyAuto.It.Web.Models.Install;
using Newtonsoft.Json.Linq;

namespace XyAuto.It.Web.Controllers
{
    [DisableAuditing]
    public class InstallController : AbpController
    {
        private readonly IInstallAppService _installAppService;
        private readonly IApplicationLifetime _applicationLifetime;

        public InstallController(
            IInstallAppService installAppService, 
            IApplicationLifetime applicationLifetime)
        {
            _installAppService = installAppService;
            _applicationLifetime = applicationLifetime;
        }

        [UnitOfWork(IsDisabled = true)]
        public ActionResult Index()
        {
            var appSettings = _installAppService.GetAppSettingsJson();
            var connectionString = GetConnectionString();

            if (DatabaseCheckHelper.Exist(connectionString))
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new InstallViewModel
            {
                Languages = DefaultLanguagesCreator.InitialLanguages,
                AppSettingsJson = appSettings
            };
            
            return View(model);
        }

        public ActionResult Restart()
        {
            _applicationLifetime.StopApplication();
            return View();
        }

        private string GetConnectionString()
        {
            var appsettingsjson = JObject.Parse(System.IO.File.ReadAllText("appsettings.json"));
            var connectionStrings = (JObject)appsettingsjson["ConnectionStrings"];
            return connectionStrings.Property(AbpZeroTemplateConsts.ConnectionStringName).Value.ToString();
        }
    }
}

