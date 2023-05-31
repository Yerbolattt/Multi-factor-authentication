namespace MultiFactor.Web
{
    using System;
    using System.Reflection;

    using AutoMapper;
    using Hangfire;
    using Hangfire.SqlServer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using MultiFactor.Common;
    using MultiFactor.Common.Hubs;
    using MultiFactor.Data;
    using MultiFactor.Data.Common;
    using MultiFactor.Data.Common.Repositories;
    using MultiFactor.Data.Models;
    using MultiFactor.Data.Repositories;
    using MultiFactor.Data.Seeding;
    using MultiFactor.Services.Answers;
    using MultiFactor.Services.Categories;
    using MultiFactor.Services.Events;
    using MultiFactor.Services.EventsGroups;
    using MultiFactor.Services.Groups;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Services.Questions;
    using MultiFactor.Services.Quizzes;
    using MultiFactor.Services.Results;
    using MultiFactor.Services.ScheduledJobsService;
    using MultiFactor.Services.StudentsGroups;
    using MultiFactor.Services.Tools.Expressions;
    using MultiFactor.Services.Users;
    using MultiFactor.Web.Infrastructure.Filters;
    using MultiFactor.Web.Infrastructure.Helpers;
    using MultiFactor.Web.ViewModels;
    using Rotativa.AspNetCore;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddHangfire(
                options => options.UseSqlServerStorage(this.configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions()
                {
                     SchemaName = "hangfire",
                }));

            services.AddHangfireServer();

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.Strict;
                    });

            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews(configure =>
                configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSingleton(this.configuration);

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.IdleTimeout = TimeSpan.FromDays(GlobalConstants.CookieTimeOut);
                options.Cookie.IsEssential = true;
            });

            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });

            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = this.configuration.GetConnectionString("DefaultConnection");
                options.SchemaName = "dbo";
                options.TableName = "Cache";
            });

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            //services.AddTransient<IEmailSender>(x => new SendGridEmailSender(new LoggerFactory(), this.configuration["Sendgrid"]));
            services.AddTransient<IResultHelper, ResultHelper>();
            services.AddTransient<IDateTimeConverter, DateTimeConverter>();
            services.AddTransient<IShuffler, Shuffler>();
            services.AddTransient<IExpressionBuilder, ExpressionBuilder>();
            services.AddTransient<IQuizzesService, QuizzesService>();
            services.AddTransient<IQuestionsService, QuestionsService>();
            services.AddTransient<IAnswersService, AnswersService>();
            services.AddTransient<IEventsGroupsService, EventsGroupsService>();
            services.AddTransient<IGroupsService, GroupsService>();
            services.AddTransient<IResultsService, ResultsService>();
            services.AddTransient<IEventsService, EventsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IStudentsGroupsService, StudentsGroupsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IScheduledJobsService, ScheduledJobsService>();
            services.AddTransient<PermissionActionFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                dbContext.Database.Migrate();

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            RotativaConfiguration.Setup(env.ContentRootPath, GlobalConstants.RotativaPath);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects(GlobalConstants.StatusCodePath);
                app.UseExceptionHandler(GlobalConstants.ExceptionHandlerPath);
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizationFilter() },
            });

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapHub<QuizHub>("/Multi-factor authentication");
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
